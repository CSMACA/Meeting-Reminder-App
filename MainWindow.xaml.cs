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
using System.Windows.Threading;

namespace Meeting_Reminder_Toture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string? reminderTime;
        private string? currentTime;
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void armAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            reminderTime = reminderTimeSet.Text + ":00";
        }

        private void equationSubmitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            currentTime = DateTime.Now.ToLongTimeString();
            if(currentTime == reminderTime && reminderTime != null)
            {
                //Call sound alarm function
                Console.WriteLine("Reminder Time meets Current Time");
                //Call puzzle selector function
            }
        }
    }
}
