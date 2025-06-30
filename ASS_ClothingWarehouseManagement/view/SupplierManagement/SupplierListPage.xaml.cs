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

        }

        private void btnDeleteSupplier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
