using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Deck_of_Cards
{
    public static class Call
    {
        public static async Task<string> FunctionGet(Uri Urle)
        {
            string contentResponse;
            using var httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(Urle);
                response.EnsureSuccessStatusCode();
                contentResponse = await response.Content.ReadAsStringAsync();

            return contentResponse; 
        }

        public static async Task<Deck> RetrieveOneDeck()
        {
            return  JsonConvert.DeserializeObject<Deck>(
                await FunctionGet(new Uri("https://deckofcardsapi.com/api/deck/new/draw/?count=52")));
            //Obtenir un jeu de 52 cartes
        }
    }
}