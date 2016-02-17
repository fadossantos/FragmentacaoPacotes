using FragmentacaoPacotesWCF;
using System.Runtime.Serialization;

namespace FragmentacaoPacotesWcf
{
    [DataContract]
    public class InformacoesArquivo
    {
       
   

        [DataMember]
        string nomearquivo;
        [DataMember]
        int quantidadepacotes;
        [DataMember]
        int tamanhoarquivo;
        [DataMember]
        string id_arquivo;
        [DataMember]
        string versao;

        public InformacoesArquivo(ArquivoParaDownload arq, string index)
        {
            nomearquivo = arq.nomeArquivo;
            quantidadepacotes = arq.totalPacotes;
            tamanhoarquivo = arq.totalBytes;
            id_arquivo = index;
            versao = "1.0";

        }
    }
}