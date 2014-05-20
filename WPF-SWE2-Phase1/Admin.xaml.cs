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
using WPF_SWE2_Phase1.DBLayer;

namespace WPF_SWE2_Phase1
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        private MedicineLogic medLogic = new MedicineLogic();

        public Admin()
        {
            InitializeComponent();
            this.userNameTxt.Text = "Welcome: " + MainWindow.user.Name;
            refreshDataGrid();
        }

        private void AddUserClicked(object sender, RoutedEventArgs e)
        {
            AddUser addUserPage = new AddUser();
            this.NavigationService.Navigate(addUserPage);
        }

        private void AddMedicineClicked(object sender, RoutedEventArgs e)
        {
            AddMedicine addMedicinePage = new AddMedicine();
            this.NavigationService.Navigate(addMedicinePage);
        }

        /////////////////////////////////////////////////////////////// TIFA'S TASK
        private void RemoveBtnClicked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text))
            {
                MessageBox.Show("Type medicine name first.");
                return;
            }

            if (medLogic.deleteMedicine(SearchBox.Text))
            {
                MessageBox.Show(SearchBox.Text + " deleted.");
                SearchBox.Text = "";
                refreshDataGrid();
            }
            else MessageBox.Show(SearchBox.Text + " not Found.");
        }

        private void refreshDataGrid()
        {
            medicineDataGrid.ItemsSource = MainWindow.db.Medicines.ToList();
        }


        /////////////////////////////////////////////////////////////// DOAA'S TASK
        private void GetMedicineButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text != "")
            {
                string searchItem = SearchBox.Text;
                Medicine medicine = new Medicine();
                medicineDataGrid.Visibility = Visibility.Visible;
                var query = MainWindow.db.Medicines.Where(med => med.Name.Contains(searchItem)).ToList();
                medicineDataGrid.ItemsSource = query;
                if (medicineDataGrid.ItemsSource != null)
                {
                    removeBtn.Visibility = Visibility.Visible;
                }
            }
            else
            {
                refreshDataGrid();
            }
        }

        private void EditProfileClicked(object sender, RoutedEventArgs e)
        {
            EditProfile editProfile = new EditProfile();
            this.NavigationService.Navigate(editProfile);
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            medicineDataGrid.ItemsSource = MainWindow.db.Medicines.ToList();
        }
    }
}