using System;
using System.Threading.Tasks;
using Game_Logic;

namespace Game_Display
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the game.");
            int nbpl = Initialization(); //Calls the method to initialize the number of players
            Game_Manager.Initialization(nbpl); //Calls the method to implement the deck
        }
        public static int Initialization() //Initialization of the number of players
        {
            int nbpl; //Number of players, min 2 and max 6
            do
            {
                Console.WriteLine("Please, enter a number between 2 and 6");
                nbpl = int.Parse(Console.ReadLine());
            } while (nbpl < 2 || nbpl > 6);

            Console.WriteLine("OK ! The game will be played between " + nbpl + " players");

            // distribution of the cards between the players in the Game_Logic > Game_Manager.cs
            Game_Manager.Distribution(nbpl);

            return nbpl;
        }

    }
}