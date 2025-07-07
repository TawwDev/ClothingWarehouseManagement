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

namespace ASS_ClothingWarehouseManagement.view.SupplierManagement
{
    /// <summary>
    /// Interaction logic for UpdateSupplierWindow.xaml
    /// </summary>
    public partial class UpdateSupplierWindow : Window
    {
        public Supplier SelectedSupplier { get; set; }
        private SupplierService _service;
        public UpdateSupplierWindow(Supplier selectedSupplier, SupplierService service)
        {
            InitializeComponent();
            SelectedSupplier = selectedSupplier;
            _service = service;
        }

        private void btnUpdateSupplier_Click(object sender, RoutedEventArgs e)
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
            SelectedSupplier.SupplierName = tbSupplierName.Text.Trim();
            SelectedSupplier.Email = tbEmail.Text.Trim();
            SelectedSupplier.Address = tbAddress.Text.Trim();
            SelectedSupplier.Phone = tbPhone.Text.Trim();
            SelectedSupplier.Status = cbStatus.Text == "Active" ? 1 : 0;
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
            _service.UpdateSupplier(SelectedSupplier);
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbAddress.Text = SelectedSupplier.Address;
            tbPhone.Text = SelectedSupplier.Phone;
            tbEmail.Text = SelectedSupplier.Email;
            cbStatus.SelectedIndex = SelectedSupplier.Status == 1 ? 0 : 1;
            tbSupplierName.Text = SelectedSupplier.SupplierName;
        }
    }
}
