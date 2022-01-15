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

        public int Num { get; set; }
        public Player(int num) //Afin de différencier les joueurs lors de l'affichage
        {
            Num = num;
            Cards = new Stack<Card>();
        }
    }
}