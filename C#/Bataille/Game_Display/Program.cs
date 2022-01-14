using System;
using System.Threading.Tasks;
using Game_Logic;

namespace Game_Display
{
    class Program
    {
        static void Main(string[] args)
        {
            Game_Manager Jeu = new Game_Manager();
            Console.WriteLine("Welcome to the game.");
            int nbpl = NombreJoueurs(); //Calls the method to initialize the number of players
            Game_Manager.Distribution(nbpl, Jeu.Jeu); //Calls the method to implement the deck
        }
        public static int NombreJoueurs() //Initialization of the number of players
        {
            int nbpl; //Number of players, min 2 and max 6
            do
            {
                Console.WriteLine("Please, enter a number between 2 and 6");
                nbpl = int.Parse(Console.ReadLine());
            } while (nbpl < 2 || nbpl > 6);

            Console.WriteLine("OK ! The game will be played between " + nbpl + " players");

            return nbpl;
        }

    }
}