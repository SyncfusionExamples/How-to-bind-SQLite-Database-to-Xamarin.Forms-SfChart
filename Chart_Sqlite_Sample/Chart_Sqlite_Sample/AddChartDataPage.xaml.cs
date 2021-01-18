using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chart_Sqlite_Sample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddChartDataPage : ContentPage
    {
        public AddChartDataPage()
        {
            InitializeComponent();
        }

        private void Insert_Clicked(object sender, EventArgs e)
        {
            // Insert items into table
            var todoItem = (ChartDataModel)BindingContext;
            App.Database.SaveChartDataModelAsync(todoItem);
            Navigation.PopAsync();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            // Delete items into table
            var todoItem = (ChartDataModel)BindingContext;
            App.Database.DeleteChartDataModelAsync(todoItem);
            Navigation.PopAsync();
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}