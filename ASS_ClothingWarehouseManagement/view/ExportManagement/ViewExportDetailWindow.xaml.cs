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

namespace ASS_ClothingWarehouseManagement.view.ExportManagement
{
    /// <summary>
    /// Interaction logic for ViewExportWindow.xaml
    /// </summary>
    public partial class ViewExportWindow : Window
    {
        public ExportReceipt SelectedExport { get; set; }
        private ExportReceiptService _exportService;
        public ViewExportWindow(ExportReceipt export, ExportReceiptService service)
        {
            InitializeComponent();
            SelectedExport = export;
            _exportService = service;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbCreatedBy.Text = SelectedExport.CreatedByNavigation.FullName;
            tbCreatedDate.Text = SelectedExport.CreatedAt.ToString();
            tbImportId.Text = SelectedExport.ReceiptId.ToString();
            tbCustomer.Text = SelectedExport.Customer.CustomerName;
            tbTotalAmount.Text = $"TOTAL AMOUNT: {SelectedExport.TotalAmount.ToString()} VND";
            dgExportReceptDetail.ItemsSource = _exportService.GetExportReceiptDetails(SelectedExport.ReceiptId);
        }
    }
}
