using ShareObject;
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

namespace ProgramB
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ShareObject.ShareObject Persons;
        ObservableCollection<ShareObject.Person> list = new ObservableCollection<ShareObject.Person>();
        public MainWindow()
        {
            InitializeComponent();
            List.ItemsSource = list;
        }

        private void GetRemoteObject(object sender, RoutedEventArgs e)
        {
            Persons = ShareObject.ShareObject.GetRemoteObject("127.0.0.1");
            if (Persons != null)
            {
                btn0.IsEnabled = btn1.IsEnabled = btn2.IsEnabled = true;
                btn.IsEnabled = false;
            }
            
        }

        private void GetPersons(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void AddPersons(object sender, RoutedEventArgs e)
        {
            Persons.AddPersons();
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
            try
            {
                foreach (ShareObject.Person person in Persons.GetPersonList())
                {
                    list.Add(person);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message,ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}
