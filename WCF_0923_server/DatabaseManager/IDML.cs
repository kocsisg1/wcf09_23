using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_0923_szerver.Models;

namespace WCF_0923_szerver.DatabaseManagement
{
    internal interface IDML
    {
        string Insert(Record record);

        string Update(Record record);
        string Delete(int id);
    }
}
