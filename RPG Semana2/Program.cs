using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Semana2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al juego de combate.");
            Console.WriteLine("Ingresa la vida del jugador (1-100):");
            int playerHealth = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el daño del jugador (1-100):");
            int playerDamage = int.Parse(Console.ReadLine());

            Game game = new Game(1, 1); // melee y de rango
            game.StartGame(playerHealth, playerDamage);
        }
    }
}
