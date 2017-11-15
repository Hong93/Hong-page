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

namespace WiseScopeDemo
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MALS : Window
    {
        public MALSController mals_ctr = new MALSController();
        public MALS()
        {
            InitializeComponent();
        }

        

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
            this.Hide();
        }


        private void StepChange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string names = StepChange.SelectedItem.ToString();
            int step = int.Parse(names.ToString().Trim());
            mals_ctr.ChangeStep(step);
        }

       

        private void SelectCoaxial_Click(object sender, RoutedEventArgs e)
        {
            mals_ctr.SelectLedCoaxial();
        }

        private void SelectRing_Click(object sender, RoutedEventArgs e)
        {
            mals_ctr.SelectLedRing();
        }

        private void TriggerSignal1_Click(object sender, RoutedEventArgs e)
        {
            mals_ctr.TrigSignal1();
        }

        private void TriggerSignal22_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string names = TriggerSignal22.SelectedItem.ToString();
            int focus = int.Parse(names.ToString().Trim());
            mals_ctr.TrigSignal2(focus);
        }

        private void TriggerSignal3_Click(object sender, RoutedEventArgs e)
        {
            mals_ctr.TrigSignal3();        
        }

        private void TriggerSignal44_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string names = TriggerSignal44.SelectedItem.ToString();
            int focus = int.Parse(names.ToString().Trim());
            mals_ctr.TrigSignal4(focus);
        }

        private void TriggerSignal55_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string names = TriggerSignal55.SelectedItem.ToString();
            int focus = int.Parse(names.ToString().Trim());
            mals_ctr.TrigSignal5(focus);
        }

        private void TriggerSet_Click(object sender, RoutedEventArgs e)
        {
            mals_ctr.TrigSignalSet();
        }

        private void TriggerReset_Click(object sender, RoutedEventArgs e)
        {
            mals_ctr.TrigSignalReset();
        }

        private void TriggerCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string names = TriggerCount.SelectedItem.ToString();
            int count = int.Parse(names.ToString().Trim());
            mals_ctr.TrigCount(count);
        }

        private void SignalDelay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string names = SignalDelay.SelectedItem.ToString();
            int time = int.Parse(names.ToString().Trim());
            mals_ctr.TrigTimeDelay(time);
        }

        private void SignalHold_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string names = SignalHold.SelectedItem.ToString();
            int time = int.Parse(names.ToString().Trim());
            mals_ctr.TrigTimeHold(time);
        }

        private void Version_Click(object sender, RoutedEventArgs e)
        {
            mals_ctr.SoftwareVer();
        }

        private void SoftReset_Click(object sender, RoutedEventArgs e)
        {
            mals_ctr.Reset();
        }

        private void coaxialontime_TextChanged(object sender, TextChangedEventArgs e)
        {
            string names = coaxialontime.Text.ToString();
            int time = int.Parse(names.ToString().Trim());            
            mals_ctr.LightOnTimeCoaxial(time);
            if (coaxialontime.Text == null)
            {
                mals_ctr.LightOnTimeCoaxial(0);
            }

        }

        private void ringontime_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(ringontime == null)
            {
                mals_ctr.LightOnTimeRing(0);
            }
            string names = ringontime.Text.ToString();
            int time = int.Parse(names.ToString().Trim());
            mals_ctr.LightOnTimeRing(time);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 32; i++)
            {
                StepChange.Items.Add(i*10);
            }
            for (int i = 0; i <= 32; i++)
            {
                TriggerSignal22.Items.Add(i * 10);
            }
            for (int i = 0; i <= 32; i++)
            {
                TriggerSignal44.Items.Add(i * 10);
            }
            for (int i = 0; i <= 32; i++)
            {
                TriggerSignal55.Items.Add(i * 10);
            }
            for (int i = 0; i <= 32; i++)
            {
                TriggerCount.Items.Add(i * 10);
            }
            for (int i = 0; i <= 100; i++)
            {
                SignalDelay.Items.Add(i);
            }
            for (int i = 0; i <= 50; i++)
            {
                SignalHold.Items.Add(i);
            }


        }
    }
}
