using Ada.Cep.Domain;
using Ada.Cep.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ada.Cep.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : ControllerBase
    {
        private readonly ICepService _cepService;

        public CepController(ICepService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet("{cep}")]
        public async Task<Address> Get(string cep)
        {
            return await _cepService.GetAddressByCepAsync(cep);
        }
    }
}