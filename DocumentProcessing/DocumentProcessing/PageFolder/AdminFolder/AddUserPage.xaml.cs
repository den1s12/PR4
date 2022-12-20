using DocumentProcessing.ClassFolder;
using DocumentProcessing.DataFolder;
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

namespace DocumentProcessing.PageFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            InitializeComponent();
            RoleCB.ItemsSource = DBEntities.Getcontext()
               .Role.ToList();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите логин");
            }
            else if (PasswordTB.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите пароль");
            }
            else
            {
                AddUser();
                MBClass.InfoMB("Пользователь зарегистрирован");
                NavigationService.Navigate(new AdminFolder.ListUserPage());
            }
        }
        private void AddUser()
        {
            DBEntities.Getcontext().User.Add(new User()
            {
                LoginUser = LoginTB.Text,
                PasswordUser = PasswordTB.Text,
                IdRole = Int32.Parse(RoleCB.SelectedValue.ToString())
            });
            DBEntities.Getcontext().SaveChanges();
        }

       
    }
}
