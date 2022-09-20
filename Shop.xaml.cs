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
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
        Product_Info product_information;
        String product_name;
        string Username;
        public Shop(string username,string product)
        {
            InitializeComponent();
            Close_Product();
            product_name = product;
            Name.Text = product_name;
            Username = username;
            Add_product();
        }
        public void Add_product()
        {
            DataBasetInfoContext context = new DataBasetInfoContext();
            var product_info =
                            (from pr in context.product
                             where pr.Product_Name == product_name
                             select pr).First();
            var company_info =
                (from pr in context.company
                 where pr.Id_company == product_info.id_f
                 select pr).First();
            string picture;
            picture = @"E:\PC\KP\Car_Magazine_KP\resource\" + product_name + ".jpg";
            Picture.Source = new BitmapImage(new Uri(@picture));
            product_information = new Product_Info(product_info.Id_Product, product_info.Product_Name, product_info.Product_Type, product_info.Marka,
                                                   product_info.Product_Year, product_info.Price, product_info.Product_count, product_info.Information);
            ID.Text = product_information.Get_Product_ID().ToString();
            Firma.Text = company_info.Name_Firma;
            Marka.Text = product_information.Get_Marka();
            Year.Text = product_information.Get_Product_Year().ToString();
            Price.Text = product_information.Get_Price().ToString();
            Count.Text = product_information.Get_Count().ToString();

            int count = product_information.Get_Count();
            if (count == 0)
            {
                Count.Background = Brushes.Red;
                Buy.IsEnabled = false;

            }
            Information.Text = product_information.Get_Information();
        }
        void Close_Product()
        {
            Firma.IsEnabled = false;
            Marka.IsEnabled = false;
            Year.IsEnabled = false;
            Price.IsEnabled = false;
            Count.IsEnabled = false;
            Information.IsEnabled = false;
            ID.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Product_Carts> product_Carts = new List<Product_Carts>();
            Product_Carts add_in_Cart;
            int number_of_product = 0;
            string file_name = @"E:\PC\KP\Car_Magazine_KP\resource\" + Username + "_cart.txt";
            StreamReader read_cart = new StreamReader(@file_name);
            string line = "read";
            string name_product; ;
            int count_product;
            do
            {
                line = read_cart.ReadLine();
                if (line == null)
                {
                    break;
                }
                line = line.ToString();
                name_product = line;
                line = read_cart.ReadLine();
                count_product = int.Parse(line);
                number_of_product++;
                add_in_Cart = new Product_Carts(name_product, count_product);
                product_Carts.Add(add_in_Cart);
            }
            while (line != null);
            read_cart.Close();


            DataBasetInfoContext context = new DataBasetInfoContext();
            Product product_info =
                            (from pr in context.product
                             where pr.Product_Name == product_name
                             select pr).First();
            product_info.Product_count--;
            context.SaveChanges();

            for (int i=0;i <= product_Carts.Count(); i++)
            {
                if (i == product_Carts.Count())
                {
                    name_product = product_info.Product_Name;
                    count_product =1;
                    add_in_Cart = new Product_Carts(name_product, count_product);
                    product_Carts.Add(add_in_Cart);
                    break;
                }
                if (product_Carts[i].Get_Name_Product()== product_name) 
                {
                    count_product = product_Carts[i].Get_Count_Product();
                    product_Carts[i].Set_Count_Product(count_product + 1);
                    break;
                }

            }

            string file_name_new = @"E:\PC\KP\Car_Magazine_KP\resource\" + Username + "_cart.txt";
            StreamWriter write_cart = new StreamWriter(file_name_new, false, Encoding.UTF8);
            for (int i = 0; i < product_Carts.Count(); i++)
            {
                add_in_Cart = product_Carts[i];
                write_cart.WriteLine(add_in_Cart.Get_Name_Product());
                write_cart.WriteLine(add_in_Cart.Get_Count_Product());
            }
            write_cart.Close();
        }
    }
}
