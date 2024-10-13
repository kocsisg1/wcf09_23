using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_0923_szerver.DatabaseManagement;
using WCF_0923_szerver.Models;

namespace WCF_0923_szerver.Controllers
{
    public class FelhasznalokController : BaseDatabaseManager, ISQL
    {
        public string Delete(int id)
        {
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType=System.Data.CommandType.Text,
                CommandText="DELETE FROM Felhasznalok WHERE Id=@Id;",
                Connection=BaseDatabaseManager.Connection
            };
            cmd.Parameters.Add(new MySqlParameter("@Id",id));

            try
            {
                cmd.Connection.Open();
                int toroltRekordok=cmd.ExecuteNonQuery();
                if(toroltRekordok==0)
                {
                    return "Nem találtam ilyen azonosítót!" + id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba!"+ex.Message);
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
            int darab = 0;
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "INSERT INTO Felhasznalok(LoginNev, HASH, SALT, Nev, Jog, Aktiv, Email, Profilkep)" +
                " VALUES(@LoginNev, @HASH, @SALT, @Nev, @Jog, @Aktiv, @Email, @Profilkep)",
                Connection = BaseDatabaseManager.Connection
            };
            Felhasznalok ujFelhasznalo = record as Felhasznalok;
            cmd.Parameters.Add(new MySqlParameter("@LoginNev", ujFelhasznalo.LoginNev));
            cmd.Parameters.Add(new MySqlParameter("@HASH", ujFelhasznalo.HASH));
            cmd.Parameters.Add(new MySqlParameter("@SALT", ujFelhasznalo.SALT));
            cmd.Parameters.Add(new MySqlParameter("@Nev", ujFelhasznalo.Nev));
            cmd.Parameters.Add(new MySqlParameter("@Jog", ujFelhasznalo.Jog));
            cmd.Parameters.Add(new MySqlParameter("@Aktiv", ujFelhasznalo.Aktiv));
            cmd.Parameters.Add(new MySqlParameter("@Email", ujFelhasznalo.Email));
            cmd.Parameters.Add(new MySqlParameter("@Profilkep", ujFelhasznalo.Profilkep));

            try
            {
                cmd.Connection.Open();
                int db=cmd.ExecuteNonQuery();
                darab = db;
                if(db== 0)
                {
                    return "Nem sikerült rögzítenem a felhasználót! " + ujFelhasznalo.Nev;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Hiba! "+e.Message);
            }
            finally
            {
                BaseDatabaseManager.Connection.Close();
            }
            return "Sikeres hozzáadás!"+darab;

        }

        public List<Record> Select()
        {
            List<Record> list = new List<Record>();
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType=System.Data.CommandType.Text,
                CommandText="SELECT * FROM Felhasznalok"
            };

            try
            {
                MySqlConnection conn = BaseDatabaseManager.Connection;
                conn.Open();
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Felhasznalok ujFelh= new Felhasznalok()
                    {
                        Id = reader.GetInt32("id"),
                        LoginNev= reader.GetString("LoginNev"),
                        HASH=reader.GetString("HASH"),
                        SALT=reader.GetString("SALT"),
                        Nev=reader.GetString("Nev"),
                        Jog=reader.GetInt32("Jog"),
                        Aktiv=reader.GetBoolean("Aktiv"),
                        Email=reader.GetString("Email"),
                        Profilkep=reader.GetString("Profilkep")
                    };
                    list.Add(ujFelh);
                }
            }
            catch(Exception e)
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
                CommandText = "UPDATE Felhasznalok(LoginNev, HASH, SALT, Nev, Jog, Aktiv, Email, Profilkep)" +
                " SET(@LoginNev, @HASH, @SALT, @Nev, @Jog, @Aktiv, @Email, @Profilkep)",
                Connection = BaseDatabaseManager.Connection
            };
            Felhasznalok updateFelhasznalo = record as Felhasznalok;
            cmd.Parameters.Add(new MySqlParameter("@LoginNev", updateFelhasznalo.LoginNev));
            cmd.Parameters.Add(new MySqlParameter("@HASH", updateFelhasznalo.HASH));
            cmd.Parameters.Add(new MySqlParameter("@SALT", updateFelhasznalo.SALT));
            cmd.Parameters.Add(new MySqlParameter("@Nev", updateFelhasznalo.Nev));
            cmd.Parameters.Add(new MySqlParameter("@Jog", updateFelhasznalo.Jog));
            cmd.Parameters.Add(new MySqlParameter("@Aktiv", updateFelhasznalo.Aktiv));
            cmd.Parameters.Add(new MySqlParameter("@Email", updateFelhasznalo.Email));
            cmd.Parameters.Add(new MySqlParameter("@Profilkep", updateFelhasznalo.Profilkep));

            try
            {
                cmd.Connection.Open();
                int db = cmd.ExecuteNonQuery();
                if (db == 0)
                {
                    return "Nem sikerült frissíteni a felhasználót! " + updateFelhasznalo.Nev;
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