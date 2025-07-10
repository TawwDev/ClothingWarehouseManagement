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
using ASS_ClothingWarehouseManagement.view.ImportManagement;
using ClothingWarehouseManagement_DAL.Models;
using ClothingWarehouseManagement_DLL.Services;

namespace ASS_ClothingWarehouseManagement.view
{
    /// <summary>
    /// Interaction logic for ImportListPage.xaml
    /// </summary>
    public partial class ImportListPage : Page
    {
        private ImportReceiptService _service = new();
        private SupplierService _supplierService = new();
        public ImportListPage()
        {
            InitializeComponent();
        }

        private void btnViewImportRecept_Click(object sender, RoutedEventArgs e)
        {
            if (dgImportRecept.SelectedItem is ImportReceipt selectedImport)
            {
                ViewDetails addImportWindow = new ViewDetails(selectedImport, _service);
                Opacity = 0.4;
                addImportWindow.ShowDialog();
                Opacity = 1;
            }
            
        }

        private void btnAddImportRecept_Click(object sender, RoutedEventArgs e)
        {
            AddImportWindow addImportWindow = new AddImportWindow();
            Opacity = 0.4;
            bool? result = addImportWindow.ShowDialog();
            Opacity = 1;
            if (result == true)
            {
                MessageBox.Show("Add success!!", "Import receipt list will be refreshed.", MessageBoxButton.OK);
                dgImportRecept.ItemsSource = null;
                dgImportRecept.ItemsSource = _service.GetListImportRecept();
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Text = string.Empty;
            cbSupplier.Text = string.Empty;
            dpFrom.SelectedDate = null;
            dpTo.SelectedDate = null;
            tbFromAmount.Text = string.Empty;
            tbToAmount.Text = string.Empty;
            dgImportRecept.ItemsSource = null;
            dgImportRecept.ItemsSource = _service.GetListImportRecept();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dgImportRecept.ItemsSource = _service.GetListImportRecept().ToList();
            var listSuppliers = _supplierService.GetListSuppliers().ToList();
            listSuppliers.Insert(0, new Supplier { SupplierId = 0, SupplierName = "-----Select All-----" });
            cbSupplier.ItemsSource = listSuppliers;
            cbSupplier.DisplayMemberPath = "SupplierName";
            cbSupplier.SelectedIndex = 0;
        }

        

        private void ApplyFilter()
        {
            IEnumerable<ImportReceipt> filteredList = _service.GetListImportRecept();
            string keyword = tbSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                filteredList = filteredList.Where(r =>
                    r.ReceiptId.ToString().Equals(keyword) ||
                    r.Supplier.SupplierName.ToLower().Contains(keyword) ||
                    r.CreatedByNavigation.FullName.ToLower().Contains(keyword));
            }
            if (cbSupplier.SelectedItem is Supplier selectedSupplier && selectedSupplier.SupplierId != 0)
            {
                filteredList = filteredList.Where(r => r.SupplierId == selectedSupplier.SupplierId);
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
            dgImportRecept.ItemsSource = null;
            dgImportRecept.ItemsSource = filteredList.ToList();
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
    }
}
