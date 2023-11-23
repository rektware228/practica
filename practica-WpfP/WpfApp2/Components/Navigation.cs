using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp2.Components
{
    internal class Navigation
    {
        private static List<PageComponent> components = new List<PageComponent>();
        public static MainWindow mainWindow;

        public static void Update(PageComponent pageComponent)
        {
            mainWindow.TitleTb.Text = pageComponent.Title;
            mainWindow.BackBTN.Visibility = components.Count() >
            1 ? System.Windows.Visibility.Visible :
            System.Windows.Visibility.Hidden;
            mainWindow.ExitBTN.Visibility = App.IsTeacher || App.IsTeacher || App.IsStudent || App.IsEngineer || App.IsOwner?
            System.Windows.Visibility.Visible :
            System.Windows.Visibility.Hidden;
            mainWindow.MyFrame.Navigate(pageComponent.Page);
        }
        public static void NextPage(PageComponent pageComponent)
        {
            components.Add(pageComponent);
            Update(pageComponent);
        }
        public static void BackPage()
        {
            if (components.Count > 1)
            {
                components.RemoveAt(components.Count - 1);
                Update(components[components.Count - 1]);
            }
        }

        public static void ClearHistory()
        {
            App.IsTeacher = false;
            App.IsStudent = false;
            App.IsEngineer = false;
            App.IsOwner = false;

            components.Clear();
        }
        public class PageComponent /// нужен для хранения заголовка и страницы
        {
            public string Title { get; set; }
            public Page Page { get; set; }
            public PageComponent(string title, Page page)
            {
                Title = title;
                Page = page;
            }

        }
    }
}
