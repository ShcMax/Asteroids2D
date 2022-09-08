using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Modifier
{
    internal sealed class AddDefenseModifier : PlayerModifier
    {
        private readonly int _maxDefense;

        public AddDefenseModifier(TestPlayer player, int maxDefense)
            : base(player)
        {
            _maxDefense = maxDefense;
        }

        public override void Handle()
        {
            if (_player.Defense <= _maxDefense)
            {
                _player.Defense++;
            }
            base.Handle();
        }
    }
}