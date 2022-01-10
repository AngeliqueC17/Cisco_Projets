using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Deck_of_Cards
{
    public static class Call
    {
        public static async Task<Deck> Draw_A_Card()
        {
            Deck RecupDeck = null;

            using (var v_HttpClient = new HttpClient())
            {
                HttpResponseMessage response;
                try
                {
                    response = await
                        v_HttpClient.GetAsync("https://deckofcardsapi.com/api/deck/new/draw/?count=52"); //Get the JSON
                    //Put "new" to directly create a deck
                    //This choice is explained in order to be able to have a deck made up of 52 cards that can be displayed
                    response.EnsureSuccessStatusCode();
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    RecupDeck = JsonConvert.DeserializeObject<Deck>(contentResponse); //Converts the recovered JSON into objects, here a deck with cards

                }
                catch(HttpRequestException)
                {
                    // Handle error
                }
            }

            return RecupDeck; //Return the deck with an ID, the count of remaining, the cards and the deck shuffled
        }
    }
}