using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_0923_szerver.DatabaseManagement;
using WCF_0923_szerver.Models;

namespace WCF_0923_szerver.Controllers
{
    public class JogosultsagokController : BaseDatabaseManager, ISQL
    {
        public string Delete(int id)
        {
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "DELETE FROM Jogosultsagok WHERE Id=@Id;",
                Connection = BaseDatabaseManager.Connection
            };
            cmd.Parameters.Add(new MySqlParameter("@Id", id));

            try
            {
                cmd.Connection.Open();
                int toroltRekordok = cmd.ExecuteNonQuery();
                if (toroltRekordok == 0)
                {
                    return "Nem találtam ilyen azonosítót!" + id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba!" + ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            cmd.Parameters.Clear();
            return "Sikeres törlés! " + id;
        }

        public string Insert(Record record)
        {
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "INSERT INTO Jogosultsagok(Szint, Nev, Leiras)" +
                " VALUES(@Szint, @Nev, @Leiras)",
                Connection = BaseDatabaseManager.Connection
            };
            Jogosultsagok ujJogosultsag = record as Jogosultsagok;
            cmd.Parameters.Add(new MySqlParameter("@Szint", ujJogosultsag.Szint));
            cmd.Parameters.Add(new MySqlParameter("@Nev", ujJogosultsag.Nev2));
            cmd.Parameters.Add(new MySqlParameter("@Leiras", ujJogosultsag.Leiras));
            

            try
            {
                cmd.Connection.Open();
                int db = cmd.ExecuteNonQuery();
                if (db == 0)
                {
                    return "Nem sikerült rögzítenem a jogosultságot! ";
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Hiba! " + e.Message);
            }
            finally
            {
                BaseDatabaseManager.Connection.Close();
            }
            return "Sikeres hozzáadás!";
        }

        public List<Record> Select()
        {
            List<Record> list = new List<Record>();
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "SELECT * FROM Jogosultsagok"
            };

            try
            {
                MySqlConnection conn = BaseDatabaseManager.Connection;
                conn.Open();
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Jogosultsagok ujJog = new Jogosultsagok()
                    {
                        Id = reader.GetInt32("id"),
                        Szint=reader.GetInt32("Szint"),
                        Nev2 = reader.GetString("Nev"),
                        Leiras=reader.GetString("Leiras")
                        
                    };
                    list.Add(ujJog);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hiba! " + e.Message);
            }
            finally
            {
                BaseDatabaseManager.Connection.Close();
            }

            return list;
        }

        public string Update(Record record)
        {
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "UPDATE Jogosultsagok(Szint, Nev, Leiras)" +
                " SET(@Szint, @Nev, @Leiras) WHERE Id = 2",
                Connection = BaseDatabaseManager.Connection
            };
            Jogosultsagok ujJogosultsag = record as Jogosultsagok;
            cmd.Parameters.Add(new MySqlParameter("@Szint", ujJogosultsag.Szint));
            cmd.Parameters.Add(new MySqlParameter("@Nev", ujJogosultsag.Nev2));
            cmd.Parameters.Add(new MySqlParameter("@Leiras", ujJogosultsag.Leiras));


            try
            {
                cmd.Connection.Open();
                int db = cmd.ExecuteNonQuery();
                if (db == 0)
                {
                    return "Nem sikerült frissítenem a jogosultságot! ";
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Hiba! " + e.Message);
            }
            finally
            {
                BaseDatabaseManager.Connection.Close();
            }
            return "Sikeres frissítés!";
        }
    }
}