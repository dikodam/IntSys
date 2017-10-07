using System.Windows;

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
        }

        private void SliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TheTextBox.Text = e.NewValue.ToString();
        }
    }
}
