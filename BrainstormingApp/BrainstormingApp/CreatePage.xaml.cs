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
    public partial class CreatePage : ContentPage
    {
        public CreatePage()
        {
            InitializeComponent();

        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            Idea newIdea = new Idea
            {
                Name = IdeaName.Text,
                Description = IdeaDescription.Text,
                Favorite = FavoriteSwitch.IsToggled
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                conn.CreateTable<Idea>();
                conn.Insert(newIdea);
            }
        }
    }
}