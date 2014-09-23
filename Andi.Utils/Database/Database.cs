using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Andi.Utils.Database
{
    public class Database
    {
        #region inner class
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

        public class InsertReader
        {
            static SQLiteConnection sql_con = new SQLiteConnection();

            public static void InsertLogs(params object[] data)
            {
                sql_con.ConnectionString = "Data Source=" + Application.StartupPath + @"\dir\Database\logs" +
                                       ".db;Version=3;";
                sql_con.Open();

                SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO logs (time, error_type,error_level,error_message) VALUES (?,?,?,?)", sql_con);
                insertSQL.Parameters.Add("@time", DbType.String).Value = DateTime.Now.ToLocalTime();
                insertSQL.Parameters.Add("@error_type", DbType.String).Value = data[0].ToString();
                insertSQL.Parameters.Add("@error_level", DbType.String).Value = data[1].ToString();
                insertSQL.Parameters.Add("@error_message", DbType.String).Value = data[2].ToString();

                try
                {
                    insertSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    sql_con.Close();
                    throw new Exception(ex.Message);
                }

                //Program.mForm.statusBarPanel2.Text = data[2].ToString().Substring(0,20) + " ...";
                sql_con.Close();
            }
        }

        public class GetDataReader
        {
            public static string[] StringArrayConverter(SQLiteDataReader dr)
            {
                List<string> a = new List<string>();

                while (dr.Read())
                {
                    a.Add(dr[0].ToString());
                }

                return a.ToArray();
            }
        }

        public class GetPrepareQuery
        {
            public static string GetCommonText(int groupid, int country)
            {
                return "SELECT a.name FROM app_common as a Where a.country = " + country + " AND a.'group' = " + groupid;
            }

            public static string GetPokemonName(int gen, int region = 1)
            {
                return "SELECT a.name FROM pokemon_name As A WHERE A.generation <= " + gen + " AND A.country = " + region;
            }

            public static string GetItemName(int gameid = 21, int country = 1)
            {
                return "SELECT a.name FROM item_name as a Where a.country = " + country + " And a.game_id = " + gameid;
            }
        }
        #endregion

        public static SQLiteConnection sql_con = new SQLiteConnection();

        public static void Connect()
        {
            sql_con.ConnectionString = "Data Source=" + Application.StartupPath + @"\dir\Database\ninfia_ff7b20" +
                                       ".db;Version=3;";
            sql_con.Open();

            //Program.mForm.statusBarPanel1.Text = sql_con.MemoryUsed+" | "+sql_con.ServerVersion;
        }

        public static string[] GetDeafultTemplate(SQLiteConnection a, string query)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = a;
            cmd.CommandText = query;
            return GetDataReader.StringArrayConverter(cmd.ExecuteReader());
        }

        public static string[] GetCommonText(int groupid, int country = 1)
        {
            checkOpen();
            return GetDeafultTemplate(sql_con, GetPrepareQuery.GetCommonText(groupid, country));
        }

        public static string[] GetPokemonName(int gen, int region = 1)
        {
            checkOpen();
            return GetDeafultTemplate(sql_con, GetPrepareQuery.GetPokemonName(gen, region));
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
            return GetDeafultTemplate(sql_con, GetPrepareQuery.GetItemName(gameid, country));
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

    
}
