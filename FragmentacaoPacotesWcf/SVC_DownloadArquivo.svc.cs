using FragmentacaoPacotesWCF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FragmentacaoPacotesWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SVC_DownloadArquivo : ISVC_DownloadArquivo, ISVC_DownloadArquivoREST
    {
        List<ArquivoParaDownload> listaArquivos;

        public SVC_DownloadArquivo()
        {
            listaArquivos = new List<ArquivoParaDownload>();
            DirectoryInfo dir = new DirectoryInfo(@ConfigurationManager.AppSettings["caminhoDiretorio"]);
            FileInfo[] arquivos = dir.GetFiles();
            foreach(FileInfo file in arquivos)
            {
                String[] nomePartido = file.Name.Split('_');
                string id_arquivo = nomePartido[0];
                string versao = nomePartido[1];
                string nomeArquivo = nomePartido[2];
                ArquivoParaDownload arq = new ArquivoParaDownload(file.FullName, 100000, id_arquivo, nomeArquivo, versao);
                listaArquivos.Add(arq);

            }
        }
        public InformacoesArquivo RetornaInformacoesArquivo(string nomeArquivo)
        {
            ArquivoParaDownload arq = listaArquivos.First(s => s.nomearquivo == nomeArquivo);
            InformacoesArquivo inf = new InformacoesArquivo(arq);
            return inf;
        }
       
        public string[] RetornaListaArquivos()
        {
            List<string> strings = new List<string>();
            foreach (ArquivoParaDownload arq in listaArquivos)
                {
                strings.Add(arq.nomearquivo);
                }
            return strings.ToArray();
        }
    
        public Pacote RetornaPacote(string _id_arquivo, string _versao, int indexPacote)
        {
            ArquivoParaDownload arq = listaArquivos.First(s => s.id_arquivo == _id_arquivo && s.versao == _versao);
            Pacote pct = new Pacote(arq.nomearquivo, arq.versao, arq.id_arquivo, indexPacote, arq.RetornaPacote(indexPacote));
            return pct;
        }



        public Pacote RetornaPacoteREST(string _id_arquivo, string _versao, string indexPacote)
        {
            return RetornaPacote(_id_arquivo, _versao, Convert.ToInt32(indexPacote));
        }
        public InformacoesArquivo RetornaInformacoesArquivoREST(string nomeArquivo)
        {
            return RetornaInformacoesArquivo(nomeArquivo);
        }
        public string[] RetornaListaArquivosREST()
        {
            return RetornaListaArquivos();
        }

        public void SubirArquivo(string id_Arquivo, string versao, string nomeArquivo, byte[] dados)
        {
            throw new NotImplementedException();
        }
    }
}
