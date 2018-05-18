using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ObserverDemo.Annotations;

namespace ObserverDemo
{
    public sealed class Person : INotifyPropertyChanged
    {
        private string name;

        private int year;

        /// <summary>
        /// Имя пользователя
        /// </summary>
        /// <exception cref="ArgumentException"/>
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Имя персоны не может быть пустым", nameof(Name));
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Year
        {
            get => year;
            set
            {
                year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException"/>
        public Person(string name, int year = 0)
        {
            Name = name;
            Year = year;
        }

        public override string ToString() => Name;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
