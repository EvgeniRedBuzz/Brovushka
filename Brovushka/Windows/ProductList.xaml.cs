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
using Brovushka.EF;
using Brovushka.Windows;
using static Brovushka.EF.AppData;

namespace Brovushka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        List<Product> products = new List<Product>();
        List<Manufacturer> manufacturers = new List<Manufacturer>();
        List<string> orderCost = new List<string>();
        int maxcountproduct = context.Product.ToList().Count();

        public ProductList()
        {
            InitializeComponent();
            manufacturers = context.Manufacturer.ToList();
            manufacturers.Insert(0, new Manufacturer() { Name = "Все" });
            CmbManufacturer.ItemsSource = manufacturers;
            CmbManufacturer.DisplayMemberPath = "Name";
            CmbManufacturer.SelectedIndex = 0;
            orderCost.Insert(0, "По увеличению");
            orderCost.Insert(1, "По уменьшению");
            CmbCost.ItemsSource = orderCost;
            CmbCost.SelectedIndex = 0;
            CountProduct2.Text = maxcountproduct.ToString();
            Filter();
        }

        private void Filter()
        {
            products = context.Product.ToList();

            products = products.Where(i =>
            i.Title.Contains(SearchNameProduct.Text) &&
            i.Description.Contains(SearchDescription.Text)).ToList();

            if(CmbManufacturer.SelectedIndex != 0)
            {
                products = products.Where(i => i.ManufacturerID ==
                CmbManufacturer.SelectedIndex).ToList();
            }

            switch(CmbCost.SelectedIndex)
            {
                case 0:
                    products = products.OrderBy(i => i.Cost).ToList();
                    break;
                case 1:
                    products = products.OrderByDescending(i => i.Cost).ToList();
                    break;
            }

            CountProduct.Text = products.Count().ToString();
            LvProductList.ItemsSource = products;
        }

        private void SearchNameProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void SearchDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void CmbManufacturer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            SearchNameProduct.Clear();
            SearchDescription.Clear();
            CmbManufacturer.SelectedIndex = 0;
            CmbCost.SelectedIndex = 0;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEditProduct addEditProduct = new AddEditProduct();
            this.Hide();
            addEditProduct.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AddEditProduct addEditProduct = new AddEditProduct();
            this.Hide();
            addEditProduct.Show();
            this.Close();
        }
    }
}
