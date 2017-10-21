using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            var boxes = ThePanel.Children;
            List<Binding> bindings = new List<Binding>();
            foreach (TextBox box in boxes)
            {
                bindings.Add(new Binding("Text"));
                bindings.Last().Source = boxes[(boxes.IndexOf(box) + 1) % boxes.Count];
                box.SetBinding(TextBox.TextProperty, bindings.Last());
            }
        }
    }
}
