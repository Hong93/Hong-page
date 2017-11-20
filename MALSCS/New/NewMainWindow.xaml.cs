using log4net;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using WiseScopeDemo.New;
using WiseScopeDemo.New.Pages;
using MALSCS.New;
using MALSCS.New.Pages;

namespace WiseScopeDemo.New
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NewMainWindow : Window
    {
        RegistryTest regtest = new RegistryTest();

        public NewMainWindow()
        {
            InitializeComponent();
            //ImplementLoggingFuntion();

        }


        private void buttonMain_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Main Page");
            frame.NavigationService.Navigate(App.pageWiseScopeMain);
        }

        private void buttonMals_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Mals Controller");

            frame.NavigationService.Navigate(App.pageAll);
            App.pageAll.scroll.ScrollToTop();
        }

        private void buttonLighting_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting Controller");

            frame.NavigationService.Navigate(App.pageAll);
            App.pageAll.scroll.ScrollToVerticalOffset(2023);
        }

        private void buttonSerial_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Serial Communication");

            frame.NavigationService.Navigate(App.pageAll);
            App.pageAll.scroll.ScrollToBottom();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("On");

            // frame.Source = new Uri("/New/Pages/PageAll.xaml", UriKind.Relative);
            App.cmachine = new Machine();

            App.pageWiseScopeMain = new PageWiseScopeMain();

            App.pageAll = new PageAll();

            App.mySerial = new SerialPort();

            App.pageSerial = new PageSerial();


            try
            {
                App.mySerial.Open();
                stbar.Content = "연결 되었습니다.";
            }
            catch (Exception ex)
            {
                stbar.Content = ex.Message + "연결 되어있지 않습니다. SerialPort를 확인해주세요.";
            }

            frame.NavigationService.Navigate(App.pageWiseScopeMain);

            try
            {
                string path = Convert.ToString(Registry.GetValue(@"HKEY_CURRENT_USER\Software\RegistryTest", "test", @"C:\Users\USER\Documents\sample.xml"));

                XmlSerializer xs = new XmlSerializer(typeof(Machine));

                StreamReader reader = new StreamReader(path);

                App.cmachine = (Machine)xs.Deserialize(reader);

                reader.Close();

                App.pageAll.InitializeBinding();
            }
            catch { }



        }


        private void Window_Closed(object sender, EventArgs e)
        {
            App.Log.Debug("Off\n");

            regtest.regtestSet();

            string path = Convert.ToString(Registry.GetValue(@"HKEY_CURRENT_USER\Software\RegistryTest", "test", @"C:\Users\USER\Documents\sample.xml"));   //@"C:\\Users\\USER\\Documents\\q.xml";
            XmlSerializer xs = new XmlSerializer(typeof(Machine));       //클래스이름

            StreamWriter writer = new StreamWriter(path);

            xs.Serialize(writer, App.cmachine);  //클래스 인스턴스이름

            writer.Close();


            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            this.Close();
        }



        private void MenuItemWinFormPropertyGrid_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Winform PropertyGrid");

            WinFormPropertyGrid wpg = new WinFormPropertyGrid();
            wpg.Show();
        }

        private void MenuItemRegistry_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Registry Data");

            PageRegistryValue regvalue = new PageRegistryValue();
            regvalue.Show();
        }



        private void MenuItemPropertyGrid_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("PropertyGrid");

            PagePropertyGrid w1 = new PagePropertyGrid();
            w1.Show();
        }

        private void MenuItemHelp_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Help MenuItem Click");
            NewMainwindow nmw = new NewMainwindow();
            nmw.Show();
            this.Hide();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Off\n");
            string path = Convert.ToString(Registry.GetValue(@"HKEY_CURRENT_USER\Software\RegistryTest", "test", @"C:\Users\USER\Documents\sample.xml"));   //@"C:\\Users\\USER\\Documents\\q.xml";

            XmlSerializer xs = new XmlSerializer(typeof(Machine));       //클래스이름

            StreamWriter writer = new StreamWriter(path);

            xs.Serialize(writer, App.cmachine);  //클래스 인스턴스이름

            writer.Close();

            regtest.regtestSet();

            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            this.Close();
        }




        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Xml Save");
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            try
            {
                if (saveFileDialog.ShowDialog() == true)
                {
                    var path = saveFileDialog.FileName;

                    XmlSerializer xs = new XmlSerializer(typeof(Machine));       //클래스이름

                    StreamWriter writer = new StreamWriter(path);

                    xs.Serialize(writer, App.cmachine);  //클래스 인스턴스이름

                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }


        private void MenuItemLoad_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Xml Load");
            OpenFileDialog openFileDiaolog = new OpenFileDialog();

            if (openFileDiaolog.ShowDialog() == true)
            {
                var path = openFileDiaolog.FileName;

                XmlSerializer xs = new XmlSerializer(typeof(Machine));

                StreamReader reader = new StreamReader(path);

                App.cmachine = (Machine)xs.Deserialize(reader);

                reader.Close();

                App.pageAll.InitializeBinding();
            }
        }

    }
}
