using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NinfiaDSToolkit.Andi.Utils.DB
{
    public class Database
    {
        public static SQLiteConnection sql_con = new SQLiteConnection();

        public static void Connect()
        {
            sql_con.ConnectionString = "Data Source=" + Application.StartupPath + @"\dir\Database\ninfia_db0ae7" +
                                       ".db;Version=3;";
            sql_con.Open();

            Program.mForm.statusBarPanel1.Text = sql_con.MemoryUsed+" | "+sql_con.ServerVersion;
        }

        public static string[] GetCommonText(int groupid, int country = 1)
        {
            string query = "SELECT a.name FROM app_common as a Where a.country = "+country+" AND a.'group' = " + groupid;
            checkOpen();
            List<string> a = new List<string>();

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = sql_con;
            cmd.CommandText = query;

            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                a.Add(dr[0].ToString());
            }

            //sql_con.Close();
            return a.ToArray();
        }

        public static string[] GetPokemonName(int gen, int region = 1)
        {
            checkOpen();
            string query = "SELECT a.name FROM pokemon_name As A WHERE A.generation <= "+gen+" AND A.country = "+region;
            List<string> a = new List<string>();

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = sql_con;
            cmd.CommandText = query;

            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                a.Add(dr[0].ToString());
            }

            //sql_con.Close();
            return a.ToArray();
        }

        public static string[] GetPokemonAlternativeName(int id, int idcountry = 1, int idgamever = 23, int idgen = 7)
        {
            checkOpen();
            List<PKMAlternativeForm> Hgbw2loc = new List<PKMAlternativeForm>();

            string query =
                "SELECT a.id_alternative,a.name FROM pokemon_name_alternative as a WHERE a.country = " + idcountry + " And a.game_ver < " + idgamever + " And a.generation < " + idgen + " And a.id = " + id;

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = Database.sql_con;
            cmd.CommandText = query;
            //Assign the data from urls to dr
            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PKMAlternativeForm n = new PKMAlternativeForm();
                n.indexforme = int.Parse(dr[0].ToString());
                n.name = dr[1].ToString();
                Hgbw2loc.Add(n);
            }

            string[] data = new string[Hgbw2loc.Count];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Hgbw2loc[i].name;
            }
            return data;
        }

        public static string[] GetItemName(int gameid = 21, int country = 1)
        {
            checkOpen();
            List<string> itemdata = new List<string>();

            string query = "SELECT a.name FROM item_name as a Where a.country = " + country + " And a.game_id = " + gameid;

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = Database.sql_con;
            cmd.CommandText = query;
            //Assign the data from urls to dr
            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                itemdata.Add(dr[0].ToString());
            }

            return itemdata.ToArray();
        }

        public static string[] GetLocationName(int idcountry = 1, int idpkm = 9999)
        {
            checkOpen();
            var Hgbw2loc = new List<BW2HGLocName>();

            string query = "";
            if (idpkm == 9999)
            {
                query = "SELECT a.id, a.name FROM app_hiddengrotto As a WHERE a.country = " + idcountry;
            }
            else
            {
                query = "SELECT a.id, a.name FROM app_hiddengrotto As a WHERE a.country = " + idcountry + " And a.id = " + idpkm;
            }


            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = Database.sql_con;
            cmd.CommandText = query;
            //Assign the data from urls to dr
            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                BW2HGLocName n = new BW2HGLocName();
                n.index = int.Parse(dr[0].ToString());
                n.name = dr[1].ToString();
                Hgbw2loc.Add(n);
            }

            string[] data = new string[Hgbw2loc.Count];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Hgbw2loc[i].name;
            }
            return data;
        }

        static void checkOpen()
        {
            if (sql_con.State == ConnectionState.Closed || sql_con.State == ConnectionState.Broken)
            {
                sql_con.Open();
            }
        }

        static void forceClosing()
        {
            if (sql_con.State == ConnectionState.Open || sql_con.State == ConnectionState.Executing)
            {
                sql_con.Close();
            }
        }
    }

    public class PKMAlternativeForm
    {
        public int indexforme;
        public string name;
    }

    public class BW2HGLocName
    {
        public int index;
        public string name;
    }
}
