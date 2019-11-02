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
    public partial class WhysPage : ContentPage
    {
        private int timesClicked = 0;
        public WhysPage()
        {
            InitializeComponent();
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (DescribeProblem.IsVisible)
            {
                DescribeProblem.IsVisible = false;
                Summary.Text = DescribeProblem.Text + "\n" + why.Text;
                Summary.IsVisible = true;
                Answer.IsVisible = true;
            }
            else if (timesClicked < 4)
            {
                timesClicked++;
                Summary.Text += "\n" + Answer.Text + "\n" + why.Text;
                Answer.Text = "";
            }
            else
            {
                Summary.Text += "\n" + Answer.Text + "\n"+idea.Text;
                Answer.Text = "";
                SubmitButton.IsVisible = false;
                AddButton.IsVisible = true;
            }
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            Idea newidea = new Idea
            {
                Name = Answer.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Idea>();
                conn.Insert(newidea);
            }
            Answer.Text = "";
        }
    }
}