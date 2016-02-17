using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragmentacaoPacotesWCF
{
    public class JuntarArquivo
    {
        public static bool RemontaArquivo(string caminhoArquivoNovo, string diretorioPacotes)
        {
            try
            {
                string[] arquivos = Directory.GetFiles(diretorioPacotes, "*.pct");
                FileStream streamLeitura;
                List<byte[]> listaArraysBytes = new List<byte[]>();
                foreach (string _file in arquivos)
                {
                    streamLeitura = File.OpenRead(_file);
                    byte[] temp = new byte[streamLeitura.Length];
                    streamLeitura.Read(temp, 0, temp.Length);
                    listaArraysBytes.Add(temp);
                }

                byte[] arquivosLidos = Combine(listaArraysBytes);

                using (Stream file = File.OpenWrite(caminhoArquivoNovo))
                {
                    file.Write(arquivosLidos, 0, arquivosLidos.Length);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
        private static byte[] Combine(List<byte[]> arrays)
        {
            byte[] rv = new byte[arrays.Sum(a => a.Length)];
            int offset = 0;
            foreach (byte[] array in arrays)
            {
                System.Buffer.BlockCopy(array, 0, rv, offset, array.Length);
                offset += array.Length;
            }
            return rv;
        }

    }
}
