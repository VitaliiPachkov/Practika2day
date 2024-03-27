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
using Pachkov_Auth.Classes;
using Pachkov_Auth.Windows;

namespace Pachkov_Auth.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow auth = new MainWindow();
            auth.Show();
            this.Hide();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {

            var login = LoginBox.Text;

            var pass = PassBox.Text;

            var mail = MailBox.Text;

            var passRepit = PassBoxRepit.Text;

            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(x => (x.Login == login || x.Email == login));

            if (login.Length >= 1)
            {
                if (mail.Contains("@") && mail.Contains("."))
                {
                    if (pass.Length > 6 && pass.Any(char.IsNumber) && pass.Any(char.IsUpper) && pass.Any(char.IsPunctuation))
                    {
                        if (pass == passRepit)
                        {
                            if (user_exists is not null)
                            {
                                ErrorBox.Text = "Такой пользователь уже есть!";
                                ErrorBtn.Visibility = Visibility.Visible;
                                RegBtn.IsEnabled = false;

                                LoginBox.IsEnabled = false;
                                PassBox.IsEnabled = false;
                                MailBox.IsEnabled = false;
                                PassBoxRepit.IsEnabled = false;

                                //MessageBox.Show("Такой пользователь уже есть!");
                                return;
                            }
                            var user = new User { Login = login, Password = pass, Email = mail };
                            context.Users.Add(user);
                            context.SaveChanges();
                            MessageBox.Show("Вы успешно зарегистрировались!");
                            MainWindow auth = new MainWindow();
                            auth.Show();
                            this.Hide();
                        }
                        else
                        {
                            PassColor.BorderThickness = new Thickness(3);
                            PassColor.BorderBrush = Brushes.Red;
                            PassColorRepit.BorderThickness = new Thickness(3);
                            PassColorRepit.BorderBrush = Brushes.Red;

                            LoginBox.IsEnabled = false;
                            PassBox.IsEnabled = false;
                            MailBox.IsEnabled = false;
                            PassBoxRepit.IsEnabled = false;

                            ErrorBox.Text = "Пароли не совпадают!";
                            ErrorBtn.Visibility = Visibility.Visible;
                            RegBtn.IsEnabled = false;

                            //MessageBox.Show("Пароли не совпадают!");
                        }
                    }
                    else
                    {
                        PassColor.BorderThickness = new Thickness(3);
                        PassColor.BorderBrush = Brushes.Red;

                        LoginBox.IsEnabled = false;
                        PassBox.IsEnabled = false;
                        MailBox.IsEnabled = false;
                        PassBoxRepit.IsEnabled = false;

                        ErrorBox.Text = "Требования к паролю:" +
                        "\n• Длина не менее 6 символов" +
                        "\n• Буквы верхнего и нижнего регистра" +
                        "\n• Включать в себя цифры, спец. символы";
                        ErrorBtn.Visibility = Visibility.Visible;
                        RegBtn.IsEnabled = false;


                        //MessageBox.Show("Пароль должен отвечать следующим требованиям:" +
                        //"\n• Длина не менее 6 символов" +
                        //"\n• Буквы верхнего и нижнего регистра" +
                        //"\n• Включать в себя цифры, спец. символы");
                    }
                }

                else
                {
                    MailColor.BorderThickness = new Thickness(3);
                    MailColor.BorderBrush = Brushes.Red;

                    LoginBox.IsEnabled = false;
                    PassBox.IsEnabled = false;
                    MailBox.IsEnabled = false;
                    PassBoxRepit.IsEnabled = false;

                    ErrorBox.Text = "Неверно введен e-mail!";
                    ErrorBtn.Visibility = Visibility.Visible;
                    RegBtn.IsEnabled = false;


                    //MessageBox.Show("Неверно введен e-mail!");
                }

            }
            else
            {
                LoginColor.BorderThickness = new Thickness(3);
                LoginColor.BorderBrush = Brushes.Red;

                LoginBox.IsEnabled = false;
                PassBox.IsEnabled = false;
                MailBox.IsEnabled = false;
                PassBoxRepit.IsEnabled = false;

                ErrorBox.Text = "Логин введен неверно!\nОн должен содержать минимум 1 символ.";
                ErrorBtn.Visibility = Visibility.Visible;
                RegBtn.IsEnabled = false;

                //MessageBox.Show("Логин введен неверно!\nОн должен содержать минимум 1 символ.");
            }

            

        }

        private void ErrorBtn_Click(object sender, RoutedEventArgs e)
        {
            ErrorBox.Text = "";
            ErrorBtn.Visibility = Visibility.Hidden;
            RegBtn.IsEnabled = true;

            LoginColor.BorderBrush = Brushes.Transparent;
            PassColor.BorderBrush = Brushes.Transparent;
            MailColor.BorderBrush = Brushes.Transparent;
            PassColorRepit.BorderBrush = Brushes.Transparent;

            LoginBox.IsEnabled = true;
            PassBox.IsEnabled = true;
            MailBox.IsEnabled = true;
            PassBoxRepit.IsEnabled = true;
        }
    }
}


// BorderBrush="Red" BorderThickness="3"