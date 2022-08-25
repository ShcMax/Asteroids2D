using System;

namespace Prototype.Scripts
{
    public class CloneablePlayerData : ICloneable
    {
        public int Speed;
        public CloneableHealthData HealthData;
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    
    
    public struct CloneableHealthData
    {
        public int MaxHealth;
        public int CurrentHealth;
    }
}