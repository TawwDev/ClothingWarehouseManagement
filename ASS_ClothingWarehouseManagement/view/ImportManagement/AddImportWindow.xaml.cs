using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddImportWindow.xaml
    /// </summary>
    public partial class AddImportWindow : Window
    {
        private ProductService _productService = new();
        private SupplierService _supplierService = new();
        private List<ImportReceiptDetail> importReceiptDetails = new List<ImportReceiptDetail>();
        public AddImportWindow()
        {
            InitializeComponent();
        }

        private void dgProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearInforProduct();
            var selectedProduct = dgProduct.SelectedItem as Product;
            if (selectedProduct != null)
            {
                tbProductId.Text = selectedProduct.ProductId.ToString();
                tbProductMaterial.Text = selectedProduct.Material;
                tbProductName.Text = selectedProduct.ProductName;
            }
        }

        private void dgImportRecreiptDetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearInforImportDetail();
            var selectedImportReceiptDetail = dgImportRecreiptDetail.SelectedItem as ImportReceiptDetail;
            if (selectedImportReceiptDetail != null)
            {
                tbProductId.Text = selectedImportReceiptDetail.Product.ProductId.ToString();
                tbProductMaterial.Text = selectedImportReceiptDetail.Product.Material;
                tbProductName.Text = selectedImportReceiptDetail.Product.ProductName;
                tbDetailPrice.Text = selectedImportReceiptDetail.UnitPrice.ToString();
                tbDetailQuantity.Text = selectedImportReceiptDetail.Quantity.ToString();
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgProduct.ItemsSource = _productService.GetListProduct();
            cbSupplier.ItemsSource = _supplierService.GetListSuppliers();
            cbSupplier.DisplayMemberPath = "SupplierName";
        }

        private void btnAddProductToTheOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dgProduct.SelectedItem as Product;
            //Regex regex = new Regex("[^0-9]+");
            if (selectedProduct == null)
            {
                MessageBox.Show("Please choose product before add import receipt detail!", "Invalid selection!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbDetailQuantity.Text.Trim()))
            {
                MessageBox.Show("Please input Quantity!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbDetailPrice.Text.Trim()))
            {
                MessageBox.Show("Please input Price!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                int quanity = int.Parse(tbDetailQuantity.Text.Trim());
                double price = double.Parse(tbDetailPrice.Text.Trim());
                if (importReceiptDetails != null)
                {
                    foreach (var item in importReceiptDetails)
                    {
                        if (item.Product.ProductId == selectedProduct.ProductId)
                        {
                            MessageBox.Show("Product must be exist! Please update this product!", "Valid Product!", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    importReceiptDetails.Add(new ImportReceiptDetail { Product = selectedProduct, Quantity = quanity, UnitPrice = price });
                    MessageBox.Show($"Add success import receipt with product id = {selectedProduct.ProductId}!", "Add success!", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearInfor();
                }
                dgImportRecreiptDetail.ItemsSource = null;
                dgImportRecreiptDetail.ItemsSource = importReceiptDetails;
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                MessageBox.Show("Input must be a number", "Wrong format!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnUpdateProductInOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedImportReceiptDetail = dgImportRecreiptDetail.SelectedItem as ImportReceiptDetail;
            if (selectedImportReceiptDetail == null)
            {
                MessageBox.Show("Please choose import receipt detail before update!", "Invalid selection!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbDetailQuantity.Text.Trim()))
            {
                MessageBox.Show("Please input Quantity!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbDetailPrice.Text.Trim()))
            {
                MessageBox.Show("Please input Price!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                int quanity = int.Parse(tbDetailQuantity.Text.Trim());
                double price = double.Parse(tbDetailPrice.Text.Trim());
                if (importReceiptDetails != null)
                {
                    foreach (var item in importReceiptDetails)
                    {
                        if (item.Product.ProductId == selectedImportReceiptDetail.Product.ProductId)
                        {
                            item.UnitPrice = price;
                            item.Quantity = quanity;
                        }
                    }
                    MessageBox.Show($"Update success import receipt with product id = {selectedImportReceiptDetail.Product.ProductId}!", "Update success!", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearInfor();
                }

                dgImportRecreiptDetail.ItemsSource = null;
                dgImportRecreiptDetail.ItemsSource = importReceiptDetails;
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                MessageBox.Show("Input must be a number", "Wrong format!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnDeleteProductInOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedImportReceiptDetail = dgImportRecreiptDetail.SelectedItem as ImportReceiptDetail;
            if (selectedImportReceiptDetail == null)
            {
                MessageBox.Show("Please choose import receipt detail before update!", "Invalid selection!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (importReceiptDetails != null)
            {
                importReceiptDetails.Remove(selectedImportReceiptDetail);
                    
                MessageBox.Show($"Delete success import receipt with product id = {selectedImportReceiptDetail.Product.ProductId}!", "Delete success!", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearInfor();
                dgImportRecreiptDetail.ItemsSource = null;
                dgImportRecreiptDetail.ItemsSource = importReceiptDetails;
            }

        }

        private void ClearInfor()
        {
            dgImportRecreiptDetail.UnselectAll();
            dgProduct.UnselectAll();
            tbDetailPrice.Clear();
            tbDetailQuantity.Clear();
            tbProductId.Clear();
            tbProductMaterial.Clear();
            tbProductName.Clear();
        }
        private void ClearInforProduct()
        {
            dgImportRecreiptDetail.UnselectAll();
            tbDetailPrice.Clear();
            tbDetailQuantity.Clear();
            tbProductId.Clear();
            tbProductMaterial.Clear();
            tbProductName.Clear();
        }
        private void ClearInforImportDetail()
        {
            dgProduct.UnselectAll();
            tbDetailPrice.Clear();
            tbDetailQuantity.Clear();
            tbProductId.Clear();
            tbProductMaterial.Clear();
            tbProductName.Clear();
        }
    }
}
