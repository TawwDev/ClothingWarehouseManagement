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
    /// Interaction logic for UpdateProductWindow.xaml
    /// </summary>
    public partial class UpdateProductWindow : Window
    {
        public Product ProductToUpdate { get; set; }
        private ProductService _productService;
        public UpdateProductWindow()
        {
            InitializeComponent();
        }
        public UpdateProductWindow(Product product, ProductService productService)
        {
            InitializeComponent();
            ProductToUpdate = product;
            _productService = productService;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ProductToUpdate != null)
            {
                tbProductId.Text = ProductToUpdate.ProductId.ToString();
                tbProductName.Text = ProductToUpdate.ProductName;
                tbPrice.Text = ProductToUpdate.Price.ToString();
                tbBrand.Text = ProductToUpdate.Brand;
                tbColor.Text = ProductToUpdate.Color;
                tbMaterial.Text = ProductToUpdate.Material;
                tbQuantity.Text = ProductToUpdate.Quantity.ToString();
                cbSize.Text = ProductToUpdate.Size;
                cbStatus.SelectedIndex = ProductToUpdate.Status == 1 ? 0 : 1;

                cbCategory.ItemsSource = _productService.GetListCategory();
                cbCategory.DisplayMemberPath = "CategoryName";
                cbCategory.SelectedValuePath = "CategoryId";
                cbCategory.SelectedValue = ProductToUpdate.CategoryId;
            }
        }
        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
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
            int productId;
            bool IsProductId = int.TryParse(tbProductId.Text, out productId);
            ProductToUpdate.ProductName = tbProductName.Text;
            ProductToUpdate.Price = price;
            ProductToUpdate.Brand = tbBrand.Text;
            ProductToUpdate.Color = tbColor.Text;
            ProductToUpdate.Material = tbMaterial.Text;
            ProductToUpdate.Quantity = quantity;
            ProductToUpdate.Size = cbSize.Text;
            ProductToUpdate.Status = cbStatus.Text == "Active" ? 1 : 0;
            ProductToUpdate.CategoryId = (int)cbCategory.SelectedValue;
            _productService.UpdateProduct(ProductToUpdate);
            this.DialogResult = true;
            this.Close();
        }

        private void btnUpdateCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
