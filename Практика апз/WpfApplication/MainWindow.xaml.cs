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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String iduser;

        public MainWindow()
        {
            InitializeComponent();
        }

        //обработка кнопок меню - открываем соответствующее окно
        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            MerchWindow newForm = new MerchWindow();
            newForm.Show();
        }
        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            UserWindow newForm = new UserWindow();
            newForm.Show();
        }
        private void MenuItem3_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow newForm = new OrderWindow();
            newForm.Show();
        }


        private void MenuItem6_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //обработка авторизации
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            //подключение к БД с помощью строки подключения из app.config
            using (SqlConnection con = new SqlConnection(WpfApplication.Properties.Settings.Default.defaultConnectionString))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    //открываем соединение
                    con.Open();
                    com.Connection = con;
                    //делаем выборку пользователей с введнным логином и паролем
                    com.CommandText = "select ФИО, Права, ПользовательНомер from Пользователь where Логин = @Логин and Пароль = @Пароль";
                    //вставляем параметры из окон ввода
                    com.Parameters.AddWithValue("@Логин", textBox.Text);
                    com.Parameters.AddWithValue("@Пароль", passwordBox.Password);
                    //выполняем запрос на выбору
                    SqlDataReader reader = com.ExecuteReader();
                    //очищаем поля ввода
                    textBox.Clear();
                    passwordBox.Clear();
                    //если есть результат выборки
                    if (reader.HasRows)
                    {
                        //читаем данные
                        reader.Read();
                        //считываем ПользовательНомер
                        iduser = reader.GetValue(2).ToString();
                        //даем форме новое имя с учетом полей ФИО и Права
                        this.Title = "Продажа счетчиков (" + reader.GetValue(0).ToString() + ", " + reader.GetValue(1).ToString() + ")";

                        //если админ
                        if (reader.GetValue(1).ToString() == "Администратор")
                        {
                            //открываем соответственное меню
                            MainMenu1.Visibility = Visibility.Visible;
                            MainMenu2.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            //иначе открываем другое меню
                            MainMenu1.Visibility = Visibility.Hidden;
                            MainMenu2.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        //нет пользователей с введенными логином и паролем
                        MessageBox.Show("Введена неверная пара логин/пароль!", "Ошибка авторизации");
                    }
                    //закрываем соединение
                    com.Dispose();
                    con.Close();
                }
            }

        }




    }
}
