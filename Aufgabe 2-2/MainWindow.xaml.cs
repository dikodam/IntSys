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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aufgabe_2_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Grid theGrid = null;
        Dictionary<String, UIElement> uiElements = null;

        public MainWindow()
        {
            InitTheGrid();
            uiElements = CreateUiElements();
            AppendUiElementsToGrid(theGrid);
            InitializeComponent();
        }

        private void InitTheGrid()
        {
            theGrid = new Grid();
            AddChild(theGrid);
        }

        private void AppendUiElementsToGrid(Grid aGrid)
        {
            foreach (UIElement element in uiElements.Values)
                aGrid.Children.Add(element);
        }

        private Dictionary<String, UIElement> CreateUiElements() => new Dictionary<String, UIElement>() {
                { "TheButton", CreateTheButton() },
                { "TheSlider", CreateTheSlider() },
                { "TheTextBlock", CreateTheTextBlock() }
            };

        private TextBlock CreateTheTextBlock() => new TextBlock {
                Width = 80,
                Height = 50,
                TextAlignment = TextAlignment.Right,
                Text = "Not initialized",
                Margin = new Thickness(-350, -20, 0, 0),
                Name = "TheTextBlock"
            };

        private Button CreateTheButton()
        {
            var button = new Button {
                Content = "Reset",
                Width = 70,
                Height = 28,
                Margin = new Thickness(380, 50, 0, 0),
                Name = "TheButton"
            };
            button.Click += new RoutedEventHandler(ResetSlider);
            return button;
        }

        private Slider CreateTheSlider()
        {
            var slider = new Slider
            {
                Width = 350,
                Height = 28,
                Minimum = 0,
                Maximum = 100,
                Margin = new Thickness(110, -50, 0, 0),
                Name = "TheSlider"
            };
            slider.AddHandler(Slider.ValueChangedEvent, new RoutedPropertyChangedEventHandler<double>(SliderChange));
            return slider;
        }
        private void ResetSlider(object sender, RoutedEventArgs e)
        {
            ((Slider) uiElements["TheSlider"]).Value = 0;
            ((TextBlock) uiElements["TheTextBlock"]).Text = "0";
        }

        private void SliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var new_value = Math.Round(e.NewValue, 0);
            ((TextBlock) uiElements["TheTextBlock"]).Text = Math.Round(e.NewValue, 0).ToString();
            if (new_value == 0)
                ((Button) uiElements["TheButton"]).IsEnabled = false;
            else
                ((Button) uiElements["TheButton"]).IsEnabled = true;
        }


    }
}
