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
using static WpfApp2.Components.Navigation;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
            App.IsTeacher = false;
            App.IsStudent = false;
            if (PasswordPb.Password == "a" && LoginTb.Text == "a")
            {
                App.IsTeacher = true;
                MessageBox.Show("Вы вошли как учитель");
                Navigation.NextPage(new PageComponent("Выбор страниц", new ChooseWindow()));
            }

            else if (PasswordPb.Password == "kirill" && LoginTb.Text == "kirill")
            {
                App.IsStudent = true;
                MessageBox.Show("Вы вошли как ученик");
                Navigation.NextPage(new PageComponent("Выбор страниц", new ChooseWindow()));
            }

            else if(PasswordPb.Password == null && LoginTb.Text == null)
                { MessageBox.Show("Доступ запрещен!");
            }
        }
    }
}
