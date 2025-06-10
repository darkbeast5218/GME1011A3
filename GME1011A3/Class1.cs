using System;

namespace GME1011A3
{
    public class Wraith : Minion
    {
        public Wraith(int health, int armor, int damage) : base(health, armor, damage)
        {
            // Wraith-specific constructor
        }

        public override bool CanUseSpecial()
        {
            // Example: Wraith can use special if health is below 20
            return _health < 20;
        }

        public int SoulDrain()
        {
            // Wraith's special attack
            int specialDamage = _damage + 4;
            Console.WriteLine("Wraith uses Soul Drain for " + specialDamage + " damage!");
            return specialDamage;
        }

        public override string ToString()
        {
            return $"Wraith (Health: {_health}, Damage: {_damage})";
        }
    }
}
