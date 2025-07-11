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
using ASS_ClothingWarehouseManagement.view.ExportManagement;
using ASS_ClothingWarehouseManagement.view.ImportManagement;
using ClothingWarehouseManagement_DAL.Models;
using ClothingWarehouseManagement_DLL.Services;

namespace ASS_ClothingWarehouseManagement.view
{
    /// <summary>
    /// Interaction logic for ExportListPage.xaml
    /// </summary>
    public partial class ExportListPage : Page
    {
        private ExportReceiptService _exportService = new();
        private CustomerService _customerService = new();
        public ExportListPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dgExportRecept.ItemsSource = _exportService.GetListExportReceipt();
            var listCustomer = _customerService.GetListCustomers();
            listCustomer.Insert(0, new Customer { CustomerName = "-----Select All-----", CustomerId = 0});
            cbCustomer.ItemsSource = listCustomer;
            cbCustomer.DisplayMemberPath = "CustomerName";
            cbCustomer.SelectedIndex = 0;
        }

        private void ApplyFilter()
        {
            IEnumerable<ExportReceipt> filteredList = _exportService.GetListExportReceipt();
            string keyword = tbSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                filteredList = filteredList.Where(r =>
                    r.ReceiptId.ToString().Equals(keyword) ||
                    r.Customer.CustomerName.ToLower().Contains(keyword) ||
                    r.CreatedByNavigation.FullName.ToLower().Contains(keyword));
            }
            if (cbCustomer.SelectedItem is Customer selectedCustomer && selectedCustomer.CustomerId != 0)
            {
                filteredList = filteredList.Where(r => r.CustomerId == selectedCustomer.CustomerId);
            }
            if (dpFrom.SelectedDate.HasValue)
            {
                filteredList = filteredList.Where(r => r.CreatedAt >= DateOnly.FromDateTime(dpFrom.SelectedDate.Value));
            }
            if (dpTo.SelectedDate.HasValue)
            {
                filteredList = filteredList.Where(r => r.CreatedAt <= DateOnly.FromDateTime(dpTo.SelectedDate.Value));
            }
            if (double.TryParse(tbFromAmount.Text, out double fromAmount))
            {
                filteredList = filteredList.Where(r => r.TotalAmount >= fromAmount);
            }
            if (double.TryParse(tbToAmount.Text, out double toAmount) && toAmount > 0)
            {
                filteredList = filteredList.Where(r => r.TotalAmount <= toAmount);
            }
            dgExportRecept.ItemsSource = null;
            dgExportRecept.ItemsSource = filteredList.ToList(); 
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }
        private void cbSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void dpFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void dpTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void tbFromAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void tbToAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void btnAddExportRecept_Click(object sender, RoutedEventArgs e)
        {
            AddExportWindow addExportWindow = new AddExportWindow();
            Opacity = 0.4;
            bool? result = addExportWindow.ShowDialog();
            Opacity = 1;
            if (result == true)
            {
                MessageBox.Show("Add success!!", "Export receipt list will be refreshed.", MessageBoxButton.OK);
                dgExportRecept.ItemsSource = null;
                dgExportRecept.ItemsSource = _exportService.GetListExportReceipt();
            }
        }

        private void btnViewExportRecept_Click(object sender, RoutedEventArgs e)
        {
            if (dgExportRecept.SelectedItem is ExportReceipt selectedExport)
            {
                ViewExportWindow addImportWindow = new ViewExportWindow(selectedExport, _exportService);
                Opacity = 0.4;
                addImportWindow.ShowDialog();
                Opacity = 1;
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Text = string.Empty;
            cbCustomer.Text = string.Empty;
            dpFrom.SelectedDate = null;
            dpTo.SelectedDate = null;
            tbFromAmount.Text = string.Empty;
            tbToAmount.Text = string.Empty;
            dgExportRecept.ItemsSource = null;
            dgExportRecept.ItemsSource = _exportService.GetListExportReceipt();
        }
    }
}
