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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using WPF_SWE2_Phase1.DBLayer;

namespace WPF_SWE2_Phase1
{
    /// <summary>
    /// Interaction logic for AddMedicine.xaml
    /// </summary>

    public partial class AddMedicine : Page
    {
        MedicineLogic med = new MedicineLogic();
        bool check;
        public AddMedicine()
        {
            InitializeComponent();
            userTextBlock.Text = "Welcome: " + MainWindow.user.Name + "\nRole: Admin";
        }

        private void SumbitClicked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameTxtBox.Text) ||
                string.IsNullOrEmpty(priceTxtBox.Text) || int.Parse(priceTxtBox.Text) <= 0 || 
                string.IsNullOrEmpty(quantityTxtBox.Text) || int.Parse(quantityTxtBox.Text) <= 0 ||
                string.IsNullOrEmpty(categoryTxtBox.Text) || 
                datePicker.SelectedDate == null || datePicker.SelectedDate < DateTime.Now)
            {
                MessageBox.Show("Wrong value, please try again.");
                return;
            }

            try
            {
                check = med.addMedicine(nameTxtBox.Text, int.Parse(priceTxtBox.Text), int.Parse(quantityTxtBox.Text), categoryTxtBox.Text, (System.DateTime)datePicker.SelectedDate);
                if (check == true)
                {
                    MessageBox.Show("Item: " + nameTxtBox.Text + "\n with price: " + int.Parse(priceTxtBox.Text) + "\n with quantity: " + int.Parse(quantityTxtBox.Text) + "\n at category: " + categoryTxtBox.Text + "\nit's expiry date: " + (System.DateTime)datePicker.SelectedDate);
                    dataGrid.ItemsSource = MainWindow.db.Medicines.ToList();
                }
                else
                {
                    MessageBox.Show("Error adding medicine.");
                }
            }
            catch
            {
                MessageBox.Show("Error adding item in database.");
            }
        }
        


        public static bool onlyNumeric(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that allows numeric input only
            return !regex.IsMatch(text); // 
        }

        private void priceTxtBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !onlyNumeric(e.Text);
        }
    }
}
