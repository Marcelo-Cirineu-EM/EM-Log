using System.IO;
using System.Collections.Generic;
using EM.Log.WebAPI.Models;

namespace EM.Log.WebAPI.Services
{
    public class PastaService
    {
        public List<PastaModel> ObtenhaPastas(string pathBase)
        {
            List<PastaModel> diretorios = new();
            DirectoryInfo directoryInfo = new(pathBase);

            DirectoryInfo[] informacoesDiretorios = directoryInfo.GetDirectories("*", SearchOption.TopDirectoryOnly);

            foreach (DirectoryInfo diretorio in informacoesDiretorios)
            {
                diretorios.Add(new PastaModel() { Nome = diretorio.Name });
            }

            return diretorios;
        }
    }
}
