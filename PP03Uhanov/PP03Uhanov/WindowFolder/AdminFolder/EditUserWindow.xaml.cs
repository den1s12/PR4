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
using System.Data.SqlClient;
using PP03Uhanov.ClassFolder;


namespace PP03Uhanov.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        CBClass cB;
        SqlConnection sqlConnection =
        new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                                Initial Catalog=PP03Uhanov;
                                Integrated Security=True");
        SqlCommand SqlCommand;
        SqlDataReader dataReader;
        public EditUserWindow()
        {
            InitializeComponent();
            cB = new CBClass();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cB.RoleCBLoad(RoleCb);
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Select * From dbo.[User] " +
                    $"Where PPUser='{VariableClass.UserId}'",
                    sqlConnection);
                dataReader = SqlCommand.ExecuteReader();
                dataReader.Read();
                LoginTb.Text = dataReader[1].ToString();
                PasswordTb.Text = dataReader[2].ToString();
                RoleCb.SelectedValue = dataReader[3].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand =
                    new SqlCommand("Update " +
                    "dbo.[User] " +
                    $"Set [Login] ='{LoginTb.Text}'," +
                    $"[Password]='{PasswordTb.Text}'," +
                    $"IDRole='{RoleCb.SelectedValue.ToString()}' " +
                    $"Where PPUser='{VariableClass.UserId}'",
                    sqlConnection);
                SqlCommand.ExecuteNonQuery();
                MBClass.InfoMB($"Данные пользователя " +
                    $"{LoginTb.Text} " +
                    $"успешно отредактированы");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new MenuAdminWindow().ShowDialog();
        }
    }
}
