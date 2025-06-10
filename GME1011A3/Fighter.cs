using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GME1011A3
{
    public class Fighter
    {
        private string _name;
        private int _health;
        private int _strength;
        private int _mana;  // Special attribute for special attacks

        public Fighter(string name, int health, int strength)
        {
            _name = name;
            _health = health;
            _strength = strength;
            _mana = 10;  // Starting mana, you can adjust this
        }

        public string GetName() => _name;

        public bool isDead() => _health <= 0;

        public int DealDamage()
        {
            return _strength;
        }

        public int SpecialAttack()
        {
            if (_mana >= 3)  // Special attack costs 3 mana
            {
                _mana -= 3;
                int specialDamage = _strength * 2; // double damage for special
                Console.WriteLine($"{_name} uses a SPECIAL ATTACK for {specialDamage} damage! (Mana left: {_mana})");
                return specialDamage;
            }
            else
            {
                Console.WriteLine($"{_name} tried to use a special attack but didn't have enough mana!");
                return DealDamage(); // fallback to regular attack
            }
        }

        public bool CanUseSpecial()
        {
            return _mana >= 3;
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health < 0) _health = 0;
            Console.WriteLine($"{_name} takes {damage} damage, health now {_health}");
        }
    }
}