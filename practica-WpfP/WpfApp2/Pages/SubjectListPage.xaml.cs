﻿using System;
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
using WpfApp2.Databases;

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
            CountDataTb.Text = disSortList.Count() + "" + App.db.Student.ToList().Count;
        }

    }
}
