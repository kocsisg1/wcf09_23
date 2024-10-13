using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_0923_szerver.Models;
using WCF_0923_szerver.Controllers;

namespace WCF_0923_szerver.DTOs
{
    public class JogosultsagokNevEmail
    {
        public string Leiras { get; set; }
        public string Nev2 { get; set; }

        public List<JogosultsagokNevEmail> JogNevEmailDTO()
        {
            List<JogosultsagokNevEmail> lista = new List<JogosultsagokNevEmail>();
            List<Record> jogosultsagok = new JogosultsagokController().Select();
            foreach (Record r in jogosultsagok)
            {
                lista.Add(new JogosultsagokNevEmail()
                {
                    Nev2 = (r as Jogosultsagok).Nev2,
                    Leiras = (r as Jogosultsagok).Leiras
                });
            }
            return lista;
        }
    }
}