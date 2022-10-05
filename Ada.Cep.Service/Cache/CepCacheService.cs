using Ada.Cep.Domain;

namespace Ada.Cep.Service.Cache
{
    public class CepCacheService : ICepCacheService
    {
        private static Dictionary<string, Address> _cache = new();
        public async Task<Address> TryGetAddressByCep(string cep)
        {
            _cache.TryGetValue(cep, out var address);
            
            return address;
        }

        public async Task AddAddressAsync(Address address)
        {
            if (_cache.ContainsKey(address.Cep))
                return;

            _cache.Add(address.Cep, address);
        }
    }
}