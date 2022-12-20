using System;
using System.Collections.Generic;
using System.Linq;
using DocumentProcessing.DataFolder;
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
using DocumentProcessing.ClassFolder;

namespace DocumentProcessing.PageFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для EditDocumentPage.xaml
    /// </summary>
    public partial class EditDocumentPage : Page
    {
        public EditDocumentPage(Document document)
        {
            InitializeComponent();
            DataContext = document;
            OpenInsurance.ItemsSource = DBEntities.Getcontext()
                .OpenInsurance.ToList();
        }

        private void EditDocBtn_Click(object sender, RoutedEventArgs e)
        {
            Document document = DBEntities.Getcontext().Document.
              FirstOrDefault(s => s.IdDocument == VariableClass.IdDocument);
            document.LastName = LastName.Text;
            document.FirstName = FirstName.Text;
            document.MiddleName = MiddleName.Text;
            document.SerialPassport = SerialPassport.Text;
            document.NumberPassport = NumberPassport.Text;
            document.DateOfInsurence = Convert.ToDateTime(DateOfInsurence.Text);
            document.DriverLicense = DriverLicense.Text;
            document.PhoneNumber = PhoneNumber.Text;
            document.EmailAddress = EmailAddress.Text;
            document.SerialCTC = SerialCTC.Text;
            document.NumberCTC = NumberCTC.Text;
            document.IdOpenInsurance = Int32.Parse(OpenInsurance.SelectedValue.ToString());
            DBEntities.Getcontext().SaveChanges();
            MBClass.InfoMB("Пользователь успешно отредактирован");
            NavigationService.Navigate(new ManagerFolder.ListDocumentPage());
        }
    }
}
