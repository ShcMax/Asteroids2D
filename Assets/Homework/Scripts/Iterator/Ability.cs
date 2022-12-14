using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Iterator
{
    internal sealed class Ability : IAbility
    {
        public string Name { get; }
        public int Damage { get; }
        public Target Target { get; }
        public DamageType DamageType { get; }


        public Ability(string name, int damage, Target target, DamageType damageType)
        {
            Name = name;
            Damage = damage;
            Target = target;
            DamageType = damageType;
        }

        public override string ToString()
        {
            return Name;
        }        
    }
}