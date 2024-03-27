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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string UserLogin1 { get; }
        public int _id;
       

        public Window1(string UserLogin1, int id)
        {
            InitializeComponent();
            //UserLogin.Text = "Здравствуйте, " + UserLogin1;
           // UserLogin2.Text = Convert.ToString(id);

            _id = id;

            int find = id;

            var context = new AppDbContext();

            var user = context.Users.SingleOrDefault(x => x.Id == id);

            string Finde = user.Login;

            UserLogin.Text = "Здравствуйте, " + Finde + "!";
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            int ide = _id;
            profile profile = new profile(UserLogin1, ide);
            profile.Show();
            this.Hide();
        }
    }
}
