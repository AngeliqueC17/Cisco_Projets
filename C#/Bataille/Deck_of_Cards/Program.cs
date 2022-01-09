using System.Net.Http;
using System.Threading.Tasks;

namespace Deck_of_Cards
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Creation of a deck of 52 cards, necessary to start a game.

            using (var v_HttpClient = new HttpClient())
            {
                HttpResponseMessage response;

                try
                {
                    response = await
                    v_HttpClient.GetAsync("https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1");

                    response.EnsureSuccessStatusCode();

                    string contentResponse = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException)
                {
                    // Handle error
                }
            }
        }
    }
}