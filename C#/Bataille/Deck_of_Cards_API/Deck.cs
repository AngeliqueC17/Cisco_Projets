using System.Collections.Generic;

namespace Deck_of_Cards_API
{
    public class Deck
    {
        public string ID { get; set; }
        public int Remaining { get; set; }
        public bool Shuffled { get; set; }
        public Stack<Card> Cards {get; set;}
        
        public Deck(string id, int remaining, bool shuffled, Stack<Card> cards)
        {
            ID = id;
            Remaining = remaining;
            Shuffled = shuffled;
            Cards = cards;
        }
    }
}