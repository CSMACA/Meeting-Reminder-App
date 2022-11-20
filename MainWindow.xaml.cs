using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;
using NCalc;

namespace Meeting_Reminder_Toture
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string? reminderTime;
        private string? currentTime;
        
        //sound path, default is instanced.
        private static string soundPath = @"C:\Alarm\alarm.wav";
        private SoundPlayer alarm = new SoundPlayer(soundPath);
        public MainWindow()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            InitializeComponent();
        }

        private void armAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            reminderTime = reminderTimeSet.Text + ":00";
        }

        private void equationSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            TextBoxEmpty(equationAnswerEnter, "You must supply an answer.");

            NCalc.Expression eq = new NCalc.Expression(equationText.Text);
            if (equationAnswerEnter.Text == eq.Evaluate().ToString())
            {
                alarm.Stop();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            currentTime = DateTime.Now.ToLongTimeString();
            if(currentTime == reminderTime && reminderTime != null)
            {
                //Call puzzle selector function (this function contains the stopAlarm function).
                startRandomPuzzle();
            }
        }
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "WAV Sound files (*.wav)|*.wav";
            openFileDialog.ShowDialog();
            soundPath = openFileDialog.FileName;
            //reinitialize sound player to new sound path.
            alarm = new SoundPlayer(soundPath);
        }

        private void startRandomPuzzle()
        {
            //start alarm
            alarm.PlayLooping();

            //for now, only picking one of the puzzles
            //case when rand 1 - # of puzzles
            equationPuzzle();
        }

        private void equationPuzzle()
        {
            Random r = new Random();

            //Set random first number, second number, and sign.
            int first = r.Next(0,99) ;
            int second = r.Next(0,first);
            //can be randomized between the 4 signs, just addition for now.
            string sign = "+";

            equationText.Text = String.Format("{0} {1} {2}",first,sign,second);
        }

        public bool TextBoxEmpty(TextBox txtBox, string displayMsg)
        {
            if (string.IsNullOrEmpty(txtBox.Text))
            {
                MessageBox.Show(displayMsg, "Required field", MessageBoxButton.OK, MessageBoxImage.Information);
                txtBox.Focus();
                return true;
            }

            return false;
        }
    }
}
