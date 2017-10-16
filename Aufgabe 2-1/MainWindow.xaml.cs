using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Timers;

namespace Aufgabe_2_1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer aTimer;
        private MediaPlayer airHorn = new MediaPlayer();
        private MediaPlayer wowEffect = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            airHorn.Open(new Uri(Path.Combine(Environment.CurrentDirectory, @"..\..\AIRHORN.mp3")));
            wowEffect.Open(new Uri(Path.Combine(Environment.CurrentDirectory, @"..\..\damn.mp3")));
            aTimer = new Timer()
            {
                Interval = 500,
                AutoReset = true
            };
            aTimer.Elapsed += ChangeLayout;
            aTimer.Enabled = true;
        }

        private void ChangeLayout(Object source, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                Height = 500;
                Width = 1000;
                TheGrid.Width = new Random().Next(200, 1000);
            });
        }

        private void ResetSlider(object sender, RoutedEventArgs e)
        {
            wowEffect.Stop();
            wowEffect.Play();
            TheSlider.Value = 0;
        }

        private void SliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color color = new Color();
            Random rnd = new Random();
            color.A = (byte)(100);
            color.R = (byte)(rnd.Next(0, 255));
            color.G = (byte)(rnd.Next(0, 255));
            color.B = (byte)(rnd.Next(0, 255));
            frcolor.Fill = new SolidColorBrush(color);

            TheTextBox.Text = e.NewValue.ToString();
            airHorn.Stop();
            airHorn.Play();
            airHorn.SpeedRatio = new Random().Next(0,100) / 100;
            TheButton.IsEnabled = e.NewValue != 0;
        }
    }
}
