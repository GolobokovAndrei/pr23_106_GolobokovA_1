using System;
using System.Windows;

namespace pr23_106_GolobokovA_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = inputTextBox.Text.Trim();

                if (input.Length != 12)
                {
                    throw new Exception("Число должно быть двенадцатизначным.");
                }

                if (!ulong.TryParse(input, out _))
                {
                    throw new Exception("Число должно содержать только цифры.");
                }

                int productFirst3 = 1;
                int sumLast9 = 0;

                try
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int digit = int.Parse(input[i].ToString());
                        productFirst3 *= digit;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при вычислении произведения первых 3 цифр: " + ex.Message);
                }

                try
                {
                    for (int i = 3; i < 12; i++)
                    {
                        int digit = int.Parse(input[i].ToString());
                        sumLast9 += digit;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при вычислении суммы последних 9 цифр: " + ex.Message);
                }

                string result = productFirst3 == sumLast9 ?
                    "Произведение первых 3 цифр РАВНО сумме последних 9 цифр." :
                    "Произведение первых 3 цифр НЕ РАВНО сумме последних 9 цифр.";

                resultTextBlock.Text = result;
            }
            catch (Exception ex)
            {
                resultTextBlock.Text = "Ошибка: " + ex.Message;
            }
        }
    }
}
