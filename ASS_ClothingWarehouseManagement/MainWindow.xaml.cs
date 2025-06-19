using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ASS_ClothingWarehouseManagement.view;
using ClothingWarehouseManagement_DAL.Models;

namespace ASS_ClothingWarehouseManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Account AuthenticatedUser { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string role = AuthenticatedUser.Role == 1 ? "Admin" : "Staff";
            lbHello.Content = $"Hello {role}!";

            if (AuthenticatedUser.Role == 2)
            {
                btnProduct.IsEnabled = false;
                btnStatistics.IsEnabled = false;
            }

        }

        private void NavigateToPage(Page page)
        {
            if (WelcomeContent.Visibility == Visibility.Visible)
            {
                WelcomeContent.Visibility = Visibility.Collapsed;
            }
            MainFrame.Navigate(page);
        }
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage(new ImportListPage());
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage(new ProductListPage());
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage(new ExportListPage());
        }

        private void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage(new SupplierListPage());
        }

        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage(new StatisticsListPage());
        }
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        
    }
}