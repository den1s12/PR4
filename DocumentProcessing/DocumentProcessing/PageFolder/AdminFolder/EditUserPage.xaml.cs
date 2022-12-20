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
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        public EditUserPage(User user)
        {
            InitializeComponent();
            DataContext = user;
            RoleCB.ItemsSource = DBEntities.Getcontext()
                .Role.ToList();
        }

        private void EditUserBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = DBEntities.Getcontext().User.
              FirstOrDefault(s => s.IdUser == VariableClass.UserId);
            user.LoginUser = LoginTB.Text;
            user.PasswordUser = PasswordTB.Text;
            user.IdRole = Int32.Parse(RoleCB.SelectedValue.ToString());
            DBEntities.Getcontext().SaveChanges();
            MBClass.InfoMB("Пользователь успешно отредактирован");
            NavigationService.Navigate(new AdminFolder.ListUserPage());
        }
    }
}
