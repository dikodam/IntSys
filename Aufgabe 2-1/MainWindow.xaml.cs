using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Aufgabe_2_1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResetSlider(object sender, RoutedEventArgs e)
        {
            TheSlider.Value = 0;
            TheTextBox.Text = "0";
        }

        private void SliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TheTextBox.Text = e.NewValue.ToString();
        }
    }
}
