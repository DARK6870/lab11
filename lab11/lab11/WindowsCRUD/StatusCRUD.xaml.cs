using lab11.CRUD.CategoryCRUD;
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

namespace lab11.WindowsCRUD
{
    public partial class StatusCRUD : Window
    {
        private Status model;
        private readonly StatusRepository _statusRepo;
        public StatusCRUD(byte ID)
        {
            InitializeComponent();

            _statusRepo = new StatusRepository(new AppDBContext());
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
            model = await _statusRepo.GetStatusById(ID);
            if (model != null)
            {
                Name_tb.Text = model.StatusName;
                NewRecord_btn.IsEnabled = false;
            }
        }

        private async void NewRecord_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Status model_ = new Status
                {
                    StatusName = Name_tb.Text
                };

                List<string> validationErrors = ValidationHelper.ValidateModel(model_);
                if (validationErrors.Count > 0)
                {
                    foreach (var item in validationErrors)
                    {
                        //notifier.ShowWarning(item);
                    }
                }
                else
                {
                    bool result = await _statusRepo.AddNewStatus(model_);
                    if (result)
                    {
                        this.Close();
                    }
                    else
                    {
                        //notifier.ShowError("Something went wrong!");
                    }
                }
            }
            catch (Exception ex)
            {
                //notifier.ShowError(ex.Message);
            }
        }

        private async void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult res = MessageBox.Show("Are you sure want to delete this record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    bool result = await _statusRepo.DeleteStatusById(model.StatusId);
                    if (result)
                    {
                        this.Close();
                    }
                    else
                    {
                        //notifier.ShowError("Womething went wrong!");
                    }
                }
            }
            catch (Exception ex)
            {
                //notifier.ShowError(ex.Message);
            }
        }

        private async void Save_changes_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                model.StatusName = Name_tb.Text;

                List<string> validationErrors = ValidationHelper.ValidateModel(model);
                if (validationErrors.Count > 0)
                {
                    foreach (var item in validationErrors)
                    {
                        //notifier.ShowWarning(item);
                    }
                }
                else
                {
                    bool result = await _statusRepo.UpdateStatus(model);
                    if (result)
                    {
                        this.Close();
                    }
                    else
                    {
                        //notifier.ShowError("Womething went wrong!");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
