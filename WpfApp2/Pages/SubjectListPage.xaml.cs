﻿using System;
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
        }
    }
}