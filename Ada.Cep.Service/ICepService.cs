using Ada.Cep.Domain;

namespace Ada.Cep.Service;

public interface ICepService
{
    Task<Address> GetAddressByCepAsync(string cep);
    
}