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
    /// PageMals.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageAll : Page
    {
        public Machine machine;
        public UserControlParameter1 step_chg_usercontrol;


        public PageAll()
        {
            InitializeComponent();
        }



        private void StepChange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void StepChangebtn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS Step Change");
            // string names =StepChange.SelectedItem.ToString();
            //int step = int.Parse(names.ToString().Trim());
            //mals_ctr.ChangeStep(step);

            //machine.mals_ctr.ChangeStep(SliderStepChangeValue.Value);   //<- slider의 value는 double.. ->함수들 int에서 double로 변경할 것.
        }
        private void SelectCoaxial_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS Select Coaxial LED");
            //  mals_ctr.SelectLedCoaxial();
        }

        private void SelectRing_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS Select Ring LED");
            // mals_ctr.SelectLedRing();
        }

        private void TriggerSignal1_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS Generate Trigger Signal(external Frame-End signal, No LED)");
            //mals_ctr.TrigSignal1();
        }

        private void TriggerSignal22_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void TriggerSignal22btn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS Generate Trigger Signal(step as defined in command, All LED)");

            /*  string names = TriggerSignal22.SelectedItem.ToString();
              int focus = int.Parse(names.ToString().Trim());
              mals_ctr.TrigSignal2(focus);*/
        }

        private void TriggerSignal3_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS Generate Trigger Signal(external H/W trigger signal, All LED)");
            //  mals_ctr.TrigSignal3();
        }

        
        private void TriggerSignal44btn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS Generate Trigger Signal(step as defined in command, Coaxial LED)");
            /*string names = TriggerSignal44.SelectedItem.ToString();
            int focus = int.Parse(names.ToString().Trim());
            mals_ctr.TrigSignal4(focus);*/
        }

        
        private void TriggerSignal55btn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS Generate Trigger Signal(step as defined in command, Ring LED)");
            /*string names = TriggerSignal55.SelectedItem.ToString();
            int focus = int.Parse(names.ToString().Trim());
            mals_ctr.TrigSignal5(focus);*/
        }

        private void TriggerSet_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS H/W Trigger Signal Manual Set");
            // mals_ctr.TrigSignalSet();
        }

        private void TriggerReset_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS H/W Trigger Signal Reset");
            //  mals_ctr.TrigSignalReset();
        }


        private void TriggerCountbtn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS Trigger Count(step) Set for Image Capture");
            /* string names = TriggerCount.SelectedItem.ToString();
             int count = int.Parse(names.ToString().Trim());
             mals_ctr.TrigCount(count);*/
        }

        
        private void SignalDelaybtn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS Trigger Signal Delay Time Set");
            /*  string names = SignalDelay.SelectedItem.ToString();
              int time = int.Parse(names.ToString().Trim());
              mals_ctr.TrigTimeDelay(time);*/
        }

        
        private void SignalHoldbtn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS Trigger Signal Hold Time Set");
            /* string names = SignalHold.SelectedItem.ToString();
             int time = int.Parse(names.ToString().Trim());
             mals_ctr.TrigTimeHold(time);*/
        }

        private void Version_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Get MALS Controller's Software Version");
            // mals_ctr.SoftwareVer();
        }

        private void SoftReset_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS Controller Software Reset");
            //  mals_ctr.Reset();
        }


        private void coaxialontime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void ringontime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void coaxialtimesend_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS Coaxial LED On Time Set");
            /*
            try
            {
                string names = coaxialontime.Text.ToString();
                int time = int.Parse(names.ToString().Trim());
                mals_ctr.LightOnTimeCoaxial(time);
            }
            catch
            {
                mals_ctr.LightOnTimeCoaxial(100);
            }*/
        }


        private void ringtimesend_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("MALS Ring LED On Time Set");
            /*
            try
            {
                string names = ringontime.Text.ToString();
                int time = int.Parse(names.ToString().Trim());

                mals_ctr.LightOnTimeRing(time);
            }
            catch
            {
                mals_ctr.LightOnTimeRing(50);
            }*/
        }

        private void LED1bright_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Get Lighting LED1 Bright");
            // lighting_ctr.LedBright1();
        }

        private void LED2bright_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Get Lighting LED2 Bright");
            // lighting_ctr.LedBright2();
        }

        
        private void LED1BrightChangebtn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting LED1 Bright Set");
            /* double bright = LED1BrightChange.Value;

                         lighting_ctr.ChangeBright1(bright);*/
        }

        
        private void LED2BrightChangebtn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting LED2 Bright Set");
            /* double bright = LED2BrightChange.Value;

                         lighting_ctr.ChangeBright2(bright);*/
        }

        private void AlarmOn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting Alarm On");

            // lighting_ctr.AlarmOn();
        }

        private void AlarmOff_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting Alarm Off");

            //  lighting_ctr.AlarmOff();
        }

        private void BuzzerOn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting Buzzer On");

            //  lighting_ctr.BuzzerOn();
        }

        private void BuzzerOff_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting Buzzer Off");

            // lighting_ctr.BuzzerOff();
        }

        private void StrobeOn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting Strobe On");

            //lighting_ctr.StrobeOn();
        }

        private void StrobeOff_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting Strobe Off");

            // lighting_ctr.StrobeOff();
        }

        private void MarkingOn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting Marking Start");

            // lighting_ctr.MarkingStart();
        }

        private void MarkingStop_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting Marking Stop");

            // lighting_ctr.MarkingStop();
        }

        private void SolenoidOn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting Solenoid On");

            //  lighting_ctr.SolenoidOn();
        }

        private void SolenoidOff_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting Solenoid Off");

            //   lighting_ctr.SolenoidOff();
        }




        private void Outportbtn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting Write Value on the Specific Channel");
            /*
                        string channelnames = ChannelList.SelectedItem.ToString();
                        int channel = int.Parse(channelnames.ToString().Trim());

                        string valuenames = Value.SelectedItem.ToString();
                        int value = int.Parse(valuenames.ToString().Trim());

                        lighting_ctr.WriteOutPort(channel, value);*/
        }


        private void LED1Flashingtimebtn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting LED1 Flashing Time Set");
            /*string names = LED1Flashingtime.SelectedItem.ToString();
              int time = int.Parse(names.ToString().Trim());
              lighting_ctr.FalshTime1(time);*/
        }

        
        private void LED2Flashingtimebtn_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting LED2 Flashing Time Set");
            /*
                        string names = LED2Flashingtime.SelectedItem.ToString();
                        int time = int.Parse(names.ToString().Trim());
                        lighting_ctr.FalshTime2(time);*/
        }

        private void Strobe_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Get Lighting Strobe Status");

            // lighting_ctr.StrobeStatus();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            App.Log.Debug("Lighting Software Reset");
            // machine.lighting_ctr.Reset();
        }







        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 7; i++)
            {
                ComboBoxChannelList_Value.Items.Add(i);
            }
            for (int i = 0; i <= 1; i++)
            {
                ComboBoxValue_Value.Items.Add(i);
            }
            InitializeBinding();


            serial.NavigationService.Navigate(App.pageSerial);

        }


        public void InitializeBinding()
        {
            machine = App.cmachine;


            Binding chgstepbind1 = new Binding();
            chgstepbind1.Source = machine.mals_ctr;
            chgstepbind1.Path = new PropertyPath("ChgStepSetValue");
            chgstepbind1.Mode = BindingMode.TwoWay;
            chgstepbind1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            BindingOperations.SetBinding(
                SliderStepChangeValue, Slider.ValueProperty, chgstepbind1);

            Binding chgstepbind2 = new Binding();
            chgstepbind2.Source = machine.mals_ctr;
            chgstepbind2.Path = new PropertyPath("ChgStepSetValue");
            chgstepbind2.Mode = BindingMode.TwoWay;
            chgstepbind2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;



            BindingOperations.SetBinding(
                TextBoxStepChangeValue,
                TextBox.TextProperty,
                chgstepbind2
                );

            Binding chgstepbind3 = new Binding();
            chgstepbind3.Source = App.cmachine.mals_ctr;
            chgstepbind3.Path = new PropertyPath("ChgStepPresentValue");
            chgstepbind3.Mode = BindingMode.TwoWay;
            chgstepbind3.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            BindingOperations.SetBinding(
                textBlock_ChangeStep_PresentValue,
                TextBlock.TextProperty,
                chgstepbind3
                );

            App.cmachine.mals_ctr.ChgStepPresentValue = 20;


            Binding coaxialontime1 = new Binding();
            coaxialontime1.Source = App.cmachine.mals_ctr;
            coaxialontime1.Path = new PropertyPath("CoaxialOnTimeSetValue");
            coaxialontime1.Mode = BindingMode.TwoWay;
            coaxialontime1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                TextBoxSetCoaxialOnTimeValue,
                TextBox.TextProperty,
                coaxialontime1);

            Binding coaxialontime2 = new Binding();
            coaxialontime2.Source = App.cmachine.mals_ctr;
            coaxialontime2.Path = new PropertyPath("CoaxialOnTimePresentValue");
            coaxialontime2.Mode = BindingMode.TwoWay;
            coaxialontime2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                textBlock_CoxialOntime_PresentValue,
                TextBlock.TextProperty,
                coaxialontime2);

            Binding ringontime1 = new Binding();
            ringontime1.Source = App.cmachine.mals_ctr;
            ringontime1.Path = new PropertyPath("RingOnTimeSetValue");
            ringontime1.Mode = BindingMode.TwoWay;
            ringontime1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                TextBoxSetRingOnTimeValue,
                TextBox.TextProperty,
                ringontime1);

            Binding ringontime2 = new Binding();
            ringontime2.Source = App.cmachine.mals_ctr;
            ringontime2.Path = new PropertyPath("RIngOnTimePresentValue");
            ringontime2.Mode = BindingMode.TwoWay;
            ringontime2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                textBlock_RingOntime_PresentValue,
                TextBlock.TextProperty,
                ringontime2);


            Binding signal2focus1 = new Binding();
            signal2focus1.Source = App.cmachine.mals_ctr;
            signal2focus1.Path = new PropertyPath("TriggerSignal2SetStepValue");
            signal2focus1.Mode = BindingMode.TwoWay;
            signal2focus1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                sliderTriggerSignal2_StepValue,
                Slider.ValueProperty,
                signal2focus1);

            Binding signal2focus2 = new Binding();
            signal2focus2.Source = App.cmachine.mals_ctr;
            signal2focus2.Path = new PropertyPath("TriggerSignal2SetStepValue");
            signal2focus2.Mode = BindingMode.TwoWay;
            signal2focus2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                TextBoxTriggerSignal2_StepValue,
                TextBox.TextProperty,
                signal2focus2);


            Binding signal4focus1 = new Binding();
            signal4focus1.Source = App.cmachine.mals_ctr;
            signal4focus1.Path = new PropertyPath("TriggerSignal4SetStepValue");
            signal4focus1.Mode = BindingMode.TwoWay;
            signal4focus1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                sliderTriggerSignal4_StepValue,
                Slider.ValueProperty,
                signal4focus1);

            Binding signal4focus2 = new Binding();
            signal4focus2.Source = App.cmachine.mals_ctr;
            signal4focus2.Path = new PropertyPath("TriggerSignal4SetStepValue");
            signal4focus2.Mode = BindingMode.TwoWay;
            signal4focus2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                TextBoxTriggerSignal4_StepValue,
                TextBox.TextProperty,
                signal4focus2);


            Binding signal5focus1 = new Binding();
            signal5focus1.Source = App.cmachine.mals_ctr;
            signal5focus1.Path = new PropertyPath("TriggerSignal5SetStepValue");
            signal5focus1.Mode = BindingMode.TwoWay;
            signal5focus1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                sliderTriggerSignal5_StepValue,
                Slider.ValueProperty,
                signal5focus1);

            Binding signal5focus2 = new Binding();
            signal5focus2.Source = App.cmachine.mals_ctr;
            signal5focus2.Path = new PropertyPath("TriggerSignal5SetStepValue");
            signal5focus2.Mode = BindingMode.TwoWay;
            signal5focus2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                TextBoxTriggerSignal5_StepValue,
                TextBox.TextProperty,
                signal5focus2);


            Binding signaldelaytime1 = new Binding();
            signaldelaytime1.Source = App.cmachine.mals_ctr;
            signaldelaytime1.Path = new PropertyPath("TriggerDelayTimeSetTimeValue");
            signaldelaytime1.Mode = BindingMode.TwoWay;
            signaldelaytime1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                SliderTriggerDelayTime_TimeValue,
                Slider.ValueProperty,
                signaldelaytime1);

            Binding signaldelaytime2 = new Binding();
            signaldelaytime2.Source = App.cmachine.mals_ctr;
            signaldelaytime2.Path = new PropertyPath("TriggerDelayTimeSetTimeValue");
            signaldelaytime2.Mode = BindingMode.TwoWay;
            signaldelaytime2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                TextBoxTriggerDelayTime_TimeValue,
                TextBox.TextProperty,
                signaldelaytime2);

            Binding signaldelaytime3 = new Binding();
            signaldelaytime3.Source = App.cmachine.mals_ctr;
            signaldelaytime3.Path = new PropertyPath("TriggerDelayTimePresentValue");
            signaldelaytime3.Mode = BindingMode.TwoWay;
            signaldelaytime3.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                textBlock_triggerdelaytime_PresentValue,
                TextBlock.TextProperty,
                signaldelaytime3);



            Binding signalholdtime1 = new Binding();
            signalholdtime1.Source = App.cmachine.mals_ctr;
            signalholdtime1.Path = new PropertyPath("TriggerHoldTimeSetTimeValue");
            signalholdtime1.Mode = BindingMode.TwoWay;
            signalholdtime1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                SliderTriggerHoldTime_TimeValue,
                Slider.ValueProperty,
                signalholdtime1);

            Binding signalholdtime2 = new Binding();
            signalholdtime2.Source = App.cmachine.mals_ctr;
            signalholdtime2.Path = new PropertyPath("TriggerHoldTimeSetTimeValue");
            signalholdtime2.Mode = BindingMode.TwoWay;
            signalholdtime2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                TextBoxTriggerHoldTime_TimeValue,
                TextBox.TextProperty,
                signalholdtime2);

            Binding signalholdtime3 = new Binding();
            signalholdtime3.Source = App.cmachine.mals_ctr;
            signalholdtime3.Path = new PropertyPath("TriggerHoldTimePresentValue");
            signalholdtime3.Mode = BindingMode.TwoWay;
            signalholdtime3.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                textBlock_triggerholdtime_PresentValue,
                TextBlock.TextProperty,
                signalholdtime3);




            Binding imagecapturestep1 = new Binding();
            imagecapturestep1.Source = App.cmachine.mals_ctr;
            imagecapturestep1.Path = new PropertyPath("ImageCaptureSetStepValue");
            imagecapturestep1.Mode = BindingMode.TwoWay;
            imagecapturestep1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                SliderImageCapture_StepValue,
                Slider.ValueProperty,
                imagecapturestep1);

            Binding imagecapturestep2 = new Binding();
            imagecapturestep2.Source = App.cmachine.mals_ctr;
            imagecapturestep2.Path = new PropertyPath("ImageCaptureSetStepValue");
            imagecapturestep2.Mode = BindingMode.TwoWay;
            imagecapturestep2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                TextBoxImageCapture_StepValue,
                TextBox.TextProperty,
                imagecapturestep2);

            Binding imagecapturestep3 = new Binding();
            imagecapturestep3.Source = App.cmachine.mals_ctr;
            imagecapturestep3.Path = new PropertyPath("StepForCapturePresentValue");
            imagecapturestep3.Mode = BindingMode.TwoWay;
            imagecapturestep3.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                textBlock_stepforcapture_presentvalue,
                TextBlock.TextProperty,
                imagecapturestep3);


            Binding chgLED1bright1 = new Binding();
            chgLED1bright1.Source = App.cmachine.lighting_ctr;
            chgLED1bright1.Path = new PropertyPath("LED1BrightChangeSetBrightValue");
            chgLED1bright1.Mode = BindingMode.TwoWay;
            chgLED1bright1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                SliderLED1_BrightChange_BrightValue,
                Slider.ValueProperty,
                chgLED1bright1);

            Binding chgLED1bright2 = new Binding();
            chgLED1bright2.Source = App.cmachine.lighting_ctr;
            chgLED1bright2.Path = new PropertyPath("LED1BrightChangeSetBrightValue");
            chgLED1bright2.Mode = BindingMode.TwoWay;
            chgLED1bright2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                TextBoxLED1_BrightChange_BrightValue,
                TextBox.TextProperty,
                chgLED1bright2);

            Binding chgLED1bright3 = new Binding();
            chgLED1bright3.Source = App.cmachine.lighting_ctr;
            chgLED1bright3.Path = new PropertyPath("LED1brightPresentValue");
            chgLED1bright3.Mode = BindingMode.TwoWay;
            chgLED1bright3.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                textBlock_LED1bright_presentvalue,
                TextBlock.TextProperty,
                chgLED1bright3);



            Binding chgLED2bright1 = new Binding();
            chgLED2bright1.Source = App.cmachine.lighting_ctr;
            chgLED2bright1.Path = new PropertyPath("LED2BrightChangeSetBrightValue");
            chgLED2bright1.Mode = BindingMode.TwoWay;
            chgLED2bright1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                SliderLED2_BrightChange_BrightValue,
                Slider.ValueProperty,
                chgLED2bright1);

            Binding chgLED2bright2 = new Binding();
            chgLED2bright2.Source = App.cmachine.lighting_ctr;
            chgLED2bright2.Path = new PropertyPath("LED2BrightChangeSetBrightValue");
            chgLED2bright2.Mode = BindingMode.TwoWay;
            chgLED2bright2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                TextBoxLED2_BrightChange_BrightValue,
                TextBox.TextProperty,
                chgLED2bright2);

            Binding chgLED2bright3 = new Binding();
            chgLED2bright3.Source = App.cmachine.lighting_ctr;
            chgLED2bright3.Path = new PropertyPath("LED2BrightPresentValue");
            chgLED2bright3.Mode = BindingMode.TwoWay;
            chgLED2bright3.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                textBlock_LED2bright_presentvalue,
                TextBlock.TextProperty,
                chgLED2bright3);


            Binding setLED1flashtime1 = new Binding();
            setLED1flashtime1.Source = App.cmachine.lighting_ctr;
            setLED1flashtime1.Path = new PropertyPath("LED1FlashTimeSetTimeValue");
            setLED1flashtime1.Mode = BindingMode.TwoWay;
            setLED1flashtime1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                SliderLED1_FlashTime_TimeValue,
                Slider.ValueProperty,
                setLED1flashtime1);

            Binding setLED1flashtime2 = new Binding();
            setLED1flashtime2.Source = App.cmachine.lighting_ctr;
            setLED1flashtime2.Path = new PropertyPath("LED1FlashTimeSetTimeValue");
            setLED1flashtime2.Mode = BindingMode.TwoWay;
            setLED1flashtime2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                TextBoxLED1_FlashTime_TimeValue,
                TextBox.TextProperty,
                setLED1flashtime2);

            Binding setLED1flashtime3 = new Binding();
            setLED1flashtime3.Source = App.cmachine.lighting_ctr;
            setLED1flashtime3.Path = new PropertyPath("LED1FlashTimePresentValue");
            setLED1flashtime3.Mode = BindingMode.TwoWay;
            setLED1flashtime3.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                textBlock_LED1flashtime_presentvalue,
                TextBlock.TextProperty,
                setLED1flashtime3);



            Binding setLED2flashtime1 = new Binding();
            setLED2flashtime1.Source = App.cmachine.lighting_ctr;
            setLED2flashtime1.Path = new PropertyPath("LED2FlashTimeSetTimeValue");
            setLED2flashtime1.Mode = BindingMode.TwoWay;
            setLED2flashtime1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                SliderLED2_FlashTime_TimeValue,
                Slider.ValueProperty,
                setLED2flashtime1);

            Binding setLED2flashtime2 = new Binding();
            setLED2flashtime2.Source = App.cmachine.lighting_ctr;
            setLED2flashtime2.Path = new PropertyPath("LED2FlashTimeSetTimeValue");
            setLED2flashtime2.Mode = BindingMode.TwoWay;
            setLED2flashtime2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                TextBoxLED2_FlashTime_TimeValue,
                TextBox.TextProperty,
                setLED2flashtime2);

            Binding setLED2flashtime3 = new Binding();
            setLED2flashtime3.Source = App.cmachine.lighting_ctr;
            setLED2flashtime3.Path = new PropertyPath("LED2FlashTimePresentValue");
            setLED2flashtime3.Mode = BindingMode.TwoWay;
            setLED2flashtime3.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                textBlock_LED2flashtime_presentvalue,
                TextBlock.TextProperty,
                setLED2flashtime3);




            Binding writeoutportchannel = new Binding();
            writeoutportchannel.Source = App.cmachine.lighting_ctr;
            writeoutportchannel.Path = new PropertyPath("ChannelListSetValue");
            writeoutportchannel.Mode = BindingMode.TwoWay;
            writeoutportchannel.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                ComboBoxChannelList_Value,
                ComboBox.SelectedItemProperty,
                writeoutportchannel);

            Binding writeoutportvalue = new Binding();
            writeoutportvalue.Source = App.cmachine.lighting_ctr;
            writeoutportvalue.Path = new PropertyPath("ValueSetValue");
            writeoutportvalue.Mode = BindingMode.TwoWay;
            writeoutportvalue.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(
                ComboBoxValue_Value,
                ComboBox.SelectedItemProperty,
                writeoutportvalue);

        }

    }

}
