using lab11.CRUD.CategoryCRUD;
using lab11.CRUD.ProductsCRUD;
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
    /// Логика взаимодействия для ProductsCRUD.xaml
    /// </summary>
    public partial class ProductsCRUD : Window
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
        private readonly CategoryRepository _categoryRepo;
        private Product product = new Product();
        private int Id;
        public ProductsCRUD(int ID)
        {
            InitializeComponent();
            _productRepo = new ProductRepository(new AppDBContext());
            _categoryRepo = new CategoryRepository(new AppDBContext());
            FillData(ID);
            Id = ID;
        }

        private async void FillData(int ID)
        {
            try
            {
                Category_cb.ItemsSource = await _categoryRepo.GetAllCategoryNames();
                if (ID == 0)
                {
                    Save_changes_btn.IsEnabled = false;
                    Delete_btn.IsEnabled = false;
                }
                else
                {
                    product = await _productRepo.GetProductById(ID);
                    ProductName_tb.Text = product.ProductName;
                    Price_tb.Text = product.Price.ToString();
                    Description_tb.Text = product.ProductDescription;
                    ImageURL_tb.Text = product.ImageUrl;
                    available_cb.IsChecked = product.Available;
                    Category cat = await _categoryRepo.GetCategoryById(product.CategoryId);
                    Category_cb.Text = cat.CategoryName;
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
                    bool result = await _productRepo.DeleteProductById(product.ProductId);
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

        private async Task<Product> GetData()
        {
            Product model = new Product
            {
                ProductId = Id,
                ProductName = ProductName_tb.Text,
                Price = int.Parse(Price_tb.Text),
                ProductDescription = Description_tb.Text,
                ImageUrl = ImageURL_tb.Text,
                CategoryId = await _categoryRepo.GetCategoryIdByCategoryNameProcedure(Category_cb.Text),
                Available = available_cb.IsChecked == true
            };

            return model;
        }


        private async void NewRecord_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product updated = await GetData();
                List<string> validationErrors = ValidationHelper.ValidateModel(updated);
                if (validationErrors.Count > 0)
                {
                    foreach (var item in validationErrors)
                    {
                        notifier.ShowWarning(item);
                    }
                }
                else
                {
                    bool res = await _productRepo.AddNewProduct(updated);
                    if (res)
                    {
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Something went wrong! Oops");
                    }
                }
            }
            catch (Exception ex)
            {
                notifier.ShowError("Something went wrong, check data and try again!");
            }
        }

        private async void Save_changes_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product updated = await GetData();
                List<string> validationErrors = ValidationHelper.ValidateModel(updated);
                if (validationErrors.Count > 0)
                {
                    foreach (var item in validationErrors)
                    {
                        notifier.ShowWarning(item);
                    }
                }
                else
                {
                    bool res = await _productRepo.UpdateProduct(updated);
                    if (res)
                    {
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Something went wrong! Oops");
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
