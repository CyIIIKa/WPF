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
using WpfApp1.Classes;
namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StudentList.ItemsSource = Classes.Connection.db.Student.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(MessageBox.Show("Вы уверены, что хотите удалть?", "Уведомление!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var Deleted = StudentList.SelectedItem as Student;

                    Classes.Connection.db.Student.Remove(Deleted);
                    Classes.Connection.db.SaveChanges();

                    StudentList.ItemsSource = Connection.db.Student.ToList();

                    MessageBox.Show("Success");
                }

            }
            catch
            {
                MessageBox.Show("Error");
            }
            


        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
             NavigationService.Navigate(new AddPage());
        }

        private void StudentList_Selected(object sender, RoutedEventArgs e)
        {

        }
        /*
                     try
            {
                NavigationService.Navigate(new AddPage());

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
    }
}
