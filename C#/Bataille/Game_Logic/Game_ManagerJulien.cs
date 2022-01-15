using System;
using System.Collections.Generic;
using Deck_of_Cards;

namespace Game_Logic
{
    public static class Game_ManagerJulien
    {
        public static void Manche(List<Player> list)
        {
            Stack<Card> pile = new Stack<Card>();
            foreach (var joueur in list)
            {
                Card carte = joueur.Cards.Pop();
                Console.WriteLine("Le joueur " + joueur.Numero + " a joué un " + carte.Value);
                pile.Push(carte);
            }


        }

        public static void Bataille()
        {
            
        }
    }
}