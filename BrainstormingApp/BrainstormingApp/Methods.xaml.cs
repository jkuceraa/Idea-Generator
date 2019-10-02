﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrainstormingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Methods : ContentPage
    {
        public Methods()
        {
            InitializeComponent();
        }

        private void MashUpButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MashUpPage());
        }

        private void RelatedWordsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RelatedWords());
        }
    }
}