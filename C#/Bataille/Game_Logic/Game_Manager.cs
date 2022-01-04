using System;

namespace Game_Logic
{
    public class Game_Manager

    {
        static void Main(string[] args)
        {
            Deck Deck1 = new Deck(true, "3p40paa87x90", true, 52);
            Console.WriteLine(Deck1.CreateDeck());
        }
    }
}