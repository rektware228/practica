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
using static WpfApp2.Components.Navigation;
using WpfApp2.Components;
using WpfApp2.Pages;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyFrame.Navigate(new ChooseWindow());
            Navigation.mainWindow = this;
            Navigation.NextPage(new PageComponent("Авторизация", new AuthorizationPage()));
        }

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.ClearHistory();
            Navigation.NextPage(new PageComponent("Авторизация", new AuthorizationPage()));
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.BackPage();
        }
    }

}
