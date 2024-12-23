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
    /// Логика взаимодействия для MerchOrderWindow.xaml
    /// </summary>
    public partial class MerchOrderWindow : Window
    {
        public String idorder;

        public MerchOrderWindow()
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
            //обновление данных
            WpfApplication.defaultDataSet defaultDataSet = ((WpfApplication.defaultDataSet)(this.FindResource("defaultDataSet")));
            WpfApplication.defaultDataSetTableAdapters.ТоварЗаказTableAdapter defaultDataSetТоварЗаказTableAdapter = new WpfApplication.defaultDataSetTableAdapters.ТоварЗаказTableAdapter();
            defaultDataSetТоварЗаказTableAdapter.Fill(defaultDataSet.ТоварЗаказ);
            String FilterString;
            FilterString = "SELECT        ТоварЗаказ.ТоварЗаказНомер, ТоварЗаказ.ТоварНомер, ТоварЗаказ.ЗаказНомер, ТоварЗаказ.Количество, Товар.Цена, Товар.Цена * ТоварЗаказ.Количество AS Сумма FROM ТоварЗаказ INNER JOIN                         Товар ON ТоварЗаказ.ТоварНомер = Товар.ТоварНомер";

            //учет номер заказа
            FilterString = FilterString + " WHERE ТоварЗаказ.ЗаказНомер= " + idorder;

            //присвоение фильтра
            defaultDataSetТоварЗаказTableAdapter.Adapter.SelectCommand.CommandText = FilterString;
            //загрузка данных
            defaultDataSetТоварЗаказTableAdapter.Fill(defaultDataSet.ТоварЗаказ);

            //обновление данных
            WpfApplication.defaultDataSetTableAdapters.ТоварTableAdapter defaultDataSetТоварTableAdapter = new WpfApplication.defaultDataSetTableAdapters.ТоварTableAdapter();
            defaultDataSetТоварTableAdapter.Fill(defaultDataSet.Товар);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //обновление даных
            WpfApplication.defaultDataSet defaultDataSet = ((WpfApplication.defaultDataSet)(this.FindResource("defaultDataSet")));
            WpfApplication.defaultDataSetTableAdapters.ТоварЗаказTableAdapter defaultDataSetТоварЗаказTableAdapter = new WpfApplication.defaultDataSetTableAdapters.ТоварЗаказTableAdapter();
            defaultDataSetТоварЗаказTableAdapter.Update(defaultDataSet.ТоварЗаказ);
            Button_Click(sender, e);
        }

        private void товарDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //вставка номера заказа при редактировании
            System.Windows.Data.CollectionViewSource товарЗаказViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("товарЗаказViewSource")));
            DataRowView drw = товарЗаказViewSource.View.CurrentItem as DataRowView;
            if (drw == null)
                return;
            if (drw["ЗаказНомер"].ToString() == "")
                drw["ЗаказНомер"] = idorder;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //удаление данных
            System.Windows.Data.CollectionViewSource товарЗаказViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("товарЗаказViewSource")));
            DataRowView drw = товарЗаказViewSource.View.CurrentItem as DataRowView;
            if (drw == null)
                return;
            drw.Delete();
        }
    }
}
