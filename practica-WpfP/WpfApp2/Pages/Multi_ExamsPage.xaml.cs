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
using System.Xml.Linq;
using WpfApp2.Databases;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Multi_ExamsPage.xaml
    /// </summary>
    public partial class Multi_ExamsPage : Page
    {
        public Exam exam;


        public Multi_ExamsPage(Exam _exam)
        {
            InitializeComponent();
            exam = _exam;
            this.DataContext = exam;

            PositionCb.ItemsSource = App.db.Positions.ToList().Where(x => x.IsDeleted == Convert.ToBoolean(0)); ;
            PositionCb.DisplayMemberPath = "name";

            DisciplineCb.ItemsSource = App.db.Discipline.ToList().Where(x => x.IsDeleted == Convert.ToBoolean(0)); ;
            DisciplineCb.DisplayMemberPath = "name";

            StudentCb.ItemsSource = App.db.Student.ToList().Where(x => x.IsDeleted == Convert.ToBoolean(0)); ;
            StudentCb.DisplayMemberPath = "lastname";

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            bool errors = false;
            var selectStudent = StudentCb.SelectedItem as Student;
            var selectTeacher = PositionCb.SelectedItem as Positions;
            var selectSubject = DisciplineCb.SelectedItem as Discipline;
            if (string.IsNullOrEmpty(AuditoriumTb.Text) || selectStudent == null || selectTeacher == null || selectSubject == null)
            {
                MessageBox.Show("Заполните данные!");
                errors = true;
            }

            if ((ScoreTb.Text == "" || char.IsDigit(char.Parse(ScoreTb.Text))) && !errors)
            {
                if (int.Parse(ScoreTb.Text) > 5 || int.Parse(ScoreTb.Text) < 1)
                {
                    MessageBox.Show("Неправильный формат оценки!");
                    errors = true;
                }
            }
            else
            { MessageBox.Show("Неправильный формат оценки!"); errors = true; }

            if (exam.ID_exam == 0 && !errors)
            {
                if (App.db.Exam.Any(x => x.date == exam.date && x.ID_student == exam.ID_student && x.ID_discipline == exam.ID_discipline))
                {
                    MessageBox.Show("Повторение!!1!");
                    errors = true;
                }
                else
                {

                    App.db.Exam.Add(new Exam()
                    {
                        date = exam.date,
                        ID_discipline = selectSubject.ID_discipline,
                        ID_student = selectStudent.ID_student,
                        ID_positions = selectTeacher.ID_positions,
                        auditorium = exam.auditorium,
                        score = exam.score,
                        IsDeleted = Convert.ToBoolean(0),
                    });
                }
            }
            if (!errors)
            {
                exam.ID_discipline = selectSubject.ID_discipline;
                exam.ID_student = selectStudent.ID_student;
                exam.ID_positions = selectTeacher.ID_positions;
                App.db.SaveChanges();
                MessageBox.Show("Сохранено!");
                NavigationService.Navigate(new ExamsListPage());
            }

            //public void ExamCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
            //{
            //    //if(ExamCb.SelectedIndex != null) 
            //    //{ 

            //    //}
            //}
        }
    }
}
