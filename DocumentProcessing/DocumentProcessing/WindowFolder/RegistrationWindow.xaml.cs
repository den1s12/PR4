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
using System.Windows.Shapes;

namespace DocumentProcessing.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void RegBTN_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите логин");
            }
            else if (PasswordPB.Password == String.Empty)
            {
                MBClass.ErrorMB("Введите пароль");
            }
            else
            {
                AddUser();
                MBClass.InfoMB("Пользователь зарегистрирован");
                this.Close();
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void AddUser()
        {
            DBEntities.Getcontext().User.Add(new User()
            {
                LoginUser = LoginTB.Text,
                PasswordUser = PasswordPB.Password,
                IdRole = 2
            });
            DBEntities.Getcontext().SaveChanges();
        }
    }
}
