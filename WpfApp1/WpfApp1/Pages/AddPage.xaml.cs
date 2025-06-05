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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();

            GroupCBX.ItemsSource = Connection.db.Group.ToList();
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            var CMBXGroups = GroupCBX.SelectedItem as Group;


            if (string.IsNullOrWhiteSpace(NameTB.Text))
            { 
                MessageBox.Show("Поле имени не заполнено");
                return;
            }
            if ((CMBXGroups == null))
            {
                MessageBox.Show("Группа не выбрана");
                return;
            }
            if (DateTB.Text == null)
            {
                MessageBox.Show("Дата заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(SurnameTB.Text))
            {
                MessageBox.Show("Поле фамилии не заполнено");
                return;
            }


            try
            {
                
                Student people = new Student()
                {
                    Name = NameTB.Text,
                    Surname = SurnameTB.Text,
                    EnterData = DateTB.DisplayDate,
                    GroupID = CMBXGroups.Id

                };
                Connection.db.Student.Add(people);
                Connection.db.SaveChanges();
                MessageBox.Show("Успешно");
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }

            
        }
    }
}
