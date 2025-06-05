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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = Classes.Connection.db.User.FirstOrDefault(u => u.Name == LoginTB.Text && u.Password == PasswodTB.Password);
                if (user != null)
                {
                    string UserName = user.Name;
                    switch(user.RoleId)
                    {
                        case 1 :
                            NavigationService.Navigate(new StudentPage(UserName));
                            break;
                        case 2:
                            NavigationService.Navigate(new TeacherPage(UserName));
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Нет такого пользователя", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
