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
using ASS_ClothingWarehouseManagement.view.SupplierManagement;
using ClothingWarehouseManagement_DAL.Models;
using ClothingWarehouseManagement_DLL.Services;

namespace ASS_ClothingWarehouseManagement.view
{
    /// <summary>
    /// Interaction logic for SupplierListPage.xaml
    /// </summary>
    public partial class SupplierListPage : Page
    {
        private SupplierService _service = new SupplierService();
        public SupplierListPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dgSupplier.ItemsSource = _service.GetListSuppliers();
        }

        private void btnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            AddSupplierWindow addSupplierWindow = new AddSupplierWindow();
            Opacity = 0.4;
            bool? result = addSupplierWindow.ShowDialog();
            Opacity = 1;
            if (result == true)
            {
                MessageBox.Show("Add success!!", "Supplier list will be refreshed.", MessageBoxButton.OK);
                dgSupplier.ItemsSource = null;
                dgSupplier.ItemsSource = _service.GetListSuppliers();
            }
        }

        private void btnEditSupplier_Click(object sender, RoutedEventArgs e)
        {
            Supplier selectedSupplier = dgSupplier.SelectedItem as Supplier;
            if (selectedSupplier == null)
            {
                MessageBox.Show("Please select a supplier to edit.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            UpdateSupplierWindow updateSupplierWindow = new UpdateSupplierWindow(selectedSupplier, _service);
            Opacity = 0.4;
            bool? result = updateSupplierWindow.ShowDialog();
            Opacity = 1;
            if (result == true)
            {
                MessageBox.Show("Update success!!", "Supplier list will be refreshed.", MessageBoxButton.OK);
                dgSupplier.ItemsSource = null;
                dgSupplier.ItemsSource = _service.GetListSuppliers();
            }

        }

        private void btnDeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            var selectedSupplier = dgSupplier.SelectedItem as Supplier;

            if (selectedSupplier == null)
            {
                MessageBox.Show("Please select a Supplier to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Do you agree?", $"Do you want to delete supplier with id: {selectedSupplier.SupplierId}", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _service.DeleteSupplier(selectedSupplier);
                    MessageBox.Show("Supplier deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgSupplier.ItemsSource = null;
                    dgSupplier.ItemsSource = _service.GetListSuppliers().ToList();
                }
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyWord = tbSearch.Text;
            var searchSuppliers = _service.SearchSupplier(keyWord);
            dgSupplier.ItemsSource = null;
            dgSupplier.ItemsSource = searchSuppliers;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            dgSupplier.SelectedItem = null;
            dgSupplier.ItemsSource = null;
            dgSupplier.ItemsSource = _service.GetListSuppliers().ToList();
            tbSearch.Text = string.Empty;
        }
    }
}
