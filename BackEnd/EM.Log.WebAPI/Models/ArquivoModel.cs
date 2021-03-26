using System;

namespace EM.Log.WebAPI.Models
{
    public class ArquivoModel
    {
        public string Nome { get; set; }
        public long Tamanho { get; set; }
        public DateTime? Data { get; set; }
    }
}
