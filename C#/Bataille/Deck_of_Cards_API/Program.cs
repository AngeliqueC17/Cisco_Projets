using System;
using System.Net.Http;

namespace Deck_of_Cards_API
{
    class Program
    {
        private const string deck_count = "https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1"; //1 jeu de carte
        private const string draw_card = "https://deckofcardsapi.com/api/deck/<<deck_id>>/draw/?count=2"; //A modifier selon le cas
        private const string adding_to_pile = "https://deckofcardsapi.com/api/deck/<<deck_id>>/pile/<<pile_name>>/add/?cards=AS,2S"; //Récuperer les cartes retournée et les mettre dans son jeu
        private const string drawing_from_pile = "https://deckofcardsapi.com/api/deck/<<deck_id>>/draw/top/"; //Tirer une carte par le haut
        
        //Objet static pour les requêtes
        private static HttpClient client;
        static void Main(string[] args)
        {
            client = new HttpClient();
            Console.WriteLine("DECK OF CARDS API");
            
        }
    }
}