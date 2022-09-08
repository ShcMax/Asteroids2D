using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Modifier
{
    public class TestPlayer
    {
        public string Name;
        public int Attack;
        public int Defense;

        public TestPlayer(string name, int attack, int defense)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
        }
    }
}