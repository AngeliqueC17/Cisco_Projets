using System;
using Game_Logic;

namespace Game_Display
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le jeu de la Bataille.");
            
            Console.WriteLine("Combien de joueurs êtes vous ?");
            Game_Manager.Initialization();
        }
    }
}