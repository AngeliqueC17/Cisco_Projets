using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Deck_of_Cards;
using Game_Logic;

namespace Game_Display
{
    static class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("Welcome to the game !");
            List<Player> listPlayers = PlayersList(NumOfPlayers());     //Create a list with players
            Deck deck = await Call.RetrieveOneDeck();   //Create a deck of 52 cards
            
            //Distribute the cards
            
            Distribution(deck.Cards, listPlayers);
            do
            {
                Game_Manager.Round(listPlayers);
            } while (listPlayers.Count > 1); //A voir

            Console.WriteLine("\n\nThe winner is the player : " + listPlayers[0].Num);
        }

        private static int NumOfPlayers()   //Initialize the number of players
        {
            int nbpl;   //nbpl = Number of players
            do
            {
                Console.WriteLine("Please, enter a number between 2 and 6.");
                nbpl = int.Parse(Console.ReadLine());
            } while (nbpl < 2 || nbpl > 6);     //Minimum 2 players, maximum 6

            Console.WriteLine("OK ! The game will be played between " + nbpl + " players.");

            return nbpl;
        }

        private static List<Player> PlayersList(int nbpl)
        {
            //Put the players in a list
            
            List<Player> list = new List<Player>();
            for (int i = 0; i < nbpl; i++)
            {
                Player p = new Player(i+1);
                list.Add(p);
            }

            return list;
        }

        private static void Distribution(Stack<Card> cards, List<Player> list)
        {
            do
            {
                foreach (var player in list)    //Browse the list of players
                {
                    if (cards.Count > 0)    //Recheck if there are any cards left to deal
                    {
                        player.Cards.Push(cards.Pop());     //Give a card to a player
                    }
                } 
            } while (cards.Count > 0);      //While there are cards left
        }
    }
}