using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExerciseTimer.API.Models
{
    public class Timer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Label { get; set; }

        public int Duration { get; set; }
    }
}