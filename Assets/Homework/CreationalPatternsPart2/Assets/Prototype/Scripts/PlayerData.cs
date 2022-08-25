using System;

namespace Prototype.Scripts
{
    [Serializable]
    public class PlayerData
    {
        public int Speed;
        public HealthData HealthData;
    }

    [Serializable]
    public class HealthData
    {
        public int MaxHealth;
        public int CurrentHealth;
    }
}