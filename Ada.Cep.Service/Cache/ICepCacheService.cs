using Ada.Cep.Domain;

namespace Ada.Cep.Service.Cache
{
    public interface ICepCacheService
    {
        Task<Address> TryGetAddressByCep(string cep);
        Task AddAddressAsync(Address address);
    }
}
