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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
            DGrid.ItemsSource = DiplomEntities2.GetContext().Human.ToList();
          

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd windowadd = new WindowAdd((sender as Button).DataContext as Human);
            windowadd.Show();
            Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd windowadd = new WindowAdd(null);
            windowadd.Show();
            Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var humanForRemoving = DGrid.SelectedItems.Cast<Human>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {humanForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DiplomEntities2.GetContext().Human.RemoveRange(humanForRemoving);
                    DiplomEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid.ItemsSource = DiplomEntities2.GetContext().Human.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DiplomEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid.ItemsSource = DiplomEntities2.GetContext().Human.ToList();
            }
        }
    }
}
