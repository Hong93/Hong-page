using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WiseScopeDemo.New;
using WiseScopeDemo.New.Pages;

namespace WiseScopeDemo
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static UserControlParameter1 cuserctr; 
        public static Machine cmachine;

        public static SerialPort mySerial;

        public static PageSerial pageSerial;

        public static PageAll pageAll;

        public static NewMainWindow newMainWindow;

        public static PageWiseScopeMain pageWiseScopeMain;

        public static Test ctest;
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
