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
using ClothingWarehouseManagement_DAL.Models;
using ClothingWarehouseManagement_DLL.Services;

namespace ASS_ClothingWarehouseManagement.view
{
    /// <summary>
    /// Interaction logic for ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        private ProductService _product = new ProductService();
        public ProductListPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dgProduct.ItemsSource = null;
            dgProduct.ItemsSource = _product.GetListProduct();
            
            cbCategory.ItemsSource = null;
            List<Category> categories = _product.GetListCategory();
            categories.Insert(0, new Category { CategoryId = 0, CategoryName = "--- All Category ---" });
            cbCategory.ItemsSource = categories;
            cbCategory.DisplayMemberPath = "CategoryName";
            cbCategory.SelectedValuePath = "CategoryId";
            cbCategory.SelectedIndex = 0;
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (cbCategory.SelectedItem != null)
            {
                int categoryId = (int)cbCategory.SelectedValue;
                if (categoryId == 0)
                {
                    dgProduct.ItemsSource = null;
                    dgProduct.ItemsSource = _product.GetListProduct();
                }
                else
                {
                    dgProduct.ItemsSource = null;
                    dgProduct.ItemsSource = _product.GetListProductByCategoryId(categoryId);
                }    
            }
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            Opacity = 0.4;
            bool? result = addProductWindow.ShowDialog();
            Opacity = 1;
            if (result == true)
            {

                MessageBox.Show("Add success!!", "Product list will be refreshed.", MessageBoxButton.OK);
                dgProduct.ItemsSource = null;
                dgProduct.ItemsSource = _product.GetListProduct();

            }
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dgProduct.SelectedItem as Product;

            if (selectedProduct == null)
            {
                MessageBox.Show("Please select a product to edit.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            UpdateProductWindow updateProductWindow = new UpdateProductWindow(selectedProduct, _product);
            Opacity = 0.4;
            bool? result = updateProductWindow.ShowDialog();
            Opacity = 1;
            if (result == true)
            {
                MessageBox.Show("Update success!!", "Product list will be refreshed.", MessageBoxButton.OK);
                dgProduct.ItemsSource = null;
                dgProduct.ItemsSource = _product.GetListProduct();

            }
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dgProduct.SelectedItem as Product;

            if (selectedProduct == null)
            {
                MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Do you agree?", $"Do you want to delete product with id: {selectedProduct.ProductId}", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _product.DeleteProduct(selectedProduct.ProductId);
                    MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgProduct.ItemsSource = null; 
                    dgProduct.ItemsSource = _product.GetListProduct();
                }
            }
        }

        private void tbSearchKeyWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            cbCategory.SelectedIndex = 0;
            var result = _product.SearchProducts(tbSearchKeyWord.Text.Trim());
            dgProduct.ItemsSource = null;
            dgProduct.ItemsSource = result;
        }
    }
}
