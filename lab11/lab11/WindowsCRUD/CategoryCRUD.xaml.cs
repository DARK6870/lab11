using lab11.CRUD.CategoryCRUD;
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
    public partial class CategoryCRUD : Window
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

        private Category model;
        private readonly CategoryRepository _categoryRepo;
        public CategoryCRUD(byte ID)
        {
            InitializeComponent();
            _categoryRepo = new CategoryRepository(new AppDBContext());
            if (ID != 0)
            {
                Load(ID);
            }
            else
            {
                Delete_btn.IsEnabled = false;
                Save_changes_btn.IsEnabled = false;
            }

        }

        private async void Load(byte ID)
        {
            model = await _categoryRepo.GetCategoryById(ID);
            if (model != null)
            {
                Category_tb.Text = model.CategoryName;
                NewRecord_btn.IsEnabled = false;
            }
        }

        private async void Save_changes_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                model.CategoryName = Category_tb.Text;

                List<string> validationErrors = ValidationHelper.ValidateModel(model);
                if (validationErrors.Count > 0)
                {
                    foreach (var item in validationErrors)
                    {
                        notifier.ShowWarning(item);
                    }
                }
                else
                {
                    bool result = await _categoryRepo.UpdateCategory(model);
                    if (result)
                    {
                        this.Close();
                    }
                    else
                    {
                        notifier.ShowError("Womething went wrong!");
                    }
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
                MessageBoxResult res = MessageBox.Show("Are you sure want to delete this record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    bool result = await _categoryRepo.DeleteCategoryById(model.CategoryId);
                    if (result)
                    {
                        this.Close();
                    }
                    else
                    {
                        notifier.ShowError("Womething went wrong!");
                    }
                }
            }
            catch (Exception ex)
            {
                notifier.ShowError(ex.Message);
            }
        }

        private async void NewRecord_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Category model = new Category
                {
                    CategoryName = Category_tb.Text
                };

                List<string> validationErrors = ValidationHelper.ValidateModel(model);
                if (validationErrors.Count > 0)
                {
                    foreach(var item in validationErrors)
                    {
                        notifier.ShowWarning(item);
                    }
                }
                else
                {
                    bool result = await _categoryRepo.AddNewCategory(model);
                    if (result)
                    {
                        this.Close();
                    }
                    else
                    {
                        notifier.ShowError("Something went wrong!");
                    }
                }
            }
            catch (Exception ex)
            {
                notifier.ShowError(ex.Message);
            }
        }
    }
}
