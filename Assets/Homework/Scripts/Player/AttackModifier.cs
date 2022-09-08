using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Modifier
{


    internal sealed class AddAttackModifier : PlayerModifier
    {
        private readonly int _attack;

        public AddAttackModifier(TestPlayer player, int attack) : base(player)
        {
            _attack = attack;
        }

        public override void Handle()
        {
            _player.Attack += _attack;
            base.Handle();
        }
    }
}