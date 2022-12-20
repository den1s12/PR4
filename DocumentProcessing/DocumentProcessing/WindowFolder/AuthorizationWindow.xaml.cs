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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void LogInBTN_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordPB.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordPB.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.Getcontext().User.FirstOrDefault
                       (u => u.LoginUser == LoginTB.Text);
                    if (user == null)
                    {
                        MBClass.ErrorMB("Пользователь не найден");
                        LoginTB.Focus();
                        return;
                    }
                    if (user.PasswordUser != PasswordPB.Password)
                    {
                        MBClass.ErrorMB("Введен неправильный пароль");
                        PasswordPB.Focus();
                        return;
                    }
                    else
                    {
                        switch (user.IdRole)
                        {
                            case 1:
                                new AdminWindow().ShowDialog();
                                break;
                            case 2:
                                new MainWindow().ShowDialog();
                                break;                          
                        }
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
               
            }
        }

        private void RegistrationTB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new RegistrationWindow().ShowDialog();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
