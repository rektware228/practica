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
    /// Логика взаимодействия для Multi_StudentPage.xaml
    /// </summary>
    public partial class Multi_StudentPage : Page
    {
        private Student student;
        public Multi_StudentPage(Student _student)
        {
            InitializeComponent();
            student = _student;
            this.DataContext = student;
            IdTb.DataContext = student;
            SpecialityTb.DataContext = student;
            LastnameTb.DataContext = student;

            
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
