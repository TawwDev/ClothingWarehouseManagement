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

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var selectedSupplier = cbSupplier.SelectedItem as Supplier;
            string keyWord = tbSearch.Text;
            var listSearch = _service.GetListSearchImportReceipts(keyWord, selectedSupplier);
            dgImportRecept.ItemsSource = null;
            dgImportRecept.ItemsSource = listSearch;
        }

        private void cbSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSupplier = cbSupplier.SelectedItem as Supplier;
            if (selectedSupplier != null && selectedSupplier.SupplierId != 0)
            {
                dgImportRecept.ItemsSource = _service.GetListImportRecept().Where(x => x.SupplierId == selectedSupplier.SupplierId).ToList();
            }
            else if (selectedSupplier != null && selectedSupplier.SupplierId == 0)
            {
                dgImportRecept.ItemsSource = _service.GetListImportRecept().ToList();
            }
        }
    }
}
