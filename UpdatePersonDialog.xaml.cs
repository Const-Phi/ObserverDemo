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
using System.Windows.Shapes;

namespace ObserverDemo
{
    /// <summary>
    /// Логика взаимодействия для UpdatePersonDialog.xaml
    /// </summary>
    public partial class UpdatePersonDialog : Window
    {
        public UpdatePersonDialog()
        {
            InitializeComponent();
        }

        private Person person;

        public void UpdatePerson(Person person)
        {
            this.person = person;
            ShowDialog();
        }

        private void UpdateButtonOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                person.Name = NameInput.Text.Trim();
                Close();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Всё плохо!");
            }
        }
    }
}
