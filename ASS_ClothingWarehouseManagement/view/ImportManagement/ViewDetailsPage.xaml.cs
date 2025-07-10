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
using System.Windows.Shapes;
using ClothingWarehouseManagement_DAL.Models;
using ClothingWarehouseManagement_DLL.Services;

namespace ASS_ClothingWarehouseManagement.view.ImportManagement
{
    /// <summary>
    /// Interaction logic for ViewDetails.xaml
    /// </summary>
    public partial class ViewDetails : Window
    {
        public ImportReceipt SelectedImport { get; set; }
        private ImportReceiptService _importService;
        public ViewDetails(ImportReceipt import, ImportReceiptService service)
        {
            InitializeComponent();
            SelectedImport = import;
            _importService = service;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbCreatedBy.Text = SelectedImport.CreatedByNavigation.FullName;
            tbCreatedDate.Text = SelectedImport.CreatedAt.ToString();
            tbImportId.Text = SelectedImport.ReceiptId.ToString();
            tbSupplier.Text = SelectedImport.Supplier.SupplierName;
            tbTotalAmount.Text = $"TOTAL AMOUNT: {SelectedImport.TotalAmount.ToString()} VND";
            dgImportReceptDetail.ItemsSource = _importService.GetImportReceiptDetails(SelectedImport.ReceiptId);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
