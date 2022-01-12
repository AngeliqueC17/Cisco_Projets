using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Deck_of_Cards
{
    public class Call
    {
        public static Deck deck;
        public static HttpClient client;

        public Call()
        {
            client = new HttpClient();
            deck = new Deck();
        }

        public static async Task<string> FonctionGet(Uri Urle)
        {
            string contentResponse = string.Empty;

                HttpResponseMessage response = await
                client.GetAsync(Urle); //Get the JSON
                                       //Put "new" to directly create a deck
                                       //This choice is explained in order to be able to have a deck made up of 52 cards that can be displayed
                response.EnsureSuccessStatusCode();
                contentResponse = await response.Content.ReadAsStringAsync();

            return contentResponse; 
        }
    }
}