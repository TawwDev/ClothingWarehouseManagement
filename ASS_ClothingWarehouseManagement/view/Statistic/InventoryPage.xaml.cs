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

namespace ASS_ClothingWarehouseManagement.view.Statistic
{
    /// <summary>
    /// Interaction logic for InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        private CustomerService _customerService = new();
        private SupplierService _supplierService = new();
        private ProductService _productService = new();
        private ExportReceiptService _exportReceiptService = new();
        private InventoryReportService _inventoryReportService = new();
        public InventoryPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<SalesReport> salesReports = new List<SalesReport>();
            //OverView
            tbTotalCustomer.Text = _customerService.GetListCustomers().Count.ToString();
            tbTotalSupplier.Text = _supplierService.GetListSuppliers().Count.ToString();
            tbTotalProduct.Text = _productService.GetListProductAvailbleQuantity().Count.ToString();

            dgSalesReport.ItemsSource = _exportReceiptService.GetSalesReport();
        }

        private void dpFromDateOverView_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilterOverView();
        }

        private void dpToDateOverView_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilterOverView();
        }

        private void ApplyFilterOverView()
        {
            var filteredList = _exportReceiptService.GetSalesReport();
            if (dpFromDateOverView.SelectedDate.HasValue)
            {
                DateOnly fromDate = DateOnly.FromDateTime(dpFromDateOverView.SelectedDate.Value);
                filteredList = filteredList.Where(r => r.Date >= fromDate).ToList();
            }
            if (dpToDateOverView.SelectedDate.HasValue)
            {
                DateOnly toDate = DateOnly.FromDateTime(dpToDateOverView.SelectedDate.Value);
                filteredList = filteredList.Where(r => r.Date <= toDate).ToList();
            }
            dgSalesReport.ItemsSource = null;
            dgSalesReport.ItemsSource = filteredList;
        }
        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (!dpFromDateInventory.SelectedDate.HasValue || !dpToDateInventory.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select both From Date and To Date.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string searchText = tbSearchInventory.Text.Trim();
            DateOnly fromDate = DateOnly.FromDateTime(dpFromDateInventory.SelectedDate.Value);
            DateOnly toDate = DateOnly.FromDateTime(dpToDateInventory.SelectedDate.Value);
            dgInventoryReport.ItemsSource = _inventoryReportService.InventoryReports(fromDate, toDate, searchText);
        }
    }
}
