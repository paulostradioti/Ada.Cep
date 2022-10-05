using Ada.Cep.Domain;
using Ada.Cep.Service.ApiClient;
using Ada.Cep.Service.Cache;

namespace Ada.Cep.Service
{
    public class CepService : ICepService
    {
        private readonly ICepCacheService _cache;
        private readonly ICepApiClient _apiClient;

        public CepService(ICepCacheService cache, ICepApiClient apiClient)
        {
            _cache = cache;
            _apiClient = apiClient;
        }

        public async Task<Address> GetAddressByCepAsync(string cep)
        {
            var address = await _cache.TryGetAddressByCep(cep);

            if (address == null)
            {
                address = await _apiClient.GetAsync(cep);
                await _cache.AddAddressAsync(address);
            }

            return address;
        }
    }
}