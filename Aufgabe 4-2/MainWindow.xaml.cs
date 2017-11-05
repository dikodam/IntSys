using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DataBinding
{
    /// <summary>
    /// Code behind of MainWindow.xaml
    /// 
    /// The code of this particular project is intentionally left incomplete
	/// (code-behind as well as XAML). Missing pieces of code are indicated by
	/// markers such as ___1___.
	///
    /// As an exercise, the missing pieces of code should be identified and
	/// inserted. Do not add additional code. The full program should use data
	/// bindings in order to display 9876543 in each Label once the button
    /// Change is clicked.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Create an instance of class student
        protected MyClass myObject = new MyClass();
        public MyClass MyObject
        {
            get { return myObject; }
            set { myObject = value; }
        }

        public MainWindow()
        {
            InitializeComponent();

            Binding myBinding = new Binding(/* 1 */ "MyField" /* 1 */);
            myBinding.Source = /* 2 */ MyObject /* 2 */;
            A.SetBinding(/* 3 */ Label.ContentProperty /* 3 */ , myBinding);

            D.DataContext = /* 4 */ this /* 4 */;
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            myObject.MyField = 9876543;
        }
    }

    /// <summary>
    /// A simple representation of a student's properties.
    /// </summary>
    public class MyClass : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor, creates an empty object.
        /// </summary>
        public MyClass()
        {
        }

        public event PropertyChangedEventHandler /* 12 */ PropertyChanged /* 12 */;

        /// <summary>
        /// Raise a PropertyChanged event.
		///
		/// Should be called after a value change in one of this' properties. 
        /// </summary>
        /// <param name="pname">A string describing the name of the property that has changed.</param>
        protected void RaisePropertyChanged(string pname)
        {
            Console.WriteLine("RAISE " + pname);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pname));
            }
        }

        int _MyField = 708312;
        public int MyField
        {
            set
            {
                _MyField = value;
                RaisePropertyChanged(/* 11 */ nameof(MyField) /* 11 */);
            }
            get
            {
                return _MyField;
            }
        }
    }
}