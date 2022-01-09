using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Deck_of_Cards
{
    public static class Call
    {
        public static async Task<Deck> Test ()
        {
            Deck RecupDeck = null;

            using (var v_HttpClient = new HttpClient())
            {
                HttpResponseMessage response;
                try
                {
                    response = await
                        v_HttpClient.GetAsync("https://deckofcardsapi.com/api/deck/new/draw/?count=52");
                    response.EnsureSuccessStatusCode();
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    RecupDeck = JsonConvert.DeserializeObject<Deck>(contentResponse);

                }
                catch(HttpRequestException)
                {
                    // Handle error
                }
            }

            return RecupDeck;
        }
    }
}