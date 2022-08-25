namespace Prototype.Scripts
{
    public static class PlayerDataFactory
    {
        public static CloneablePlayerData CreateCloneablePlayerData()
        {
            var playerData = new CloneablePlayerData() { Speed = 15, HealthData = new CloneableHealthData { MaxHealth = 100, CurrentHealth = 99 } };
            return playerData;
        }

        public static PlayerData CreatePlayerData()
        {
            var playerData = new PlayerData { Speed = 15, HealthData = new HealthData { MaxHealth = 100, CurrentHealth = 99 } };
            return playerData;
        }
    }
}