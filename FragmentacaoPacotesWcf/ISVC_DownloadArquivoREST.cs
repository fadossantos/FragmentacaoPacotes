using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace FragmentacaoPacotesWcf
{
    [ServiceContract]
    public interface ISVC_DownloadArquivoREST
    {
        
       [OperationContract]
       [WebGet(UriTemplate = "/RetornaPacote/{indexArquivo}/{indexPacote}", RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json)]
        Pacote RetornaPacoteREST(string indexArquivo, string indexPacote);

        [OperationContract]
        [WebGet(UriTemplate = "/RetornaListaArquivos", ResponseFormat = WebMessageFormat.Json)]
        string[] RetornaListaArquivosREST();

        [OperationContract]
        [WebGet(UriTemplate = "/RetornaInformacoesArquivo/{nomeArquivo}", RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json)]
        InformacoesArquivo RetornaInformacoesArquivoREST(string nomeArquivo);




    }
    }

