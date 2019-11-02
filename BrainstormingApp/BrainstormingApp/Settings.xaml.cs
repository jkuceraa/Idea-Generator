using BrainstormingApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrainstormingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void DeleteNonfavorite_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Idea>();
                var ideas = conn.Table<Idea>().ToList();
                foreach (Idea idea in ideas)
                {
                    if (!idea.Favorite)
                    {
                        conn.Delete(idea);
                    }
                }
            }
        }

        private void DeleteAll_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Idea>();
                var ideas = conn.Table<Idea>().ToList();
                foreach (Idea idea in ideas)
                {
                        conn.Delete(idea);                    
                }
            }
        }
    }
}