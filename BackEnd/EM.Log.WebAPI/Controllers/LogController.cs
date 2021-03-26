using System.IO;
using System.Threading.Tasks;
using EM.Log.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace EM.Log.WebAPI.Controllers
{
    [ApiController]
    [Route("Logs")]
    public class LogController : ControllerBase
    {
        private readonly LogService _service;
        private readonly IConfiguration _configuration;

        public LogController(IConfiguration configuration, LogService service)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet("{pasta}/{arquivo}")]
        public async Task<IEnumerable<dynamic>> ObtenhaArquivos([FromRoute] string pasta, [FromRoute] string arquivo)
        {
            return await Task.Run(() => _service.CarregueLog(Path.Combine(_configuration.GetSection("PathLogs").Value, pasta, arquivo)));
        }
    }
}
