using System;

namespace EM.Log.WebAPI.Models
{
    public class LogModel
    {
        public DateTime DataHora { get; set; }
        public string IpServidor { get; set; }
        public string TipoRequisicao { get; set; }
        public string OperacaoAlvo { get; set; }
        public string Parametros { get; set; }
        public int Porta { get; set; }
        public string Usuario { get; set; }
        public string IpCliente { get; set; }
        public string VersaoProtocolo { get; set; }
        public string UsuarioAgente { get; set; }
        public string Referencia { get; set; }
        public int Status { get; set; }
        public int SubStatus { get; set; }
        public int StatusWin32 { get; set; }
        public long TamanhoResposta { get; set; }
        public long TamanhoRequisicao { get; set; }
        public long TempoRequisicao { get; set; }
    }
}
