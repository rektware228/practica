using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Databases;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static UchPr2_3NFEntities1 db = new UchPr2_3NFEntities1();
        public static bool IsStudent = false; //вход студента
        //public static bool IsTeacher = false; //вход учителя
        //public static bool IsHeadDepartment = false; //вход зава кафедры
        public static bool IsTeacher = false; //вход учителя

    }
}
