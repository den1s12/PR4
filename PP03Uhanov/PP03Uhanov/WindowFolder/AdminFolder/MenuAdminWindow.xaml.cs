using PP03Uhanov.ClassFolder;
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

namespace PP03Uhanov.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuAdminWindow.xaml
    /// </summary>
    public partial class MenuAdminWindow : Window
    {
        DGClass dGClass;
        public MenuAdminWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ListUserDG);
        }

        private void AddIm_Click(object sender, RoutedEventArgs e)
        {
            new AddUserWindow().ShowDialog();
            dGClass.LoadDG("Select * From dbo.[User]");
            Close();
        }

        private void ListUserDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListUserDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                VariableClass.UserId = dGClass.SelectId();
                try
                {             
                    new EditUserWindow().ShowDialog();
                    dGClass.LoadDG("Select * From dbo.[User]");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDG("Select * From dbo.[User] " +
               $"Where Login Like '%{SearchTb.Text}%' " +
               $"OR IDRole Like '%{SearchTb.Text}%'");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("Select * From dbo.[User]");
        }

        private void EditIm_Click(object sender, RoutedEventArgs e)
        {
            new EditUserWindow().ShowDialog();
            dGClass.LoadDG("Select * From dbo.[User]");
            Close();
        }

        private void BackIm_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow window = new AuthorizationWindow();
            window.ShowDialog();
        }

        private void ExitIm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
