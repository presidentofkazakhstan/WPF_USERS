using DataAccess;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElementsLesson
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void SignButtonClick(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordBox.Password;


            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите все поля");
                return;
            }


            using (var context = new ProgramContext())
            {
                var user = context.Users.FirstOrDefault(searchingUser => searchingUser.Login == login);


                if (user != null && DataEncryptor.isTruePassword(password , user.Password))
                {
                    MessageBox.Show("Hello");
                }
                else
                {
                    MessageBox.Show("GG ");
                }
            }
        }

        
    }
}
