using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Iterator
{
    public class IteratorExample : MonoBehaviour
    {
       
        void Start()
        {
            var abilities = new List<IAbility>
            {
                new Ability("Inner Fire", 100, Target.None, DamageType.Magical),
                new Ability("Burning Spear", 200, Target.Unit | Target.Autocast, DamageType.Magical),
                new Ability("Berserk's Blood", 300, Target.Passive, DamageType.None),
                new Ability("Life Break", 400, Target.Unit, DamageType.Magical)
            };

            IEnemy enemy = new Enemy(abilities);

            Debug.Log("IteratorExample.Start: enemy[0] = " + enemy[0]);
            Debug.Log("IteratorExample.Start: enemy[Target.Unit | Target.Autocast] = " + enemy[Target.Unit | Target.Autocast]);
            Debug.Log("IteratorExample.Start: enemy[Target.Unit | Target.Passive] = " + enemy[Target.Unit | Target.Passive]);
            Debug.Log("IteratorExample.Start: enemy.MaxDamage = " + enemy.MaxDamage);

            foreach (var a in enemy)
            {
                Debug.Log("IteratorExample.Start: a = " + a);
            }

            foreach (var b in enemy.GetAbility().Take(2))
            {
                Debug.Log("IteratorExample.Start: b = " + b);
            }

            foreach (var c in enemy.GetAbility(DamageType.Magical))
            {
                Debug.Log("IteratorExample.Start: c = " + c);
            }
        }
    }
}