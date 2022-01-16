using System.Collections.Generic;
using Newtonsoft.Json;

namespace Deck_of_Cards
{
    public class Player
    {
        [JsonProperty("remaining")]
        public int Remaining { get; set; }
        
        [JsonProperty("cards")]
        public Stack<Card> Cards { get; set; }

        //Assign a number to each player
        public int Num { get; }
        
        //To differentiate players during display
        public Player(int num)
        {
            Num = num;
            Cards = new Stack<Card>();
        }
    }
}