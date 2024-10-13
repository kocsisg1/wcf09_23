using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_0923_szerver.Controllers;
using WCF_0923_szerver.DTOs;
using WCF_0923_szerver.Interfaces;
using WCF_0923_szerver.Models;

namespace WCF_0923_szerver
{

    public class Service1 : IService1
    {
        public string FelhasznaloAdd_CS(Felhasznalok felhasznalo)
        {
            FelhasznalokController controller = new FelhasznalokController();
            return controller.Insert(felhasznalo);
        }

        public string FelhasznaloDelete_CS(int Id)
        {
            FelhasznalokController controller = new FelhasznalokController();
            string valasz = controller.Delete(Id);
            return valasz;
        }

        public List<Felhasznalok> FelhasznalokLista_CS()
        {
            FelhasznalokController controller = new FelhasznalokController();
            List<Record> rekordok = controller.Select();
            List<Felhasznalok> ujlista=new List<Felhasznalok>();
            foreach (Record r in rekordok)
            {
                ujlista.Add(r as Felhasznalok);
            }
            return ujlista;
            /*List<Felhasznalok> felhlista=new List<Felhasznalok>();
            Felhasznalok f1= new Felhasznalok()
            {
                Id=1,
                LoginNev="pimpike",
                HASH="sadfagfb",
                SALT="KJDBUBAI",
                Nev="Bojtos Pimpike",
                Jog= 1,
                Aktiv=true,
                Email="pimpike@alza.sk",
                Profilkep="pimpike.jpg"
            };
            felhlista.Add(f1);
            return felhlista;*/
        }

        public string FelhasznaloUpdate_CS(Felhasznalok felhasznalo)
        {
            FelhasznalokController controller = new FelhasznalokController();
            return controller.Update(felhasznalo);
        }

        public List<Jogosultsagok> JogosultsagokLista_CS()
        {
            JogosultsagokController controller =new JogosultsagokController();
            List<Record> rekordok = controller.Select();
            List<Jogosultsagok> ujlista = new List<Jogosultsagok>();
            foreach (Record r in rekordok)
            {
                ujlista.Add(r as Jogosultsagok);
            }
            return ujlista;

        }
        public string JogosultsagokAdd_CS(Jogosultsagok jog)
        {
            JogosultsagokController controller = new JogosultsagokController();
            return controller.Insert(jog);
        }
        public string JogosultsagokDelete_CS(int Id)
        {
            JogosultsagokController controller = new JogosultsagokController();
            string valasz = controller.Delete(Id);
            return valasz;
        }
        public string JogosultsagokUpdate_CS(Jogosultsagok jog)
        {
            JogosultsagokController controller = new JogosultsagokController();
            return controller.Update(jog);
        }

        public List<Felhasznalok> FelhasznalokLista_WEB()
        {
            return FelhasznalokLista_CS();
        }

        public string FelhasznaloAdd_WEB(Felhasznalok felhasznalo)
        {
            return FelhasznaloAdd_CS(felhasznalo);
        }

        public string FelhasznaloDelete_WEB(int id)
        {
            return FelhasznaloDelete_CS(id);
        }

        public string FelhasznaloUpdate_WEB(Felhasznalok felhasznalo)
        {
            return FelhasznaloUpdate_CS(felhasznalo);
        }

        public List<FelhasznalokNevEmail> FelhasznalokLista_NevEmailDTO_WEB()
        {
            return new FelhasznalokNevEmail().NevEmailDTO();
        }

        public List<JogosultsagokNevEmail> JogosultsagokLista_NevEmailDTO_WEB()
        {
            return new JogosultsagokNevEmail().JogNevEmailDTO();
        }

        public List<Jogosultsagok> JogosultsagokLista_WEB()
        {
            return JogosultsagokLista_CS();
        }

        public string JogosultsagAdd_WEB(Jogosultsagok jog)
        {
            return JogosultsagokAdd_CS(jog);
        }

        public string JogosultsagDelete_WEB(int id)
        {
            return JogosultsagokDelete_CS(id);
        }

        public string JogosultsagUpdate_WEB(Jogosultsagok jog)
        {
            return JogosultsagokUpdate_CS(jog);
        }
    }
}
