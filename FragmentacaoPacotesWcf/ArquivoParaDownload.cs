using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragmentacaoPacotesWCF
{
    public class ArquivoParaDownload
    {
        public List<string> listaString64;
        public int totalBytes;
        public int totalPacotes;
        public string nomeArquivo;

        public ArquivoParaDownload(string caminhoArquivo, int tamanhoPacotes)
        {
            listaString64 = new List<string>();
            FileStream streamLeitura = File.OpenRead(caminhoArquivo);
            byte[] arquivoBytes = new byte[streamLeitura.Length];
            streamLeitura.Read(arquivoBytes, 0, arquivoBytes.Length);
            totalBytes = arquivoBytes.Length;
            totalPacotes = arquivoBytes.Length / tamanhoPacotes;
            nomeArquivo = Path.GetFileName(caminhoArquivo);
            streamLeitura.Close();

            //Begins the process of writing the byte array back to a file
            for (int i = 0; i < totalBytes; i = i + tamanhoPacotes)
            {
                if (totalBytes < i + tamanhoPacotes)
                {
                    tamanhoPacotes = totalBytes - i;
                }
                byte[] arrayBytesTemp = new byte[tamanhoPacotes];
                Array.Copy(arquivoBytes, i, arrayBytesTemp, 0, tamanhoPacotes);
                listaString64.Add(Convert.ToBase64String(arrayBytesTemp));
            }
        }

        public string RetornaPacote(int index)
        {
            return listaString64[index];
        }
        


    }
}
