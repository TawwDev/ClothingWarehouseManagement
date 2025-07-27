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

namespace ASS_ClothingWarehouseManagement.view.ExportManagement
{
    /// <summary>
    /// Interaction logic for AddExportWindow.xaml
    /// </summary>
    public partial class AddExportWindow : Window
    {
        private ProductService _productService = new();
        private CustomerService _customerService = new();
        private ExportReceiptService _exportService = new();
        private List<ExportReceiptDetail> exportReceiptDetails = new List<ExportReceiptDetail>();
        public AddExportWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgProduct.ItemsSource = _productService.GetListProductAvailbleQuantity();
            cbCustomer.ItemsSource = _customerService.GetListCustomers();
            cbCustomer.DisplayMemberPath = "CustomerName";
            string createdBy = Session.CurrentUser.FullName;
            tbCreatedBy.Text = createdBy;
            int id = _exportService.GetLastExportId() + 1;
            tbImportReceiptId.Text = id.ToString();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyWord = tbSearch.Text;
            dgProduct.ItemsSource = null;
            dgProduct.ItemsSource = _productService.SearchProducts(keyWord);
        }

        private void btnAddProductToTheOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dgProduct.SelectedItem as Product;
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
            try
            {
                int quantity = int.Parse(tbDetailQuantity.Text.Trim());
                double price = double.Parse(tbDetailPrice.Text.Trim());
                if (quantity > selectedProduct.Quantity)
                {
                    MessageBox.Show("Quantity not enough to export!", "Invalid Input!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (exportReceiptDetails != null)
                {
                    foreach (var item in exportReceiptDetails)
                    {
                        if (item.Product.ProductId == selectedProduct.ProductId)
                        {
                            MessageBox.Show("Product must be exist! Please update this product!", "Valid Product!", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    exportReceiptDetails.Add(new ExportReceiptDetail { Product = selectedProduct, ProductId = selectedProduct.ProductId, Quantity = quantity, UnitPrice = price, BasePriceAtExport = selectedProduct.BasePrice});
                    MessageBox.Show($"Add success export receipt with product id = {selectedProduct.ProductId}!", "Add success!", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearInfor();
                    double? totalAmount = 0;
                    foreach (var item in exportReceiptDetails)
                    {
                        totalAmount += (item.UnitPrice * item.Quantity);
                    }
                    tbTotalAmount.Text = "Total Amount: " + totalAmount.ToString() + " VND";
                }

                dgExportRecreiptDetail.ItemsSource = null;
                dgExportRecreiptDetail.ItemsSource = exportReceiptDetails;
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
            var selectedExportReceiptDetail = dgExportRecreiptDetail.SelectedItem as ExportReceiptDetail;
            if (selectedExportReceiptDetail == null)
            {
                MessageBox.Show("Please choose export receipt detail before update!", "Invalid selection!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbDetailQuantity.Text.Trim()))
            {
                MessageBox.Show("Please input Quantity!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                int quantity = int.Parse(tbDetailQuantity.Text.Trim());
                double price = double.Parse(tbDetailPrice.Text.Trim());
                if (exportReceiptDetails != null)
                {
                    foreach (var item in exportReceiptDetails)
                    {
                        if (item.Product.ProductId == selectedExportReceiptDetail.Product.ProductId)
                        {
                            item.UnitPrice = price;
                            item.Quantity = quantity;
                        }
                    }
                    MessageBox.Show($"Update success export receipt with product id = {selectedExportReceiptDetail.Product.ProductId}!", "Update success!", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearInfor();
                }

                dgExportRecreiptDetail.ItemsSource = null;
                dgExportRecreiptDetail.ItemsSource = exportReceiptDetails;
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
            var selectedExportReceiptDetail = dgExportRecreiptDetail.SelectedItem as ExportReceiptDetail;
            if (selectedExportReceiptDetail == null)
            {
                MessageBox.Show("Please choose import receipt detail before update!", "Invalid selection!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (exportReceiptDetails != null)
            {
                exportReceiptDetails.Remove(selectedExportReceiptDetail);

                MessageBox.Show($"Delete success export receipt with product id = {selectedExportReceiptDetail.Product.ProductId}!", "Delete success!", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearInfor();
                dgExportRecreiptDetail.ItemsSource = null;
                dgExportRecreiptDetail.ItemsSource = exportReceiptDetails;
            }
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
                tbDetailPrice.Text = selectedProduct.Price.ToString();
            }
        }

        private void dgExportRecreiptDetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearInforImportDetail();
            var selectedExportReceiptDetail = dgExportRecreiptDetail.SelectedItem as ExportReceiptDetail;
            if (selectedExportReceiptDetail != null)
            {
                tbProductId.Text = selectedExportReceiptDetail.Product.ProductId.ToString();
                tbProductMaterial.Text = selectedExportReceiptDetail.Product.Material;
                tbProductName.Text = selectedExportReceiptDetail.Product.ProductName;
                tbDetailPrice.Text = selectedExportReceiptDetail.UnitPrice.ToString();
                tbDetailQuantity.Text = selectedExportReceiptDetail.Quantity.ToString();
            }
        }

        private void btnAddExportReceipt_Click(object sender, RoutedEventArgs e)
        {
            string createdBy = Session.CurrentUser.UserName;
            var customer = cbCustomer.SelectedItem as Customer;
            if (customer == null)
            {
                MessageBox.Show("Please choose customer before create import!", "Invalid selection!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DateOnly createdDate = DateOnly.FromDateTime(DateTime.Now);
            double totalAmount = (double)exportReceiptDetails.Sum(x => x.Quantity * x.UnitPrice);
            ExportReceipt er = new ExportReceipt { CreatedAt = createdDate, CreatedBy = createdBy, CustomerId = customer.CustomerId, TotalAmount = totalAmount, ExportReceiptDetails = exportReceiptDetails };
            _exportService.AddExportRecept(er);
            foreach (var item in exportReceiptDetails)
            {
                _productService.UpdateQuantityProductAfterExport(item.ProductId, (int)item.Quantity);
            }
            this.DialogResult = true;
            this.Close();
        }

        private void ClearInfor()
        {
            dgExportRecreiptDetail.UnselectAll();
            dgProduct.UnselectAll();
            tbDetailPrice.Clear();
            tbDetailQuantity.Clear();
            tbProductId.Clear();
            tbProductMaterial.Clear();
            tbProductName.Clear();
        }
        private void ClearInforProduct()
        {
            dgExportRecreiptDetail.UnselectAll();
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
