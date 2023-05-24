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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Guest_Click(object sender, RoutedEventArgs e)
        {
            Goods Goods1= new Goods();
            this.Close();
            Goods1.Show();
        }

        private void Button_Void_Click(object sender, RoutedEventArgs e)
        {
            Trade123Entities db = new Trade123Entities();

            // 1 способ
            var user = db.User.ToList().Find(u => u.UserLogin == TextBox_Login.Text && u.UserPassword == TextBox_Password.Text);

            // 2 способ
            //foreach (var user1 in db.User)
            //{
            //    if (user1.UserLogin == TextBox_Login.Text && user1.UserPassword == TextBox_Password.Text)
            //    {
            //        Goods Goods1 = new Goods();
            //        this.Close();
            //        Goods1.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Неверный логин или пароль");
            //    }
            //}

            if (user != null)
            {
                Goods Goods1 = new Goods();
                this.Close();
                Goods1.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
