using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //обновить данные при загрузки
            Button_Click(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //обновляем данные в таблице
            WpfApplication.defaultDataSet defaultDataSet = ((WpfApplication.defaultDataSet)(this.FindResource("defaultDataSet")));
            WpfApplication.defaultDataSetTableAdapters.ПользовательTableAdapter defaultDataSetПользовательTableAdapter = new WpfApplication.defaultDataSetTableAdapters.ПользовательTableAdapter();
            defaultDataSetПользовательTableAdapter.Fill(defaultDataSet.Пользователь);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //сохраняем данные в таблице
            WpfApplication.defaultDataSet defaultDataSet = ((WpfApplication.defaultDataSet)(this.FindResource("defaultDataSet")));
            WpfApplication.defaultDataSetTableAdapters.ПользовательTableAdapter defaultDataSetПользовательTableAdapter = new WpfApplication.defaultDataSetTableAdapters.ПользовательTableAdapter();
            defaultDataSetПользовательTableAdapter.Update(defaultDataSet.Пользователь);
            defaultDataSetПользовательTableAdapter.Fill(defaultDataSet.Пользователь);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //удаляем текщую строчку
            System.Windows.Data.CollectionViewSource пользовательViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("пользовательViewSource")));
            DataRowView drw = пользовательViewSource.View.CurrentItem as DataRowView;
            if (drw == null)
                return;
            drw.Delete();
        }
    }
}
