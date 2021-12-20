using System;
using Game_Logic;

namespace Game_Display
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game.");
            
            Initialization();
        }
        
        public static void Initialization() //Initialization of the number of players
        {
            int nbpl; //Number of players, min 2 and max 6
            do
            {
                Console.WriteLine("Please, enter a number between 2 and 6");
                nbpl = int.Parse(Console.ReadLine());
            } while (nbpl < 2 || nbpl > 6);
            
            Console.WriteLine("OK ! The game will be played between " + nbpl + " players");
        }
    }
}