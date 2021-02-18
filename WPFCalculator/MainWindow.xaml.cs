using System;
using System.Collections.Generic;
using System.Data;
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

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string inputBar = "";
        string smallinputBar = "";
        public MainWindow()
        {
            InitializeComponent();
            btnDivide.Content = "\u00F7";

        }

        private void btnNumClick(object sender, RoutedEventArgs e)
        {
            var btnname = ((Button)sender).Content;
            if (inputBar == "0")
            {
                inputBar = btnname.ToString();
            }
            else
            {
                inputBar += btnname;
            }
            inputText.Text = inputBar;


        }


        public void Calculate(object sender, RoutedEventArgs e)
        {

            if (inputBar != "" && smallinputBar != "")
            {
                var result = new DataTable().Compute(smallinputBar + inputBar, null);
                smallinputBar += inputBar + "=" + result.ToString();
                smallinput.Text = smallinputBar;
                inputBar = result.ToString();
                inputText.Text = inputBar;
                smallinputBar = "";
            }
            else
            {
                inputBar = "";
                inputText.Text = inputBar;
                smallinputBar = "";
                smallinput.Text = smallinputBar;
            }

        }
        private void aDDOperator(object sender, RoutedEventArgs e)
        {
            var btnname = ((Button)sender).Content;
            if (((Button)sender).Name == "btnMultiple")
            {
                btnname = "*";
            }
            else if (((Button)sender).Name == "btnDivide")
            {
                btnname = "/";
            }

            smallinputBar += inputBar + btnname;
            smallinput.Text = smallinputBar;

            inputBar = "0";
            inputText.Text = inputBar;

        }

        public void deleteAll(object sender, RoutedEventArgs e)
        {
            inputBar = "";
            inputText.Text = inputBar;
            smallinputBar = "";
            smallinput.Text = smallinputBar;

        }
        private void deleteOne(object sender, RoutedEventArgs e)
        {
            if (inputBar.Length > 1)
            {

                inputBar = inputBar.Remove(inputBar.Length - 1);
            }
            else
            {
                inputBar = "";
            }


            inputText.Text = inputBar;
        }
        private void plusOrMinus(object sender, RoutedEventArgs e)
        {

            if (inputBar != "0")
            {

                if (inputBar.Substring(0, 1) == "-")
                {

                    inputBar = inputBar.Remove(0, 1);

                }
                else
                {
                    inputBar = "-" + inputBar;

                }
                inputText.Text = inputBar;

            }
        }

        private void addDot(object sender, RoutedEventArgs e)
        {


           
                if (inputBar.Substring(inputBar.Length - 1) == ".")
                {

                    inputBar = inputBar.Remove(inputBar.Length - 1);

                }
                else
                {
                if (!inputBar.Contains(".")) {
                    inputBar = inputBar + ".";
                }
                   

                }
                inputText.Text = inputBar;

            
        }

    }
}
