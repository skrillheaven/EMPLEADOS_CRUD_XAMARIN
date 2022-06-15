using CRUD_Final.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_Final.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteCompanyPage : ContentPage
    {
        Company _company = new Company();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public DeleteCompanyPage()
        {
            InitializeComponent();
            var db = new SQLiteConnection(_dbPath);

            LV_lista2.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            LV_lista2.ItemSelected += _LV_lista_ItemSelected;
        }
        private void _LV_lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _company = (Company)e.SelectedItem;
           
        }

        private async void btn_Eliminar_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<Company>().Delete(x => x.Id == _company.Id);
            await Navigation.PopAsync();

        }
    }
}