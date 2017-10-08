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
                Name = "TheSlider",
                IsSnapToTickEnabled = true
            };
            slider.ValueChanged += SliderChange;
            return slider;
        }

        private void ResetSlider(object sender, RoutedEventArgs e)
        {
            ((Slider) uiElements["TheSlider"]).Value = 0;
            ((TextBlock) uiElements["TheTextBlock"]).Text = "0";
        }

        private void SliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((TextBlock) uiElements["TheTextBlock"]).Text = e.NewValue.ToString();
            if (e.NewValue == 0)
                ((Button) uiElements["TheButton"]).IsEnabled = false;
            else
                ((Button) uiElements["TheButton"]).IsEnabled = true;
        }

        private void GoAway(object sender, RoutedEventArgs e)
        {
            GenerateRandomPaddings(out int leftPadding, out int topPadding);
            ((Button)uiElements["TheButton"]).Margin = new Thickness(leftPadding, topPadding, 0, 0);
        }

        private void GenerateRandomPaddings(out int leftPadding, out int topPadding)
        {
            Random rnd = new Random();
            int buttonWidht = (int)((Button)uiElements["TheButton"]).Width;
            int buttonHeight = (int)((Button)uiElements["TheButton"]).Height;
            int halfWindowWidth = (int)Math.Floor(Width) / 2;
            int halfWindowHeight = (int)Math.Floor(Height) / 2;
            leftPadding = rnd.Next(-halfWindowWidth, halfWindowWidth - buttonWidht);
            topPadding = rnd.Next(-halfWindowHeight, halfWindowHeight - buttonHeight);
        }
    }
}
