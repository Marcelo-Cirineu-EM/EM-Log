using System.IO;
using EM.Log.WebAPI.Models;
using System.Threading.Tasks;
using EM.Log.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace EM.Log.WebAPI.Controllers
{
    [ApiController]
    [Route("Arquivos")]
    public class ArquivoController :  ControllerBase
    {
        private readonly ArquivoService _service;
        private readonly IConfiguration _configuration;

        public ArquivoController(IConfiguration configuration, ArquivoService service)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet("{pasta}")]
        public async Task<IEnumerable<ArquivoModel>> ObtenhaArquivos([FromRoute]string pasta)
        {
            return await Task.Run(() => _service.ObtenhaArquivos(Path.Combine(_configuration.GetSection("PathLogs").Value, pasta)));
        }
    }
}
