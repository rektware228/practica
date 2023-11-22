using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.PerformanceData;
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
using System.Xml.Linq;
using WpfApp2.Components;
using WpfApp2.Databases;
using static WpfApp2.Components.Navigation;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для SubjectListPage.xaml
    /// </summary>
    public partial class SubjectListPage : Page
    {
        public SubjectListPage()
        {
            InitializeComponent();
            MyList.ItemsSource = App.db.Discipline.ToList();
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
            IEnumerable<Discipline> disSortList = App.db.Discipline.ToList();
            if (SortCb.SelectedIndex != 0)
            {
                if (SortCb.SelectedIndex == 1)
                    disSortList = disSortList.Where(x => x.volume >= 0 && x.volume < 80);
                else if (SortCb.SelectedIndex == 2)
                    disSortList = disSortList.Where(x => x.volume >= 80 && x.volume < 160);
                else if (SortCb.SelectedIndex == 3)
                    disSortList = disSortList.Where(x => x.volume >= 160 && x.volume < 320);
                else if (SortCb.SelectedIndex == 4)
                    disSortList = disSortList.Where(x => x.volume >= 320 && x.volume <= 640);
            }
            MyList.ItemsSource = disSortList.ToList();
            if (SearchTb.Text != null)
            {
                disSortList = disSortList.Where(x => x.name.ToLower().Contains(SearchTb.Text.ToLower()) || x.name.ToLower().Contains(SearchTb.Text.ToLower()));
                MyList.ItemsSource = disSortList;
            }
            MyList.ItemsSource = disSortList.ToList().Where(x => x.IsDeleted != Convert.ToBoolean(1));

        }

        private void MultiBTN_Click(object sender, RoutedEventArgs e)
        {
            Discipline discipline = MyList.SelectedItem as Discipline;
            if (MyList.SelectedItem != null)
                Navigation.NextPage(new PageComponent("Изменения", new Multi_SubjectPage(discipline)));
            else
                Navigation.NextPage(new PageComponent("Добавление", new Multi_SubjectPage(new Discipline())));
        }

        private void DeletosBTN_Click(object sender, RoutedEventArgs e)
        {
            var subject = (Discipline)MyList.SelectedItem;
            if (MyList.SelectedItem != null)
            {
                subject.IsDeleted = Convert.ToBoolean(1);
                Refresh();
                App.db.SaveChanges();
            }
            else MessageBox.Show("Выберите строку!");
        }
    }
}
