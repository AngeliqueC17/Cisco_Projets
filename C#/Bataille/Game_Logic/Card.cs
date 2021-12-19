using Newtonsoft.Json;

namespace Game_Logic
{
    public class Card
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        
        [JsonProperty("value")]
        public string Value { get; set; }
        
        [JsonProperty("suit")]
        public string Suit { get; set; }

        public Card(string code, string value, string suit)
        {
            Code = code;
            Value = value;
            Suit = suit;
        }
    }
}