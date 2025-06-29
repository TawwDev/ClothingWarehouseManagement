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
using ClothingWarehouseManagement_DAL.Models;
using ClothingWarehouseManagement_DLL.Services;

namespace ASS_ClothingWarehouseManagement
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private ProductService _product = new ProductService();
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbCategory.ItemsSource = _product.GetListCategory();
            cbCategory.DisplayMemberPath = "CategoryName";
            cbCategory.SelectedValuePath = "CategoryId";
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbBrand.Text) || string.IsNullOrWhiteSpace(tbColor.Text) || string.IsNullOrWhiteSpace(tbMaterial.Text) || string.IsNullOrWhiteSpace(tbProductName.Text) || string.IsNullOrWhiteSpace(tbPrice.Text))
            {
                MessageBox.Show("Please ensure all product information is filled out.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            double price;
            if (!double.TryParse(tbPrice.Text, out price))
            {
                MessageBox.Show("Price must be a number!", "Format Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbPrice.Focus();
                return;
            }
            int quantity;
            if (!int.TryParse(tbQuantity.Text, out quantity))
            {
                MessageBox.Show("Quantity must be an integer number!", "Format Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbQuantity.Focus();
                return;
            }

            string brand = tbBrand.Text;
            string color = tbColor.Text;
            string material = tbMaterial.Text;
            string productName = tbProductName.Text;
            int status = cbStatus.Text == "Active" ? 1 : 0;
            string size = cbSize.Text;
            int category = (int)cbCategory.SelectedValue;
            Product p = new Product(productName, category, quantity, size, color, material, price, brand, status);
            _product.CreateProduct(p);
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
