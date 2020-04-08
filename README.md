# How-to-bind-SQLite-Database-to-Chart-in-Xamarin
This example demonstrates how to show the SQLite database data to Chart.
Please refer KB links for more details,

[How to bind the SQLite Database to the Xamarin.Forms Chart (SfChart)](https://www.syncfusion.com/kb/11267/?utm_medium=listing&utm_source=github-examples)


Let us start learning how to work with the Xamarin.Forms Chart using the SQLite database with the following steps:

**Step 1:** Add the  SQLite reference in your project. 

**Step 2:** Create the database access class as follows,

 ```

public class ChartDatabase
{
        readonly SQLiteConnection _database;

        public ChartDatabase(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<ChartDataModel>();
        }
    
         //Get the list of ChartDataModel items from the database
        public List<ChartDataModel> GetChartDataModel()
        {
            return _database.Table<ChartDataModel>().ToList();
        }

        //Insert an item in the database
        public int SaveChartDataModelAsync(ChartDataModel chartDataModel)
        {
            if (chartDataModel == null)
            {
                throw new Exception("Null");
            }

            return _database.Insert(chartDataModel);
        }

         //Delete an item in the database 
        public int DeleteChartDataModelAsync(ChartDataModel chartDataModel)
        {
            return _database.Delete(chartDataModel);
        }
}

```

```

public partial class App : Application
{
        …
        public static ChartDatabase Database
        {
            get
            {
                if (database == null)
                {
                     database = new ChartDatabase(Path.Combine( 
                     Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                                                  "ChartDataBase.db3"));
                }
                return database;
            }
        }
        ….
}

```

**Step 3:** Now, create the following Model for the Chart data.

```

public class ChartDataModel
{
        [PrimaryKey]
        public string XValue { get; set; }
        public double YValue { get; set; }
}

```

**Step 4:** Bind the retrieved data from Database to SfChart.

```

<ContentPage.BindingContext>
        <local:ViewModel/>
</ContentPage.BindingContext>
<ContentPage.Content>
        <StackLayout>
            <chart:SfChart x:Name="chart" HorizontalOptions="FillAndExpand" 
                                       VerticalOptions="FillAndExpand">
                  …
                <chart:SfChart.Series>
                    <chart:ColumnSeries ItemsSource="{Binding Data}" XBindingPath="XValue" 
                                       YBindingPath="YValue">
                    </chart:ColumnSeries>
                </chart:SfChart.Series>
            </chart:SfChart>
        </StackLayout>
</ContentPage.Content>

```

Retrieving the database data of Chart as follows.

```

public partial class ChartSample : ContentPage
{
      public ChartSample ()
      {
             InitializeComponent ();
             (BindingContext as ViewModel).Data = App.Database.GetChartDataModel();
      }
}

```

Also refer our [feature tour](https://www.syncfusion.com/xamarin-ui-controls/xamarin-charts) page to know more features available in our charts.

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

