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
        public string WhatToDo;
        public Multi_TeacherPage(Positions _positions)
        {
            InitializeComponent();
            positions = _positions;
            this.DataContext = positions;

            DepartmentCb.ItemsSource = App.db.Department.ToList();
            DepartmentCb.DisplayMemberPath = "name";

            SpecialityCb.ItemsSource = App.db.Title.ToList();
            SpecialityCb.DisplayMemberPath = "name";

            ShefCb.ItemsSource = App.db.Positions.ToList().Where(x => x.ID_positions == x.shef);
            ShefCb.DisplayMemberPath = "name";

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            bool errors = false;

            var selectLectern = DepartmentCb.SelectedItem as Department;
            var selectPosition = SpecialityCb.SelectedItem as Title;
            var selectChief = ShefCb.SelectedItem as Positions;

            if (selectLectern == null || selectPosition == null || IdTb.Text == "0" || NameTb.Text == "" || SalaryTb.Text == "" || selectChief == null)
            {
                errors = true; if (NameTb.Text == "кириешки") MessageBox.Show("какие нафиг кириешки?!");
                MessageBox.Show("Заполните обязательные данные!");
            }
            if (IdTb.Text.Length < 3)
            {
                errors = true;
                MessageBox.Show("Длина таб.номера должна быть 3 символа!");
            }
            if (App.db.Positions.Any(x => x.ID_positions == positions.ID_positions) && WhatToDo == "add")
            {
                errors = true;
                MessageBox.Show("Такой таб.номер уже есть!");
            }
            if (!errors)
            {
                if (WhatToDo == "add")
                {
                    App.db.Positions.Add(new Positions()
                    {
                       ID_positions = positions.ID_positions,
                        ID_department = selectLectern.ID_department,
                        name = NameTb.Text,
                        ID_title = selectPosition.ID_title,
                        salary = decimal.Parse(SalaryTb.Text),
                        shef = selectChief.ID_positions,
                        IsDeleted = Convert.ToBoolean(0)
                    });
                }
                if (selectPosition != null)
                positions.ID_department = selectLectern.ID_department;
                positions.ID_title = selectPosition.ID_title;
                positions.shef = selectChief.ID_positions;
                MessageBox.Show("Сохранено!");
                App.db.SaveChanges();
                NavigationService.Navigate(new TeacherListPage());
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
