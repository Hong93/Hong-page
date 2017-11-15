using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WiseScopeDemo.New;

namespace WiseScopeDemo
{
    public class LightingController : INotifyPropertyChanged
    {
        //
        //
        //LED1 bright change binding
        private int LED1_brightchange_brightvalue;

        /// <summary>
        /// 1번 조명의 LED 밝기 정도를 변경한다.
        /// </summary>
        /// <param name="bright">밝기 값. 0~100사이</param>
        [Category("LED 밝기조절")]
        [DisplayName("LED1의 밝기를 설정합니다.(0-100)")]
        public int LED1BrightChangeSetBrightValue
        {
            get { return LED1_brightchange_brightvalue; }
            set { if (value > 100)
                  {
                    return;
                  }
                    LED1_brightchange_brightvalue = value;
                OnPropertyChanged();
            }
        }
        private int LED1bright_presentvalue;

        public int LED1brightPresentValue
        {
            get { return LED1bright_presentvalue; }
            set {LED1bright_presentvalue = value;
                OnPropertyChanged();
            }
        }

        //
        //
        //LED2 bright change binding
        private int LED2_brightchange_brightvalue;

        /// <summary>
        /// 2번 조명의 LED 밝기 정도를 변경한다.
        /// </summary>
        /// <param name="bright">밝기 값. 0~100사이</param>
        [Category("LED 밝기조절")]
        [DisplayName("LED2의 밝기를 설정합니다.(0-100)")]
        public int LED2BrightChangeSetBrightValue
        {
            get { return LED2_brightchange_brightvalue; }
            set {
                if (value > 100)
                {
                    return;
                }
                LED2_brightchange_brightvalue = value;
                OnPropertyChanged();
            }
        }
        private int LED2bright_presentvalue;

        public int LED2BrightPresentValue
        {
            get { return LED2bright_presentvalue; }
            set { LED2bright_presentvalue = value;
                OnPropertyChanged();
            }
        }

        //
        //
        //LED1 Flashtime binding
        private int LED1_flashtime_timevalue;

        /// <summary>
        /// 조명1의 flash 시간을 설정한다.
        /// </summary>
        /// <param name="time">시간 값. 0~100(ms)사이</param>
        [Category("LED FlashTime 조절")]
        [DisplayName("LED1의 FlashTime을 설정합니다.(0-100)")]
        public int LED1FlashTimeSetTimeValue
        {
            get { return LED1_flashtime_timevalue; }
            set {
                if (value > 100)
                {
                    return;
                }
                LED1_flashtime_timevalue = value;
                OnPropertyChanged();
            }
        }
        private int LED1flashtime_presentvalue;

        public int LED1FlashTimePresentValue
        {
            get { return LED1flashtime_presentvalue; }
            set { LED1flashtime_presentvalue = value;
                OnPropertyChanged();
            }
        }
        
        //
        //
        //LED2 Flashtime binding
        private int LED2_flashtime_timevalue;

        /// <summary>
        /// 조명2의 flash 시간을 설정한다.
        /// </summary>
        /// <param name="time">시간 값. 0~100(ms)사이</param>
        [Category("LED FlashTime 조절")]
        [DisplayName("LED2의 FlashTime을 설정합니다.(0-100)")]
        public int LED2FlashTimeSetTimeValue
        {
            get { return LED2_flashtime_timevalue; }
            set { if (value > 100)
            {
                return;
            }
            LED2_flashtime_timevalue = value;
                OnPropertyChanged();
            }
        }
        private int LED2flashtime_presentvalue;

        public int LED2FlashTimePresentValue
        {
            get { return LED2flashtime_presentvalue; }
            set { LED2flashtime_presentvalue = value; }
        }

        //
        //
        //write output port
        private int channellist_value;

        [Category("Write Output Port")]
        [DisplayName("채널(PIN) 선택.(0-7)")]
        public int ChannelListSetValue
        {
            get { return channellist_value; }
            set { channellist_value = value;
                OnPropertyChanged();
            }
        }

        private int value_value;

        [Category("Write Output Port")]
        [DisplayName("값 선택(0(Off) or 1(On))")]
        public int ValueSetValue
        {
            get { return value_value; }
            set {
                value_value = value;
                OnPropertyChanged();
            }
        }


        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));

                App.newMainWindow = new NewMainWindow();
                App.newMainWindow.stbar.Content = "작업중 입니다";
            }
        }






        /// <summary>
        /// input port의 상태를 확인한다.
        /// </summary>
        public void InPortStatus()
        {
            String data = String.Format("I{0}", Convert.ToString('\r'));            
            Trace.WriteLine(data);
           // App.mySerial.Write(data);
        }

        /// <summary>
        /// strobe의 상태를 확인한다
        /// </summary>
        public void StrobeStatus()
        {
            String data = String.Format("E,2{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
            //App.mySerial.Write(data);
        }


        /// <summary>
        /// 조명1의 LED 밝기 정도를 확인한다.
        /// </summary>
        public void LedBright1()
        {
            String data = String.Format("R,0{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
            //App.mySerial.Write(data);
        }

        /// <summary>
        /// 조명2의 LED 밝기 정도를 확인한다.
        /// </summary>
        public void LedBright2()
        {
            String data = String.Format("R,1{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
           // App.mySerial.Write(data);
        }


        /// <summary>
        /// 알람을 킨다.
        /// </summary>
        public void AlarmOn()
        {
            String data = String.Format("A,1{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
           
            //App.mySerial.Write(data);
        }

        /// <summary>
        /// 알람을 끈다.
        /// </summary>
        public void AlarmOff()
        {
            String data = String.Format("A,0{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
           // App.mySerial.Write(data);
        }

        /// <summary>
        /// 버저를 킨다.
        /// </summary>
        public void BuzzerOn()
        {
            String data = String.Format("B,1{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
            //App.mySerial.Write(data);
        }

        /// <summary>
        /// 버저를 끈다.
        /// </summary>
        public void BuzzerOff()
        {
            String data = String.Format("B,0{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
            //App.mySerial.Write(data);
        }

        /// <summary>
        /// strobe을 킨다.
        /// </summary>
        public void StrobeOn()
        {
            String data = String.Format("E,1{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
            //App.mySerial.Write(data);
        }

        /// <summary>
        /// strobe을 끈다.
        /// </summary>
        public void StrobeOff()
        {
            String data = String.Format("E,0{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
           // App.mySerial.Write(data);
        }

        /// <summary>
        /// 1번 조명의 LED 밝기 정도를 변경한다.
        /// </summary>
        /// <param name="bright">밝기 값. 0~100사이</param>
        public void ChangeBright1(double bright)
        {
            String data = String.Format("L,0,{0}{1}", bright, Convert.ToString('\r'));
            Trace.WriteLine(data);
            //App.mySerial.Write(data);
        }

        /// <summary>
        /// 2번 조명의 LED 밝기 정도를 변경한다.
        /// </summary>
        /// <param name="bright">밝기 값. 0~100사이</param>
        public void ChangeBright2(double bright)
        {
            String data = String.Format("L,1,{0}{1}", bright, Convert.ToString('\r'));
            Trace.WriteLine(data);
           // App.mySerial.Write(data);
        }

        /// <summary>
        /// marking을 시작한다.
        /// </summary>
        public void MarkingStart()
        {
            String data = String.Format("M,1{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);
        }

        /// <summary>
        /// marking을 멈춘다.
        /// </summary>
        public void MarkingStop()
        {
            String data = String.Format("M,0{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
         //   App.mySerial.Write(data);
        }

        /// <summary>
        /// 특정 채널에 value값을 쓴다.
        /// </summary>
        /// <param name="channel">채널 값. 0~7사이</param>
        /// <param name="value">on/off 값. 1/0</param>
        public void WriteOutPort(int channel, int value)
        {
            String data = String.Format("O,{0},{1}{2}", channel, value, Convert.ToString('\r'));
            Trace.WriteLine(data);
           // App.mySerial.Write(data);
        }

        /// <summary>
        /// 조명1의 flash 시간을 설정한다.
        /// </summary>
        /// <param name="time">시간 값. 0~100(ms)사이</param>
        public void FalshTime1(int time)
        {
            String data = String.Format("S,0,0,0,{0}{1}", time, Convert.ToString('\n'));
            Trace.WriteLine(data);
            //App.mySerial.Write(data);
        }

        /// <summary>
        /// 조명2의 flash 시간을 설정한다.
        /// </summary>
        /// <param name="time">시간 값. 0~100(ms)사이</param>
        public void FalshTime2(int time)
        {
            String data = String.Format("S,1,0,0,{0}{1}", time, Convert.ToString('\n'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);
        }

        /// <summary>
        /// solenoid를 킨다.
        /// </summary>
        public void SolenoidOn()
        {
            String data = String.Format("V,1{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);
        }

        /// <summary>
        /// solenoid를 끈다.
        /// </summary>
        public void SolenoidOff()
        {
            String data = String.Format("V,0{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
         //   App.mySerial.Write(data);
        }

        /// <summary>
        /// LCB board의 software를 리셋한다.
        /// </summary>
        public void Reset()
        {
            String data = String.Format("X,1,2,3{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
            //App.mySerial.Write(data);
        }
    }
}
