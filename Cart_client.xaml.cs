using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Cart_client.xaml
    /// </summary>
    public partial class Cart_client : Window
    {
        public string Username;
        public string product_information;
        List<Cart_list> cart_list = new List<Cart_list>();
        Cart_list cart;
        int number_of_Product = 0;
        public Cart_client(string username)
        {

            Username = username;
            InitializeComponent();
            add_list_cart(Username);
            Client_Name.Text = "Hello " + Username + " !";

        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            string product_information;
            product_information = Product_in_cart.SelectedItem.ToString();
            Shop shop = new Shop(Username, product_information);
            shop.Show();
        }

        private void Product_in_cart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string product_name;
            product_name = Product_in_cart.SelectedItem.ToString();
            DataBasetInfoContext context = new DataBasetInfoContext();
            var product_info =
                            (from pr in context.product
                             where pr.Product_Name == product_name
                             select pr).First();
            ID_Product.Text = product_info.Id_Product.ToString();
            Price_Product.Text = product_info.Price.ToString();
            for (int i = 0; i < number_of_Product; i++)
            {
                if(cart_list[i].Get_Product_Name()==product_name)
                {
                    Count_Product.Text = cart_list[i].Get_Count().ToString();
                    break;
                }
            }
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            string file_name_new = @"E:\PC\KP\Car_Magazine_KP\resource\" + Username + "_cart.txt";
            StreamWriter clear_cart = new StreamWriter(file_name_new, false, Encoding.UTF8);
            clear_cart.WriteLine("");
            clear_cart.WriteLine("0");
            clear_cart.Close();
        }

        public void add_list_cart(string username)
        {
            string file_name_new = @"E:\PC\KP\Car_Magazine_KP\resource\" + Username + "_cart.txt";
            StreamReader read_cart = new StreamReader(@file_name_new);
            string line= "read";
            do{
                line = read_cart.ReadLine();
                if (line == null)
                {
                    break;
                }
                line = line.ToString();
                string name = line;
                line = read_cart.ReadLine();
                int count = int.Parse(line);
                number_of_Product++;
                cart = new Cart_list(name, count);
                cart_list.Add(cart);
            }
            while(line!= null);
            read_cart.Close();

           for(int i=0; i < number_of_Product; i++) 
            {
                Product_in_cart.Items.Add(cart_list[i].Get_Product_Name());
            }
            DataBasetInfoContext context = new DataBasetInfoContext();
            List<Product> product_date = context.product.ToList();
            List<double> Sum_product = new List<double>();
            for(int i=0;i<number_of_Product; i++)
            {
                for (int j = 0; j < product_date.Count(); j++)
                    if (cart_list[i].Get_Product_Name() == product_date[j].Product_Name)
                    {
                        float price = product_date[j].Price * cart_list[i].Get_Count();
                        Sum_product.Add(price);
                        break;
                    }
            }
            double sum = Sum_product.Sum();
            Sum.Text = sum.ToString() + " lv.";
        }

    }
}
