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

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text.Length > 0)
            {
                if (password.Password.Length > 0)
                {
                    if (login.Text == "Admin")
                    {
                        if (password.Password == "12345678")
                        {
                            Window1 window1 = new Window1();
                            window1.Show();

                            Close();
                        }
                    }
                   

                }
            }
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Подсказка для пользователя");
        }
    }

   
}
