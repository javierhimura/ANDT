using System.Collections.Generic;
using System.Data.SQLite;

namespace Andi.Utils.Database
{
    public class MoveList
    {
        public int id;
        public int move;
        public int level;
    }

    public class MVGList
    {
        public static List<PokemonMVListname> listmove = new List<PokemonMVListname>();
        public static List<string> movelist = new List<string>();


        /*
        public static string getFlavor(int idpokemon, int gamever, int idcountry = 1)
        {
            string query = "SELECT a.text FROM pokemon_flavor as a WHERE a.vergame = "+gamever+" AND Country = "+idcountry+" AND id = " + idpokemon;

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = Database.sql_con;
            cmd.CommandText = query;
            //Assign the data from urls to dr
            SQLiteDataReader dr = cmd.ExecuteReader();

            string b = "";
            while (dr.Read())
            {
                b = dr[0].ToString();
            }

            return b;
        }*/

        public static void Load(int gamever, int idcountry = 1)
        {
            listmove.Clear();
            movelist.Clear();

            string query = "";

            query = "SELECT a.id, a.name FROM app_moveseteditor as a WHERE a.country = " + idcountry +
                    " AND a.game_ver = " + gamever + " ORDER BY a.id";


            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = Database.sql_con;
            cmd.CommandText = query;
            //Assign the data from urls to dr
            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PokemonMVListname n = new PokemonMVListname();
                n.id = int.Parse(dr[0].ToString());
                n.name = dr[1].ToString();
                listmove.Add(n);
            }

            int gen = 5;

            if (gamever < 17)
            {
                gen = 4;
            }

            query = "SELECT a.id, a.name FROM moves_name As a WHERE a.country = "+idcountry+" AND a.generation <= " + gen;

            cmd = new SQLiteCommand();
            cmd.Connection = Database.sql_con;
            cmd.CommandText = query;
            //Assign the data from urls to dr
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                movelist.Add(dr[1].ToString());
            }
        }

        public static string GetMoveName(int id, int idcountry = 1)
        {
            string query = "SELECT a.name FROM moves_name as a WHERE a.country = '"+idcountry+"' AND a.id ='"+id+"'";
            List<string> a = new List<string>();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = Database.sql_con;
            cmd.CommandText = query;
            //Assign the data from urls to dr
            SQLiteDataReader dr = cmd.ExecuteReader();
            string b = "";
            while (dr.Read())
            {
                b = dr[0].ToString();
            }

            return b;
        }

        public static string[] GetMoveList(int gen, int idcountry=1)
        {
            string query = "SELECT a.name FROM moves_name As a WHERE a.country = " + idcountry + " AND a.generation <= " + gen;
            List<string> a = new List<string>();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = Database.sql_con;
            cmd.CommandText = query;
            //Assign the data from urls to dr
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                a.Add(dr[0].ToString());
            }

            return a.ToArray();
        }

        public static string[] GetPokemonNameMVList()
        {
            string[] data = new string[listmove.Count];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = listmove[i].name;
            }
            return data;
        }
    }

    public class PokemonMVListname
    {
        public int id;
        public string name;
    }
}
