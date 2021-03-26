using System;
using System.IO;
using System.Linq;
using EM.Log.WebAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EM.Log.WebAPI.Services
{
    public class LogService
    {
        public async Task<List<LogModel>> CarregueLog(string pathArquivo)
        {
            List<LogModel> logs = new();

            if (File.Exists(pathArquivo))
            {
                string[] linhas = await File.ReadAllLinesAsync(pathArquivo);

                foreach (var linha in linhas)
                {
                    if (Regex.IsMatch(linha.Substring(0, 10), @"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$"))
                    {
                        string[] informacoesLinha = linha.Split(" ", StringSplitOptions.TrimEntries);

                        if (informacoesLinha.Length == 18)
                        {
                            logs.Add(new LogModel()
                            {
                                DataHora = DateTime.Parse($"{informacoesLinha[0]} {informacoesLinha[1]}"),
                                IpServidor = informacoesLinha[2],
                                TipoRequisicao = informacoesLinha[3],
                                OperacaoAlvo = informacoesLinha[4],
                                Parametros = informacoesLinha[5],
                                Porta = int.Parse(informacoesLinha[6]),
                                Usuario = informacoesLinha[7],
                                IpCliente = informacoesLinha[8],
                                VersaoProtocolo = informacoesLinha[9],
                                UsuarioAgente = informacoesLinha[10],
                                Referencia = informacoesLinha[11],
                                Status = int.Parse(informacoesLinha[12]),
                                SubStatus = int.Parse(informacoesLinha[13]),
                                StatusWin32 = int.Parse(informacoesLinha[14]),
                                TamanhoResposta = long.Parse(informacoesLinha[15]),
                                TamanhoRequisicao = long.Parse(informacoesLinha[16]),
                                TempoRequisicao = long.Parse(informacoesLinha[17])
                            });
                        }
                    }
                }
            }

            return logs;
        }
    }
}
