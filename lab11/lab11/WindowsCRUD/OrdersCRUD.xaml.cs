using lab11.CRUD.OrdersCRUD;
using lab11.CRUD.StatusesCRUD;
using lab11.DataBase;
using lab11.Entityes;
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

namespace lab11.WindowsCRUD
{
    /// <summary>
    /// Логика взаимодействия для OrdersCRUD.xaml
    /// </summary>
    public partial class OrdersCRUD : Window
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

        private readonly OrderRepository _orderRepo;
        private readonly StatusRepository _statusRepo;
        private int Id;
        private Order model = new Order();

        public OrdersCRUD(int ID)
        {
            InitializeComponent();
            _orderRepo = new OrderRepository(new AppDBContext());
            _statusRepo = new StatusRepository(new AppDBContext());
            Id = ID;
            FillData();
        }

        private async void FillData()
        {
            try
            {
                Status_tb.ItemsSource = await _statusRepo.GetAllStatusNames();
                if (Id == 0)
                {
                    Save_changes_btn.IsEnabled = false;
                    Delete_btn.IsEnabled = false;
                }
                else
                {
                    model = await _orderRepo.GetOrderById(Id);
                    Status stat = await _statusRepo.GetStatusById(model.StatusId);
                    Status_tb.Text = stat.StatusName;
                }
            }
            catch (Exception ex)
            {
                notifier.ShowError(ex.Message);
            }
        }

        private async void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                model.StatusId = await _statusRepo.GetStatusIdByStatusName("Canceled");
                bool res = await _orderRepo.UpdateOrder(model);
                if (res)
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("Something went wrong! Oops");
                }
            }
            catch(Exception ex)
            {
                notifier.ShowError(ex.Message);
            }
        }

        private async void Save_changes_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                model.StatusId = await _statusRepo.GetStatusIdByStatusName(Status_tb.Text);
                bool res = await _orderRepo.UpdateOrder(model);
                if (res)
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("Something went wrong! Oops");
                }
            }
            catch (Exception ex)
            {
                notifier.ShowError(ex.Message);
            }
        }
    }
}
