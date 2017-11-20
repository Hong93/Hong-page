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
using System.Windows.Shapes;


namespace WiseScopeDemo
{
    /// <summary>
    /// PagePropertyGrid.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Lighting : Window
    {
        public LightingController light_ctr = new LightingController();
        
        
        public Lighting()
        {
            InitializeComponent();
        }

        

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Application.Current.MainWindow.Show();
        }
        
        private void LED1bright_Click(object sender, RoutedEventArgs e)
        {
            light_ctr.LedBright1();
        }

        private void LED2bright_Click(object sender, RoutedEventArgs e)
        {
            light_ctr.LedBright2();
        }

        private void LED1bright_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double bright = LED1BrightChange.Value;
            light_ctr.ChangeBright1(bright);
        }

        private void LED2bright_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double bright = LED2BrightChange.Value;
            light_ctr.ChangeBright2(bright);
        }

        private void AlarmOn_Click(object sender, RoutedEventArgs e)
        {
            light_ctr.AlarmOn();
        }

        private void AlarmOff_Click(object sender, RoutedEventArgs e)
        {
            light_ctr.AlarmOff();
        }

        private void BuzzerOn_Click(object sender, RoutedEventArgs e)
        {
            light_ctr.BuzzerOn();
        }

        private void BuzzerOff_Click(object sender, RoutedEventArgs e)
        {
            light_ctr.BuzzerOff();
        }

        private void StrobeOn_Click(object sender, RoutedEventArgs e)
        {
            light_ctr.StrobeOn();
        }

        private void StrobeOff_Click(object sender, RoutedEventArgs e)
        {
            light_ctr.StrobeOff();
        }

        private void MarkingOn_Click(object sender, RoutedEventArgs e)
        {
            light_ctr.MarkingStart();
        }

        private void MarkingStop_Click(object sender, RoutedEventArgs e)
        {
            light_ctr.MarkingStop();
        }

        private void SolenoidOn_Click(object sender, RoutedEventArgs e)
        {
            light_ctr.SolenoidOn();
        }

        private void SolenoidOff_Click(object sender, RoutedEventArgs e)
        {
            light_ctr.SolenoidOff();
        }

        

        private void Value_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string channelnames = ChannelList.SelectedItem.ToString();
            int channel = int.Parse(channelnames.ToString().Trim());

            string valuenames = Value.SelectedItem.ToString();
            int value = int.Parse(valuenames.ToString().Trim());

            light_ctr.WriteOutPort(channel, value);
        }

        private void LED1Flashingtime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {         
            string names = LED1Flashingtime.SelectedItem.ToString();
            int time = int.Parse(names.ToString().Trim());
            light_ctr.FalshTime1(time);
        }

        private void LED2Flashingtime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string names = LED2Flashingtime.SelectedItem.ToString();
            int time = int.Parse(names.ToString().Trim());
            light_ctr.FalshTime2(time);
        }

        private void Strobe_Click(object sender, RoutedEventArgs e)
        {
            light_ctr.StrobeStatus();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            light_ctr.Reset();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 7; i++)
            {
                ChannelList.Items.Add(i);
            }
            for (int i = 0; i <= 1; i++)
            {
                Value.Items.Add(i);
            }
            for (int i = 0; i <= 100; i++)
            {
                LED1Flashingtime.Items.Add(i);
            }
            for (int i = 0; i <= 100; i++)
            {
                LED2Flashingtime.Items.Add(i);
            }
        }
    }
}
