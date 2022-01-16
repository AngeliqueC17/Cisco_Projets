using System;
using System.Collections.Generic;
using System.Linq;
using Deck_of_Cards;

namespace Game_Logic
{
    public static class Game_Manager
    {
        private static string[] cardsValue = new[] {"2","3","4","5","6","7","8","9","10","JACK","QUEEN","KING","ACE"};

        private static void RemovePlayers(List<Player> lists)
        {
            //Remove the player if he has no more cards
            
            var emptyDeck = lists.Where(p => p.Cards.Count == 0).ToList();
            emptyDeck.ForEach(p=>lists.Remove(p));
        }
        public static void Round(List<Player> list)
        {
            List<Card> pile = new List<Card>();
            foreach (var joueur in list)
            {
                //Each player reveals a card
                
                Card carte = joueur.Cards.Pop();
                carte.IsReturned = true;
                Console.WriteLine("Player " + joueur.Num + " played a " + carte.Value + ".");
                pile.Add(carte);    //Revealed cards are added to a pile
            }

            List<Player> winners = Winners(list, pile);
            
            if (winners.Count == 1)
            {
                //Case of no battle
                
                Console.WriteLine("\nThe winner is the player : " + winners[0].Num + ".\n");
                GetCardsWin(winners[0].Cards, pile);    //The winner collects the cards played
                RemovePlayers(list);    //If one of the players has no more cards, he is eliminated
            }
            else
            {
                //Case of battle
                
                Player winner = Battle(winners, list);
                GetCardsWin(winner.Cards, pile);
                RemovePlayers(list);
            }
        }
        public static void GetCardsWin(Stack<Card> playerPile,  List<Card> cardsWon)
        {
            Stack<Card> temp = new Stack<Card>();
            var test = playerPile.Reverse().ToList();
            playerPile.Clear();
            cardsWon.ForEach(card => temp.Push(card));   //Put the won cards in a temporary pile, at the bottom of the pile
            test.ForEach(card => temp.Push(card));   //Put the player cards in a temporary pile, above the cards won
            temp.Reverse().ToList().ForEach(card => playerPile.Push(card));
        }
        public static int[] FindAllIndexof<T>(this IEnumerable<T> values, T val)
        {
            //A voir
            return values.Select((b,i) => object.Equals(b, val) ? i : -1).Where(i => i != -1).ToArray();
        }

        public static List<Player> Winners(List<Player> playersTotal, List<Card> cardsPlayed)
        {
            List<int> cardsRanks = new List<int>();
            
            //The cards played are matched according to their rank in the tableau
            foreach (var aCard in cardsPlayed)
            {
                if (aCard.IsReturned)
                {
                    cardsRanks.Add(Array.FindIndex(cardsValue, card => card == aCard.Value));
                }
            }
            
            var max = cardsRanks.Max();     //Retrieve the index of the strongest card according to the table
            var t = cardsRanks.FindAllIndexof(max);     ////Retrieve the index of the players who played the strongest card
            return t.Select(t1 => playersTotal[t1]).ToList();   //Returns the list of players with the highest card played
        }
        public static Player Battle(List<Player> listP, List<Player> playersT)
        {
            List<Card> pile = new List<Card>();
            List<Player> winners = new List<Player>();

            //Battle is played with the players who have won the round
            
            do
            {
                List<Card> cardsPlayed = new List<Card>();
                Console.WriteLine("\n\nStart of the battle");
                
                //Checking before the battle that players have enough cards to do it
                
                for (int i = 0; i <= 1; i++)
                {
                    var playerWithoutCards = listP.Where(p => p.Cards.Count == 0).ToList();
                    playerWithoutCards.ForEach(p=>
                    {
                        listP.Remove(p);
                        playersT.Remove(p);
                    });
                    foreach (var player in listP)
                    {
                        //If the players have no more cards, then there is a tie
                        
                        if (player.Cards.Count == 0 && playersT.Count == 2)
                        {
                            Console.WriteLine("Égalité == PAT ");
                            Environment.Exit(0);
                        }
                        Card carte = player.Cards.Pop();
                        
                        //If i = 0 then the card is not turned over, otherwise it is turned over (visible)
                        
                        carte.IsReturned = (i != 0);
                        if (carte.IsReturned)
                        {
                            Console.WriteLine("Player " + player.Num + " played a " + carte.Value + ".");
                        }
                        else
                        {
                            Console.WriteLine("Cards are not visible.");
                        }
                        cardsPlayed.Add(carte);
                    }
                }
                winners = Winners(listP, cardsPlayed);
                Console.WriteLine("\nEnd of the battle !\n");
                cardsPlayed.ForEach(card => pile.Add(card));
            } while (winners.Count > 1);
            
            Console.WriteLine("The winner of the battle is the player " + winners[0].Num + " !\n");
            GetCardsWin(winners[0].Cards, pile);    //The winner takes the cards
            return winners[0];
        }
    }
}