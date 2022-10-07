using Ada.Cep.Domain;
using Ada.Cep.Service.ApiClient;
using Ada.Cep.UnitTests.Base;
using FluentAssertions;
using System.Text.Json;

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
            var response = await sut.GetAsync("15050305");

            //Assert
            response.Should().BeEquivalentTo(expected);
        }
    }
}
