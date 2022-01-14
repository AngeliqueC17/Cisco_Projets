using Newtonsoft.Json;

namespace Deck_of_Cards
{
    public class Card
    {
        public string image { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
        
        [JsonProperty("value")]
        public string Value { get; set; }
        
        [JsonProperty("suit")]
        public string Suit { get; set; }

    }
}