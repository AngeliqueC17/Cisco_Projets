using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Deck_of_Cards;
using Game_Logic;

namespace Game_Display
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*
            Game_Manager Jeu = new Game_Manager();
            Console.WriteLine("Welcome to the game.");
            int nbpl = NombreJoueurs(); //Calls the method to initialize the number of players
            Game_Manager.Distribution(nbpl, Jeu.Jeu); //Calls the method to implement the deck
            */
            List<Player> ListPlayers = LaZigounetAMichelle(NombreJoueurs());
            Deck deck = await Call.RetrieveOneDeck();
            Distribution(deck.Cards, ListPlayers);
            do
            {
                Game_ManagerJulien.Manche(ListPlayers);
            } while (ListPlayers.Count > 1);

            Console.WriteLine("\n\nLe gagnant est le joueur" + ListPlayers[0].Num);
        }
        public static int NombreJoueurs() //Initialiser le nombre des joueurs
        {
            int nbpl; //nbpl = Nombre des joueurs
            do
            {
                Console.WriteLine("Please, enter a number between 2 and 6");
                nbpl = int.Parse(Console.ReadLine());
            } while (nbpl < 2 || nbpl > 6); //Minimum 2 joueurs, maximum 6

            Console.WriteLine("OK ! The game will be played between " + nbpl + " players");

            return nbpl;
        }

        public static List<Player> LaZigounetAMichelle(int nbpl)
        {
            List<Player> list = new List<Player>();
            for (int i = 0; i < nbpl; i++)
            {
                Player p = new Player(i+1);
                list.Add(p);
            }

            return list;
        }

        public static void Distribution(Stack<Card> cartes, List<Player> list)
        {
            do
            {
                foreach (var joueur in list)
                {
                    if (cartes.Count > 0)
                    {
                        joueur.Cards.Push(cartes.Pop());
                    }
                } 
            } while (cartes.Count > 0);
        }
    }
}