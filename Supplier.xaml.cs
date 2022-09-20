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
    /// Interaction logic for Supplier.xaml
    /// </summary>
    public partial class Supplier : Window
    {
        public string Username;
        public int number_of_Product;
        List<string> product_list = new List<string>();
        Product_Info product_information;
        string firma_name;
        string product_name;
        public Supplier(string username)
        {
            Username = username;
            InitializeComponent();
            Add_products();
            List<string> type = new List<string>();
            type.Add("Cars");
            type.Add("Acceeories");
            type.Add("Car_parts");
            for (int i = 0; i < 3; i++)
            {
                Type.Items.Add(type[i]);
            }
        }

        void Close_Product()
        {
            Firma.IsEnabled = false;
            Marka.IsEnabled = false;
            Year.IsEnabled = false;
            Price.IsEnabled = false;
            Count.IsEnabled = false;
            Information.IsEnabled = false;
            Model.IsEnabled = false;
        }

        void clear_view()
        {
            ID.Clear();
            Marka.Clear();
            Year.Clear();
            Price.Clear();
            Count.Clear();
            Information.Clear();
            Model.Clear();
            Type.Items.Clear();
            string picture;
            picture = @"E:\PC\KP\Car_Magazine_KP\resource\clear.jpg";
            Picture.Source = new BitmapImage(new Uri(@picture));
            List<string> type = new List<string>();
            type.Add("Cars");
            type.Add("Acceeories");
            type.Add("Car_parts");
            for (int i = 0; i < 3; i++)
            {
                Type.Items.Add(type[i]);
            }
        }


        private void See_Prodect_Click(object sender, RoutedEventArgs e)
        {
            product_name=Products.SelectedItem.ToString();
            DataBasetInfoContext context = new DataBasetInfoContext();
            var product_info =
                            (from pr in context.product
                             where pr.Product_Name == product_name
                             select pr).First();
            string picture;
            picture = @"E:\PC\KP\Car_Magazine_KP\resource\" + product_name + ".jpg";
            Picture.Source = new BitmapImage(new Uri(@picture));
            product_information = new Product_Info(product_info.Id_Product, product_info.Product_Name, product_info.Product_Type, product_info.Marka,
                                                   product_info.Product_Year, product_info.Price, product_info.Product_count, product_info.Information);
            ID.Text = product_information.Get_Product_ID().ToString();
            Firma.Text =firma_name;
            Firma.IsEnabled = false;
            Marka.Text = product_information.Get_Marka();
            Year.Text = product_information.Get_Product_Year().ToString();
            Price.Text = product_information.Get_Price().ToString();
            Count.Text = product_information.Get_Count().ToString();

            int count = product_information.Get_Count();
            if (count == 0)
            {
                Count.Background = Brushes.Red;
                MessageBox.Show("The product is over. Add a new amount!");

            }
            Information.Text = product_information.Get_Information();
            Model.Text = product_information.Get_Product_Name();
            Type.Items.Clear();
            Type.Items.Add(product_information.Get_Product_Type());
        }

        private void Add_Picture_Button_Click(object sender, RoutedEventArgs e)
        {
            string new_picture;
            new_picture = Model.Text;
            new_picture = @"E:\BestCar_magazine\resource\" + new_picture + ".jpg";
            Picture.Source = new BitmapImage(new Uri(@new_picture));
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int id = rnd.Next(1000, 40000);
            ID.Text = id.ToString();
            Marka.IsEnabled = true;
            Year.IsEnabled = true;
            Price.IsEnabled = true;
            Count.IsEnabled = true;
            Information.IsEnabled = true;
            Model.IsEnabled = true;
            List<string> type = new List<string>();
            type.Add("Cars");
            type.Add("Acceeories");
            type.Add("Car_parts");
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            Marka.IsEnabled = true;
            Year.IsEnabled = true;
            Price.IsEnabled = true;
            Count.IsEnabled = true;
            Information.IsEnabled = true;
        }

        private void Close_Checked(object sender, RoutedEventArgs e)
        {
            Close_Product();
        }

        private void Add_Product_Click(object sender, RoutedEventArgs e)
        {
            Product add_product = new Product();
            string type = Type.SelectedItem.ToString();
            Product_Info new_product = new Product_Info(int.Parse(ID.Text), Model.Text, type, Marka.Text, int.Parse(Year.Text),
                                                        float.Parse(Price.Text), int.Parse(Count.Text), Information.Text);
            DataBasetInfoContext context = new DataBasetInfoContext();
            var company_data =
                 (from cm in context.company
                  where cm.Name_Firma == Firma.Text
                  select cm).First();
            add_product.Id_Product = new_product.Get_Product_ID();
            add_product.Product_Name = new_product.Get_Product_Name();
            add_product.Product_Type = new_product.Get_Product_Type();
            add_product.Product_Year = new_product.Get_Product_Year();
            add_product.Price = new_product.Get_Price();
            add_product.Marka = new_product.Get_Marka();
            add_product.Product_count = new_product.Get_Count();
            add_product.Information = new_product.Get_Information();
            add_product.id_f = company_data.Id_company;
            context.product.Add(add_product);
            context.SaveChanges();
        }

        private void Change_Product_Click(object sender, RoutedEventArgs e)
        {
            DataBasetInfoContext context = new DataBasetInfoContext();
            var product_change =
                            (from pr in context.product
                             where pr.Product_Name == product_name
                             select pr).First();
            product_change.Marka = Marka.Text;
            product_change.Product_Year = int.Parse(Year.Text);
            product_change.Price = float.Parse(Price.Text);
            product_change.Product_count = int.Parse(Count.Text);
            product_change.Information = Information.Text;
            context.SaveChanges();
            MessageBox.Show("Ínformation for product is change");
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataBasetInfoContext context = new DataBasetInfoContext();
            var delObj =
                            (from pr in context.product
                             where pr.Product_Name == product_name
                             select pr).First();
            context.product.Remove(delObj);
            context.SaveChanges();
            Add_products();
        }


        public void Add_products()
        {
            DataBasetInfoContext context = new DataBasetInfoContext();
            var user_log =
                        (from us in context.Users
                         where us.Username == Username
                         select us).First();
            var user_info =
                        (from us in context.user_info
                         where us.Id_User == user_log.Id_user
                         select us).First();
            var firma_info =
                        (from com in context.company
                         where com.Id_company == user_info.Firma_id
                         select com).First();
            firma_name = firma_info.Name_Firma;
            List<Product> products = context.product.ToList();
            number_of_Product = products.Count();
            for (int i = 0; i < number_of_Product; i++)
            {
                if (user_info.Firma_id == products[i].id_f)
                {
                    Products.Items.Add(products[i].Product_Name);
                }
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clear_view();
        }
    }
}
