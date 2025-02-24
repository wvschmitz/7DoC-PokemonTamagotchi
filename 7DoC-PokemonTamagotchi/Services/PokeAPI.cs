using RestSharp;

namespace _7DoC_PokemonTamagotchi.Services;

internal class PokeAPI
{
    protected RestResponse GetUrl(string url)
    {
        using (RestClient http = new RestClient())
        {
            var response = http.Execute(new RestRequest(url, Method.Get));

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response;
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }
        }
    }
}
