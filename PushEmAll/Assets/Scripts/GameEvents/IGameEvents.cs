namespace Assignment.Events
{
    public interface IGameEvents
    {
        public void StartGame();
        public void EnterEnemyZone(int a_enemyCount);
        public void EnemyKill();
        public void ZoneComplete();
        public void GameOver();
    }
}