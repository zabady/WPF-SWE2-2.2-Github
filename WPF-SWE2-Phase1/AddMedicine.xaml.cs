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

namespace WPF_SWE2_Phase1
{
    /// <summary>
    /// Interaction logic for AddMedicine.xaml
    /// </summary>
    public partial class AddMedicine : Page
    {
        public AddMedicine()
        {
            InitializeComponent();
            userTextBlock.Text = "Welcome: " + MainWindow.user.Name + "\nRole: Admin";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (nameTxtBox.Text != null && categoryTxtBox.Text != null)
            {
                try
                {
                    Medicine medicine = new Medicine();
                    medicine.Name = nameTxtBox.Text;
                    medicine.Price = int.Parse(priceTxtBox.Text);
                    medicine.Quantity = int.Parse(quantityTxtBox.Text);
                    medicine.Category = categoryTxtBox.Text;
                    medicine.ExpireDate = (System.DateTime)datePicker.SelectedDate;

                    MessageBox.Show(medicine.Name + "\n" +
                            medicine.Price + "\n" +
                            medicine.Quantity + "\n" +
                            medicine.Category + "\n" +
                            medicine.ExpireDate + "\n");
                    try
                    {
                        MainWindow.db.Medicines.Add(medicine);
                        MainWindow.db.SaveChanges();
                        dataGrid.ItemsSource = MainWindow.db.Medicines.ToList();
                    }
                    catch
                    {
                        MessageBox.Show("Errod adding medicine");
                    }
                }
                catch
                {
                    MessageBox.Show("All Fields are required");
                }
            } else MessageBox.Show("All Fields are required");
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
