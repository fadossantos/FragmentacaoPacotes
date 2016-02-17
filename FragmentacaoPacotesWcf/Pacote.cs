using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FragmentacaoPacotesWcf
{
    [DataContract]
    public class Pacote
    {
        [DataMember]
        string nomearquivo;
        [DataMember]
        string versao;
        [DataMember]
        string id_arquivo;
        [DataMember]
        int id_pct;
        [DataMember]
        string pctbase64;

        public Pacote(string _nomeArquivo, string _versao, int _id_Arquivo, int _id_Pct, string _pctBase64)
        {
            nomearquivo = _nomeArquivo;
            versao = _versao;
            id_arquivo = _id_Arquivo.ToString();
            id_pct = _id_Pct;
            pctbase64 = _pctBase64;
        }
    }
}
