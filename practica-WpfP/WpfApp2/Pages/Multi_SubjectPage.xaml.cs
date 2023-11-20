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
    /// Логика взаимодействия для Multi_SubjectPage.xaml
    /// </summary>
    public partial class Multi_SubjectPage : Page
    {
        private Discipline discipline;
        public Multi_SubjectPage(Discipline _discipline)
        {
            InitializeComponent();
            discipline = _discipline;
            this.DataContext = discipline;
            IdTb.DataContext = discipline;
            DepartmentTb.DataContext = discipline;  
            LastnameTb.DataContext = discipline;
            VolumeTb.DataContext = discipline;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
