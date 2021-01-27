﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Chart_Sqlite_Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = App.Database.GetChartDataModel();
        }
        private void Insert_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddChartDataPage());
        }
        private void GenerateHandle_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChartSample());
        }
    }
}
