# How to bind the SQLite Database to the Xamarin.Forms Chart (SfChart)?

This example demonstrates how to show the SQLite database data to Chart.

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

## Output:

![Displaying the database data in a ListView](https://user-images.githubusercontent.com/53489303/200647742-0e2c157a-a7ff-4d46-9131-a8bfe4d9dc0c.png)

_**Initial page to display the SQLite database data**_

![Inserting an data item in the database](https://user-images.githubusercontent.com/53489303/200647795-cfd1d8be-f95d-4205-8402-315fe26bd819.png)

_**Inserting an item to the database.**_

![Output after inserting a data into the database](https://user-images.githubusercontent.com/53489303/200647840-e8c6a72d-7bbc-4378-81ac-e9c86902ee0b.png)

_**After inserting data into the database.**_

![Chart output based on the database data](https://user-images.githubusercontent.com/53489303/200647888-def1ce16-6528-4f0e-8867-e7ae17af04a3.png)

_**Display the chart with generated data**_

KB article - [How to bind the SQLite Database to the Xamarin.Forms Chart (SfChart)?](https://www.syncfusion.com/kb/11267/how-to-bind-the-sqlite-database-to-the-xamarin-forms-chart)

Also refer our [feature tour](https://www.syncfusion.com/xamarin-ui-controls/xamarin-charts) page to know more features available in our charts.

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

