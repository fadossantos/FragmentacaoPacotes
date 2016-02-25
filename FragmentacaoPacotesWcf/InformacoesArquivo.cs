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

        public InformacoesArquivo(ArquivoParaDownload arq)
        {
            nomearquivo = arq.nomearquivo;
            quantidadepacotes = arq.totalPacotes;
            tamanhoarquivo = arq.totalBytes;
            id_arquivo = arq.id_arquivo;
            versao = arq.versao;

        }
    }
}