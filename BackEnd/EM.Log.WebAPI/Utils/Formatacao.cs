using System.Linq;

namespace EM.Log.WebAPI.Utils
{
    public static class Formatacao
    {
        public static string SomenteNumeros(string str) =>
            string.Concat((str ?? string.Empty).ToArray().Where(m => char.IsDigit(m)));
    }
}
