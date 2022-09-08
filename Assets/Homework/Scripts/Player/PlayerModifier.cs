using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Modifier
{


    internal class PlayerModifier
    {
        protected TestPlayer _player;
        protected PlayerModifier Next;

        public PlayerModifier(TestPlayer player)
        {
            _player = player;
        }

        public void Add(PlayerModifier cm)
        {
            if (Next != null)
            {
                Next.Add(cm);
            }
            else
            {
                Next = cm;
            }
        }

        public virtual void Handle() => Next?.Handle();

    }
}