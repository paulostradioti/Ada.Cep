using Ada.Cep.Domain;

namespace Ada.Cep.Service.ApiClient
{
    public interface ICepApiClient
    {
        Task<Address> GetAsync(string cep);
    }
}
