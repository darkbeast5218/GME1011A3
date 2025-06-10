using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GME1011A3
{
    public class Skellie : Minion
    {
        public Skellie(int health, int armor, int damage) : base(health, armor, damage)
        {
            // Skellie-specific constructor, armor is usually 0
        }

        public override bool CanUseSpecial()
        {
            // Example: Skellie can use special if health below some threshold
            return _health < 15;
        }

        public int SkellieRattle()
        {
            // Skellie's special attack damage calculation
            int specialDamage = _damage + 5;  // just an example boost
            Console.WriteLine("Skellie uses Skellie Rattle for " + specialDamage + " damage!");
            return specialDamage;
        }

        public override string ToString()
        {
            return $"Skellie (Health: {_health}, Damage: {_damage})";
        }
    }
}