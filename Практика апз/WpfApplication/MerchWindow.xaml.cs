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
    /// Логика взаимодействия для MerchWindow.xaml
    /// </summary>
    public partial class MerchWindow : Window
    {
        public MerchWindow()
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
            WpfApplication.defaultDataSetTableAdapters.ТоварTableAdapter defaultDataSetТоварTableAdapter = new WpfApplication.defaultDataSetTableAdapters.ТоварTableAdapter();
            defaultDataSetТоварTableAdapter.Fill(defaultDataSet.Товар);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //сохраняем данные в таблице
            WpfApplication.defaultDataSet defaultDataSet = ((WpfApplication.defaultDataSet)(this.FindResource("defaultDataSet")));
            WpfApplication.defaultDataSetTableAdapters.ТоварTableAdapter defaultDataSetТоварTableAdapter = new WpfApplication.defaultDataSetTableAdapters.ТоварTableAdapter();
            defaultDataSetТоварTableAdapter.Update(defaultDataSet.Товар);
            defaultDataSetТоварTableAdapter.Fill(defaultDataSet.Товар);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //удаляем текщую строчку
            System.Windows.Data.CollectionViewSource товарViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("товарViewSource")));
            DataRowView drw = товарViewSource.View.CurrentItem as DataRowView;
            if (drw == null)
                return;
            drw.Delete();
        }
    }
}
