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
    public partial class EditDeletePage : ContentPage
    {
        Idea idea;
        public EditDeletePage()
        {
            InitializeComponent();
            
        }

        public EditDeletePage(Idea selectedIdea)
        {
            InitializeComponent();
            idea = selectedIdea;
            IdeaName.Text = idea.Name;
            IdeaDescription.Text = idea.Description;
            FavoriteSwitch.IsToggled = idea.Favorite;
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                idea.Name = IdeaName.Text;
                idea.Description = IdeaDescription.Text;
                idea.Favorite = FavoriteSwitch.IsToggled;
                conn.CreateTable<Idea>();
                int rows = conn.Update(idea);
                if (rows > 0)
                    DisplayAlert("Úspěch", "Data úspěšně přidána", "OK");
                else
                    DisplayAlert("Chyba", "Data nebylo možné přidat", "OK");
            }
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Idea>();
                int rows = conn.Delete(idea);
                if (rows > 0)
                    DisplayAlert("Úspěch", "Data úspěšně přidána", "OK");
                else
                    DisplayAlert("Chyba", "Data nebylo možné přidat", "OK");
            }

        }
    }
}