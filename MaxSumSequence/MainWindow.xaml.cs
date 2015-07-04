namespace MaxSumSequence
{

    using System;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //given sequence parse to array
                var myArray = textBoxSequence.Text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();

                int currentSum = myArray[0];
                int maxSum = myArray[0];
                int tempStart = 0;
                int bestStart = 0;
                int bestFinal = 0;

                for (int i = 1; i < myArray.Length; i++)
                {
                    currentSum += myArray[i];

                    //Check for eventual best start of subsequence
                    if (myArray[i] > currentSum)
                    {
                        currentSum = myArray[i];
                        tempStart = i;
                    }

                    //Check current sum and max sum
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        bestStart = tempStart;
                        bestFinal = i;
                    }
                }

                string bestSequence = string.Empty;

                //make string with the best sequence
                for (int i = bestStart; i <= bestFinal; i++)
                {
                    bestSequence += myArray[i] + " ";
                }

                //visualize data
                tbError.Text = string.Empty;
                tbBestSequence.Text = bestSequence;
                tbMaxSumCount.Text = maxSum.ToString();
                tbMaxSumText.Text = "Maximum sum:";
            }
            catch
            {
                //clear text fields
                tbMaxSumCount.Text = string.Empty;
                tbBestSequence.Text = string.Empty;
                tbMaxSumText.Text = string.Empty;

                //error massage
                tbError.Text = "The sequence was not correctly entered.";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}