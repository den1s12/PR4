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
    /// Логика взаимодействия для ListDocumentPage.xaml
    /// </summary>
    public partial class ListDocumentPage : Page
    {
        public ListDocumentPage()
        {
            InitializeComponent();
            ListDocDG.ItemsSource = DBEntities.Getcontext().Document.ToList()
            .OrderBy(c => c.IdDocument);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListDocDG.ItemsSource = DBEntities.Getcontext().Document.Where
                (u => u.LastName.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void ListDocDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListDocDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                try
                {
                    Document document = ListDocDG.SelectedItem as Document;
                    VariableClass.IdDocument = document.IdDocument;
                    NavigationService.Navigate(new EditDocumentPage(document));
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void EditM_Click(object sender, RoutedEventArgs e)
        {
            Document document = ListDocDG.SelectedItem as Document;
            VariableClass.IdDocument = document.IdDocument;
            NavigationService.Navigate(new EditDocumentPage(document));
        }

        private void DeleteM_Click(object sender, RoutedEventArgs e)
        {
            Document document = ListDocDG.SelectedItem as Document;
            DBEntities.Getcontext().Document.Remove(document);
            DBEntities.Getcontext().SaveChanges();
            MessageBox.Show("Данные удалены");

            ListDocDG.ItemsSource = DBEntities.Getcontext().User.ToList();
        }
    }
}
