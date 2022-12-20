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


namespace PP03Uhanov.WindowFolder.RieltorFolder
{
    /// <summary>
    /// Логика взаимодействия для RieltorWindow.xaml
    /// </summary>
    public partial class RieltorWindow : Window
    {
        DGClass dGClass;

        public RieltorWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ListUserDG);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("Select * From dbo.[Housing]");
        }

        private void AddIm_Click(object sender, RoutedEventArgs e)
        {
            new AddProperty().ShowDialog();
        }

        private void EditIm_Click(object sender, RoutedEventArgs e)
        {
            new EditProperty().ShowDialog();
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
                    VariableClass.CustomerId = dGClass.SelectId();
                    new EditProperty().ShowDialog();
                    dGClass.LoadDG("Select * From dbo.[Housing]");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDG("Select * From dbo.[Housing] " +
                $"Where LastNameV Like '%{SearchTb.Text}%' " +
                $"OR FirstNameV Like '%{SearchTb.Text}%' " +
                $"OR MiddleNameV Like '%{SearchTb.Text}%'");
        }

        private void ExitIm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
