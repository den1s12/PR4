using System;
using System.Windows;
using System.Windows.Controls;

namespace PR8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Num;
        public MainWindow()
        {
            InitializeComponent();
        }

        void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            // MessageBox.Show(pressed.Content.ToString());
            switch (pressed.Content.ToString())
            {
                case "BIN":
                    Num = String.Format("BIN {0:X8}", Convert.ToString(Convert.ToInt32(inNum.Text.ToString()), 2));
                    break;
                case "OCT":
                    Num = String.Format("OCT {0:X8}", Convert.ToString(Convert.ToInt32(inNum.Text.ToString()), 8));
                    //Num=String.format("0x{0:X8}", Num);
                    break;
                case "HEX":
                    Num = String.Format("HEX {0:X8}", Convert.ToString(Convert.ToInt32(inNum.Text.ToString()), 16)); ;
                    break;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            outNum.Text = Num;
        }
    }
}