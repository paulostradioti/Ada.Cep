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

namespace Ada.Cep.UnitTests
{
    public class CepApiClientUnitTests : CepCacheServiceUnitTestsBase
    {
        [Fact]
        public async Task GetAsync_WhenCalled_ShouldReturnJson()
        {
            //Arrange
            var expected = JsonSerializer.Deserialize<Address>(ApiResponseJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var sut = new CepApiClient(MockHttpClient);

            // Act
            var response = await sut.GetAsync("15840000");

            //Assert
            response.Should().BeEquivalentTo(expected);
        }
    }
}
