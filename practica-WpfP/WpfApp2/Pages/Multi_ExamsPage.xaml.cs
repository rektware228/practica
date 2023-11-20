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
    /// Логика взаимодействия для Multi_ExamsPage.xaml
    /// </summary>
    public partial class Multi_ExamsPage : Page
    {
        private Exam exam;
        public Multi_ExamsPage(Exam _exam)
        {
            InitializeComponent();
            exam = _exam;
            this.DataContext = exam;
            IdTb.DataContext = exam;
            DateTb.DataContext = exam;
            DisciplineTb.DataContext = exam;
            StudentTb.DataContext = exam;
            PositionTb.DataContext = exam;
            AuditoriumTb.DataContext = exam;
            ScoreTb.DataContext = exam;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExamCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(ExamCb.SelectedIndex != null) 
            //{ 

            //}
        }
    }
}
