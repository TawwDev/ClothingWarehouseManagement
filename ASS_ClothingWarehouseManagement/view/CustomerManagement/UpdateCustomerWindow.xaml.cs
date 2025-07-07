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

namespace ASS_ClothingWarehouseManagement.view.CustomerManagement
{
    /// <summary>
    /// Interaction logic for UpdateCustomerWindow.xaml
    /// </summary>
    public partial class UpdateCustomerWindow : Window
    {
        public Customer SelectedCustomer { get; set; }
        private CustomerService _service;
        public UpdateCustomerWindow(Customer selectedCustomer, CustomerService service)
        {
            InitializeComponent();
            _service = service;
            SelectedCustomer = selectedCustomer;
        }

        private void btnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCustomerName.Text))
            {
                MessageBox.Show("Supplier Name empty!", "Empty input");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                MessageBox.Show("Address empty!", "Empty input");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Phone empty!", "Empty input");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Email empty!", "Empty input");
                return;
            }
            SelectedCustomer.CustomerName = tbCustomerName.Text.Trim();
            SelectedCustomer.Email = tbEmail.Text.Trim();
            SelectedCustomer.Address = tbAddress.Text.Trim();
            SelectedCustomer.Phone = tbPhone.Text.Trim();
            SelectedCustomer.Status = cbStatus.Text == "Active" ? 1 : 0;
            if (!Regex.IsMatch(tbPhone.Text.Trim(), @"^0\d{9}$"))
            {
                MessageBox.Show("Phone not correct format: start with 0, following 9 number!", "Wrong format input");
                return;
            }
            if (!Regex.IsMatch(tbEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("The email address format is incorrect. It should look like 'name@example.com'.", "Wrong format input");
                return;
            }
            _service.UpdateCustomer(SelectedCustomer);
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbAddress.Text = SelectedCustomer.Address;
            tbPhone.Text = SelectedCustomer.Phone;
            tbEmail.Text = SelectedCustomer.Email;
            tbCustomerName .Text = SelectedCustomer.CustomerName;
            cbStatus.SelectedIndex = SelectedCustomer.Status == 1 ? 0 : 1;
        }
    }
}
