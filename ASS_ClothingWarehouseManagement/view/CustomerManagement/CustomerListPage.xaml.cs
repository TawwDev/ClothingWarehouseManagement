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

namespace ASS_ClothingWarehouseManagement.view.CustomerManagement
{
    /// <summary>
    /// Interaction logic for CustomerListPage.xaml
    /// </summary>
    public partial class CustomerListPage : Page
    {
        private CustomerService _service = new();
        public CustomerListPage()
        {
            InitializeComponent();
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            Opacity = 0.4;
            bool? result = addCustomerWindow.ShowDialog();
            Opacity = 1;
            if (result == true)
            {
                MessageBox.Show("Add success!!", "Customer list will be refreshed.", MessageBoxButton.OK);
                dgCustomer.ItemsSource = null;
                dgCustomer.ItemsSource = _service.GetListCustomers();
            }
        }

        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = dgCustomer.SelectedItem as Customer;
            if (selectedCustomer == null)
            {
                MessageBox.Show("Please select a Customer to edit.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            UpdateCustomerWindow updateCustomerWindow = new UpdateCustomerWindow(selectedCustomer, _service);
            Opacity = 0.4;
            bool? result = updateCustomerWindow.ShowDialog();
            Opacity = 1;
            if (result == true)
            {
                MessageBox.Show("Update success!!", "Supplier list will be refreshed.", MessageBoxButton.OK);
                dgCustomer.ItemsSource = null;
                dgCustomer.ItemsSource = _service.GetListCustomers();
            }
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = dgCustomer.SelectedItem as Customer;

            if (selectedCustomer == null)
            {
                MessageBox.Show("Please select a Customer to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Do you agree?", $"Do you want to delete customer with id: {selectedCustomer.CustomerId}", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _service.DeleteCustomer(selectedCustomer);
                    MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgCustomer.ItemsSource = null;
                    dgCustomer.ItemsSource = _service.GetListCustomers().ToList();
                }
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            dgCustomer.SelectedItem = null;
            dgCustomer.ItemsSource = null;
            dgCustomer.ItemsSource = _service.GetListCustomers().ToList();
            tbSearch.Text = string.Empty;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyWord = tbSearch.Text;
            var searchCusomers = _service.SearchCustomer(keyWord);
            dgCustomer.ItemsSource = null;
            dgCustomer.ItemsSource = searchCusomers;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dgCustomer.ItemsSource = _service.GetListCustomers();
        }
    }
}
