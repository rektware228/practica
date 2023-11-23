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
        public string WhatToDo;
        public Multi_StudentPage(Student _student)
        {
            InitializeComponent();
            student = _student;

            this.DataContext = student;

            if (student != null && student.ID_speciality > 0) IdTb.IsReadOnly = true;
            SpecialityCb.ItemsSource = App.db.Speciality.ToList();
            SpecialityCb.DisplayMemberPath = "direction";

            if (student.ID_student > 0)
            {
                var sss = App.db.Speciality.ToList().Where(x => x.ID_spec == student.ID_speciality).First();
                SpecialityCb.SelectedIndex = SpecialityCb.Items.IndexOf(sss);
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            bool errors = false;
            var selectSpec = SpecialityCb.SelectedItem as Speciality;
            if (selectSpec == null || LastnameTb.Text == "")
            {
                errors = true;
                MessageBox.Show("Заполните обязательные данные!");
            }
            
            if (App.db.Student.Any(x => x.ID_student == student.ID_student) && WhatToDo == "add")
            {
                errors = true;
                MessageBox.Show("Такой таб.номер уже есть!");
            }
            if (!errors)
            {
                if (!errors)
                {
                    App.db.Student.Add(new Student()
                    {
                        ID_student = student.ID_student,
                        lastname = student.lastname,
                        ID_speciality= selectSpec.ID_spec,
                        IsDeleted = Convert.ToBoolean(0)
                    });
                }
                else student.ID_speciality = selectSpec.ID_spec;
                MessageBox.Show("Сохранено!");
                App.db.SaveChanges();
                NavigationService.Navigate(new StudentListPage());
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
