using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Deck_of_Cards
{
    public class Deck
    {
        //Propertie of a deck
        
        [JsonProperty("deck_id")]
        public string ID { get; set; }
        
        [JsonProperty("remaining")]
        public int Remaining { get; set; }
        
        [JsonProperty("shuffled")]
        public bool Shuffled { get; set; }
        
        [JsonProperty("cards")]
        public Stack<Card> Cards {get; set;}
    }
}