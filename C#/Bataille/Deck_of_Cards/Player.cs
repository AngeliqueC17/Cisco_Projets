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

        public int Numero { get; set; }
        public Player(int numero)
        {
            Numero = numero;
            Cards = new Stack<Card>();
        }
    }
}