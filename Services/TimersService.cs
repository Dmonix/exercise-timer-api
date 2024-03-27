using ExerciseTimer.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ExerciseTimer.API.Services
{
    public class TimersService
    {
        private readonly IMongoCollection<Models.Timer> timerCollection;

        public TimersService(IOptions<TimerDatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            timerCollection = mongoDatabase.GetCollection<Models.Timer>(databaseSettings.Value.TimersCollectionName);
        }

        public async Task<List<Models.Timer>> GetTimersAsync() =>
            await timerCollection.Find(_ => true).ToListAsync();

        public async Task<Models.Timer> GetTimerAsync(string id) =>
            await timerCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateTimerAsync(Models.Timer timer) =>
            await timerCollection.InsertOneAsync(timer);

        public async Task UpdateTimerAsync(string id, Models.Timer updatedTimer) =>
            await timerCollection.ReplaceOneAsync(x => x.Id == id, updatedTimer);

        public async Task RemoveTimerAsync(string id) =>
            await timerCollection.DeleteOneAsync(x => x.Id == id);
    }
}