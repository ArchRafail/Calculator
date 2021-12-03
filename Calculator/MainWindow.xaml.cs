using Calculator.Properties;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            CheckingAnswer();
            if (ZeroChecking())
                ZeroTrim();
            this.NumbersTextBlock.Text += this.Button1.Content;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            CheckingAnswer();
            if (ZeroChecking())
                ZeroTrim();
            this.NumbersTextBlock.Text += this.Button2.Content;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            CheckingAnswer();
            if (ZeroChecking())
                ZeroTrim();
            this.NumbersTextBlock.Text += this.Button3.Content;
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            CheckingAnswer();
            if (ZeroChecking())
                ZeroTrim();
            this.NumbersTextBlock.Text += this.Button4.Content;
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            CheckingAnswer();
            if (ZeroChecking())
                ZeroTrim();
            this.NumbersTextBlock.Text += this.Button5.Content;
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            CheckingAnswer();
            if (ZeroChecking())
                ZeroTrim();
            this.NumbersTextBlock.Text += this.Button6.Content;
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            CheckingAnswer();
            if (ZeroChecking())
                ZeroTrim();
            this.NumbersTextBlock.Text += this.Button7.Content;
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            CheckingAnswer();
            if (ZeroChecking())
                ZeroTrim();
            this.NumbersTextBlock.Text += this.Button8.Content;
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            CheckingAnswer();
            if (ZeroChecking())
                ZeroTrim();
            this.NumbersTextBlock.Text += this.Button9.Content;
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            CheckingAnswer();
            if (ZeroChecking())
                ZeroTrim();
            this.NumbersTextBlock.Text += this.Button0.Content;
        }

        private void Addition_Click(object sender, RoutedEventArgs e)
        {
            CheckOperation();
            this.NumbersTextBlock.Text = DoublingOperation();
            this.NumbersTextBlock.Text += this.Addition.Content;
        }

        private void Subtraction_Click(object sender, RoutedEventArgs e)
        {
            CheckOperation();
            this.NumbersTextBlock.Text = DoublingOperation();
            this.NumbersTextBlock.Text += this.Subtraction.Content;
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            CheckOperation();
            this.NumbersTextBlock.Text = DoublingOperation();
            this.NumbersTextBlock.Text += this.Multiplication.Content;
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            CheckOperation();
            this.NumbersTextBlock.Text = DoublingOperation();
            this.NumbersTextBlock.Text += this.Division.Content;
        }

        private void CheckOperation()
        {
            if (this.AnswerTextBlock.Text != "0")
            {
                this.NumbersTextBlock.Text = string.Empty;
                this.NumbersTextBlock.Text = this.AnswerTextBlock.Text;
                this.AnswerTextBlock.Text = "0";
            }
        }

        private string DoublingOperation()
        {
            string text = this.NumbersTextBlock.Text;
            if (CheckSymbols(text, 1))
                text = RemoveOperation();
            return text;
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            string text = this.NumbersTextBlock.Text;
            if (CheckSymbols(text, 1))
            {
                text = this.NumbersTextBlock.Text = RemoveOperation();
            }
            do
            {
                text = Calculation(text);
                if (text == "Error. Division by zero")
                    break;
            } while (Check(text));
            AnswerTextBlock.Text = "";
            AnswerTextBlock.Text = text;
        }

        private string RemoveOperation()
        {
            return this.NumbersTextBlock.Text.Remove
                    (this.NumbersTextBlock.Text.Length - 1);
        }

        private bool Check(string toCheck)
        {
            return toCheck.IndexOfAny(new char[] { '+', '/', '-', '*' }) != -1;
        }

        private string Calculation(string text)
        {
            int index;
            if (text.IndexOf('*') != -1 || text.IndexOf('/') != -1)
            {
                if (text.IndexOf('*') != -1)
                    index = text.IndexOf('*');
                else
                    index = text.IndexOf('/');
            }
            else
            {
                if (text.IndexOf('+') != -1)
                    index = text.IndexOf('+');
                else
                    index = text.IndexOf('-');
            }
            string a = text.Substring(0, index);
            while (Check(a))
            {
                a = TrimStringLeft(a);
            }
            double num1 = Convert.ToDouble(ConvertToDouble(a));
            string b = text.Substring(index + 1, (text.Length-1)-index);
            while (Check(b))
            {
                b = TrimStringRight(b);
            }
            double num2 = Convert.ToDouble(ConvertToDouble(b));
            double result = 0;
            switch (text[index])
            {
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    try
                    {
                        if (num2 == 0)
                            throw new NewDivideByZeroException();
                        result = num1 / num2;
                        break;
                    }
                    catch(NewDivideByZeroException ex)
                    {
                        return ex.Message;
                    }
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
            }
            string[] substring = text.Split(text[index]);
            substring[0] = substring[0].Remove((substring[0].Length) - a.Length, a.Length);
            substring[0] += result.ToString();
            substring[1] = substring[1].Remove(0, b.Length);
            text = substring[0] + substring[1];
            return text;
        }

        private string TrimStringLeft(string text)
        {
            string[] new_text = text.Split(new char[] { '+', '/', '-', '*' });
            int i = new_text.Length;
            return new_text[i-1];
        }

        private string TrimStringRight(string text)
        {
            string[] new_text = text.Split(new char[] { '+', '/', '-', '*' });
            return new_text[0];
        }

        private string ConvertToDouble(string text)
        {
            if (text.IndexOf('.') != -1)
                text = text.Replace('.', ',');
            return text;
        }

        private bool ZeroChecking()
        {
            string text = this.NumbersTextBlock.Text;
            if (text == "") return false;
            return (text[text.Length - 1] == '0' && CheckSymbols(text, 2));
        }

        private void ZeroTrim()
        {
            this.NumbersTextBlock.Text = this.NumbersTextBlock.Text.Remove(this.NumbersTextBlock.Text.Length - 1);

        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            this.NumbersTextBlock.Text += this.Point.Content;
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            this.NumbersTextBlock.Text = string.Empty;
            this.AnswerTextBlock.Text = "0";
        }

        private void ClearLastNumber_Click(object sender, RoutedEventArgs e)
        {
            string text = this.NumbersTextBlock.Text;
            string[] numbers = null;
            if (!CheckSymbols(text, 1))
            {
                numbers = text.Split(new char[] { '+', '/', '-', '*' });
                this.NumbersTextBlock.Text = this.NumbersTextBlock.Text.Remove(
                    this.NumbersTextBlock.Text.Length - numbers[numbers.Length-1].Length);
            }
        }

        private bool CheckSymbols(string text, int position)
        {
            return (text[text.Length - position] == '+' ||
               text[text.Length - position] == '-' ||
               text[text.Length - position] == '*' ||
               text[text.Length - position] == '/');
        }

        private void CheckingAnswer()
        {
            if (AnswerTextBlock.Text != "0")
            {
                this.AnswerTextBlock.Text = "0";
                this.NumbersTextBlock.Text = string.Empty;
            }
        }

        private void ClearLastSymbol_Click(object sender, RoutedEventArgs e)
        {
            this.NumbersTextBlock.Text = this.NumbersTextBlock.Text.Remove(this.NumbersTextBlock.Text.Length - 1);
        }
    }
}
