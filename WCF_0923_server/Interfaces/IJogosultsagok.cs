using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Services;
using WCF_0923_szerver.DTOs;
using WCF_0923_szerver.Models;

namespace WCF_0923_szerver.Interfaces
{
    [ServiceContract]
    public interface IJogosultsagok
    {
        [OperationContract]
        List<Jogosultsagok> JogosultsagokLista_CS();

        
        [OperationContract]
        string JogosultsagokAdd_CS(Jogosultsagok jog);

        
        [OperationContract]
        string JogosultsagokUpdate_CS(Jogosultsagok jog);

        
        [OperationContract]
        string JogosultsagokDelete_CS(int Id);

        [OperationContract]

        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/GetJogosultsagokLista")]
        List<Jogosultsagok> JogosultsagokLista_WEB();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/PostJogosultsagokLista")]
        string JogosultsagAdd_WEB(Jogosultsagok jog);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/DeleteJogosultsagokLista")]
        string JogosultsagDelete_WEB(int id);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/UpdateJogosultsagokLista")]
        string JogosultsagUpdate_WEB(Jogosultsagok jog);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/JogosultsagokDTO")]
        List<JogosultsagokNevEmail> JogosultsagokLista_NevEmailDTO_WEB();
    }
}
