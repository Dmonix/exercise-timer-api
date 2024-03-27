using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ExerciseTimer.API.Models
{
    public class Exercise
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public IEnumerable<Segment> Segments { get; set; }
        public Repeat Repeat { get; set; }
    }

    public class Segment
    {
        public TimeSpan Duration { get; set; }
        public string Colour { get; set; }
        public SegmentType SegmentType { get; set; }
    }

    public class Repeat
    {
        public int Repeats { get; set; }
        public Segment Break { get; set; }
    }

    public enum SegmentType
    {
        Exercise,
        Break,
        Rest
    }
}