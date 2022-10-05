using Ada.Cep.Domain;
using System.Net.Http.Json;

namespace Ada.Cep.Service.ApiClient
{
    public class CepApiClient : ICepApiClient
    {
        private static readonly HttpClient _httpClient = new();

        static CepApiClient()
        {
            _httpClient.BaseAddress = Constants.Cep.CepApiBaseUrl;
        }

        public async Task<Address> GetAsync(string cep)
        {
            var response = await _httpClient.GetFromJsonAsync<Address>(cep);

            return response;
        }
    }
}
