using FragmentacaoPacotesWCF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FragmentacaoPacotesWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SVC_DownloadArquivo : ISVC_DownloadArquivo, ISVC_DownloadArquivoREST
    {
        List<ArquivoParaDownload> listaArquivos;

        public SVC_DownloadArquivo()
        {
            listaArquivos = new List<ArquivoParaDownload>();
            string caminhoArquivo = @ConfigurationManager.AppSettings["caminhoArquivo"];
            ArquivoParaDownload arq = new ArquivoParaDownload(caminhoArquivo, 100000);
            listaArquivos.Add(arq);
        }
        public InformacoesArquivo RetornaInformacoesArquivo(string nomeArquivo)
        {
            ArquivoParaDownload arq = listaArquivos.First(s => s.nomeArquivo == nomeArquivo);
            InformacoesArquivo inf = new InformacoesArquivo(arq, listaArquivos.IndexOf(arq).ToString());
            return inf;
        }
       
        public string[] RetornaListaArquivos()
        {
            List<string> strings = new List<string>();
            foreach (ArquivoParaDownload arq in listaArquivos)
                {
                strings.Add(arq.nomeArquivo);
                }
            return strings.ToArray();
        }
    
        public Pacote RetornaPacote(int indexArquivo, int indexPacote)
        {
            Pacote pct = new Pacote(listaArquivos[indexArquivo].nomeArquivo, "1.0", indexArquivo, indexPacote, listaArquivos[indexArquivo].RetornaPacote(indexPacote));
            return pct;
        }



        public Pacote RetornaPacoteREST(string indexArquivo, string indexPacote)
        {
            return RetornaPacote(Convert.ToInt32(indexArquivo), Convert.ToInt32(indexPacote));
        }
        public InformacoesArquivo RetornaInformacoesArquivoREST(string nomeArquivo)
        {
            return RetornaInformacoesArquivo(nomeArquivo);
        }
        public string[] RetornaListaArquivosREST()
        {
            return RetornaListaArquivos();
        }


    }
}
