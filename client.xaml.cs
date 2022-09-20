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

namespace Car_Magazine_KP
{
    /// <summary>
    /// Interaction logic for client.xaml
    /// </summary>
    public partial class client : Window
    {
        public string Username;
        public string proguct_name;
        public client(string username)
        {
            InitializeComponent();
            Username = username;
        }
        DataBasetInfoContext context = new DataBasetInfoContext();
        
        private void Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Cars_Checked(object sender, RoutedEventArgs e)
        {
            List<Product> product_list = context.product.ToList();
            for (int i = 0; i < product_list.Count(); i++)
            {
                if (product_list[i].Product_Type == "Car")
                {
                    Product.Items.Add(product_list[i].Product_Name);
                }
            }
        }

        private void Accessories_Checked(object sender, RoutedEventArgs e)
        {
            List<Product> product_list = context.product.ToList();
            for (int i = 0; i < product_list.Count(); i++)
            {
                if (product_list[i].Product_Type == "Acceeories")
                {
                    Product.Items.Add(product_list[i].Product_Name);
                }
            }
        }

        private void Car_parts_Checked(object sender, RoutedEventArgs e)
        {
            List<Product> product_list = context.product.ToList();
            for (int i = 0; i < product_list.Count(); i++)
            {
                if (product_list[i].Product_Type == "Car parts")
                {
                    Product.Items.Add(product_list[i].Product_Name);
                }
            }
        }

        private void clear_list_Click(object sender, RoutedEventArgs e)
        {
            Product.Items.Clear();
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            string product_information;
            product_information = Product.SelectedItem.ToString();
            Shop shop = new Shop(Username, product_information);
            shop.Show();
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            Cart_client client = new Cart_client(Username);
            client.Show();
        }
    }
}
