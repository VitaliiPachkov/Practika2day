using Microsoft.Identity.Client;
using Pachkov_Auth.Classes;
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

namespace Pachkov_Auth.Windows
{
    /// <summary>
    /// Логика взаимодействия для profile.xaml
    /// </summary>
    public partial class profile : Window
    {
        public string UserLogin1 { get; }
        public int ide = new int();


        public profile(string UserLogin1, int id)
        {

            InitializeComponent();

            ide = id;

            var context = new AppDbContext();

            var user = context.Users.SingleOrDefault(x => x.Id == ide);

            string x = Convert.ToString(ide);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            string EMail = Mail.Text;


            if (Password.Text.Length <= 0 && Mail.Text.Length <= 0)
            {
                
                MessageBox.Show("Вы ничего не ввели!");
            }
            else
            {
                if (Password.Text.Length>=1 && Mail.Text.Length <= 0)
                {
                    if (Password.Text.Length > 6 && Password.Text.Any(char.IsNumber) && Password.Text.Any(char.IsUpper) && Password.Text.Any(char.IsPunctuation))
                    {
                        var userId = Convert.ToInt32( ide);

                        var context = new AppDbContext();

                        var user = context.Users.Find(userId);

                        string Passik = Password.Text;

                        user.Password = Passik;
                        context.SaveChanges();

                        MessageBox.Show("Пароль успешно поменен!");
                    }
                    else
                    {
                        MessageBox.Show("Пароль должен отвечать следующим требованиям:" +
                        "\n• Длина не менее 6 символов" +
                        "\n• Буквы верхнего и нижнего регистра" +
                        "\n• Включать в себя цифры, спец. символы");
                    }
                }
                if (Password.Text.Length <= 0 && Mail.Text.Length >=1)
                {
                    if (Mail.Text.Contains("@") && Mail.Text.Contains("."))
                    {
                        var userId = Convert.ToInt32(ide);

                        var context = new AppDbContext();

                        var user = context.Users.Find(userId);

                        string Milo = Mail.Text;

                        user.Email = Milo;
                        context.SaveChanges();

                        MessageBox.Show("Почта успешно изменена!");
                    }
                    else
                    {
                        MessageBox.Show("Неверно введен e-mail!");
                    }
                }
                if (Password.Text.Length >= 1 && Mail.Text.Length >=1)
                {
                    if (Password.Text.Length > 6 && Password.Text.Any(char.IsNumber) && Password.Text.Any(char.IsUpper) && Password.Text.Any(char.IsPunctuation))
                    {
                        if (Mail.Text.Contains("@") && Mail.Text.Contains("."))
                        {
                            var userId = ide;

                            var context = new AppDbContext();

                            var user = context.Users.SingleOrDefault(x => x.Id == ide);

                            user.Password = Password.Text;
                            user.Email = Mail.Text;
                            context.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Неверно введен e-mail!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль должен отвечать следующим требованиям:" +
                        "\n• Длина не менее 6 символов" +
                        "\n• Буквы верхнего и нижнего регистра" +
                        "\n• Включать в себя цифры, спец. символы");
                    }
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1(UserLogin1, ide);
            window1.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
