using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        User user;
        UserInfo User_iformation;
        Comany_Info company_informatio;
        DataBasetInfoContext context = new DataBasetInfoContext();

        public Admin()
        {
            InitializeComponent();
        }
        List<string> usersname = new List<string>();
        List<string> Reight = new List<string>();
        
        public int number_of_user;
        public string Username_addmin;
        public Admin(string username)
        {
            InitializeComponent();

            Name.IsEnabled = false;
            Last_Name.IsEnabled = false;
            Username.IsEnabled = false;
            Password.IsEnabled = false;
            Address.IsEnabled = false;
            Telephone.IsEnabled = false;
            Firma.IsEnabled = false;
            Telephone_Frim.IsEnabled = false;
            Address_Firm.IsEnabled = false;
            Right.IsEnabled = false;
            Username_addmin = username;
            Reight.Add("client");
            Reight.Add("supplier");
            Reight.Add("addmin");
            for (int i = 0; i < 3; i++)
            {
                Right.Items.Add(Reight[i]);
            }


        }
        public void User_Information_Add()
        {
            List<Loggin_User> log_Users = context.Users.ToList();
            number_of_user = log_Users.Count();
            for (int i = 0; i < number_of_user; i++)
            {
                Users_List.Items.Add(log_Users[i].Username);
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Telephone_Frim_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Users_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Right_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            Name.Clear();
            Last_Name.Clear();
            Username.Clear();
            Password.Clear();
            Address.Clear();
            Telephone.Clear();
            Firma.Clear();
            Telephone_Frim.Clear();
            Address_Firm.Clear();
            Right.Items.Clear();
            Reight.Add("client");
            Reight.Add("seller");
            Reight.Add("admin");
            for (int i = 0; i < 3; i++)
            {
                Right.Items.Add(Reight[i]);
            }
            Users_List.Items.Clear();
            Company_List_Name.Items.Clear();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Name.IsEnabled = true;
            Last_Name.IsEnabled = true;
            Username.IsEnabled = true;
            Password.IsEnabled = true;
            Address.IsEnabled = true;
            Telephone.IsEnabled = true;
            Right.IsEnabled = true;
        }

        private void Add_Firma_Checked(object sender, RoutedEventArgs e)
        {
            Firma.IsEnabled = true;
            Telephone_Frim.IsEnabled = true;
            Address_Firm.IsEnabled = true;
            List<Company> company_list_name = context.company.ToList();
            for(int i=0; i< company_list_name.Count(); i++)
            {
                Company_List_Name.Items.Add(company_list_name[i].Name_Firma);
            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            Name.IsEnabled = false;
            Last_Name.IsEnabled = false;
            Username.IsEnabled = false;
            Password.IsEnabled = false;
            Address.IsEnabled = false;
            Telephone.IsEnabled = false;
            Firma.IsEnabled = false;
            Telephone_Frim.IsEnabled = false;
            Address_Firm.IsEnabled = false;
            Right.IsEnabled = false;
        }

        private void Change_UserInformation_Click(object sender, RoutedEventArgs e)
        {
            string change_user = Users_List.SelectedItem.ToString();
            var change_user_information =
                                        (from us in context.Users
                                         where us.Username == change_user
                                         select us).First();
            var add_information =
                                (from us_info in context.user_info
                                 where us_info.Id_User == change_user_information.Id_user
                                 select us_info).First();
            add_information.First_Name = Name.Text;
            add_information.Last_Name = Last_Name.Text;
            add_information.User_address = Address.Text;
            add_information.User_phone = Telephone.Text;
            context.SaveChanges();
            MessageBox.Show("User information are change in data base");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Firma.Clear();
            Telephone_Frim.Clear();
            Address_Firm.Clear();
            string Users_information;
            Users_information = Users_List.SelectedItem.ToString();
            var user_log =
                (from us in context.Users
                 where us.Username == Users_information
                 select us).First();
            var user_info =
                (from us in context.user_info
                 where us.Id_User == user_log.Id_user
                 select us).First();
            user = new User(user_log.Username, user_log.Password_u, user_log.Access);
            User_iformation = new UserInfo(user_info.First_Name, user_info.Last_Name, user_info.User_address, user_info.User_phone);
            Username.Text = user.GetUsername();
            Password.Text = user.GetPassword();
            Right.Items.Clear();
            Right.Items.Add(user_log.Access);
            Name.Text = User_iformation.Get_FirstName();
            Last_Name.Text = User_iformation.Get_Last_Name();
            Address.Text = User_iformation.Get_User_address();
            Telephone.Text = User_iformation.Get_User_Phone();
            if(user_info.Firma_id!=0)
            {
                var company_info =
                    (from f in context.company
                     where f.Id_company == user_info.Firma_id
                     select f).First();
                company_informatio = new Comany_Info(company_info.Name_Firma, company_info.Address_Frima, company_info.Telephone_Frima);
                Firma.Text = company_informatio.Get_Name_f();
                Address_Firm.Text = company_informatio.Get_Address_f();
                Telephone_Frim.Text = company_informatio.Get_Telephone_f();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            IList<Loggin_User> log_user_information = context.Users.ToList();
            //List<User_Information> add_us_info = context.user_info.ToList();
            List<Company> com_info = context.company.ToList();
            int br_user = 0;
            for (int i = 0; i < log_user_information.Count(); i++)
            {
                if (Username.Text!=log_user_information[i].Username)
                {
                    br_user++;
                }
            }
            string access;
            access = Right.SelectedItem.ToString();
            if (br_user == log_user_information.Count())
            {
                user = new User(Username.Text, Password.Text, access);
                User_iformation = new UserInfo(Name.Text, Last_Name.Text, Address.Text, Telephone.Text);
                Loggin_User add_log_user = new Loggin_User();

                add_log_user.Id_user = br_user+1;
                add_log_user.Username = user.GetUsername();
                add_log_user.Password_u = user.GetPassword();
                add_log_user.Access = user.GetReight();
                //log_user_information.Add(add_log_user);

                context.Users.Add(add_log_user);

                User_Information us_ifromation = new User_Information();
                us_ifromation.Id_User = add_log_user.Id_user;
                us_ifromation.First_Name = User_iformation.Get_FirstName();
                us_ifromation.Last_Name = User_iformation.Get_Last_Name();
                us_ifromation.User_address = User_iformation.Get_User_address();
                us_ifromation.User_phone = User_iformation.Get_User_Phone();



                Company add_company_db = new Company();
                int id_of_company = 0;
                if (Add_Firma.IsChecked == false)
                {
                    us_ifromation.Firma_id = 0;
                    context.user_info.Add(us_ifromation);
                }
                else
                {
                    for (int i = 0; i < com_info.Count(); i++)
                    {
                        if (Firma.Text == com_info[i].Name_Firma)
                        {
                            id_of_company = i;
                            us_ifromation.Firma_id = i;
                            com_info.Add(add_company_db);
                            break;
                        }
                    }

                    if (id_of_company >= com_info.Count() - 1)
                    {
                        company_informatio = new Comany_Info(Firma.Text, Address_Firm.Text, Telephone_Frim.Text);
                        add_company_db.Id_company = us_ifromation.Firma_id;
                        add_company_db.Name_Firma = company_informatio.Get_Name_f();
                        add_company_db.Address_Frima = company_informatio.Get_Address_f();
                        add_company_db.Telephone_Frima = company_informatio.Get_Telephone_f();

                        context.company.Add(add_company_db);
                        context.user_info.Add(us_ifromation);
                    }
                }


            }
            else
            {
                MessageBox.Show("We have user with sama name");
            }
            context.SaveChanges();
            MessageBox.Show("User are added in data base");
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            Name.IsEnabled = true;
            Last_Name.IsEnabled = true;
            Address.IsEnabled = true;
            Telephone.IsEnabled = true;
        }

        private void Add_User_Check_Checked(object sender, RoutedEventArgs e)
        {
            User_Information_Add();
        }

        private void Company_List_Name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string company_name;
            company_name = Company_List_Name.SelectedItem.ToString();
            var company_info =
                    (from f in context.company
                     where f.Name_Firma == company_name
                     select f).First();
            company_informatio = new Comany_Info(company_info.Name_Firma, company_info.Address_Frima, company_info.Telephone_Frima);
            Firma.Text = company_informatio.Get_Name_f();
            Address_Firm.Text = company_informatio.Get_Address_f();
            Telephone_Frim.Text = company_informatio.Get_Telephone_f();
        }
    }
}
