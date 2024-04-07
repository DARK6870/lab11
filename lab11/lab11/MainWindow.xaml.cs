using lab11.CRUD.CategoryCRUD;
using lab11.CRUD.OrdersCRUD;
using lab11.CRUD.ProductsCRUD;
using lab11.CRUD.StatusesCRUD;
using lab11.CRUD.UsersCRUD;
using lab11.DataBase;
using lab11.Entityes;
using lab11.WindowsCRUD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
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
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;

namespace lab11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(5),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });


        private readonly ProductRepository _productRepo;
        private readonly OrderRepository _orderRepo;
        private readonly CategoryRepository _categoryRepo;
        private readonly StatusRepository _statusRepo;
        private readonly UserRepository _userRepo;

        private string TableName = "";
        private int ID = 0;


        public MainWindow()
        {
            InitializeComponent();
            _orderRepo = new OrderRepository(new AppDBContext());
            _productRepo = new ProductRepository(new AppDBContext());
            _categoryRepo = new CategoryRepository(new AppDBContext());
            _statusRepo = new StatusRepository(new AppDBContext());
            _userRepo = new UserRepository(new AppDBContext());
        }

        public void SetItemsSource<T>(List<T> dataSource)
        {
            myDataGrid.ItemsSource = dataSource;
            myDataGrid.Items.Refresh();
        }

        private async void UpdateDataAsync()
        {
            if (TableName == "Products")
            {
                SetItemsSource(await _productRepo.GetAllProducts());
            }
            else if (TableName == "Orders")
            {
                SetItemsSource(await _orderRepo.GetAllOrders());
            }
            else if (TableName == "Category")
            {
                SetItemsSource(await _categoryRepo.GetAllCategories());
            }
            else if (TableName == "Status")
            {
                SetItemsSource(await _statusRepo.GetAllStatuses());
            }
            else if (TableName == "Users")
            {
                SetItemsSource(await _userRepo.GetAllUsers());
            }
        }

        private async void table_cb_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                ID = 0;
                string table = table_cb.Text;

                ComboBox? comboBox = sender as ComboBox;
                if (comboBox == null)
                {
                    return;
                }
                ComboBoxItem? selectedItem = comboBox.SelectedItem as ComboBoxItem;
                if (selectedItem == null)
                    return;

                TableName = selectedItem.Content.ToString();
                UpdateDataAsync();
            }
            catch (Exception ex)
            {
                notifier.ShowError(ex.Message);
            }
        }

        private async void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TableName != "" && ID != 0)
                {
                    Window? window = null;
                    if (TableName == "Products")
                    {
                        window = new ProductsCRUD(ID);
                    }
                    else if (TableName == "Orders")
                    {
                        window = new OrdersCRUD(ID);
                    }
                    else if (TableName == "Category")
                    {
                        window = new CategoryCRUD((byte)ID);
                    }
                    else if (TableName == "Status")
                    {
                        window = new StatusCRUD((byte)ID);
                    }

                    window.ShowDialog();
                    UpdateDataAsync();

                    notifier.ShowSuccess("Data updated!");
                }
            }
            catch (Exception ex)
            {
                notifier.ShowError(ex.Message);
            }
        }

        private void NewRecord_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TableName != "")
                {
                    if (TableName == "Orders" || TableName == "Users")
                    {
                        throw new Exception("You cannot add new revord to this table!");
                    }
                    Window? window = null;
                    if (TableName == "Products")
                    {
                        window = new ProductsCRUD(0);
                    }
                    else if (TableName == "Category")
                    {
                        window = new CategoryCRUD(0);
                    }
                    else if (TableName == "Status")
                    {
                        window = new StatusCRUD(0);
                    }

                    window.ShowDialog();
                    UpdateDataAsync();
                }
            }
            catch (Exception ex)
            {
                notifier.ShowError(ex.Message);
            }
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                if (TableName != "")
                {
                    if (TableName == "Category")
                    {
                        CategoryViewModel selectedRow = (CategoryViewModel)myDataGrid.SelectedItem;

                        ID = selectedRow.CategoryId;
                    }
                    else if (TableName == "Status")
                    {
                        StatusViewModel selectedRow = (StatusViewModel)myDataGrid.SelectedItem;

                        ID = selectedRow.StatusId;
                    }
                    else if (TableName == "Products")
                    {
                        ProductViewModel selectedRow = (ProductViewModel)myDataGrid.SelectedItem;

                        ID = selectedRow.ProductId;
                    }
                    else if (TableName == "Orders")
                    {
                        OrderViewModel selectedRow = (OrderViewModel)myDataGrid.SelectedItem;

                        ID = selectedRow.OrderId;
                    }
                }
            }
        }
    }
}
