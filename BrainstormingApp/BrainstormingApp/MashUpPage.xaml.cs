using BrainstormingApp.Helpers;
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
    public partial class MashUpPage : ContentPage
    {
        public MashUpPage()
        {
            InitializeComponent();
            IdeasShuffleShow();

        }

        private void IdeasShuffleShow()
        {
            List<Idea> ideas = new List<Idea>();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Idea>();
                ideas = conn.Table<Idea>().ToList();
            }
            if(ideas.Count < 2)
            {
                NotEnoughErrorLabel.IsVisible = true;
            }
            else
            {
                ideas.Shuffle();
                Idea1.Text = ideas[0].Name;
                Idea2.Text = ideas[1].Name;
            }
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            Idea idea = new Idea
            {
                Name = NewIdeaName.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation)){
                conn.CreateTable<Idea>();
                conn.Insert(idea);
            }
            NewIdeaName.Text = null;
            IdeasShuffleShow();
        }
    }
}