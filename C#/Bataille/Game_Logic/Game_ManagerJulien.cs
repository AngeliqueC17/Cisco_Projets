using System;
using System.Collections.Generic;
using System.Linq;
using Deck_of_Cards;

namespace Game_Logic
{
    public static class Game_ManagerJulien
    {
        private static string[] valeurCarte = new[] {"2", "3","4","5","6","7","8","9","10","JACK","QUEEN","KING","ACE"};

        private static void removePlayers(List<Player> lists)
        {
            var joueursPlusCard = lists.Where(p => p.Cards.Count == 0).ToList();
            joueursPlusCard.ForEach(p=>lists.Remove(p));
        }
        public static void Manche(List<Player> list)
        {
            List<Card> pile = new List<Card>();
            foreach (var joueur in list)
            {
                Card carte = joueur.Cards.Pop();
                carte.IsReturned = true;
                Console.WriteLine("Le joueur " + joueur.Num + " a joué un " + carte.Value);
                pile.Add(carte);
            }

            List<Player> winners = Winners(list, pile);
            
            if (winners.Count == 1)
            {
                Console.WriteLine("\nLe gagnant est le joueur " + winners[0].Num + "\n");
                GetCardsWin(winners[0].Cards, pile);
                removePlayers(list);
            }
            else
            {
                Player winner = Bataille(winners, list);
                GetCardsWin(winner.Cards, pile);
                removePlayers(list);
            }
        }
        public static void GetCardsWin(Stack<Card> PileDuJoueur,  List<Card> cartesGagne)
        {
 
            // Temporary stack
            Stack<Card> temp = new Stack<Card>();

            var test = PileDuJoueur.Reverse().ToList();
            
            PileDuJoueur.Clear();
            
            //On met les cartes gagné dans temp => en bas de la pile
            cartesGagne.ForEach(card => temp.Push(card));
            
            //On met les cartes tu joueurs dans temp => au dessus des cartes gagnés
            test.ForEach(card => temp.Push(card));
            
            temp.Reverse().ToList().ForEach(card => PileDuJoueur.Push(card));

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
                if (carte.IsReturned)
                {
                    cardsRanks.Add(Array.FindIndex(valeurCarte, card => card == carte.Value));
                }
            }
            
            //On récupère l'indice de la carte la plus forte d'après le tableau valeurCarte
            var max = cardsRanks.Max();
            
            //On récupère l'indice des joueurs ayant joué la carte la plus forte
            var t = cardsRanks.FindAllIndexof(max);
            
            //On retounr le liste des joueurs avec la plus forte carte jouée
            return t.Select(t1 => playersTotal[t1]).ToList();
        }
        public static Player Bataille(List<Player> pq, List<Player> TotalDeJoueur)
        {
            List<Card> pile = new List<Card>();
            List<Player> winners = new List<Player>();
            //Les joueurs posent une carte
            
            do
            {
                List<Card> cardsPlayed = new List<Card>();
                Console.WriteLine("\n\nDébut de la bataille");
                for (int i = 0; i <= 1; i++)
                {
                    var joueursPlusCard = pq.Where(p => p.Cards.Count == 0).ToList();
                    joueursPlusCard.ForEach(p=>
                    {
                        pq.Remove(p);
                        TotalDeJoueur.Remove(p);
                    });
                    foreach (var joueur in pq)
                    {
                        if (joueur.Cards.Count == 0 && TotalDeJoueur.Count == 2)
                        {
                            Console.WriteLine("Égalité == PAT ");
                            Environment.Exit(0);
                        }
                        Card carte = joueur.Cards.Pop();
                        //Si i = 0 alors la carte n'est pas retourné et sinon elle est retourné (visible)
                        carte.IsReturned = (i != 0);
                        if (carte.IsReturned)
                        {
                            Console.WriteLine("Le joueur " + joueur.Num + " a joué un " + carte.Value);
                        }
                        else
                        {
                            Console.WriteLine("Carte cachée");
                        }
                        cardsPlayed.Add(carte);
                    }
                }
                winners = Winners(pq, cardsPlayed);
                Console.WriteLine("\nFin de la bataille\n");
                cardsPlayed.ForEach(card => pile.Add(card));
            } while (winners.Count > 1);
            
            Console.WriteLine("Le gagnant de la bataille est le joueur " + winners[0].Num + "\n");
            GetCardsWin(winners[0].Cards, pile);
            return winners[0];
        }
    }
}