using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_0923_szerver.Interfaces;

namespace WCF_0923_szerver
{
    
    [ServiceContract]
    public interface IService1 : IFelhasznalok, IJogosultsagok
    {

  
    }

    
}
