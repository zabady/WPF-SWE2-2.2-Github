using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_SWE2_Phase1
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Page
    {
        private PharmacyFinalEntities db = new PharmacyFinalEntities();
        public User()
        {
            InitializeComponent();
            userTextBlock.Text = "Welcome: " + MainWindow.user.Name + "\nRole: User";
        }

        public static bool onlyNumeric(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that allows numeric input only
            return !regex.IsMatch(text); // 
        }

        private void GetMedicineButton_Click(object sender, RoutedEventArgs e)
        {
            Medicine medicine = db.Medicines.Single(med => med.Name == SearchBox.Text);
            medicine.Quantity = medicine.Quantity - int.Parse(amount.Text);
            db.Entry(medicine).State = EntityState.Modified;
            db.SaveChanges();
            var query = db.Medicines.Where(med => med.Name == SearchBox.Text).ToList();
            dataGrid.ItemsSource = query.ToList();
        }

        private void RemoveBtn(object sender, RoutedEventArgs e)
        {

        }

        private void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !onlyNumeric(e.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Medicine medicine = db.Medicines.Single(med => med.Name == SearchBox.Text);
            medicine.Quantity = medicine.Quantity + int.Parse(amount.Text);
            db.Entry(medicine).State = EntityState.Modified;
            db.SaveChanges();
            var query = db.Medicines.Where(med => med.Name == SearchBox.Text).ToList();
            dataGrid.ItemsSource = query.ToList();
        }

        private void EditProfilePage(object sender, RoutedEventArgs e)
        {
            EditProfile editProfile = new EditProfile();
            this.NavigationService.Navigate(editProfile);
        }
    }
}