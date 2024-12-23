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
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //обновление данных
            WpfApplication.defaultDataSet defaultDataSet = ((WpfApplication.defaultDataSet)(this.FindResource("defaultDataSet")));
            WpfApplication.defaultDataSetTableAdapters.ПользовательTableAdapter defaultDataSetПользовательTableAdapter = new WpfApplication.defaultDataSetTableAdapters.ПользовательTableAdapter();
            defaultDataSetПользовательTableAdapter.Fill(defaultDataSet.Пользователь);
            WpfApplication.defaultDataSetTableAdapters.СтатусTableAdapter defaultDataSetСтатусTableAdapter = new WpfApplication.defaultDataSetTableAdapters.СтатусTableAdapter();
            defaultDataSetСтатусTableAdapter.Fill(defaultDataSet.Статус);
            //обновление данных
            Button_Click_4(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button_Click_4(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Сохранение даных
            WpfApplication.defaultDataSet defaultDataSet = ((WpfApplication.defaultDataSet)(this.FindResource("defaultDataSet")));
            WpfApplication.defaultDataSetTableAdapters.ЗаказTableAdapter defaultDataSetЗаказTableAdapter = new WpfApplication.defaultDataSetTableAdapters.ЗаказTableAdapter();
            defaultDataSetЗаказTableAdapter.Update(defaultDataSet.Заказ);
            //обновление данных
            Button_Click_4(sender, e);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //удаление данных
            System.Windows.Data.CollectionViewSource заказViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("заказViewSource")));
            DataRowView drw = заказViewSource.View.CurrentItem as DataRowView;
            if (drw == null)
                return;
            drw.Delete();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //обновление данных
            WpfApplication.defaultDataSet defaultDataSet = ((WpfApplication.defaultDataSet)(this.FindResource("defaultDataSet")));
            WpfApplication.defaultDataSetTableAdapters.ЗаказTableAdapter defaultDataSetЗаказTableAdapter = new WpfApplication.defaultDataSetTableAdapters.ЗаказTableAdapter();
            defaultDataSetЗаказTableAdapter.Fill(defaultDataSet.Заказ);
            //подготовка фильтра
            String FilterString;
            FilterString = "SELECT        Заказ.ЗаказНомер, Заказ.ДатаЗаказа, Заказ.ПользовательНомер, Заказ.Примечание, Заказ.СтатусНомер,                             (SELECT        SUM(Товар.Цена * ТоварЗаказ.Количество) AS Expr1                               FROM            ТоварЗаказ INNER JOIN                                                         Товар ON ТоварЗаказ.ТоварНомер = Товар.ТоварНомер                               WHERE(ТоварЗаказ.ЗаказНомер = Заказ.ЗаказНомер)) AS Сумма, Пользователь.ФИО, Статус.Статус FROM            Заказ INNER JOIN                 Пользователь ON Заказ.ПользовательНомер = Пользователь.ПользовательНомер INNER JOIN                         Статус ON Заказ.СтатусНомер = Статус.СтатусНомер WHERE ЗаказНомер=ЗаказНомер ";

            //учет параметров
            if (ComboBox1.Text.Trim() != "")
                FilterString = FilterString + " and Заказ.ПользовательНомер LIKE " + ComboBox1.SelectedValue;

            if (ComboBox2.Text.Trim() != "")
                FilterString = FilterString + " and Заказ.СтатусНомер LIKE " + ComboBox2.SelectedValue;

            if (DataPicker1.Text.Trim() != "")
                FilterString = FilterString + " and ДатаЗаказа >= '" + DataPicker1.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";

            if (DataPicker2.Text.Trim() != "")
                FilterString = FilterString + " and ДатаЗаказа <= '" + DataPicker2.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";

            //присвоение фильтра
            defaultDataSetЗаказTableAdapter.Adapter.SelectCommand.CommandText = FilterString;
            //загрузка данных
            defaultDataSetЗаказTableAdapter.Fill(defaultDataSet.Заказ);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //очистка параметров фильтра
            ComboBox1.Text = "";
            ComboBox2.Text = "";
            DataPicker1.Text = "";
            DataPicker2.Text = "";
            //обновление данных
            Button_Click_4(sender, e);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            {// создаем приложение Excel 
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // создаем новую книгу 
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // создаем новый лист 
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // приложение видимо 
                app.Visible = true;
                // связь с листом 
                worksheet = workbook.ActiveSheet;


                // переименование листа 
                worksheet.Name = "Заказы от " + DateTime.Now.ToString("yyyy-MM-dd");
                worksheet.Cells[1, 1] = "Заказы от " + DateTime.Now.ToString("yyyy-MM-dd");

                int offset = 3;
                int i, count;
                String temp;


                // выводим заголовок 
                worksheet.Cells[offset, 1] = "Номер";
                worksheet.Cells[offset, 2] = "Менеджер";
                worksheet.Cells[offset, 3] = "Дата заказа";
                worksheet.Cells[offset, 4] = "Статус";
                worksheet.Cells[offset, 5] = "Примечание";
                worksheet.Cells[offset, 6] = "Сумма";

                /* 
                for ( i = 1; i < заказDataGrid.Columns.Count + 1; i++)
                { worksheet.Cells[offset, i] = заказDataGrid.Columns[i - 1].Header; }
               */

                // экспорт данных                 
                System.Windows.Data.CollectionViewSource заказViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("заказViewSource")));
                заказViewSource.View.MoveCurrentToFirst();
                count = заказViewSource.View.SourceCollection.Cast<object>().Count();
                for (i = 0; i < count; i++)
                {
                    DataRowView drw = заказViewSource.View.CurrentItem as DataRowView;
                    temp = drw["ЗаказНомер"].ToString();//drw[4].ToString();
                    worksheet.Cells[i + 1 + offset, 1] = temp;
                    temp = drw["ФИО"].ToString();
                    worksheet.Cells[i + 1 + offset, 2] = temp;
                    DateTime d = (DateTime)drw["ДатаЗаказа"];
                    temp = d.ToString("yyyy-MM-dd");
                    worksheet.Cells[i + 1 + offset, 3] = temp;
                    temp = drw["Статус"].ToString();
                    worksheet.Cells[i + 1 + offset, 4] = temp;
                    temp = drw["Примечание"].ToString();
                    worksheet.Cells[i + 1 + offset, 5] = temp;
                    temp = drw["Сумма"].ToString();
                    worksheet.Cells[i + 1 + offset, 6] = temp;
                    заказViewSource.View.MoveCurrentToNext();
                }


                worksheet.Range["A" + offset.ToString() + ":F" + Convert.ToString(offset + count)].Borders.LineStyle = 1;

                // устанавливаем жирный шрифт для заголовков 
                (worksheet.Rows[1, Type.Missing]).Font.Bold = true;
                (worksheet.Rows[3, Type.Missing]).Font.Bold = true;
                (worksheet.Rows[i + 1 + offset, Type.Missing]).Font.Bold = true;
                // авто-размер столбцов 
                worksheet.Columns.AutoFit();



                // сохранение файла 
                workbook.SaveAs("Заказы.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            }
        }


        private void заказDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //учет значений по умолчанию, если они не были указаны
            System.Windows.Data.CollectionViewSource заказViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("заказViewSource")));
            DataRowView drw = заказViewSource.View.CurrentItem as DataRowView;
            if (drw == null)
                return;
            if (drw["СтатусНомер"].ToString() == "")
                drw["СтатусНомер"] = "1";
            if (drw["ДатаЗаказа"].ToString() == "")
                drw["ДатаЗаказа"] = DateTime.Today.ToShortDateString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //открываем окно с товарми выбранного заказа
            MerchOrderWindow newForm = new MerchOrderWindow();
            System.Windows.Data.CollectionViewSource заказViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("заказViewSource")));
            //считываем выбранный номер заказа
            DataRowView drw = заказViewSource.View.CurrentItem as DataRowView;
            if (drw == null)
                return;
            //передаем номер заказа в окно с товарми выбранного заказа
            newForm.idorder = drw["ЗаказНомер"].ToString();
            //именуем окно
            newForm.Title = "Товары заказа №" + drw["ЗаказНомер"].ToString();
            newForm.Show();
        }


    }
}
