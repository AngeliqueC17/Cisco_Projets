using System.Collections.Generic;
using Newtonsoft.Json;

namespace Deck_of_Cards
{
    public class Deck
    {
        public bool success { get; set; }

        [JsonProperty("deck_id")]
        public string ID { get; set; }
        
        [JsonProperty("remaining")]
        public int Remaining { get; set; }
        
        [JsonProperty("shuffled")]
        public bool Shuffled { get; set; }

        public Piles piles { get; set; }

        [JsonProperty("cards")]
        public List<Card> Cards {get; set;}

    }
}