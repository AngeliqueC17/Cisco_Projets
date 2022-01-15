using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Deck_of_Cards;

namespace Game_Logic
{
    public static class Game_ManagerJulien
    {
        private static string[] valeurCarte = new[] {"2", "3","4","5","6","7","8","9","10","JACK","QUEEN","KING","ACE"};
        public static void Manche(List<Player> list)
        {
            List<Card> pile = new List<Card>();
            foreach (var joueur in list)
            {
                Card carte = joueur.Cards.Pop();
                Console.WriteLine("Le joueur " + joueur.Numero + " a joué un " + carte.Value);
                pile.Add(carte);
            }

            List<Player> winners = Winners(list, pile);
            
            if (winners.Count == 1)
            {
                Console.WriteLine("Le gagnant est le joueur " + winners[0].Numero);
            }
            else
            {
                Bataille(winners);
            }
        }
        public static int[] FindAllIndexof<T>(this IEnumerable<T> values, T val)
        {
            return values.Select((b,i) => object.Equals(b, val) ? i : -1).Where(i => i != -1).ToArray();
        }

        public static List<Player> Winners(List<Player> playersTotal, List<Card> cardsPlayed)
        {
            List<int> cardsRanks = new List<int>();
            
            //On fait correspondre les cartes jouées selon leur rang dans le tableau valeurCarte
            foreach (var carte in cardsPlayed)
            {
                cardsRanks.Add(Array.FindIndex(valeurCarte, card => card == carte.Value));
            }
            
            //On récupère l'indice de la carte la plus forte d'après le tableau valeurCarte
            var max = cardsRanks.Max();
            
            //On récupère l'indice des joueurs ayant joué la carte la plus forte
            var t = cardsRanks.FindAllIndexof(max);
            
            //On retounr le liste des joueurs avec la plus forte carte jouée
            return t.Select(t1 => playersTotal[t1]).ToList();
        }
        public static void Bataille(List<Player> pq)
        {
            
        }
    }
}