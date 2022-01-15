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

        public bool IsReturned { get; set; } //Utilisé lors de la bataille pour différencier la carte retournée et la carte cachée
        public override string ToString() //A retirer
        {
            return "Value : " + Value;
        }
    }
}