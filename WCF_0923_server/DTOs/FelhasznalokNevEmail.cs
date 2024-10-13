using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_0923_szerver.DatabaseManagement;
using WCF_0923_szerver.Models;
using WCF_0923_szerver.Controllers;

namespace WCF_0923_szerver.DTOs
{
    public class FelhasznalokNevEmail
    {
        public string Email { get; set; }
        public string Nev { get; set; }

        public List<FelhasznalokNevEmail> NevEmailDTO()
        {
            List<FelhasznalokNevEmail> lista = new List<FelhasznalokNevEmail>();
            List<Record> felhasznalok = new FelhasznalokController().Select();
            foreach(Record r in felhasznalok)
            {
                lista.Add(new FelhasznalokNevEmail()
                {
                    Nev=(r as Felhasznalok).Nev,
                    Email=(r as Felhasznalok).Email
                });
            }
            return lista;
        }
    }
}