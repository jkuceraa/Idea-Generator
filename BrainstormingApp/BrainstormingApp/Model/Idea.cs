using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrainstormingApp.Model
{
    class Idea
    {
        [PrimaryKey, AutoIncrement]
        public int Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Favorite { get; set; }
    }
}
