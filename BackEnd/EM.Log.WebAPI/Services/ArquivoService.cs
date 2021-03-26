using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using EM.Log.WebAPI.Utils;
using EM.Log.WebAPI.Models;

namespace EM.Log.WebAPI.Services
{
    public class ArquivoService
    {
        public List<ArquivoModel> ObtenhaArquivos(string pathArquivos)
        {
            List<ArquivoModel> arquivos = new();
            DirectoryInfo directoryInfo = new(pathArquivos);

            FileInfo[] files = directoryInfo.GetFiles("*.log", SearchOption.TopDirectoryOnly);

            foreach (FileInfo file in files)
            {
                if (!DateTime.TryParseExact(Formatacao.SomenteNumeros(file.Name), "yyMMdd", null, DateTimeStyles.None, out DateTime dataArquivo))
                {
                    dataArquivo = file.CreationTime;
                }

                arquivos.Add(new()
                {
                    Nome = file.Name,
                    Tamanho = file.Length,
                    Data = dataArquivo
                });
            }

            return arquivos;
        }
    }
}
