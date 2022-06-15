using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CRUD_Final.Model;

namespace CRUD_Final.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCompanyPage : ContentPage
    {



        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public AddCompanyPage()
        {
            InitializeComponent();
        }

        private async void btn_Add_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Company>();

            var maxPk = db.Table<Company>().OrderByDescending(c => c.Id).FirstOrDefault();

            Company company = new Company()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                Name = txtName.Text,
                Address = txtAddress.Text
            };

            db.Insert(company);
            await DisplayAlert(null, "'"+company.Name + "' Ha Sido Guardado", "OK");
            await Navigation.PopAsync();


        }
    }
}