using System;
using System.Threading.Tasks;
using Deck_of_Cards;

namespace Game_Logic
{
    public class Game_Manager

    {
        public static async Task Initialization()
        {
            Deck deck = await Call.Test();
        }
        
    }
}