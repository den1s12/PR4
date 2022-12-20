using PP03Uhanov.ClassFolder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace PP03Uhanov.WindowFolder.RieltorFolder
{
    /// <summary>
    /// Логика взаимодействия для EditProperty.xaml
    /// </summary>
    public partial class EditProperty : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=home-pc\sqlexpress;
                                Initial Catalog=PP03Uhanov;
                                Integrated Security=True");
        SqlCommand SqlCommand;
        SqlDataReader dataReader;
        public EditProperty()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Select * from dbo.[Housing] " +
                    $"Where pp='{VariableClass.CustomerId}'",
                    sqlConnection);
                dataReader = SqlCommand.ExecuteReader();
                dataReader.Read();
                LastNameV.Text = dataReader[1].ToString();
                FirstNameV.Text = dataReader[2].ToString();
                MiddleNameV.Text = dataReader[4].ToString();
                LastNameR.Text = dataReader[3].ToString();
                FirstNameR.Text = dataReader[5].ToString();
                MiddleNameR.Text = dataReader[6].ToString();
                Value.Text = dataReader[7].ToString();
                Address.Text = dataReader[8].ToString();
                Jk.Text = dataReader[9].ToString();
                QuantityOfRooms.Text = dataReader[10].ToString();
                QuantityOfBathrooms.Text = dataReader[11].ToString();
                Lodjia.Text = dataReader[12].ToString();
                TotalArea.Text = dataReader[13].ToString();
                LivingArea.Text = dataReader[14].ToString();
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
                    "dbo.[Housing] " +
                    $"Set LastNameV ='{LastNameV.Text}'," +
                    $"FirstNameV='{FirstNameV.Text}'," +
                    $"MiddleNameV='{MiddleNameV.Text}'," +
                    $"LastNameR='{LastNameR.Text}'," +
                    $"FirstNameR='{FirstNameR.Text}'," +
                    $"MiddleNameR='{MiddleNameR.Text}', " +
                    $"Value='{Value.Text}', " +
                    $"Address='{Address.Text}', " +
                    $"Jk='{Jk.Text}', " +
                    $"QuantityOfRooms='{QuantityOfRooms.Text}', " +
                    $"QuantityOfBathrooms='{QuantityOfBathrooms.Text}', " +
                    $"Lodjia='{Lodjia.Text}', " +
                    $"TotalArea='{TotalArea.Text}', " +
                    $"LivingArea='{LivingArea.Text}' " +
                    $"Where pp='{VariableClass.CustomerId}'",
                    sqlConnection);
                SqlCommand.ExecuteNonQuery();
                MBClass.InfoMB($"Данные пользователя " +
                    $"{LastNameV.Text} {FirstNameV.Text} " +
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
            new RieltorWindow().ShowDialog();
        }
    }
}
