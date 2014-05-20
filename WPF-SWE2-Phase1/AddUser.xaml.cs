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
using WPF_SWE2_Phase1.DBLayer;

namespace WPF_SWE2_Phase1
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        public AddUser()
        {
            InitializeComponent();
            userTextBlock.Text = "Welcome: " + MainWindow.user.Name + "\nRole: Admin";
        }

        private void SubmitCliced(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(usernameTextField.Text) ||
                string.IsNullOrEmpty(PasswordTextField.Password))
            {
                MessageBox.Show("All fields are required");
                return;
            }

            if (AccountLogic.addAccount(usernameTextField.Text,
                                        PasswordTextField.Password,
                                        (bool)AdminRadioBtn.IsChecked))
            {
                MessageBox.Show("User added successfully.");
                dataGrid.ItemsSource = MainWindow.db.Accounts.ToList();
            }
            else MessageBox.Show("Error adding user to the database.");

        }
    }
}
