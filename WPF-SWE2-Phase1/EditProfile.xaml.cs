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
using System.Data.Entity;
using System.Data;

namespace WPF_SWE2_Phase1
{
    /// <summary>
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Page
    {
        public EditProfile()
        {
            InitializeComponent();
            userTextBlock.Text = "Welcome: " + MainWindow.user.Name + "\nRole: Admin";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (nameTextField.Text != "" || PasswordTextField.Password != "")
            {
                try
                {
                    if (nameTextField.Text != "") MainWindow.user.Name = nameTextField.Text;
                    if (PasswordTextField.Password != "") MainWindow.user.Password = PasswordTextField.Password;

                    MainWindow.db.Entry(MainWindow.user).State = EntityState.Modified;
                    MainWindow.db.SaveChanges();

                    MessageBox.Show("Done");
                    this.NavigationService.GoBack();
                }
                catch
                {
                    MessageBox.Show("Error updating database");
                }
            }
            else
            {
                MessageBox.Show("You must fill at least one field.");
            }
        }
    }
}
