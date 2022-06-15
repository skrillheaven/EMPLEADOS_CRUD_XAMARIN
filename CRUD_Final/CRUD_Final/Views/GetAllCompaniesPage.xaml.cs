using CRUD_Final.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_Final.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetAllCompaniesPage : ContentPage
    {


        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        
        public GetAllCompaniesPage()
        {
            InitializeComponent();
            var db = new SQLiteConnection(_dbPath);
            listaxdxd.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
        }
    }
}