using System;
using System.Collections;
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
using WpfApp2.Databases;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для TeacherListPage.xaml
    /// </summary>
    public partial class TeacherListPage : Page
    {
        public TeacherListPage()
        {
            InitializeComponent();
            PositionsList.ItemsSource = App.db.Positions.ToList();
            Refresh();
        }
        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<Positions> positionsSortList = App.db.Positions.ToList();
            if (SortCb.SelectedIndex != 0)
            {
                if (SortCb.SelectedIndex == 1)
                    positionsSortList = positionsSortList.Where(x => x.experience >= 0 && x.experience < 10);
                else if (SortCb.SelectedIndex == 2)
                    positionsSortList = positionsSortList.Where(x => x.experience >= 10 && x.experience < 20);
                else if (SortCb.SelectedIndex == 3)
                    positionsSortList = positionsSortList.Where(x => x.experience >= 20 && x.experience < 30);
                else if (SortCb.SelectedIndex == 4)
                    positionsSortList = positionsSortList.Where(x => x.experience >= 30 && x.experience < 100);
            }
            PositionsList.ItemsSource = positionsSortList.ToList();

            if (SearchTb.Text != null)
            {
                positionsSortList = positionsSortList.Where(x => x.name.ToLower().Contains
                (SearchTb.Text.ToLower()) || x.name.ToLower().Contains
                (SearchTb.Text.ToLower()));
                PositionsList.ItemsSource = positionsSortList;
            }
        }


    }
}
