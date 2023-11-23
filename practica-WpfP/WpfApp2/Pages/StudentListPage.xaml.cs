using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp2.Components;
using WpfApp2.Databases;
using static WpfApp2.Components.Navigation;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentListPage.xaml
    /// </summary>
    public partial class StudentListPage : Page
    {
        public StudentListPage()
        {
            InitializeComponent();
            MyList.ItemsSource = App.db.Student.ToList();
            Refresh();
            if (App.IsTeacher == true)
            {
                DeletosBTN.Visibility = Visibility.Hidden;
                MultiBTN.Visibility = Visibility.Hidden;
            }
        }
        private void Refresh()

        {
            IEnumerable<Student> objectsSortList = App.db.Student.ToList();
            if (SortCb.SelectedIndex != 0)
            {
                if (SortCb.SelectedIndex == 1)
                {
                    objectsSortList = objectsSortList.OrderBy(x => x.lastname);
                }
                else if (SortCb.SelectedIndex == 2)
                {
                    objectsSortList = objectsSortList.OrderByDescending(X => X.lastname);
                }
            }

            MyList.ItemsSource = objectsSortList.ToList();
            if (SearchTb.Text != null)
            {
                objectsSortList = objectsSortList.Where(x => x.lastname.ToLower().Contains(SearchTb.Text.ToLower()) ||
                x.lastname.ToLower().Contains(SearchTb.Text.ToLower()));
                MyList.ItemsSource = objectsSortList;
            }

            MyList.ItemsSource = objectsSortList.ToList().Where(x => x.IsDeleted != Convert.ToBoolean(1));

        }



        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }


        private void SortCb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void MultiBTN_Click(object sender, RoutedEventArgs e)
        {
            Student student = MyList.SelectedItem as Student;
            if (student != null)
                Navigation.NextPage(new PageComponent("Изменения", new Multi_StudentPage(student)));
            else if (student == null)
            {
                Navigation.NextPage(new PageComponent("Изменения", new Multi_StudentPage(student)));
            }
        }

        private void DeletosBTN_Click(object sender, RoutedEventArgs e)
        {
            var stud = (Student)MyList.SelectedItem;
            if (MyList.SelectedItem != null)
            {
                stud.IsDeleted = Convert.ToBoolean(1);
                Refresh();
                App.db.SaveChanges();
            }
            else MessageBox.Show("Выберите строку!");
        }
    }
}
