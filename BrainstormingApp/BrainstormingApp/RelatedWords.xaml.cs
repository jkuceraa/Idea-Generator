using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrainstormingApp.Logic;
using BrainstormingApp.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrainstormingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RelatedWords : ContentPage
    {
        public RelatedWords()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await IdeaListLogic.GetRelated("cow");
        }
    }
}