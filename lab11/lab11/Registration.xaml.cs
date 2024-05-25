using lab11.DataBase;
using lab11.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
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

namespace lab11
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void openLoginForm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow windows = new MainWindow();
            windows.Show();
            this.Close();
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            Registration window = new Registration();
            window.Show();
            this.Close();
        }

        private void reg_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User? regUser = new User();
                regUser.UserName = username_tb.Text;
                regUser.Email = email_tb.Text;
                regUser.FullName = fullName_tb.Text;
                string password = password_tb.Password;
                regUser.PasswordHash = password;

                var validationContext = new ValidationContext(regUser, null, null);//1
                var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();//2
                if (Validator.TryValidateObject(regUser, validationContext, validationResults, true))//3
                {
                    using (AppDBContext context = new AppDBContext())
                    {
                        using (SHA256 sha256 = SHA256.Create())
                        {
                            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                            regUser.PasswordHash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                        }

                        User? checkUserName = context.Users.FirstOrDefault(p => p.Email == regUser.Email);
                        if (checkUserName == null)
                        {
                            regUser.Adress = "";
                            regUser.RoleId = 0;
                            regUser.PhoneNumber = "";

                            context.Users.Add(regUser);
                            int res = context.SaveChanges();
                            if (res > 0)
                            {
                                MainWindow window = new MainWindow();
                                window.FillData(regUser.Email, password);
                                window.Show();
                                this.Close();
                            }
                            else
                            {
                                msg.Content = "Oooops, somthing went wrong, SERVER ERROR :(";
                            }
                        }
                        else
                        {
                            msg.Content = "User with this email is already exist.";
                        }
                    }
                }
                else
                {
                    string validationErrors = string.Join(Environment.NewLine, validationResults.Select(result => result.ErrorMessage));
                    msg.Content = $"{validationErrors}";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
