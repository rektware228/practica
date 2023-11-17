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
using WpfApp2.Databases;

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
        }
        private void Refresh()

        {   IEnumerable<Student> objectsSortList = App.db.Student.ToList();
            if(SortCb.SelectedIndex != 0)
            {
                if(SortCb.SelectedIndex == 1)
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
                 objectsSortList = objectsSortList.Where(x => x.lastname.ToLower().Contains(SearchTb.Text.ToLower()) || x.lastname.ToLower().Contains(SearchTb.Text.ToLower()));
                MyList.ItemsSource = objectsSortList;
            }
          
        }



        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

       
        private void SortCb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
