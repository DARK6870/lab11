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
using System.Windows;
using System.Windows.Controls;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using System.Text;
using lab11.Entityes;
using System.Security.Cryptography;

namespace lab11
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void FillData(string username, string password)
        {
            username_tb.Text = username;
            password_tb.Password = password;
        }

        private void openRegForm_Click(object sender, RoutedEventArgs e)
        {
            Registration window = new Registration();
            window.Show();
            this.Close();
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            username_tb.Text = string.Empty;
            password_tb.Password = string.Empty;
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (AppDBContext context = new AppDBContext())
                {
                    string email = username_tb.Text;
                    string password = password_tb.Password;

                    User? userData = context.Users.FirstOrDefault(p => p.Email == email);

                    if (userData != null)
                    {
                        string storedHash = userData.PasswordHash;

                        using (SHA256 sha256 = SHA256.Create())
                        {
                            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                            string enteredHash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                            if (storedHash == enteredHash)
                            {
                                if (userData.RoleId == 1)
                                {
                                    AdminDashboardWindow window = new AdminDashboardWindow();
                                    window.Show();
                                }
                                else if (userData.RoleId == 2)
                                {
                                    DeliveryWindow window = new DeliveryWindow();
                                    window.Show();
                                }
                                this.Close();
                            }
                            else
                            {
                                message.Content = "Invalid data, please try again";
                            }
                        }
                    }
                    else
                    {
                        message.Content = "User not found";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
