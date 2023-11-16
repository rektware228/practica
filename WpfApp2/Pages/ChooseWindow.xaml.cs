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
using WpfApp2.Components;
using WpfApp2.Pages;
using static WpfApp2.Components.Navigation;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChooseWindow.xaml
    /// </summary>
    public partial class ChooseWindow : Page
    {
        public ChooseWindow()
        {
            InitializeComponent();
        }

        private void StudentBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Список студентов", new StudentListPage()));
        }

        private void ExamsBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Список экзаменов", new ExamsListPage()));
        }

        private void EmployeeBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Список сотрудников", new TeacherListPage()));
        }

        private void SubjectsBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Список предметов", new SubjectListPage()));
        }
    }
}
