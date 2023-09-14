using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RPG_Semana2
{
    internal class Game
    {
        private List<Enemy> enemies;
        private Player player;

        public Game(int numMeleeEnemies, int numRangeEnemies)
        {
            enemies = new List<Enemy>();

            for (int i = 0; i < numMeleeEnemies; i++)
            {
                enemies.Add(new MeleeEnemy(50, 10, 5)); // Vida, Daño, Armadura
            }

            for (int i = 0; i < numRangeEnemies; i++)
            {
                enemies.Add(new RangeEnemy(40, 10, 5)); // Vida, Daño, Balas
            }
        }

        public void StartGame(int playerHealth, int playerDamage)
        {
            player = new Player(playerHealth, playerDamage);
            int currentPlayerIndex = 0;
            bool playerTurn = true;

            while (player.IsAlive() && currentPlayerIndex < enemies.Count)
            {
                if (playerTurn)
                {
                    Console.WriteLine("Es el turno del jugador.");
                    Console.WriteLine($"Vida del jugador: {player.GetLife()}");
                    Console.WriteLine($"Daño del jugador: {playerDamage}");
                    Console.WriteLine("Elige un enemigo para atacar (1 - Melee, 2 - Range):");
                    int enemyChoice = int.Parse(Console.ReadLine());

                    if (enemies.Count > 0) 
                    {
                        if (enemyChoice == 1 && enemies.Any(e => e is MeleeEnemy))
                        {
                            MeleeEnemy currentEnemy = enemies.FirstOrDefault(e => e is MeleeEnemy) as MeleeEnemy;
                            if (currentEnemy != null)
                            {
                                Console.WriteLine($"Atacando al enemigo melee.");
                                currentEnemy.ReceiveDamageFromPlayer(playerDamage);


                                if (!currentEnemy.IsAlive())
                                {
                                    Console.WriteLine($"El enemigo ({currentEnemy.GetType().Name}) ha sido derrotado.");
                                    enemies.Remove(currentEnemy);
                                }
                            }
                        }
                        else if (enemyChoice == 2 && enemies.Any(e => e is RangeEnemy))
                        {
                            RangeEnemy currentEnemy = enemies.FirstOrDefault(e => e is RangeEnemy) as RangeEnemy;
                            if (currentEnemy != null)
                            {
                                if (currentEnemy.HasBullets()) 
                                {
                                    Console.WriteLine($"Atacando al enemigo de rango.");
                                    currentEnemy.ReceiveDamage(playerDamage);

                                    if (!currentEnemy.IsAlive())
                                    {
                                        Console.WriteLine($"El enemigo ({currentEnemy.GetType().Name}) ha sido derrotado.");
                                        enemies.Remove(currentEnemy);
                                    }

                                    currentEnemy.ConsumeBullet(); 
                                }
                                else
                                {
                                    currentEnemy.ReceiveDamage(playerDamage);
                                    Console.WriteLine("El enemigo de rango se quedó sin balas y debe pasar de turno.");
                                    if (!currentEnemy.IsAlive())
                                    {
                                        Console.WriteLine($"El enemigo ({currentEnemy.GetType().Name}) ha sido derrotado.");
                                        enemies.Remove(currentEnemy);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Elección de enemigo no válida.");
                        }
                        if (enemies.Count <= 0)
                        {
                            Console.WriteLine("No quedan enemigos para atacar.");
                            Console.WriteLine("¡Has ganado!");
                        }
                    }
                    playerTurn = false;
                }
                else
                {
                    Console.WriteLine("Es el turno de los enemigos.");
                    foreach (Enemy enemy in enemies.ToList())
                    {
                        if (enemy.IsAlive())
                        {
                            Console.WriteLine($"El enemigo ({enemy.GetType().Name}) tiene {enemy.Health} de vida, {enemy.Damage} de daño.");

                            if (enemy is MeleeEnemy)
                            {
                                MeleeEnemy currentEnemy = (MeleeEnemy)enemy;
                                Console.WriteLine($"Armadura del enemigo melee: {currentEnemy.GetArmor()}");

                                int damageToPlayer = (playerDamage - currentEnemy.GetArmor());
                                Console.WriteLine($"El enemigo melee ataca al jugador con {enemy.Damage} de daño.");
                                player.ReceiveDamage(enemy.Damage);
                            }
                            else if (enemy is RangeEnemy)
                            {
                                RangeEnemy currentEnemy = (RangeEnemy)enemy;
                                Console.WriteLine($"Balas del enemigo de rango: {currentEnemy.GetBullets()}");

                                if (currentEnemy.HasBullets())
                                {
                                    int damageToPlayer = (playerDamage);
                                    Console.WriteLine($"El enemigo range ataca al jugador con {enemy.Damage} de daño.");
                                    player.ReceiveDamage(enemy.Damage);

                                    if (!currentEnemy.IsAlive())
                                    {
                                        enemies.Remove(currentEnemy);
                                    }

                                    currentEnemy.ConsumeBullet();
                                }
                                else
                                {
                                    Console.WriteLine("El enemigo de rango se quedó sin balas y debe pasar de turno.");
                                }
                            }
                        }
                       
                    }

                    playerTurn = true;
                }
            }

        }
    }
}

