using Newtonsoft.Json;

namespace Deck_of_Cards
{
    public class Card
    {
        //Properties of a card
        
        [JsonProperty("code")]
        public string Code { get; set; }
        
        [JsonProperty("value")]
        public string Value { get; set; }
        
        [JsonProperty("suit")]
        public string Suit { get; set; }

        //Used in a war to differentiate between face up card and face down card
        public bool IsReturned { get; set; }
    }
}