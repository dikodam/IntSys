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

namespace FittsExercise
{
    /// <summary>
    /// Interaction logic for Config.xaml
    /// </summary>
    public partial class Config : Window
    {

        public int ID { get; set; }
        public int NumberOfTasks { get; set; }
        public bool ResetMousePosition { get; set; }
        public bool Precueing { get; set; }

        public Config()
        {
            DataContext = this;
            ID = 20;
            NumberOfTasks = 1;
            ResetMousePosition = false;
            Precueing = false;
            InitializeComponent();
        }

        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
