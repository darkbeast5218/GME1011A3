using System;
using System.Collections.Generic;

namespace GME1011A3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();

            string name;
            while (true)
            {
                Console.Write("What's your hero's name? ");
                name = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(name)) break;
                Console.WriteLine("Please enter a valid name.");
            }

            int health;
            Console.Write("How much health does your hero have? ");
            while (!int.TryParse(Console.ReadLine(), out health) || health <= 0)
            {
                Console.WriteLine("Please enter a valid positive number for health.");
            }

            int strength;
            Console.Write("How strong is your hero? ");
            while (!int.TryParse(Console.ReadLine(), out strength) || strength <= 0)
            {
                Console.WriteLine("Please enter a valid positive number for strength.");
            }

            int numEnemies;
            Console.Write("How many monsters do you wanna fight? ");
            while (!int.TryParse(Console.ReadLine(), out numEnemies) || numEnemies <= 0)
            {
                Console.WriteLine("Please enter a valid positive number for number of enemies.");
            }

            Fighter hero = new Fighter(name, health, strength);

            int numAliveBaddies = numEnemies;
            List<Minion> baddies = new List<Minion>();

            for (int i = 0; i < numEnemies; i++)
            {
                int roll = rng.Next(3); // 0: Goblin, 1: Skellie, 2: Wraith

                if (roll == 0)
                {
                    int h = rng.Next(30, 36);
                    int armor = rng.Next(1, 5);
                    int damage = rng.Next(2, 9);
                    baddies.Add(new Goblin(h, armor, damage));
                }
                else if (roll == 1)
                {
                    int h = rng.Next(25, 31);
                    int damage = rng.Next(2, 9);
                    baddies.Add(new Skellie(h, 0, damage));
                }
                else
                {
                    int h = rng.Next(28, 34);
                    int damage = rng.Next(3, 7);
                    baddies.Add(new Wraith(h, 1, damage));
                }
            }

            Console.WriteLine("\nHere are the baddies!!!");
            foreach (var baddie in baddies)
            {
                Console.WriteLine(baddie);
            }

            Console.WriteLine("\nLet the EPIC battle begin!!!");
            Console.WriteLine("----------------------------");

            while (numAliveBaddies > 0 && !hero.isDead())
            {
                int indexOfEnemy = 0;
                while (baddies[indexOfEnemy].isDead())
                {
                    indexOfEnemy++;
                    if (indexOfEnemy >= baddies.Count) break;
                }
                if (indexOfEnemy >= baddies.Count) break;

                Console.WriteLine($"{hero.GetName()} attacks enemy #{indexOfEnemy + 1} ({baddies[indexOfEnemy].GetType().Name})");

                int heroDamage;
                if (rng.Next(100) < 33 && hero.CanUseSpecial())
                {
                    heroDamage = hero.SpecialAttack();
                    Console.WriteLine("Hero uses special attack!");
                }
                else
                {
                    heroDamage = hero.DealDamage();
                }

                Console.WriteLine($"Hero deals {heroDamage} damage.");
                baddies[indexOfEnemy].TakeDamage(heroDamage);

                if (baddies[indexOfEnemy].isDead())
                {
                    numAliveBaddies--;
                    Console.WriteLine($"Enemy #{indexOfEnemy + 1} defeated!");
                }
                else
                {
                    int baddieDamage;
                    if (rng.Next(100) < 33 && baddies[indexOfEnemy].CanUseSpecial())
                    {
                        if (baddies[indexOfEnemy] is Goblin goblin)
                        {
                            baddieDamage = goblin.GoblinBite();
                        }
                        else if (baddies[indexOfEnemy] is Skellie skellie)
                        {
                            baddieDamage = skellie.SkellieRattle();
                        }
                        else if (baddies[indexOfEnemy] is Wraith wraith)
                        {
                            baddieDamage = wraith.SoulDrain();
                        }
                        else
                        {
                            baddieDamage = baddies[indexOfEnemy].DealDamage();
                        }
                    }
                    else
                    {
                        baddieDamage = baddies[indexOfEnemy].DealDamage();
                    }

                    Console.WriteLine($"Enemy #{indexOfEnemy + 1} attacks for {baddieDamage} damage!");
                    hero.TakeDamage(baddieDamage);

                    if (hero.isDead())
                    {
                        Console.WriteLine($"{hero.GetName()} has died. Game Over.");
                        break;
                    }
                }
                Console.WriteLine("----------------------------");
            }

            if (!hero.isDead())
            {
                Console.WriteLine($"\n{hero.GetName()} is victorious!");
            }
        }
    }
}
