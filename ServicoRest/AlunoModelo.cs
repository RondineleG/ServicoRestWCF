using System;
using System.Runtime.Serialization;

namespace ServicoRest
{

    [DataContract]
    public class AlunoModelo
    {

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string nome { get; set; }

        [DataMember]
        public string sobrenome { get; set; }

        [DataMember]
        public string telefone { get; set; }

        [DataMember]
        public int? ra { get; set; }




    }
}