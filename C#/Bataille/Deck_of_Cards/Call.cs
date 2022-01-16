using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Deck_of_Cards
{
    public static class Call
    {
        public static async Task<string> FunctionGet(Uri urle)
        {
            using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(urle);
                response.EnsureSuccessStatusCode();
                var contentResponse = await response.Content.ReadAsStringAsync();

            return contentResponse;
        }

        public static async Task<Deck> RetrieveOneDeck()
        {
            return  JsonConvert.DeserializeObject<Deck>(
                await FunctionGet(new Uri("https://deckofcardsapi.com/api/deck/new/draw/?count=52")));
            //Get a deck of 52 cards
        }
    }
}