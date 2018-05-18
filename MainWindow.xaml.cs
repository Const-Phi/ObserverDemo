using System.Collections.ObjectModel;
using System.Windows;

namespace ObserverDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Persons = new ObservableCollection<Person>();

        public MainWindow()
        {
            InitializeComponent();

            PersonsListView.ItemsSource = Persons;
        }

        private void AddButtonOnClick(object sender, RoutedEventArgs e)
        {
            (new AddPersonDialog() { Owner = this }).ShowDialog();
        }

        private void DeleteButtonOnClick(object sender, RoutedEventArgs e)
        {
            if (PersonsListView.SelectedItem is Person person)
                Persons.Remove(person);
        }

        private void UpdateButtonOnClick(object sender, RoutedEventArgs e)
        {
            if (PersonsListView.SelectedItem is Person person)
            {
                new UpdatePersonDialog().UpdatePerson(person);
            }
        }
    }
}
