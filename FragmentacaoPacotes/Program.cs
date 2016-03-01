using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FragmentacaoPacotesWCF
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<ArquivoParaDownload>  listaArquivos = new List<ArquivoParaDownload>();
            DirectoryInfo dir = new DirectoryInfo(@ConfigurationManager.AppSettings["caminhoDiretorio"]);
            FileInfo[] arquivos = dir.GetFiles();
            foreach (FileInfo file in arquivos)
            {
                String[] nomePartido = file.Name.Split('_');
                string id_arquivo = nomePartido[0];
                string versao = nomePartido[1];
                string nomeArquivo = nomePartido[2];
                ArquivoParaDownload arq = new ArquivoParaDownload(file.FullName, 100000, id_arquivo, nomeArquivo, versao);
                listaArquivos.Add(arq);

            }
            string caminhoArquivo = ConfigurationManager.AppSettings["caminhoArquivo"]; 
            string caminhoDiretorio = ConfigurationManager.AppSettings["caminhoDiretorio"];
            string caminhoNovoArquivo = ConfigurationManager.AppSettings["caminhoNovoArquivo"]; ;
            foreach (ArquivoParaDownload arq in listaArquivos)
            {
                int contador = 0;
                foreach (string bt in arq.listaString64)
                {
                    byte[] btbyte = Convert.FromBase64String(bt);
                    using (Stream file = File.OpenWrite(caminhoDiretorio + contador.ToString("000000") + ".pct"))
                    {
                        file.Write(btbyte, 0, btbyte.Length);
                    }
                    contador = contador + 1;
                }
                JuntarArquivo.RemontaArquivo(caminhoNovoArquivo, caminhoDiretorio);
                string hash1 = GetMD5HashFromFile(caminhoArquivo);
                string hash2 = GetMD5HashFromFile(caminhoNovoArquivo);
                Console.WriteLine("{0} --> {1}", hash1, hash2);
                Console.ReadKey();
            }
        }

        public static string GetMD5HashFromFile(string fileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }
    }
}
