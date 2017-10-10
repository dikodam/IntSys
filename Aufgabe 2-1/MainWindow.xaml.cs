using System;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace Aufgabe_2_1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer airHorn = new MediaPlayer();
        private MediaPlayer wowEffect = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            airHorn.Open(new Uri(Path.Combine(Environment.CurrentDirectory, @"..\..\AIRHORN.mp3")));
            wowEffect.Open(new Uri(Path.Combine(Environment.CurrentDirectory, @"..\..\damn.mp3")));
        }

        private void ResetSlider(object sender, RoutedEventArgs e)
        {
            wowEffect.Stop();
            wowEffect.Play();
            TheSlider.Value = 0;
        }

        private void SliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TheTextBox.Text = e.NewValue.ToString();
            airHorn.Stop();
            airHorn.Play();
            TheButton.IsEnabled = e.NewValue == 0 ? false : true;
            
        }
    }
}
