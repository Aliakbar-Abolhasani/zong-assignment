namespace ZongDemo.Core.PlayerStats
{
    public interface IPlayerStatsService
    {
        int Points { get; }
        void AddPoints(int points);
    }
}