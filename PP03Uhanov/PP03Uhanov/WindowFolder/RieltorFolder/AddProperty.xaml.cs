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
using PP03Uhanov.ClassFolder;
using System.Data.SqlClient;


namespace PP03Uhanov.WindowFolder.RieltorFolder
{
    /// <summary>
    /// Логика взаимодействия для AddProperty.xaml
    /// </summary>
    public partial class AddProperty : Window
    {
        SqlConnection sqlConnection =
          new SqlConnection(@"Data Source=home-pc\sqlexpress;
                                Initial Catalog=PP03Uhanov;
                                Integrated Security=True");
        SqlCommand SqlCommand;
        public AddProperty()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastNameV.Text))
            {
                MBClass.ErrorMB("Не введена фамилия владельца");
                LastNameV.Focus();
            }
            else if (string.IsNullOrWhiteSpace(FirstNameV.Text))
            {
                MBClass.ErrorMB("Не введено имя владельца");
                FirstNameV.Focus();
            }
            else if (string.IsNullOrWhiteSpace(MiddleNameV.Text))
            {
                MBClass.ErrorMB("Не введено отчество владельца");
                MiddleNameV.Focus();
            }
            else if (string.IsNullOrWhiteSpace(LastNameR.Text))
            {
                MBClass.ErrorMB("Не введена фамилия риелтора");
                LastNameR.Focus();
            }
            else if (string.IsNullOrWhiteSpace(FirstNameR.Text))
            {
                MBClass.ErrorMB("Не введено имя риелтора");
                LastNameR.Focus();
            }
            else if (string.IsNullOrWhiteSpace(MiddleNameR.Text))
            {
                MBClass.ErrorMB("Не введено отчество риелтора");
                MiddleNameR.Focus();
            }
            else if (string.IsNullOrWhiteSpace(Value.Text))
            {
                MBClass.ErrorMB("Не указана стоимость собственности");
                Value.Focus();
            }
            else if (string.IsNullOrWhiteSpace(Address.Text))
            {
                MBClass.ErrorMB("Не указан адрес собственности");
                Address.Focus();
            }
            else if (string.IsNullOrWhiteSpace(Jk.Text))
            {
                MBClass.ErrorMB("Не указан ЖК");
                Jk.Focus();
            }
            else if (string.IsNullOrWhiteSpace(QuantityOfRooms.Text))
            {
                MBClass.ErrorMB("Не указано количество комнат");
                QuantityOfRooms.Focus();
            }
            else if (string.IsNullOrWhiteSpace(QuantityOfBathrooms.Text))
            {
                MBClass.ErrorMB("Не указано количество ванных комнат");
                QuantityOfBathrooms.Focus();
            }
            else if (string.IsNullOrWhiteSpace(Lodjia.Text))
            {
                MBClass.ErrorMB("Не указана лоджия (Да/Нет)");
                Lodjia.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TotalArea.Text))
            {
                MBClass.ErrorMB("Не указана общая площадь");
                TotalArea.Focus();
            }
            else if (string.IsNullOrWhiteSpace(LivingArea.Text))
            {
                MBClass.ErrorMB("Не указана жилая площадь");
                LivingArea.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand = new SqlCommand("Insert Into dbo.[Housing] " +
                        "(LastNameV, FirstNameV, MiddleNameV, LastNameR, " +
                        "FirstNameR, MiddleNameR, Value, Address, Jk, " +
                        "QuantityOfRooms, QuantityOfBathrooms, Lodjia, " +
                        "TotalArea, LivingArea) " +
                        $"Values ('{LastNameV.Text}'," +
                        $"'{FirstNameV.Text}'," +
                        $"'{MiddleNameV.Text}'," +
                        $"'{LastNameR.Text}'," +
                        $"'{FirstNameR.Text}'," +
                        $"'{MiddleNameR.Text}'," +
                        $"'{Value.Text}'," +
                        $"'{Address.Text}'," +
                        $"'{Jk.Text}'," +
                        $"'{QuantityOfRooms.Text}'," +
                        $"'{QuantityOfBathrooms.Text}'," +
                        $"'{Lodjia.Text}'," +
                        $"'{TotalArea.Text}'," +
                        $"'{LivingArea.Text}')",
                        sqlConnection);
                    SqlCommand.ExecuteNonQuery();
                    MBClass.InfoMB($"Клиент {LastNameV.Text} " +
                        $"{FirstNameV.Text} успешно добавлен");
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
        }
    

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new RieltorWindow().Show();
            Close();
        }
    }
}
