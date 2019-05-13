using DataAccess;
using Models;
using Services;
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

namespace ElementsLesson
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

        private void registratioButtonClick(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordBox.Password;
            var repeatPassword = repeatPasswordBox.Password;


            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repeatPassword))
            {
                MessageBox.Show("Введите все поля");
                return;
            }

            if (repeatPassword != password)
            {
                MessageBox.Show("Разные пароли");
                return;
            }

            using (var context = new ProgramContext())
            {
                //context.Users.Add(new User
                //{
                //    Login = login,
                //    Password = DataEncryptor.HashPassword(password)
                //});

                var user = new User
                {
                    Login = login,
                    Password = DataEncryptor.HashPassword(password)
                };

                context.Users.Add(user);
                context.SaveChanges();


                MessageBox.Show("Регистрация прошла успешно");
            }
        }
    }
}
