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
using WiseScopeDemo.New;

namespace WiseScopeDemo
{
    /// <summary>
    /// Window3.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NewMainwindow : Window
    {
        public NewMainwindow()
        {
            InitializeComponent();
        }


        private void buttonSerialCommunication_Click(object sender, RoutedEventArgs e)
        {
            
             Serial SerialCommunication = new Serial();
             SerialCommunication.Show();
             App.Current.MainWindow.Hide();
          
        }

        private void buttonMALSController_Click(object sender, RoutedEventArgs e)
        {
            MALS mals = new MALS();
            mals.Show();
            App.Current.MainWindow.Hide();
        }

        private void buttonLightingController_Click(object sender, RoutedEventArgs e)
        {
            Lighting light = new Lighting();
            light.Show();
            App.Current.MainWindow.Hide();
        }

        private void buttonNew_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Show();
            this.Hide();
        }
    }
}
