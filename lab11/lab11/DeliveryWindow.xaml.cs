using lab11.CRUD.CategoryCRUD;
using lab11.CRUD.OrdersCRUD;
using lab11.CRUD.ProductsCRUD;
using lab11.CRUD.StatusesCRUD;
using lab11.CRUD.UsersCRUD;
using lab11.DataBase;
using lab11.WindowsCRUD;
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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace lab11
{
    /// <summary>
    /// Логика взаимодействия для DeliveryWindow.xaml
    /// </summary>
    public partial class DeliveryWindow : Window
    {

        public DeliveryWindow()
        {
            InitializeComponent();
            _orderRepo = new OrderRepository(new AppDBContext());
            _productRepo = new ProductRepository(new AppDBContext());
            _categoryRepo = new CategoryRepository(new AppDBContext());
            _statusRepo = new StatusRepository(new AppDBContext());
            _userRepo = new UserRepository(new AppDBContext());
        }

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
        dynamic data;

        public void SetItemsSource<T>(List<T> dataSource)
        {
            myDataGrid.ItemsSource = dataSource;
            myDataGrid.Items.Refresh();
            data = dataSource;
        }

        private async void UpdateDataAsync()
        {
            try
            {   
                if (TableName == "Orders")
                {
                    SetItemsSource(await _orderRepo.GetAllOrders());
                }
            }
            catch
            {
                notifier.ShowError("Oops, something went wrong!");
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
                    if (TableName == "Orders")
                    {
                        window = new OrdersCRUD(ID);
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

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                if (TableName != "")
                {
                    if (TableName == "Orders")
                    {
                        OrderViewModel selectedRow = (OrderViewModel)myDataGrid.SelectedItem;

                        ID = selectedRow.OrderId;
                    }
                }
            }
        }

        private List<T> GetDataFromDataGrid<T>(DataGrid dataGrid)
        {
            if (dataGrid == null || dataGrid.Items.Count == 0)
            {
                return new List<T>();
            }
            List<T> dataList = dataGrid.Items.Cast<T>().ToList();

            return dataList;
        }


        private void search_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = search_tb.Text.ToLower();
                var modelList = (IEnumerable<dynamic>)data;
                var foundModels = new List<dynamic>();
                foreach (dynamic model in modelList)
                {
                    foreach (var property in model.GetType().GetProperties())
                    {
                        var value = property.GetValue(model);
                        if (value != null && value.ToString().ToLower().Contains(searchText))
                        {
                            foundModels.Add(model);
                            break;
                        }
                    }
                }

                SetItemsSource(foundModels);
                data = modelList;
            }
            catch (Exception ex)
            {
                notifier.ShowError("Извините, разрабы дануы накосячили в коде :)");
            }
        }
    }
}
