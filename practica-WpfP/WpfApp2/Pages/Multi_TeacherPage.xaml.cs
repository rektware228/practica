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
using WpfApp2.Databases;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Multi_TeacherPage.xaml
    /// </summary>
    public partial class Multi_TeacherPage : Page

    {
        private Positions positions;
        public Multi_TeacherPage(Positions _positions)
        {
            InitializeComponent();
            positions = _positions;
            this.DataContext = positions;
            IdTb.DataContext = positions;
            NameTb.DataContext = positions;
            DepartmentTb.DataContext = positions;
            SpecialityTb.DataContext = positions;
            SalaryTb.DataContext = positions;   
            ShefTb.DataContext = positions;
            ExpTb.DataContext = positions;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
