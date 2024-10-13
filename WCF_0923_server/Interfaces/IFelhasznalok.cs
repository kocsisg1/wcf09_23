using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WCF_0923_szerver.Models;
using WCF_0923_szerver.DTOs;

namespace WCF_0923_szerver.Interfaces
{

    [ServiceContract]
    public interface IFelhasznalok
    {
        //CRUD műveletek

        //R
        [OperationContract]
        List<Felhasznalok> FelhasznalokLista_CS();

        //C
        [OperationContract]
        string FelhasznaloAdd_CS(Felhasznalok felhasznalo);

        //U
        [OperationContract]
        string FelhasznaloUpdate_CS(Felhasznalok felhasznalo);

        //D
        [OperationContract]
        string FelhasznaloDelete_CS(int Id);

        [OperationContract]

        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/GetFelhasznaloLista")]
        List<Felhasznalok> FelhasznalokLista_WEB();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/PostFelhasznaloLista")]
        string FelhasznaloAdd_WEB(Felhasznalok felhasznalo);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/DeleteFelhasznaloLista")]
        string FelhasznaloDelete_WEB(int id);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/UpdateFelhasznaloLista")]
        string FelhasznaloUpdate_WEB(Felhasznalok felhasznalo);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/GetFelhasznaloListaDTO")]
        List<FelhasznalokNevEmail> FelhasznalokLista_NevEmailDTO_WEB();

    }

}
