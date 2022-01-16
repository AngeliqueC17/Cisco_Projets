using Newtonsoft.Json;

namespace Deck_of_Cards
{
    public class Piles
    {
        //Maximum of 6 players
        
        [JsonProperty("player1")]
        public Player Player1 { get; set; }
        
        [JsonProperty("player2")]
        public Player Player2 { get; set; }
        
        [JsonProperty("player3")]
        public Player Player3 { get; set; }
        
        [JsonProperty("player4")]
        public Player Player4 { get; set; }
        
        [JsonProperty("player5")]
        public Player Player5 { get; set; }
        
        [JsonProperty("player6")]
        public Player Player6 { get; set; }
        
        //For the player to discard a card
        
        [JsonProperty("discard")]
        public int Discard { get; set; }

    }
}