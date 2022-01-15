using Newtonsoft.Json;

namespace Deck_of_Cards
{
    public class Card
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        
        [JsonProperty("value")]
        public string Value { get; set; }
        
        [JsonProperty("suit")]
        public string Suit { get; set; }

        public override string ToString()
        {
            return "Value : " + Value;
        }
    }
}