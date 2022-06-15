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
    public partial class EditCompanyPage : ContentPage
    {

        Company _company = new Company();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public EditCompanyPage()
        {
            InitializeComponent();

            var db = new SQLiteConnection(_dbPath);

            LV_lista.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            LV_lista.ItemSelected += _LV_lista_ItemSelected;
            txt_Id.IsVisible = false;
            txtName.Keyboard = Keyboard.Text;
            txtAddress.Keyboard = Keyboard.Text;

        }

        private void _LV_lista_ItemSelected (object sender, SelectedItemChangedEventArgs e)
        {
            _company = (Company)e.SelectedItem;
            txt_Id.Text = _company.Id.ToString();
            txtName.Text = _company.Name;
            txtAddress.Text = _company.Address;
        }

        private async void btn_Cambiar_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Company company = new Company()
            {
                Id = Convert.ToInt32(txt_Id.Text),
                Name = txtName.Text,
                Address = txtAddress.Text
            };
            db.Update(company);
            await Navigation.PopAsync();

        }
    }
}