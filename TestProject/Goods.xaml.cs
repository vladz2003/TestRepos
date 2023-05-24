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

namespace TestProject
{
    /// <summary>
    /// Логика взаимодействия для Goods.xaml
    /// </summary>
    public partial class Goods : Window
    {
        List<Order> _orders;
        private object _db;

        public Goods()
        {
            InitializeComponent();
            Trade123Entities db = new Trade123Entities();
            _orders = db.Order.ToList();
            DG_Orders.ItemsSource = _orders;

            ComboBoxSort.ItemsSource = new List<string>
            {
                "По умолчанию",
                "По возрастанию",
                "По убыванию"
            };

            ComboBoxSort.SelectedIndex = 0;
        }

        private void TextBox_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            SortOrders();
        }

        private void ComboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortOrders();
        }

        private void SortOrders()
        {
            var sorted = _orders;

            sorted = SortByPrice(sorted);
            sorted = SearchByText(sorted);

            DG_Orders.ItemsSource = sorted;
        }

        private List<Order> SearchByText(List<Order> orders)
        {
            return orders.FindAll(order => order.OrderID.ToString().Contains(TextBox_Search.Text));
        }

        private List<Order> SortByPrice(List<Order> orders)
        {
            switch (ComboBoxSort.SelectedIndex)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        orders = orders.OrderBy(o => o.OrderID).ToList();
                        break;
                    }
                case 2:
                    {
                        orders = orders.OrderByDescending(o => o.OrderID).ToList();
                        break;
                    }
            }

            return orders;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Edit Edit1 = new Edit();
            this.Close();
            Edit1.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow1 = new AddWindow();
            this.Close();
            addWindow1.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using(Trade123Entities db = new Trade123Entities())
            {
                var selectedOrders = (sender as Button).DataContext as Order;
                db.Order.Remove(selectedOrders);
                _orders.Remove(selectedOrders);
                db.SaveChanges();
            }
        }

    }
}
