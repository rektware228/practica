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
using WpfApp2.Components;
using WpfApp2.Databases;
using static WpfApp2.Components.Navigation;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExamsListPage.xaml
    /// </summary>
    public partial class ExamsListPage : Page
    {
        public ExamsListPage()
        {
            InitializeComponent();
            ExamsList.ItemsSource = App.db.Exam.ToList();
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
            IEnumerable<Exam> examSortList = App.db.Exam.ToList();
            if (SortCb.SelectedIndex != 0)
            {
                if (SortCb.SelectedIndex == 1)
                    examSortList = examSortList.Where(x => x.score == 1);
                else if (SortCb.SelectedIndex == 2)
                    examSortList = examSortList.Where(x => x.score == 2);
                else if (SortCb.SelectedIndex == 3)
                    examSortList = examSortList.Where(x => x.score == 3);
                else if (SortCb.SelectedIndex == 4)
                    examSortList = examSortList.Where(x => x.score == 4);
                else if (SortCb.SelectedIndex == 5)
                    examSortList = examSortList.Where(x => x.score == 5);
            }
            ExamsList.ItemsSource = examSortList.ToList();

            if (SearchTb.Text != null)
            {
                examSortList = examSortList.Where(x => x.auditorium.ToLower().Contains
                (SearchTb.Text.ToLower()) || x.auditorium.ToLower().Contains
                (SearchTb.Text.ToLower()));
                ExamsList.ItemsSource = examSortList;
            }
            ExamsList.ItemsSource = examSortList.ToList().Where(x => x.IsDeleted != Convert.ToBoolean(1));
        }

        private void MultiBTN_Click(object sender, RoutedEventArgs e)
        {
            Exam exam = ExamsList.SelectedItem as Exam;
            if (ExamsList.SelectedItem != null)
                Navigation.NextPage(new PageComponent("Изменения", new Multi_ExamsPage(exam)));
            else

                Navigation.NextPage(new PageComponent("Добавление", new Multi_ExamsPage(new Exam())));
            //else if (exam == null)
            //{
            //    NavigationService.Navigate(new Multi_ExamsPage());
            //}

        }

        private void DeletosBTN_Click(object sender, RoutedEventArgs e)
        {
            var exm = (Exam)ExamsList.SelectedItem;
            if (ExamsList.SelectedItem != null)
            {
                exm.IsDeleted = Convert.ToBoolean(1);
                Refresh();
                App.db.SaveChanges();
            }
            else MessageBox.Show("Выберите строку!");

            




        }



    }
}
