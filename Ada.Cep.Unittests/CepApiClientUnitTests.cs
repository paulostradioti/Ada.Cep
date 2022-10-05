using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Ada.Cep.Domain;
using Ada.Cep.Service;
using Ada.Cep.Service.ApiClient;
using FluentAssertions;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Ada.Cep.Unittests
{
    public class CepApiClientUnitTests : CepCacheServiceUnitTestsBase
    {
        [Fact]
        public async Task GetAsync_WhenCalled_ShouldReturnJson()
        {
            //arrange
            var httpMessageHandlerMock = new MockHttpMessageHandler();
            httpMessageHandlerMock.When("https://opencep.com/v1/15840000").Respond("application/json", ApiResponseJson);
            var expected = JsonSerializer.Deserialize<Address>(ApiResponseJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var sut = new CepApiClient(httpMessageHandlerMock);

            // Act
            var response = await sut.GetAsync("15840000");

            response.Should().BeEquivalentTo(expected);
        }
    }
}
