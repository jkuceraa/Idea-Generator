using BrainstormingApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BrainstormingApp.Model
{
    public class Idea
    {
        [PrimaryKey, AutoIncrement]
        public int Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Favorite { get; set; }

        public static List<Idea> GetIdeas()
        {
            using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Idea>();
                return conn.Table<Idea>().ToList();
            }
        }
    }
}
