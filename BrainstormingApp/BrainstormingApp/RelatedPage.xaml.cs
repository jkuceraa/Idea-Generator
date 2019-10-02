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
    public partial class RelatedPage : ContentPage
    {
        public RelatedPage()
        {
            InitializeComponent();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            Idea idea = new Idea
            {
                Name = IdeaAdder.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Idea>();
                conn.Insert(idea);
            }
            IdeaAdder.Text = null;
        }

        private void ConfirmButton_Clicked(object sender, EventArgs e)
        {
            WordsList.Text = WordsAdder.Text;
            WordsAdder.IsVisible = false;
            ConfirmButton.IsVisible = false;
            WordsList.IsVisible = true;
            IdeaAdder.IsVisible = true;
            AddButton.IsVisible = true;
        }
    }
}