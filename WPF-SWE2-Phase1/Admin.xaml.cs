using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_SWE2_Phase1
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        private PharmacyFinalEntities db = new PharmacyFinalEntities();
        public Admin()
        {
            InitializeComponent();
            this.userNameTxt.Text = "Welcome: " + MainWindow.user.Name;
            this.medicineData.ItemsSource = MainWindow.db.Medicines.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddUser addUserPage = new AddUser();
            this.NavigationService.Navigate(addUserPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddMedicine addMedicinePage = new AddMedicine();
            this.NavigationService.Navigate(addMedicinePage);
        }

        /////////////////////////////////////////////////////////////// TIFA'S TASK
        private void RemoveBtnClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Medicine deletedata = new Medicine();
                Medicine data = MainWindow.db.Medicines.Single(c => c.Name == SearchBox.Text);
                MainWindow.db.Medicines.Remove(data); // DeleteOnSubmit()
                MainWindow.db.SaveChanges();
                MessageBox.Show(data.Name + "\n" + "Returned Successfully");
            }
            catch
            {
                MessageBox.Show(SearchBox.Text + "\n" + "not Found");
            }

            medicineData.ItemsSource = MainWindow.db.Medicines.ToList();

        }


        /////////////////////////////////////////////////////////////// DOAA'S TASK
        private void GetMedicineButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text != "")
            {
                string searchItem = SearchBox.Text;
                Medicine medicine = new Medicine();
                medicineData.Visibility = Visibility.Visible;
                var query = db.Medicines.Where(med => med.Name.Contains(searchItem)).ToList();
                medicineData.ItemsSource = query;
                if (medicineData.ItemsSource != null)
                {
                    removeBtn.Visibility = Visibility.Visible;
                }
            }
            else
            {
                medicineData.ItemsSource = MainWindow.db.Medicines.ToList();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            EditProfile editProfile = new EditProfile();
            this.NavigationService.Navigate(editProfile);
        }
    }
}