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
        
        [JsonProperty("discard")]
        public int Discard { get; set; }
        
        public Piles(Player player1, Player player2, Player player3, Player player4, Player player5, Player player6, int discard)
        {
            Player1 = player1;
            Player2 = player2;
            Player3 = player3;
            Player4 = player4;
            Player5 = player5;
            Player6 = player6;
            Discard = discard;
        }
    }
}