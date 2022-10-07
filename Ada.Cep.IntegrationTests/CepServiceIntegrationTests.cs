using Microsoft.AspNetCore.Mvc.Testing;
using Ada.Cep.Api;
using Ada.Cep.Domain;

namespace Ada.Cep.IntegrationTests
{
    public class CepServiceIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CepServiceIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task Test1()
        {
            var result = await _client.GetFromJsonAsync<Address>("cep/15050305");

            Assert.Equal("Rua Josina Teixeira de Carvalho", result.Logradouro);
            Assert.Equal("Vila Anchieta", result.Bairro);
            Assert.Equal("São José do Rio Preto", result.Localidade);
            Assert.Equal("SP", result.Uf);
        }
    }
}