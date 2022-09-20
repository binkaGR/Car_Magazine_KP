using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Workflow.ComponentModel;

namespace Car_Magazine_KP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string check;
            UserLogin loggin = new UserLogin();
            loggin.addUsers();
            string username, password;
            username = Username.Text;
            password = Password.Password.ToString();
            check = loggin.CheckUser(username, password);
            switch (check)
            {
                case "client":
                    {
                        //MessageBox.Show("Shop");
                        client Client = new client(username);
                        Client.Show();
                    }
                    break;
                case "supplier":
                    {
                        //MessageBox.Show("Seller");

                        Supplier supplier = new Supplier(username);
                        supplier.Show();
                    }
                    break;
                case "addmin":
                    {
                        //MessageBox.Show("Admin");

                        Admin admiin = new Admin(username);
                        admiin.Show();
                    }
                    break;
                default:
                    {
                        MessageBox.Show("Access is not correct!");
                        Username.Background = Brushes.Red;
                        Password.Background = Brushes.Red;
                    }
                    break;
            }
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            Username.Background = Brushes.White;
            Password.Background = Brushes.White;
        }
    }
}
