using BrainstormingApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BrainstormingApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Idea>();
                var ideas = conn.Table<Idea>().ToList();
                ideaList.ItemsSource = ideas;
            }
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreatePage());
        }
    }
}
