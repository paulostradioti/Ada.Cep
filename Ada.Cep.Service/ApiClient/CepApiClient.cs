using System.Net.Http.Json;
using Ada.Cep.Domain;

namespace Ada.Cep.Service.ApiClient
{
    public class CepApiClient : ICepApiClient
    {
        private readonly HttpClient _httpClient;

        public CepApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Address> GetAsync(string cep)
        {
            var response = await _httpClient.GetFromJsonAsync<Address>(cep);

            return response;
        }
    }
}
