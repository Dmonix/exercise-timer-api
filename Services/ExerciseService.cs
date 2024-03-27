using ExerciseTimer.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ExerciseTimer.API.Services
{
    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetExercisesAsync();
        Task<Exercise> GetExerciseAsync(string exerciseId);
        Task<Exercise> AddSegmentAsync(string exerciseId, Segment newSegment);
    }

    public class ExerciseService : IExerciseService
    {
        private readonly IMongoCollection<Exercise> _exerciseCollection;

        public ExerciseService(IOptions<TimerDatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _exerciseCollection = mongoDatabase.GetCollection<Exercise>(databaseSettings.Value.ExerciseCollectionName);
        }

        public async Task<Exercise> AddSegmentAsync(string exerciseId, Segment newSegment)
        {
            var exercise = await _exerciseCollection.Find(exercise => exercise.Id == exerciseId).FirstOrDefaultAsync();
            exercise.Segments.Append(newSegment);
            await _exerciseCollection.ReplaceOneAsync(ex => ex.Id == exerciseId, exercise);
            return exercise;
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync() =>
            await _exerciseCollection.Find(_ => true).ToListAsync();


        public async Task<Exercise> GetExerciseAsync(string exerciseId) =>
            await _exerciseCollection.Find(exercise => exercise.Id == exerciseId).FirstOrDefaultAsync();
    }
}