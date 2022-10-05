using Ada.Cep.Domain;
using Ada.Cep.Service.Cache;

namespace Ada.Cep.Unittests;

public class CepCacheServiceUnitTestsBase
{
    public string ApiResponseJson =>
        "{\"cep\":\"15840000\",\"logradouro\":\"Quadra SGAN 906\",\"complemento\":\"\",\"bairro\":\"Asa Norte\",\"localidade\":\"Brasília\",\"uf\":\"DF\",\"ibge\":\"5300108\"}";

    public static string DefaultCep => "70790060";
    public static Address DefaultAddress => address;

    static Address address = new Address
    {
        Cep = "70790060",
        Logradouro = "Quadra SGAN 906",
        Bairro = "Asa Norte",
        Localidade = "Brasília",
        Uf = "DF"
    };

    public class FakeCacheService : CepCacheService
    {
        public FakeCacheService() : base()
        {
            _cache.Add(address.Cep, address);
        }

        public int Count => _cache.Count;
    }
}