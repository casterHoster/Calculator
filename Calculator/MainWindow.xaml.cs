using System;
using System.Collections;
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

namespace Calculator
{
    
    public partial class MainWindow : Window
    {
        public bool checkEquals;
        public ArrayList numbers = new ArrayList();
        public ArrayList operands = new ArrayList();
        public string permanentNumber;
        public double number1;
        public double number2;
        public double result;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Of_Numbers(object sender, RoutedEventArgs e)
        {

            checkingEquals();

            Button b = (Button)sender;
            if (TextBoxOfNumber.Text.Substring(TextBoxOfNumber.Text.Length - 1) == "²")
            {
                return;
            }


            if (TextBoxOfNumber.Text == "0")
            {
                if ((string)b.Content == "*" || (string)b.Content == "/" || (string)b.Content == "+")
                {
                    TextBoxOfNumber.Text = "0";
                }
                else
                {
                    TextBoxOfNumber.Text = (string)b.Content;
                    permanentNumber += (string)b.Content;
                }
            }
            else
            {
                TextBoxOfNumber.Text += b.Content;
                permanentNumber += (string)b.Content;
            }
        }

        private void Button_Click_Of_Operands(object sender, RoutedEventArgs e)
        {

            checkingEquals();

            Button b = (Button)sender;


            if ((TextBoxOfNumber.Text.Substring(TextBoxOfNumber.Text.Length - 1).Equals("+")) || (TextBoxOfNumber.Text.Substring(TextBoxOfNumber.Text.Length - 1).Equals("-"))
                || (TextBoxOfNumber.Text.Substring(TextBoxOfNumber.Text.Length - 1).Equals("/")) || (TextBoxOfNumber.Text.Substring(TextBoxOfNumber.Text.Length - 1).Equals("*")))
            {
                return;
            }
            if (TextBoxOfNumber.Text == "0")
            {
                if ((string)b.Content == "*" || (string)b.Content == "/" || (string)b.Content == "+")
                {
                    TextBoxOfNumber.Text = "0";
                }
                else
                {
                    TextBoxOfNumber.Text = (string)b.Content;
                    permanentNumber += (string)b.Content;
                }
            }
            else
            {

                numbers.Add(permanentNumber);
                permanentNumber = "";
                TextBoxOfNumber.Text += b.Content;

                if ((string)b.Content == "+" || (string)b.Content == "-" || (string)b.Content == "*" || (string)b.Content == "/")
                {
                    operands.Add(b.Content);

                }
            }

        }


        private void Button_Click_Of_AC(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if ((string)b.Content == "AC")
            {
                TextBoxOfNumber.Text = "0";
                numbers.Clear();
                operands.Clear();
                permanentNumber = "";
                
            }
        }


        private void Button_Click_Dot(object sender, RoutedEventArgs e)
        {
            checkingEquals();
            Button b = (Button)sender;

            if(TextBoxOfNumber.Text.Substring(TextBoxOfNumber.Text.Length - 1) == "²")
            {
                return;
            }

            if (TextBoxOfNumber.Text == "0")
            {
                return;
            }
            else
            {
                if ((TextBoxOfNumber.Text.Substring(TextBoxOfNumber.Text.Length - 1).Equals(",")))
                {
                    return;
                }
                else
                {
                    if (permanentNumber.Contains(","))
                    {
                        return;
                    }
                   

                                      
                    TextBoxOfNumber.Text += (string)b.Content;
                    permanentNumber += (string)b.Content;
                }
            }

        }

        private void Button_Click_Square(object sender, RoutedEventArgs e)
        {
            checkingEquals();
            Button b = (Button)sender;
            string s = (string)b.Content;

            s = s.Remove(0, 1);

            if ((TextBoxOfNumber.Text == "0") || ((TextBoxOfNumber.Text.Substring(TextBoxOfNumber.Text.Length - 1).Equals("²"))))
            {
                return;
            }
            else
            {
                TextBoxOfNumber.Text += s;
                number1 = Convert.ToDouble(permanentNumber);
                number1 *= number1;
                permanentNumber = number1.ToString();
            }
        }



        private void Button_Click_Equals(object sender, RoutedEventArgs e)
        {
            checkingEquals();

            Button b = (Button)sender;
            numbers.Add(permanentNumber);
            permanentNumber = "";

            TextBoxOfNumber.Text += b.Content;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                number1 = Convert.ToDouble(numbers[i]);
                number2 = Convert.ToDouble(numbers[i + 1]);

                if ((string)operands[i] == "*")
                {
                    numbers[i] = number1 * number2;
                    numbers.RemoveAt(i + 1);
                    operands.RemoveAt(i);
                    i = 0;
                }
                else
                {
                    if ((string)operands[i] == "/")
                    {
                        numbers[i] = number1 / number2;
                        numbers.RemoveAt(i + 1);
                        operands.RemoveAt(i);
                        i = 0;
                    }
                }
            }

            if (operands.Count == 0 || numbers == null)
            {
                try
                {
                    result = Convert.ToDouble(numbers[0]);
                }
                catch {
                    TextBoxOfNumber.Text = "";
                    result = 0;
                }
            }
            else
            {


                for (int i = 0; i < numbers.Count - 1; i++)
                {


                    number1 = Convert.ToDouble(numbers[i]);
                    number2 = Convert.ToDouble(numbers[i + 1]);

                    if ((string)operands[i] == "-")
                    {
                        number2 = number2 * (-1);
                        operands[i] = "+";
                    }



                    if ((string)operands[i] == "+")
                    {
                        numbers[i + 1] = number1 + number2;
                        result = Convert.ToDouble(numbers[i + 1]);
                    }
                  
                }
            }
            checkEquals = true;
            TextBoxOfNumber.Text += result;

        }

        private void checkingEquals()
        {
            if (checkEquals == true)
            {
                checkEquals = false;
                TextBoxOfNumber.Text = "0";
                numbers.Clear();
                operands.Clear();
                permanentNumber = "";
            }
        }



        
    }

}
