using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GME1011A3
{
    public class Minion
    {
        protected int _health;
        protected int _armour;  
        protected int _damage;

        public Minion(int health, int armor, int damage)
        {
            _health = health;
            _armour = armor;
            _damage = damage;
        }


        // Can use special? Always true for now 
        public virtual bool CanUseSpecial()
        {
            return true;
        }

        // Special attack does double the regular damage by default
        public virtual int SpecialAttack()
        {
            return DealDamage() * 2;
        }

        public int GetHealth() { return _health; }
        public int GetArmour() { return _armour; }

        
        public virtual void TakeDamage(int damage)
        {
            int damageTaken = damage - _armour;
            if (damageTaken < 0) damageTaken = 0;
            _health -= damageTaken;
        }

        // Default damage is 5
        public virtual int DealDamage()
        {
            return 5;
        }

        // Check if dead (health 0 or less)
        public bool isDead()
        {
            return _health <= 0;
        }

        public override string ToString()
        {
            return "Minion[Health: " + _health + ", Armour: " + _armour + "]";
        }
    }
}
