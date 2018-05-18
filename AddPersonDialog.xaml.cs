using System;
using System.Windows;
using System.Windows.Media;

namespace ObserverDemo
{
    /// <summary>
    /// Логика взаимодействия для AddPersonDialog.xaml
    /// </summary>
    public partial class AddPersonDialog : Window
    {
        public AddPersonDialog()
        {
            InitializeComponent();

            borderBrush = NameInput.BorderBrush;
            backgroundBrush = NameInput.Background;
        }

        private readonly Brush borderBrush;

        private readonly Brush backgroundBrush;

        private void AddButtonOnClick(object sender, RoutedEventArgs e)
        {
            var name = NameInput.Text.Trim();
            try
            {
                var person = new Person(name);
                if (Owner is MainWindow owner)
                    owner.Persons.Add(person);
                Close();
            }
            catch (ArgumentException)
            {
                NameInput.BorderBrush = Brushes.DarkRed;
                NameInput.Background = Brushes.PaleVioletRed;
            }
        }

        private void NameInput_OnGotFocus(object sender, RoutedEventArgs e)
        {
            NameInput.BorderBrush = borderBrush;
            NameInput.Background = backgroundBrush;
        }
    }
}
