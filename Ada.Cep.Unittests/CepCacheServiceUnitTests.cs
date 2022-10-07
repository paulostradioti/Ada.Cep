using Ada.Cep.Domain;
using Ada.Cep.UnitTests.Base;

namespace Ada.Cep.UnitTests
{
    public class CepCacheServiceUnitTests : CepCacheServiceUnitTestsBase
    {
        /*
         * 1 encontra o cep
         * 2 nao encontra o cep
         * cep passado for invalido
         */

        [Fact]
        public async Task TryGetAddressByCep_WhenHit_ShouldReturnAddress()
        {
            var sut = new FakeCacheService();

            var address = await sut.TryGetAddressByCep(DefaultCep);

            Assert.Equal(DefaultAddress, address);
        }

        [Fact]
        public async Task AddAddressAsync_WhenMiss_ShouldCacheAddress()
        {
            var sut = new FakeCacheService();
            var expected = sut.Count + 1;
            var address = new Address
            {
                Cep = "15840000",
                Logradouro = "Avenida Jorge Tibiriçá",
                Complemento = "Casa 1",
                Bairro = "Centro",
                Localidade = "Itajobi",
                Uf = "SP"
            };
            
            await sut.AddAddressAsync(address);
            Assert.Equal(expected, sut.Count);
        }
    }
}