using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO.Ports;
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
using WiseScopeDemo.New;
using MALSCS.New;


namespace WiseScopeDemo.New.Pages
{
    /// <summary>
    /// PageWiseScopeMain.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageWiseScopeMain : Page
    {
        
        public PageWiseScopeMain()
        {
            InitializeComponent();

            Loaded += new RoutedEventHandler(InitSerialPort);
        }

        string g_sRecvData = String.Empty;
        delegate void SetTextCallBack(String text);

        void InitSerialPort(object sender, EventArgs e)
        {
            App.mySerial.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);
        }

        void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                g_sRecvData = App.mySerial.ReadExisting();
                if ((g_sRecvData != string.Empty)) //&& (g_sRecvData.Contains('\n')))
                {
                    SetText(g_sRecvData);
                }
            }
            catch (TimeoutException)
            {
                g_sRecvData = string.Empty;
            }
        }

        void OpenComPort(object sender, RoutedEventArgs e)
        {
            try
            {
                App.mySerial.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SetText(string text)
        {
            if (RecvData.Dispatcher.CheckAccess())
            {
                RecvData.AppendText(text);
            }
            else
            {
                SetTextCallBack d = new SetTextCallBack(SetText);
                RecvData.Dispatcher.Invoke(d, new object[] { text });
            }
        }



        private void Serial1_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            if (App.mySerial.IsOpen)
            {
                App.mySerial.Close();
            }

                App.mySerial = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One); //추후에 필요하면 Port를 레지스트리를 이용해서 가져오는 방법도 있음.
                //App.mySerial.PortName = "COM1";
                //App.mySerial.BaudRate = 115200;
                //App.mySerial.DataBits = 8;
                //App.mySerial.StopBits = StopBits.One;
                //App.mySerial.Parity = Parity.None;

                OpenComPort(sender, e);
            } 

            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Serial2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (App.mySerial.IsOpen)
                {
                    App.mySerial.Close();
                }

                App.mySerial = new SerialPort("COM2", 115200, Parity.None, 8, StopBits.One); //추후에 필요하면 Port를 레지스트리를 이용해서 가져오는 방법도 있음.
                //App.mySerial.PortName = "COM2";
                //    App.mySerial.BaudRate = 115200;
                //    App.mySerial.DataBits = 8;
                //    App.mySerial.StopBits = StopBits.One;
                //    App.mySerial.Parity = Parity.None;

                OpenComPort(sender, e);
            }

            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.mySerial = new SerialPort();
        }
    }
        
    }

