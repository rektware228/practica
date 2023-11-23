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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using WpfApp2.Databases;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Multi_SubjectPage.xaml
    /// </summary>
    public partial class Multi_SubjectPage : Page
    {
        private Discipline discipline;

        public string WhatToDo;
        public Multi_SubjectPage(Discipline _discipline)
        {
            InitializeComponent();
            discipline = _discipline;
            this.DataContext = discipline;
            //IdTb.DataContext = discipline;
            //DepartmentTb.DataContext = discipline;  
            //LastnameTb.DataContext = discipline;
            //VolumeTb.DataContext = discipline;
            if (discipline != null && discipline.ID_discipline > 0) IdTb.IsReadOnly = true;
            DepartmentCb.ItemsSource = App.db.Department.ToList();
            DepartmentCb.DisplayMemberPath = "name";

            if (discipline.ID_discipline > 0)
            {
                var sss = App.db.Department.ToList().Where(x => x.ID_department == discipline.ID_department).First();
                DepartmentCb.SelectedIndex = DepartmentCb.Items.IndexOf(sss);
            }

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            bool errors = false;
            var selectLec = DepartmentCb.SelectedItem as Department;
            if (selectLec == null || nameTb.Text == "" || VolumeTb.Text == "")
            {
                errors = true;
                MessageBox.Show("Заполните обязательные данные!");
            }
            //if (IdTb.Text.Length < 3)
            //{
            //    errors = true;
            //   MessageBox.Show("Длина таб.номера должна быть 3 символа!");
            //}
            if (App.db.Discipline.Any(x => x.ID_discipline == discipline.ID_discipline) && WhatToDo == "add")
            {
                errors = true;
                MessageBox.Show("Такой таб.номер уже есть!");
            }

            if (!errors)
            {
                if (!errors)
                {
                    App.db.Discipline.Add(new Discipline()
                    {
                        ID_discipline = Convert.ToInt32(IdTb.Text),
                        name = nameTb.Text,
                        volume = int.Parse(VolumeTb.Text),
                        ID_department = selectLec.ID_department,
                        IsDeleted = Convert.ToBoolean(0)
                    });
                }
                if (selectLec != null)
                {
                    MessageBox.Show("Сохранено!");
                    App.db.SaveChanges();
                    NavigationService.Navigate(new SubjectListPage());
                }

            }
        }
    }
}
