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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASS_ClothingWarehouseManagement
{
    /// <summary>
    /// Interaction logic for AddSupplierWindow.xaml
    /// </summary>
    public partial class AddSupplierWindow : Window
    {
        SupplierService _service = new SupplierService();
        public AddSupplierWindow()
        {
            InitializeComponent();
        }

        private void btnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSupplierName.Text))
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
            string name = tbSupplierName.Text.Trim();
            string address = tbAddress.Text.Trim();
            string phone = tbPhone.Text.Trim();
            string email = tbEmail.Text.Trim();
            int status = cbStatus.Text == "Active" ? 1 : 0;

            if (!Regex.IsMatch(phone, @"^0\d{9}$"))
            {
                MessageBox.Show("Phone not correct format: start with 0, following 9 number!", "Wrong format input");
                return;
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("The email address format is incorrect. It should look like 'name@example.com'.", "Wrong format input");
                return;
            }

            Supplier supplier = new Supplier
            {
                SupplierName = name,
                Address = address,
                Phone = phone,
                Email = email,
                Status = status
            };
            _service.AddSupplier(supplier);
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
