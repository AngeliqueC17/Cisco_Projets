namespace Deck_of_Cards_API
{
    public class Card
    {
        public string Code { get; set; }
        public string Value { get; set; }
        public string Suit { get; set; }

        public Card(string code, string value, string suit)
        {
            Code = code;
            Value = value;
            Suit = suit;
        }
    }
}