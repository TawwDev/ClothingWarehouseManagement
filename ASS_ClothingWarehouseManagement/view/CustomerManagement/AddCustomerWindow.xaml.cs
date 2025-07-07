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
    /// Interaction logic for AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        CustomerService _service = new CustomerService();
        public AddCustomerWindow()
        {
            InitializeComponent();
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCustomerName.Text))
            {
                MessageBox.Show("Customer Name empty!", "Empty input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                MessageBox.Show("Address empty!", "Empty input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Phone empty!", "Empty input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Email empty!", "Empty input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string name = tbCustomerName.Text.Trim();
            string address = tbAddress.Text.Trim();
            string phone = tbPhone.Text.Trim();
            string email = tbEmail.Text.Trim();
            int status = cbStatus.Text == "Active" ? 1 : 0;

            if (!Regex.IsMatch(phone, @"^0\d{9}$"))
            {
                MessageBox.Show("Phone not correct format: start with 0, following 9 number!", "Wrong format input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("The email address format is incorrect. It should look like 'name@example.com'.", "Wrong format input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Customer customer = new Customer
            {
                CustomerName = name,
                Address = address,
                Phone = phone,
                Email = email,
                Status = status
            };
            _service.AddCustomer(customer);
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
