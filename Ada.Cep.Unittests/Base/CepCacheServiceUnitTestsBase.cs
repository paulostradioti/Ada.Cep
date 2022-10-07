using Ada.Cep.Domain;
using Ada.Cep.Service;
using Ada.Cep.Service.Cache;
using RichardSzalay.MockHttp;

namespace Ada.Cep.UnitTests.Base;

public class CepCacheServiceUnitTestsBase
{
    public static string ApiResponseJson => "{\"cep\":\"15840000\",\"logradouro\":\"Quadra SGAN 906\",\"complemento\":\"\",\"bairro\":\"Asa Norte\",\"localidade\":\"Brasília\",\"uf\":\"DF\",\"ibge\":\"5300108\"}";
    public static string DefaultCep => "70790060";
    public static Address DefaultAddress => _address;
    public HttpClient MockHttpClient => _httpClient;

    private static HttpClient _httpClient = new HttpClient(CreateNewMockMesssageHandler())
    { BaseAddress = Constants.Cep.CepApiBaseUrl };

    private static Address _address = new()
    {
        Cep = DefaultCep,
        Logradouro = "Quadra SGAN 906",
        Bairro = "Asa Norte",
        Localidade = "Brasília",
        Uf = "DF"
    };

    private static HttpMessageHandler CreateNewMockMesssageHandler()
    {
        var httpMessageHandlerMock = new MockHttpMessageHandler();
        httpMessageHandlerMock.When("https://opencep.com/v1/15840000").Respond("application/json", ApiResponseJson);

        return httpMessageHandlerMock;
    }

    public class FakeCacheService : CepCacheService
    {
        public FakeCacheService() => _cache.Add(_address.Cep, _address);
        public int Count => _cache.Count;
    }
}