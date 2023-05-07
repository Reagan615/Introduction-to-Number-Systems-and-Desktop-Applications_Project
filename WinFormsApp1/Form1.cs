using System;
using System.Data;
using System.Linq.Expressions;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        decimal storedResult = 0;

        string storedOperation = null;

        bool hasStoredResult = false;

        bool hasStoredOperation = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void LableChangedButton_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            string buttonText = button.Text;

            if(hasStoredOperation)
            {
                TextLabel.Text = " ";

                hasStoredOperation = false;
            }

            TextLabel.Text = TextLabel.Text + buttonText;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (hasStoredResult)
            {
                decimal storedNumber = decimal.Parse(TextLabel.Text);

                decimal result = 0;

                switch (storedOperation)
                {
                    case "+":
                        result = storedResult + storedNumber;
                        break;
                    case "-":
                        result = storedResult - storedNumber;
                        break;
                    case "*":
                        result = storedResult * storedNumber;
                        break;
                    case "/":
                        result = storedResult / storedNumber;
                        break;
                }

                TextLabel.Text = result.ToString();

                storedResult = result;

                hasStoredResult = true;

                hasStoredOperation = true;

                storedOperation = ((Button)sender).Text;

                operatLabel.Text = storedOperation;


            }
            else
            {
                Button button = (Button)sender;

                storedOperation = button.Text;

                hasStoredOperation = true;

                operatLabel.Text = storedOperation;

                storedResult = decimal.Parse(TextLabel.Text);

                hasStoredResult = true;

                TextLabel.Text = " ";
            }




        }

        private void equalButton_Click(object sender, EventArgs e)
        {

            if (hasStoredResult )
            {
                decimal storedNumber = decimal.Parse(TextLabel.Text);
                decimal result = 0;

                switch (storedOperation)
                {
                    case "+":
                        result = storedResult + storedNumber;
                        break;
                    case "-":
                        result = storedResult - storedNumber;
                        break;
                    case "x":
                        result = storedResult * storedNumber;
                        break;
                    case "/":
                        result = storedResult / storedNumber;
                        break;
                }

                TextLabel.Text = result.ToString();
                storedResult = result;

                
                hasStoredResult = false;
                hasStoredOperation = false;
                storedOperation = null;
                operatLabel.Text = "";
            }
            else
            {

                TextLabel.Text = "";
            }


        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            TextLabel.Text = " ";

            operatLabel.Text = " ";

            BinLabel.Text = " ";

            storedResult = 0;

            storedOperation = null;

            hasStoredResult = false;

            hasStoredOperation = false;

        }

        private void PointButton_Click(object sender, EventArgs e)
        {
            if (!TextLabel.Text.Contains("."))
            {
                TextLabel.Text += ".";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextLabel_Click(object sender, EventArgs e)
        {

        }

        private void Bin_Click(object sender, EventArgs e)
        {
            BinLabel.Text = "BIN";
            
            decimal Number = decimal.Parse(TextLabel.Text);

            if(Number > 0 && Math.Floor(Number) == Number)
            {
                TextLabel.Text = Convert.ToString((int)Number, 2);
            } else
            {
                TextLabel.Text = "ERROR";
            }

            
        }

        private void Dec_Click(object sender, EventArgs e)
        {
            BinLabel.Text = "DEC";

            string Number = TextLabel.Text.ToString();

            int decimalNumber = Convert.ToInt32(Number, 2);

            TextLabel.Text = decimalNumber.ToString();

            
        }

        private void Loc_Click(object sender, EventArgs e)
        {
            BinLabel.Text = "LOC";

            string letters = "abcdefghijklmnopqrstuvwxyz";

            int number = int.Parse(TextLabel.Text);

            string result = "";

            if(number > 0)
            {
                while(number > 0)
                {
                    if (number % 2 == 1)
                    {
                        result = letters[(int)Math.Log(number, 2)] + result;
                    }

                    number = number / 2;
                }
            } else
            {
                result = "ERROR";
            }
            

            TextLabel.Text = result;
        }
    }
}