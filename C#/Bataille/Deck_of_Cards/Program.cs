using System;
using System.Collections.Generic;
using System.Text;

namespace Deck_of_Cards
{
    class Program
    {

        using (var v_HttpClient = new HttpClient())
{
HttpResponseMessage response;
try
{
response = await
v_HttpClient.GetAsync("https://jsonplaceholder.typicode.com/users/1");
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
