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

namespace DocumentProcessing.PageFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для AddDocumentPage.xaml
    /// </summary>
    public partial class AddDocumentPage : Page
    {
        public AddDocumentPage()
        {
            InitializeComponent();
            OpenInsurance.ItemsSource = DBEntities.Getcontext()
                .OpenInsurance.ToList();
        }

        private void AddDocBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LastName.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер дома");
            }
            else if (LastName.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер");
            }
            else if (MiddleName.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите общую");
            }
            else if (SerialPassport.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер");
            }
            else if (NumberPassport.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер");
            }
            else if (DateOfInsurence.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер");
            }
            else if (DriverLicense.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер");
            }
            else if (PhoneNumber.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер");
            }
            else if (EmailAddress.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер");
            }
            else if (SerialCTC.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер");
            }
            else if (NumberCTC.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер");
            }
            
            else
            {
                AddUser();
                MBClass.InfoMB("Данные добавлены");
                NavigationService.Navigate(new ManagerFolder.ListDocumentPage());
            }
        }
        private void AddUser()
        {
            DBEntities.Getcontext().Document.Add(new Document()
            {
                LastName = LastName.Text,
                FirstName = FirstName.Text,
                MiddleName = MiddleName.Text,
                SerialPassport = SerialPassport.Text,
                NumberPassport = NumberPassport.Text,
                DateOfInsurence = Convert.ToDateTime(DateOfInsurence.Text),
                DriverLicense = NumberPassport.Text,
                PhoneNumber = NumberPassport.Text,
                EmailAddress = NumberPassport.Text,
                SerialCTC = NumberPassport.Text,
                NumberCTC = NumberPassport.Text,
                IdOpenInsurance = Int32.Parse(OpenInsurance.SelectedValue.ToString())                
            });
            DBEntities.Getcontext().SaveChanges();
        }

    }
}
