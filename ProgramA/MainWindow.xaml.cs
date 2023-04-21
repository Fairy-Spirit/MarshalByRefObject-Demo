using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProgramA
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ShareObject.Person> list = new ObservableCollection<ShareObject.Person>();
        public MainWindow()
        {
            InitializeComponent();
            ShareObject.ShareObject.InitRemoteService();
            List.ItemsSource = list;
        }
        ShareObject.ShareObject Persons = new ShareObject.ShareObject();
        private void GetPersons(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            Persons.ClearPersons();
            UpdateList();
        }

        private void UpdateList()
        {
            list.Clear();
            foreach (ShareObject.Person person in Persons.GetPersonList())
            {
                list.Add(person);
            }
        }

        private void AddPersons(object sender, RoutedEventArgs e)
        {
            Persons.AddPersons();
            UpdateList();
        }
    }
}
