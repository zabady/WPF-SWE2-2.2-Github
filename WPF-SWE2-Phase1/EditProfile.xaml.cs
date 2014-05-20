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
using WPF_SWE2_Phase1.DBLayer;

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

        private void SubmitClicked(object sender, RoutedEventArgs e)
        {
            if (nameTextField.Text != "" || PasswordTextField.Password != "")
            {
                if (AccountLogic.editAccount(MainWindow.user, nameTextField.Text, PasswordTextField.Password))
                {
                    MessageBox.Show("Done");
                    this.NavigationService.GoBack();
                }
                else MessageBox.Show("Error updating database");
            }
            else
            {
                MessageBox.Show("You must fill at least one field.");
            }
        }
    }
}
