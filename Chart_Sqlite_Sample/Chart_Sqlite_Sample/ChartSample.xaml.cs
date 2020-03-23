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
	public partial class ChartSample : ContentPage
	{
		public ChartSample ()
		{
			InitializeComponent ();
            (BindingContext as ViewModel).Data = App.Database.GetChartDataModel();
        }
    }
}