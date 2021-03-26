using EM.Log.WebAPI.Models;
using EM.Log.WebAPI.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace EM.Log.WebAPI.Controllers
{
    [ApiController]
    [Route("Pastas")]
    public class PastaController : ControllerBase
    {
        private readonly PastaService _service;
        private readonly IConfiguration _configuration;

        public PastaController(IConfiguration configuration, PastaService service)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IEnumerable<PastaModel>> ObtenhaPastas()
        {
            return await Task.Run(() => _service.ObtenhaPastas(_configuration.GetSection("PathLogs").Value));
        }
    }
}
