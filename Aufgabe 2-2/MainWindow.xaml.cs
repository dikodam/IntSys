using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Aufgabe_2_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string buttonKey = "TheButton";
        const string sliderKey = "TheSlider";
        const string textBlockKey = "TheTextBlock";

        Grid theGrid = new Grid();
        Dictionary<String, UIElement> uiElements = null;

        public MainWindow()
        {
            AddChild(theGrid);
            uiElements = CreateUiElements();
            AppendUiElementsToGrid(theGrid);
            InitializeComponent();
        }

        private void AppendUiElementsToGrid(Grid aGrid)
        {
            foreach (UIElement element in uiElements.Values)
                aGrid.Children.Add(element);
        }

        private Dictionary<String, UIElement> CreateUiElements() => new Dictionary<String, UIElement>() {
                { buttonKey, CreateTheButton() },
                { sliderKey, CreateTheSlider() },
                { textBlockKey, CreateTheTextBlock() }
            };

        private TextBlock CreateTheTextBlock() => new TextBlock {
                Width = 80,
                Height = 50,
                TextAlignment = TextAlignment.Right,
                Text = "Not initialized",
                Margin = new Thickness(-350, -20, 0, 0),
                Name = textBlockKey
        };

        private Button CreateTheButton()
        {
            var button = new Button {
                Content = "Reset",
                Width = 70,
                Height = 28,
                Margin = new Thickness(380, 50, 0, 0),
                Name = buttonKey
            };
            button.Click += ResetSlider;
            button.MouseEnter += GoAway;
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
                Name = sliderKey,
                IsSnapToTickEnabled = true
            };
            slider.ValueChanged += SliderChange;
            return slider;
        }

        private void ResetSlider(object sender, RoutedEventArgs e)
        {
            ((Slider) uiElements[sliderKey]).Value = 0;
            ((TextBlock) uiElements[textBlockKey]).Text = "0";
        }

        private void SliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((TextBlock) uiElements[textBlockKey]).Text = e.NewValue.ToString();
            ((Button)uiElements[buttonKey]).IsEnabled = e.NewValue == 0 ? false : true;
        }

        private void GoAway(object sender, RoutedEventArgs e)
        {
            ((Button)uiElements[buttonKey]).Margin = GenerateRandomPaddings();
        }

        private Thickness GenerateRandomPaddings()
        {
            Random rnd = new Random();
            int buttonWidht = (int)((Button)uiElements[buttonKey]).Width;
            int buttonHeight = (int)((Button)uiElements[buttonKey]).Height;
            int halfWindowWidth = (int)Math.Floor(Width) / 2;
            int halfWindowHeight = (int)Math.Floor(Height) / 2;
            int leftPadding = rnd.Next(-halfWindowWidth, halfWindowWidth - buttonWidht);
            int topPadding = rnd.Next(-halfWindowHeight, halfWindowHeight - buttonHeight);
            return new Thickness(leftPadding, topPadding, 0, 0);
        }
    }
}
