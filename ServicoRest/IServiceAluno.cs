using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace ServicoRest
{    
    [ServiceContract(Namespace = "http://localhost:61263/ServiceAluno.svc")]
    public interface IServiceAluno
    {        
        [OperationContract]
        [WebInvoke(Method = "POST",
                 BodyStyle = WebMessageBodyStyle.Bare,
                 ResponseFormat = WebMessageFormat.Json,
                 RequestFormat = WebMessageFormat.Json,
               
                 UriTemplate = "Inserir")]
        String Inserir(AlunoModelo alunoEntity);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                  BodyStyle = WebMessageBodyStyle.WrappedResponse,
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json,
                      
                     UriTemplate = "Atualizar")]
        String Atualizar(AlunoModelo alunoEntity);

       
        [OperationContract]
        [WebInvoke(Method = "GET",
              BodyStyle = WebMessageBodyStyle.Bare,
                   ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                       
                      UriTemplate = "RecuperarPorId/{id}")]
        AlunoModelo RecuperarPorId(String id);

        
        [OperationContract]
        string InsertViaSql(AlunoModelo alunoModelo);
        [OperationContract]
        DataSet SelectViaSql();

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,              
              UriTemplate = "Recuperar")]
        IList<AlunoModelo> Recuperar();


        [OperationContract]
        [WebInvoke(Method = "DELETE",
              BodyStyle = WebMessageBodyStyle.Bare,
                   ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                   
                      UriTemplate = "Deletar/{id}")]
        String Deletar(String id);
    }
}
