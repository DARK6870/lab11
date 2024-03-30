using lab11.CRUD.CategoryCRUD;
using lab11.CRUD.OrdersCRUD;
using lab11.CRUD.ProductsCRUD;
using lab11.CRUD.StatusesCRUD;
using lab11.DataBase;
using lab11.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace lab11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ProductRepository _productRepo;
        private readonly OrderRepository _orderRepo;
        private readonly CategoryRepository _categoryRepo;
        private readonly StatusRepository _statusRepo;
        public MainWindow()
        {
            InitializeComponent();
            _orderRepo = new OrderRepository(new AppDBContext());
            _productRepo = new ProductRepository(new AppDBContext());
            _categoryRepo = new CategoryRepository(new AppDBContext());
            _statusRepo = new StatusRepository(new AppDBContext());
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var productsData = await _statusRepo.GetAllStatuses();

                DataGrid.ItemsSource = productsData;
                DataGrid.Items.Refresh();

            }
            catch
            {
                
            }
        }

    }
}
