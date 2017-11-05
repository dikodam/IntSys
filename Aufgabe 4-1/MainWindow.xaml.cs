using System;
using System.Windows;

namespace Aufgabe_4_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Student MyStudent { get; set; } = new Student() {
            Matrikelnummer = new Random().Next(0, 1000000).ToString("D6"),
            Name = Environment.UserName
        };

        public Editor editor = new Editor();

        public MainWindow()
        {
            editor.DataContext = this;
            editor.Show();

            InitializeComponent();
        }
    }
}
