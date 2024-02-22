namespace ZongDemo.Core.PlayerStats
{
    /// <summary>
    ///     Saves stats in the memory (it resets after application quit)
    /// </summary>
    public class InMemoryPlayerStatsService : IPlayerStatsService
    {
        public int Points { get; private set; }

        public void AddPoints(int points)
        {
            Points += points;
        }
    }
}