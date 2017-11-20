using System;
using System.IO.Ports;
using System.Windows;
using System.Windows.Controls;

namespace WiseScopeDemo.New.Pages
{
    /// <summary>
    /// PageSerial.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageSerial : Page
    {

        public LightingController light_ctr;
        public MALSController mals_ctr = new MALSController();

        public PageSerial()
        {
            InitializeComponent();


            // 시리얼 통신 관련 함수 호출
            Loaded += new RoutedEventHandler(InitSerialPort);
        }

        #region < 시리얼 통신 관련 함수 >

        SerialPort serial = App.mySerial;

        string g_sRecvData = String.Empty;
        delegate void SetTextCallBack(String text);

        //
        // 시리얼 통신 초기화
        //
        void InitSerialPort(object sender, EventArgs e)
        {
            serial.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cbComPort.Items.Add(port);
            }

            sbStrip1.Content = "통신포트와 통신속도를 선택해 주세요";
        }

        //
        // 콤보박스에서 시리얼 통신포트 선택시 발생되는 이벤트 핸들러
        //
        private void cbComPort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 통신포트가 열려 있을 경우 닫음
            if (serial.IsOpen)
            {
                serial.Close();

            }

            serial.PortName = cbComPort.SelectedItem.ToString();
            sbStrip1.Content = serial.PortName + " : " + serial.BaudRate + ", 8N1";

            OpenComPort(sender, e);
        }

        //
        // 시리얼 통신 열기 메소드
        //
        void OpenComPort(object sender, RoutedEventArgs e)
        {
            try
            {
                serial.Open();
            }
            catch (Exception ex)
            {
                sbStrip1.Content = "통신포트 " + serial.PortName + "열 수 없습니다";
                cbComPort.SelectedItem = "";
            }
        }

        // 콤보박스에서 시리얼 통신속도 선택시 발생되는 이벤트 핸들러
        private void cbComSpeed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] names = cbComSpeed.SelectedItem.ToString().Split(':');
            serial.BaudRate = int.Parse(names[1].ToString().Trim());

            // 통신포트가 열려 있을 경우 닫음
            if (serial.IsOpen)
            {
                serial.BaudRate = 115200; //

                sbStrip1.Content = serial.PortName + " : " + serial.BaudRate + ", 8N1";
            }
        }

        private void Communication_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Serial Communication");

            if (serial.IsOpen)
            {
                serial.Close();
            }

            serial.PortName = cbComPort.SelectedItem.ToString();

            //string[] names = cbComSpeed.SelectedItem.ToString().Split(':');
            //serial.BaudRate = int.Parse(names[1].ToString().Trim());
            serial.BaudRate = 115200;

            sbStrip1.Content = serial.PortName + " : " + serial.BaudRate + ", 8N1";

            OpenComPort(sender, e);

        }

        //
        // 시리얼 데이터 수신시 발생되는 이벤트 핸들러
        //
        void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                g_sRecvData = serial.ReadExisting();
                if ((g_sRecvData != string.Empty))// && (g_sRecvData.Contains('\n')))
                {
                    SetText(g_sRecvData);
                }
            }
            catch (TimeoutException)
            {
                g_sRecvData = string.Empty;
            }
        }

        //
        // 수신 데이터 처리 메소드
        //
        private void SetText(string text)
        {
            if (tbRecvData.Dispatcher.CheckAccess())
            {
                tbRecvData.AppendText(text);
            }
            else
            {
                SetTextCallBack d = new SetTextCallBack(SetText);
                tbRecvData.Dispatcher.Invoke(d, new object[] { text });
            }
        }

        //
        // 화면 지우기 버튼을 클릭시 발생되는 이벤트 핸들러
        //
        private void btnScreenClear_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Serial Data Screen Clear");

            tbRecvData.Text = string.Empty;
        }

        #endregion 시리얼 통신 관련 함수

        private void Window_Closed(object sender, EventArgs e)
        {
            // 윈도우 종료시 시리얼 포트 닫기
            if (serial.IsOpen) serial.Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.mySerial = new SerialPort();
        }


    }
}
