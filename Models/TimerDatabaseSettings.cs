namespace ExerciseTimer.API.Models
{
    public class TimerDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string TimersCollectionName { get; set; } = null!;
        public string ExerciseCollectionName { get; set; } = null!;
    }
}