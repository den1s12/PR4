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
    /// Логика взаимодействия для ListUserPage.xaml
    /// </summary>
    public partial class ListUserPage : Page
    {
        public ListUserPage()
        {
            InitializeComponent();
            ListUserDG.ItemsSource = DBEntities.Getcontext().User.ToList()
             .OrderBy(c => c.IdUser);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListUserDG.ItemsSource = DBEntities.Getcontext().User.Where
                (u => u.LoginUser.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        } 

        private void ListUserDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListUserDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                try
                {
                    User user = ListUserDG.SelectedItem as User;
                    VariableClass.UserId = user.IdUser;
                    NavigationService.Navigate(new EditUserPage(user));
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }        
        }

        private void EditM_Click(object sender, RoutedEventArgs e)
        {
            User user = ListUserDG.SelectedItem as User;
            VariableClass.UserId = user.IdUser;
            NavigationService.Navigate(new EditUserPage(user));
        }

        private void DeleteM_Click(object sender, RoutedEventArgs e)
        {
            User user = ListUserDG.SelectedItem as User;
            DBEntities.Getcontext().User.Remove(user);
            DBEntities.Getcontext().SaveChanges();
            MessageBox.Show("Данные удалены");

            ListUserDG.ItemsSource = DBEntities.Getcontext().User.ToList();
        }
    }
}
