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

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        private Human _currentHuman = new Human();
        public WindowAdd(Human selectHuman)
        {
            InitializeComponent();

            if (selectHuman != null)
                _currentHuman = selectHuman;

            DataContext = _currentHuman;
            ComboStreet.ItemsSource = DiplomEntities2.GetContext().Street.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentHuman.Name))
                Error.AppendLine("Укажите ФИО");
            if (Error.Length > 0)
            {
                MessageBox.Show(Error.ToString());
                return;
            }
            if (_currentHuman.IDHuman == 0)
                DiplomEntities2.GetContext().Human.Add(_currentHuman);
            try
            {
                DiplomEntities2.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Window1 window1 = new Window1();
                window1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Close();


        }
    }
}
