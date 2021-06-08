using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;

namespace prjProg6112_ICE_Task_
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string Detail;
        public string Message = "";
        public string Question = "";
        public int Index = 0;

        //Instantiating Object of Read_WriteDetails class
        Read_WriteDetails Read = new Read_WriteDetails();

        //Instantiating a list
        List<string> QuestionAnswers = new List<string>();

        //Instantiating a random object
        Random RandomAnswers = new Random();

        //Setting values into string array
        string[] Answers = { "YES!!", "NO!!", "MAYBE!?" , "IN YOUR DREAMS!", "HIGHLY UNLIKELY!", "TOO STUPID!", "MEH!", "POGGERS!"};

        public Window1()
        {
            InitializeComponent();
            QuestionAnswers.Clear();
            string Content = Read.ReadFromTextFile();
            txtOuput.Text = Content;
            rchReport.Visibility = Visibility.Hidden;
            bImage.Visibility = Visibility.Hidden;
        }
        
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            
            if(txtUserInput.Text == "")
            {
                MessageBox.Show("Please enter a question before trying to SPIN!");
            }
            else
            {
                bImage.Visibility = Visibility.Visible;

                var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
                timer.Start();
                timer.Tick += (sender, args) =>
                {
                    bImage.Visibility = Visibility.Hidden;
                    timer.Stop();
                    Question = txtUserInput.Text;
                    Index = RandomAnswers.Next(Answers.Length);
                    Message = Answers[Index];
                    txtUserInput.Text = "";
                    QuestionAnswers.Add("Question: " + Question + "\n" + "Answer: " + Message + "\n");
                   
                    MessageBox.Show(Message);
                };
            }
        }
        
        private void txtOuput_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtOuput.Focusable = false;
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (rchReport.Visibility == Visibility.Visible)
            {
                rchReport.Visibility = Visibility.Hidden;
            }
            else
            {
                rchReport.Visibility = Visibility.Visible;
            }
            rchReport.Focusable = false;

            //Displaying values stored to rchReport
            foreach (var Item in QuestionAnswers)
            {
                rchReport.AppendText(Item);
            }
            QuestionAnswers.Clear();
        }
    }
}
