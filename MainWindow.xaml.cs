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

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cmbFont.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            tb.Text += b.Content.ToString();
        }

        private void Result(object sender, RoutedEventArgs e)
        {
            try
            {
                result();
            }
            catch (Exception ex)
            {
                tb.Text = "Error!";
            }
        }
        private void result()
        {
            String op;
            int iOp = 0;
            if (tb.Text.Contains("+"))
            {
                iOp = tb.Text.IndexOf("+");
            }
            else if (tb.Text.Contains("-"))
            {
                iOp = tb.Text.IndexOf("-");
            }
            else if (tb.Text.Contains("*"))
            {
                iOp = tb.Text.IndexOf("*");
            }
            else if (tb.Text.Contains("/"))
            {
                iOp = tb.Text.IndexOf("/");
            }
            else
            {
                //error    
            }

            op = tb.Text.Substring(iOp, 1);
            double op1 = Convert.ToDouble(tb.Text.Substring(0, iOp));
            double op2 = Convert.ToDouble(tb.Text.Substring(iOp + 1, tb.Text.Length - iOp - 1));

            if (op == "+")
            {
                tb.Text += "=" + (op1 + op2);
            }
            else if (op == "-")
            {
                tb.Text += "=" + (op1 - op2);
            }
            else if (op == "*")
            {
                tb.Text += "=" + (op1 * op2);
            }
            else
            {
                tb.Text += "=" + (op1 / op2);
            }
        }

        private void Clear_tb(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
            tb.Clear();
        }

        private void Delete_tb(object sender, RoutedEventArgs e)
        {
            tb.Text = tb.Text.Remove(tb.Text.Length - 1);
        }

        private void CloseCalculator(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show("Разработали Граф И.К. и Лезных К.Ю. в 2023 году v0.1");
        }

        private void cmbFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (cmbFont.SelectedItem != null)
            //    tb.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFont.SelectedItem);
        }
    }
}
