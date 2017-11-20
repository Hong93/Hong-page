using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WiseScopeDemo
{
    public class MALSController : INotifyPropertyChanged
    {
        //MALS Change Step Binding          
        private int change_step_set_value;

        /// <summary>
        /// MALS의 Step을 변경한다.
        /// </summary>
        /// <param name="step">초점 값. 0~320사이(10단위)</param>
        [Category("Step 변경")]
        [DisplayName("MALS의 Step 값을 변경합니다.(0-320. 10단위)")]
        public int ChgStepSetValue
        {
            get { return change_step_set_value; }
            set {
                if (value % 10 != 0)
                {
                    return;
                }
                else if (value > 320)
                {
                    return;
                }
                change_step_set_value = value;
                OnPropertyChanged();
            }
        }
        private int change_step_present_value;

        public int ChgStepPresentValue
        {
            get { return change_step_present_value; }
            set { change_step_present_value = value;
                OnPropertyChanged();
            }            
        }

        //
        //
        //동축조명 Ontime 설정 Binding
        private int set_coaxial_on_time_value;

        /// <summary>
        /// 동축 조명이 켜져있는 시간을 설정한다.
        /// </summary>
        /// <param name="time">시간 값. 32-5000(us)사이</param>
        [Category("조명 On Time 설정")]
        [DisplayName("동축 조명이 켜져있는 시간을 설정합니다.(32-5000)")]
        public int CoaxialOnTimeSetValue
        {
            get { return set_coaxial_on_time_value; }
            set { if (value > 5000 || value < 32)
                {
                    return;
                }
                set_coaxial_on_time_value = value;
                OnPropertyChanged();
            }
        }
        private int coaxial_ontime_present_value;

        public int CoaxialOnTimePresentValue
        {
            get { return coaxial_ontime_present_value; }
            set { coaxial_ontime_present_value = value;
                OnPropertyChanged();
                }
        }
        
        //
        //
        //링조명 Ontime 설정 Binding
        private int set_ring_on_time_value;

        /// <summary>
        /// 링 조명이 켜져있는 시간을 설정한다.
        /// </summary>
        /// <param name="time">시간 값. 32-5000(us)사이</param>
        [Category("조명 On Time 설정")]
        [DisplayName("링 조명이 켜져 있는 시간을 설정합니다.(32-5000)")]
        public int RingOnTimeSetValue
        {
            get { return set_ring_on_time_value; }
            set { if (value > 5000 || value < 32)
                {
                    return;
                }
                set_ring_on_time_value = value;
                OnPropertyChanged();
            }
        }
        private int ring_ontime_present_value;

        public int RIngOnTimePresentValue
        {
            get { return ring_ontime_present_value; }
            set { ring_ontime_present_value = value;
                OnPropertyChanged();
            }
        }

        //
        //trigger signal present value
        private int triggersignal_presentvalue;

        public int TriggerSignalPresentValue
        {
            get { return triggersignal_presentvalue; }
            set
            {
                triggersignal_presentvalue = value;
                OnPropertyChanged();
            }
        }
        //
        //
        //Trigger Signal2 focus Binding
        private int triggersignal2_stepvalue;

        /// <summary>
        /// MALS controller가 정해준 focus값으로 step을 변경한 후
        /// 동축 조명을 킨 뒤 카메라에 H/W Trigger 신호를 보내고, 링 조명을 킨 뒤 카메라에 H/W Trigger 신호를 보내 두 신호를 맞춘다.
        /// </summary>
        /// <param name="focus">초점 값. 0-320사이(10단위)</param>
        [Category("Trigger Signal 보낼 때 Step 값 설정")]
        [DisplayName("사용자가 설정한 값으로 MALS의 Step을 변경한 뒤 동축 조명을 켜서 신호를 보냅니다. MALS Controller는 카메라로부터 동축조명의 신호를 받고 조명을 링 조명으로 변경합니다. 조명을 변경한 뒤 링 조명의 신호를 받아 신호의 값을 반환한 뒤 동작을 끝낸다.(0-320. 10단위)")]
        public int TriggerSignal2SetStepValue
        {
            get { return triggersignal2_stepvalue; }
            set {
                if (value % 10 != 0)
                {
                    return;
                }
                else if (value > 320)
                {
                    return;
                }
                triggersignal2_stepvalue = value;
                OnPropertyChanged();
            }
        }
        

        //
        //
        //Trigger Signal4 focus Binding
        private int triggersignal4_stepvalue;

        /// <summary>
        /// MALS controller가 정해준 focus값으로 step을 변경한 후
        /// 동축 조명을 킨 뒤 카메라에 H/W Trigger 신호를 보낸다.
        /// </summary>
        /// <param name="focus">초점 값. 0-320사이(10단위)</param>
        [Category("Trigger Signal 보낼 때 Step 값 설정")]
        [DisplayName("사용자가 설정한 값으로 MALS의 Step을 변경한 뒤 동축 조명만 켜서 신호를 전송합니다. MALS Controller는 카메라로부터 동축조명의 신호를 받고 신호의 값을 반환한 뒤 동작을 끝낸다.(0-320. 10단위)")]
        public int TriggerSignal4SetStepValue
        {
            get { return triggersignal4_stepvalue; }
            set{
                if (value % 10 != 0)
                {
                    return;
                }
                else if (value > 320)
                {
                    return;
                }
                triggersignal4_stepvalue = value;
                OnPropertyChanged();
            }
        }
       

        //
        //
        //Trigger Signal5 focus Binding
        private int triggersignal5_stepvalue;

        /// <summary>
        /// MALS controller가 정해준 focus값으로 step을 변경한 후
        /// 링 조명을 킨 뒤 카메라에 H/W Trigger 신호를 보낸다.
        /// </summary>
        /// <param name="focus">초점 값. 0-320사이(10단위)</param>
        [Category("Trigger Signal 보낼 때 Step 값 설정")]
        [DisplayName("사용자가 설정한 값으로 MALS의 Step을 변경한 뒤 링 조명만 켜서 신호를 전송합니다. MALS Controller는 카메라로부터 링조명의 신호를 받고 신호의 값을 반환한 뒤 동작을 끝낸다.(0-320. 10단위)")]
        public int TriggerSignal5SetStepValue
        {
            get { return triggersignal5_stepvalue; }
            set {
                if (value % 10 != 0)
                {
                    return;
                }
                else if (value > 320)
                {
                    return;
                }
                triggersignal5_stepvalue = value;
                OnPropertyChanged();
            }
        }
        

        //
        //
        //Trigger Delay time Binding
        private int triggerdelaytime_timevalue;

        /// <summary>
        /// MALS의 초점을 바꾼 뒤 H/W Trigger 신호를 얼마동안 지연 시킬 지 설정한다.
        /// </summary>
        /// <param name="time">시간 값.0-100(us)</param>
        [Category("Trigger Time 설정")]
        [DisplayName("Step이 변경된 후 Trigger Signal이 얼마 후에 발생할 지 시간을 설정합니다.(0-100)")]
        public int TriggerDelayTimeSetTimeValue
        {
            get { return triggerdelaytime_timevalue; }
            set {if (value > 100)
                {
                    return;
                }
                    triggerdelaytime_timevalue = value;
                OnPropertyChanged();
            }
        }
        
        private int triggerdelaytime_presentvalue;

        public int TriggerDelayTimePresentValue
        {
            get { return triggerdelaytime_presentvalue; }
            set { triggerdelaytime_presentvalue = value;
                OnPropertyChanged();
            }
        }

        //
        //
        //Trigger Hold time Binding
        private int triggerholdrime_timevalue;

        /// <summary>
        /// Trigger 신호를 보낼 수 있는 상태가 되었을 때
        /// Trigger 신호를 얼마 동안 유지 시키고 보낼 지 설정한다.
        /// </summary>
        /// <param name="time">시간 값.0-50(us)</param>
        [Category("Trigger Time 설정")]
        [DisplayName("신호가 생성된 후 Trigger Signal의 전송 대기 시간을 설정합니다.(0-50)")]
        public int TriggerHoldTimeSetTimeValue
        {
            get { return triggerholdrime_timevalue; }
            set {
                if (value > 50)
                {
                    return;
                }
                triggerholdrime_timevalue = value;
                OnPropertyChanged();
            }
        }
        
        private int triggerholdtime_presentvalue;

        public int TriggerHoldTimePresentValue
        {
            get { return triggerholdtime_presentvalue; }
            set { triggerholdtime_presentvalue = value;
                OnPropertyChanged();
            }
        }

        //
        //
        //Change Step For Image Capture
        private int imagecapture_stepvalue;

        /// <summary>
        /// 이미지 캡쳐를 위한 MALS step을 정의한다.
        /// </summary>
        /// <param name="count">Trigger Count 값.0-320사이(10단위)</param>
        [Category("이미지 캡처를 하기 위한 Step 값 설정")]
        [DisplayName("Step 값 설정.(0-320. 10단위)")]
        public int ImageCaptureSetStepValue
        {
            get { return imagecapture_stepvalue; }
            set {
                if (value % 10 != 0 || value > 320)
                {
                    return;
                }
                imagecapture_stepvalue = value;
                OnPropertyChanged();
            }
        }
        
        private int step_for_capture_presentvalue;

        public int StepForCapturePresentValue
        {
            get { return step_for_capture_presentvalue; }
            set { step_for_capture_presentvalue = value;
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
            }
        }
















        /// <summary>
        /// MALS의 Step을 변경한다.
        /// </summary>
        /// <param name="step">초점 값. 0~320사이</param>
        public void ChangeStep(int step)
        {
            String data = String.Format("R,1,{0}{1}", step, Convert.ToString('\r'));
            Trace.WriteLine(data);
           // App.mySerial.Write(data);
        }

        /// <summary>
        /// 동축 조명을 선택한다.
        /// </summary>
        public void SelectLedCoaxial()
        {
            String data = String.Format("B,0,0{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
           // App.mySerial.Write(data);
        }

        /// <summary>
        /// 링 조명을 선택한다.
        /// </summary>
        public void SelectLedRing()
        {
            String data = String.Format("B,0,2{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);
        }

        /// <summary>
        /// 동축 조명이 켜져있는 시간을 설정한다.
        /// </summary>
        /// <param name="time">시간 값. 32-5000(us)사이</param>
        public void LightOnTimeCoaxial(int time)
        {
            String data = String.Format("N,2,{0}{1}", time, Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);

        }

        /// <summary>
        /// 링 조명이 켜져있는 시간을 설정한다.
        /// </summary>
        /// <param name="time">시간 값. 32-5000(us)사이</param>
        public void LightOnTimeRing(int time)
        {
            String data = String.Format("N,3,{0}{1}", time, Convert.ToString('\r'));
            Trace.WriteLine(data);
           // App.mySerial.Write(data);

        }

        /// <summary>
        /// "J"command 를 사용하기 위한 MALS table steps 을 설정한다.
        /// </summary>
        /// <param name="index">테이블 index 값. 0-50사이</param>
        /// <param name="step">step 값. 0-320사이</param>
        public void TableStep1(int index, int step)
        {
            String data = String.Format("G,0,0,{0},{1}{2}", index, step, Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);

        }

        /// <summary>
        /// "J"command 를 사용하기 위한 MALS table steps 을 설정한다.
        /// </summary>
        /// <param name="index">테이블 index 값. 0-50사이</param>
        /// <param name="step">step 값. 0-320사이</param>
        public void TableStep2(int index, int step)
        {
            String data = String.Format("G,1,0,{0},{1}{2}", index, step, Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);

        }

        /// <summary>
        /// "J"command 를 사용하기 위한 MALS table steps 을 설정한다.
        /// </summary>
        /// <param name="index">테이블 index 값. 0-50사이</param>
        /// <param name="step">step 값. 0-320사이</param>
        /// <param name="number_of_step">현재 command의 step 값. 0-320사이</param>
        public void TableStep3(int index, int step, int number_of_step)
        {
            String data = String.Format("G,{0},0,{1},{2},0,{1},{2},0,{1},{2},0,{1},{2}{3}", number_of_step, index, step, Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);

        }

        /// <summary>
        /// MALS controller가 카메라에 H/W Trigger를 보내 MALS의 step을 바꾸고, "G"command에 정의된 값으로 초점을 바꾼다.
        /// </summary>
        public void TrigSignal1()
        {
            String data = String.Format("J,0{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);

        }

        /// <summary>
        /// MALS controller가 정해준 focus값으로 step을 변경한 후
        /// 동축 조명을 킨 뒤 카메라에 H/W Trigger 신호를 보내고, 링 조명을 킨 뒤 카메라에 H/W Trigger 신호를 보내 두 신호를 맞춘다.
        /// </summary>
        /// <param name="focus">초점 값. 0-320사이</param>
        public void TrigSignal2(int focus)
        {
            String data = String.Format("J,1,{0}{1}", focus, Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);

        }

        /// <summary>
        /// 외부의 H/W Trigger 신호를 카메라에 보내고 MALS controller가 "G"command에 정의된 값으로 step을 바꾸고
        /// 동축 조명을 킨 뒤 카메라에 H/W Trigger 신호를 보내고, 링 조명을 킨 뒤 카메라에 H/W Trigger 신호를 보낸다.
        /// </summary>
        public void TrigSignal3()
        {
            String data = String.Format("J,2{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);

        }

        /// <summary>
        /// MALS controller가 정해준 focus값으로 step을 변경한 후
        /// 동축 조명을 킨 뒤 카메라에 H/W Trigger 신호를 보낸다.
        /// </summary>
        /// <param name="focus">초점 값. 0-320사이</param>
        public void TrigSignal4(int focus)
        {
            String data = String.Format("J,3,{0}{1}", focus, Convert.ToString('\r'));
            Trace.WriteLine(data);
         //   App.mySerial.Write(data);

        }

        /// <summary>
        /// MALS controller가 정해준 focus값으로 step을 변경한 후
        /// 링 조명을 킨 뒤 카메라에 H/W Trigger 신호를 보낸다.
        /// </summary>
        /// <param name="focus">초점 값. 0-320사이</param>
        public void TrigSignal5(int focus)
        {
            String data = String.Format("J,4,{0}{1}", focus, Convert.ToString('\r'));
            Trace.WriteLine(data);
           // App.mySerial.Write(data);

        }

        /// <summary>
        /// MALS의 초점을 바꾼 뒤 H/W Trigger 신호를 얼마동안 지연 시킬 지 설정한다.
        /// </summary>
        /// <param name="time">시간 값.(us)</param>
        public void TrigTimeDelay(int time)
        {
            String data = String.Format("K,2,{0}{1}", time, Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);

        }

        /// <summary>
        /// Trigger 신호를 보낼 수 있는 상태가 되었을 때
        /// Trigger 신호를 얼마 동안 유지 시키고 보낼 지 설정한다.
        /// </summary>
        /// <param name="time">시간 값.(us)</param>
        public void TrigTimeHold(int time)
        {
            String data = String.Format("K,3,{0}{1}", time, Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);

        }

        /// <summary>
        /// H/W Trigger 신호를 리셋한다.
        /// </summary>
        public void TrigSignalReset()
        {
            String data = String.Format("K,4,0{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);

        }

        /// <summary>
        /// H/W Trigger 신호를 수동 설정한다.
        /// </summary>
        public void TrigSignalSet()
        {
            String data = String.Format("K,4,1{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);

        }

        /// <summary>
        /// 이미지 캡쳐를 위한 MALS step을 정의한다.
        /// </summary>
        /// <param name="count">Trigger Count 값.0-320사이</param>
        public void TrigCount(int count)
        {
            String data = String.Format("N,4,{0}{1}", count, Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);

        }



        /// <summary>
        /// MALS controller의 software 버전을 확인한다.
        /// </summary>
        public void SoftwareVer()
        {
            String data = String.Format("Q{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
         //   App.mySerial.Write(data);

        }

        /// <summary>
        /// MALS controller의 software를 리셋한다.
        /// </summary>
        public void Reset()
        {
            String data = String.Format("X,1,2,3{0}", Convert.ToString('\r'));
            Trace.WriteLine(data);
          //  App.mySerial.Write(data);

        }
    }
}
