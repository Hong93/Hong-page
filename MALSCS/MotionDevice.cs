////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// 해당 소스코드는 Pineapplesoft의 Machine Framework(TM)의 일부분이며 사용권 계약이 이루어진 제3자만 사용할 수 있습니다.               //
/// 소스코드가 배포된 이후 검증을 거치지 않은 채로 변경된 내용은 올바른 작동을 보증하지 않으며 저작권은 Pineapplesoft가 가지고 있습니다    //
/// 자세한 사항은 배포된 도움말 혹은 http://mf.pineapples.kr/license 에서 확인하시기 바랍니다.                                        //
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MachineFrameworkCore.Model
{
    public enum MoveOption : int
    {
        // Default Setting
        Default
            // 사다리꼴 속도Profile, vel속도로 dist위치 만큼 상대이동을 
        ,
        VelocityMovement
            // 비대칭형 사다리꼴 속도 
            ,
        AsymmetricVelocityMovement
            // SCurve Velocity Profile
            ,
        SCurvedMovement
            // 비대칭형 SCurve Velocity Profile
            , AsymmetricSCurvedMovement
    };
    public enum StopMode : int
    {
        EmergencyStop,
        SlowDownStop,
    }
    public enum MotorSensorType : int
    {
        HomePlus,
        HomeMinus,
        LimitPlus,
        LimitMinus,
    }
    // VelocityMovement
    public struct MoveOptionData
    {
        public double velocity;
        /// <summary>
        /// 가속하는데 걸리는 시간(sec)
        /// </summary>
        public double accelation_duration;
        /// <summary>
        /// 감속하는데 걸리는 시간(sec)
        /// </summary>
        public double deceleration_duration;
        /// <summary>
        /// 멈출 때 까지 blocking하는지 여부
        /// </summary>
        public bool wait_for_stop;
    } 
    public struct BoardMappingSetting
    {
        public int nIndex;
        public int nBoardIndex;
        public int nMotorLength;
        public int nInLength;
        public int nOutLength;
    };
    public struct BoardIndex
    {
        public int nBoardIndex;
        public int nBoardPosition;
        public int nBoardOptionIndex;

        // 	<!-- 
        // 		output_offset ~ output_offset - output_length를 정의함
        // 		Board의 output_board_offset 부터 참조함
        // 	-->
        public int nInputBoardOffset;

        // 	<!-- 
        // 		output_offset ~ output_offset - output_length를 정의함
        // 		Board의 output_board_offset 부터 참조함
        // 	-->
        public int nOutputBoardOffset;

        public Boolean reverseFlag;
        public Boolean bUseOption;
    };
    public class MotorSetting
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MtoP"></param>
        /// <param name="MinStroke"></param>
        /// <param name="MaxStroke"></param>
        /// <param name="MaxVelocity"></param>
        /// <param name="DefaultAccelationDuration"></param>
        /// <param name="PositionOverridesCommand">Position 위치 값을 Command 값으로 대체한다 MMC 보드의 STEP의 경우 이 값이 TRUE일 때가 있다</param>
        public MotorSetting(double MtoP, double MinStroke, double MaxStroke, double MaxVelocity, double DefaultAccelationDuration, Boolean PositionOverridesCommand = true)
        {
            this.MtoP = MtoP;
            this.MinStroke = MinStroke;
            this.MaxStroke = MaxStroke;
            this.MaxVelocity = MaxVelocity;
            this.DefaultAccelationDuration = DefaultAccelationDuration;
            this.PositionOverridesCommand = PositionOverridesCommand;
        }
        public double MtoP
        {
            get;set;
        }
        public double MinStroke
        {
            get;set;
        }
        public double MaxStroke
        {
            get; set;
        }
        public double MaxVelocity
        {
            get;set;
        }
        /// <summary>
        /// 기본 가속 시간, 단위 ms
        /// </summary>
        public double DefaultAccelationDuration
        {
            get; set;
        }
        /// <summary>
        /// 기본 감속 시간, 단위 ms
        /// </summary>
        public double DefaultDecelerationDuration
        {
            get;
            set;
        }
        /// <summary>
        /// Encode가 없는 경우 Command 값을 Encoder로 대체
        /// </summary>
        public Boolean PositionOverridesCommand
        {
            get;set;
        }


        /// <summary>
        /// 조그용으로 사용됨
        /// </summary>
        public double DefaultSpeedMultiplier
        {
            get; set;
        }
        public double MinSpeedMultiplier
        {
            get; set;
        }
        public double MaxSpeedMultiplier
        {
            get; set;
        }

         
        // 50
        public double DefaultIncrement
        {
            get
            {
                return default_increment;
            }
            set
            {
                default_increment = value;
            }
        }


        // TODO: 검토 필요(Soft Limit 관련)
        public Boolean UseSoftLimitNegative
        {
            get;
            set;
        }
        public Boolean UseSoftLimitPositive
        {
            get;
            set;
        }

        public double SoftLimitNegative
        {
            get;
            set;
        }
        public double SoftLimitNegativeInPulse
        {
            get
            {
                return SoftLimitNegative * MtoP; // Measure to Pulse
            }
            set
            {
                SoftLimitNegative = value / MtoP;
            }
        }

        private StopMode _stop_mode = StopMode.EmergencyStop;
        public StopMode SoftLimitStopModePositive
        {
            get
            {
                return _stop_mode;
            }
            set
            {
                _stop_mode = value;
            }

        }
        public StopMode SoftLimitStopModeNegative
        {
            get
            {
                return _stop_mode;
            }
            set
            {
                _stop_mode = value;
            }

        }
        /// <summary>
        /// Soft Limit의 Positive Measure
        /// </summary>
        public double SoftLimitPositive
        {
            get;
            set;
        }
        /// <summary>
        /// Soft Limit의 Positive Pulse
        /// </summary>
        public double SoftLimitPositiveInPulse
        {
            get
            {
                return SoftLimitPositiveInPulse * MtoP;
            }
            set
            {
                SoftLimitPositiveInPulse = value / MtoP;
            }
        }



        protected double motor_speed_multiplier = 10;
        protected double motor_speed_multiplier_min = 1;
        protected double motor_speed_multiplier_max = 100;

        protected double default_increment = 0.1;

        /// <summary>
        /// 속도의 배수를 정한다.
        /// </summary>
        public double SpeedMultiplier
        {
            get { return motor_speed_multiplier; }
            set { motor_speed_multiplier = value; }
        }
        public void DecreaseSpeedMultiplier()
        {
            motor_speed_multiplier--;
            if (motor_speed_multiplier < MinSpeedMultiplier) 
            {
                motor_speed_multiplier = MinSpeedMultiplier;
            }
        }
        public void IncreaseSpeedMultiplier()
        {
            motor_speed_multiplier++;
            if (motor_speed_multiplier > MaxSpeedMultiplier)
            {
                motor_speed_multiplier = MaxSpeedMultiplier;
            }
        }
 
    };

    [Serializable]
    public abstract class MotionDevice
    {
        private Machine _binding_machine = null;
        public Machine BindingMachine
        {
            get
            {
                return _binding_machine;
            }
            set
            {
                _binding_machine = value;
            }
        }
        private bool _isInitialized;
        private DateTime dtInitialization;
        protected int nMotorLength = 0;
        protected int nOutputLength = 0;
        protected int nInputLength = 0;

        protected Dictionary<int, BoardMappingSetting> defaultBoardMap;
        protected Dictionary<int, Dictionary<int, BoardMappingSetting>> optionalBoardMap;

        public Dictionary<int, BoardIndex> internalInputMap;
        public Dictionary<int, BoardIndex> internalOutputMap;
        public Dictionary<int, BoardIndex> internalMotorMap;
        public Dictionary<int, MotorSetting> motorSetting;

        public abstract Boolean IsHomePEnabled();
        public abstract Boolean IsHomeMEnabled();
        public abstract Boolean IsLimitPEnabled();
        public abstract Boolean IsLimitMEnabled();
        /// <summary>
        ///  연속 동작 가능한지 여부
        /// </summary>
        /// <returns></returns>
        public abstract Boolean IsContinuousMoveEnabled();

        public System.Xml.XmlNode xn_init;
        public MotionDevice()
        {
            _isInitialized = false;
            defaultBoardMap = new Dictionary<int, BoardMappingSetting>();
            optionalBoardMap = new Dictionary<int, Dictionary<int, BoardMappingSetting>>();
            internalInputMap = new Dictionary<int, BoardIndex>();
            internalOutputMap = new Dictionary<int, BoardIndex>();
            internalMotorMap = new Dictionary<int, BoardIndex>();
            motorSetting = new Dictionary<int, MotorSetting>();

            dicMotorName = new Dictionary<int, String>();
            dicInputName = new Dictionary<int, String>();
            dicInputNameUnit = new Dictionary<int, String>();
            dicInputNamePort = new Dictionary<int, String>();
            dicOutputName = new Dictionary<int, String>();
            dicOutputNameUnit = new Dictionary<int, String>();
            dicOutputNamePort = new Dictionary<int, String>();
        }
        ~MotionDevice()
        {
            if (_isInitialized)
            {
                FinalizeDevice();
            }
        }
        public virtual Boolean FinalizeDevice()
        {
            if (_isInitialized == false)
            {
                Debug.WriteLine("초기화 된 적이 없음");
                return true;
            }
            return false;
        }
        public virtual Boolean InitializeDevice()
        {
            dtInitialization = DateTime.Now;
            _isInitialized = true;
            return false;
        }
        public Boolean IsInitialized()
        {
            return _isInitialized;
        }
        public void SetBoardLength(int nIndex, int nBoardIndex, int nMotorLength, int nInLength, int nOutLength)
        {
            BoardMappingSetting bs;
            bs.nIndex = nIndex;
            bs.nBoardIndex = nBoardIndex;
            bs.nMotorLength = nMotorLength;
            bs.nInLength = nInLength;
            bs.nOutLength = nOutLength;
            defaultBoardMap[nIndex] = bs;

        }
        /// <summary>
        /// 보드 자체에서 넘어오는 Bit의 반전을 할 때 사용(일종의 Active Low, Active High 설정임)
        /// true if active low
        /// false if active high
        /// </summary>

        public Boolean InputReverseFlag
        {
            get;
            set;
        }

        public Boolean OutputReverseFlag
        {
            get;
            set;
        }


        public void SetBoardOptionLength(int nIndex, int nBoardIndex, int nOptionIndex, int nMotorLength, int nInLength, int nOutLength)
        {
            BoardMappingSetting bs;
            bs.nIndex = nIndex;
            bs.nBoardIndex = nBoardIndex;
            bs.nMotorLength = nMotorLength;
            bs.nInLength = nInLength;
            bs.nOutLength = nOutLength;
            if(!optionalBoardMap.ContainsKey(nIndex))
            {
                optionalBoardMap[nIndex] = new Dictionary<int, BoardMappingSetting>();
            }
            optionalBoardMap[nIndex][nBoardIndex] = bs; 
        } 
        public void SetMotorLength(int nMotorLength)
        {
            this.nMotorLength = nMotorLength;
            int i;
            for(i=0;i<nMotorLength;i++)
            {
                dicMotorItem[i] = new MotorItem("", this);
            }
        }
        public void SetInputLength(int nInputLength)
        {
            this.nInputLength = nInputLength;
            for (int i = 0; i < nInputLength; i++)
            {
                dicInputItem[i] = new InputItem("", this);
            }
        }
        public void SetOutputLength(int nOutputLength)
        {
            this.nOutputLength = nOutputLength;
            for (int i = 0; i < nOutputLength; i++)
            {
                dicOutputItem[i] = new OutputItem("", this);
            }
        }
        public int GetMotorLength()
        {
            return this.nMotorLength;
        }
        public int GetInputLength()
        {
            return this.nInputLength;
        }
        public int GetOutputLength()
        {
            return this.nOutputLength;
        }

        
        protected Dictionary<int, String> dicMotorName;
        protected Dictionary<int, String> dicInputName;
        protected Dictionary<int, String> dicInputNameUnit;
        protected Dictionary<int, String> dicInputNamePort;
        protected Dictionary<int, String> dicOutputName;
        protected Dictionary<int, String> dicOutputNameUnit;
        protected Dictionary<int, String> dicOutputNamePort;

        //////////////////////////////////////////////////////////////////////////
        /// 모터 및 io 이름
        //////////////////////////////////////////////////////////////////////////
        public void SetMotorNameAt(int axis, String name)
        {
            this.dicMotorName[axis] = name;
        }
        public String GetMotorNameAt(int axis)
        {
            if (dicMotorName.ContainsKey(axis))
            {
                return dicMotorName[axis];
            }
            return null;
        }
        public void SetInputNameAt(int port, String name)
        {
            this.dicInputName[port] = name;
        }
        public void SetInputNameAt(int port, String unit_name, String port_name)
        {
            this.dicInputName[port] = unit_name + "(" + port_name + ")";
            this.dicInputNameUnit[port] = unit_name;
            this.dicInputNamePort[port] = port_name;
        }
        public String GetInputNameAt(int port)
        {
            if (dicInputName.ContainsKey(port))
            {
                return dicInputName[port];
            }
            return null;
        }
        public String GetInputUnitNameAt(int port)
        {
            if (dicInputNameUnit.ContainsKey(port))
            {
                return dicInputNameUnit[port];
            }
            return null;
        }
        public String GetInputPortNameAt(int port)
        {
            if (dicInputNamePort.ContainsKey(port))
            {
                return dicInputNamePort[port];
            }
            return null;
        }
        public void SetOutputNameAt(int port, String name)
        {
            this.dicOutputName[port] = name;
        }
        public void SetOutputNameAt(int port, String unit_name, String port_name)
        {
            this.dicOutputName[port] = unit_name + "(" + port_name + ")";
            this.dicOutputNameUnit[port] = unit_name;
            this.dicOutputNamePort[port] = port_name;
        }
        public String GetOutputNameAt(int port)
        {
            if (dicOutputName.ContainsKey(port))
            {
                return dicOutputName[port];
            }
            return null;
        }

        public String GetOutputUnitNameAt(int port)
        {
            if (dicOutputNameUnit.ContainsKey(port))
            {
                return dicOutputNameUnit[port];
            }
            return null;
        }
        public String GetOutputPortNameAt(int port)
        {
            if (dicOutputNamePort.ContainsKey(port))
            {
                return dicOutputNamePort[port];
            }
            return null;
        }

        protected Dictionary<int, MotorItem> dicMotorItem = new Dictionary<int, MotorItem>();
        protected Dictionary<int, InputItem> dicInputItem = new Dictionary<int, InputItem>();
        protected Dictionary<int, OutputItem> dicOutputItem = new Dictionary<int, OutputItem>();

        public MotorItem GetMotorItemAt(int index)
        {
            if (dicMotorItem.ContainsKey(index)) return dicMotorItem[index];
            return null;
        }
        public InputItem GetInputItemAt(int index)
        {
            if (dicInputItem.ContainsKey(index)) return dicInputItem[index];
            return null;
        }
        public OutputItem GetOutputItemAt(int index)
        {
            if (dicOutputItem.ContainsKey(index)) return dicOutputItem[index];
            return null;
        }

        [Obsolete("Motor Setting으로 바뀜")]
        protected Dictionary<int, KeyValuePair<DateTime, double>> dicLastPosition = new Dictionary<int, KeyValuePair<DateTime, double>>();
        [Obsolete("Motor Setting으로 바뀜")]
        protected Dictionary<int, KeyValuePair<DateTime, double>> dicLastCommand = new Dictionary<int, KeyValuePair<DateTime, double>>();
        [Obsolete("Motor Setting으로 바뀜")]
        protected Dictionary<int, KeyValuePair<DateTime, double>> dicLastPositionInPulse = new Dictionary<int, KeyValuePair<DateTime, double>>();
        [Obsolete("Motor Setting으로 바뀜")]
        protected Dictionary<int, KeyValuePair<DateTime, double>> dicLastCommandInPulse = new Dictionary<int, KeyValuePair<DateTime, double>>();
        [Obsolete("Motor Setting으로 바뀜")]
        protected Dictionary<int, KeyValuePair<DateTime, Boolean>> dicLastLimitM = new Dictionary<int, KeyValuePair<DateTime, Boolean>>();
        [Obsolete("Motor Setting으로 바뀜")]
        protected Dictionary<int, KeyValuePair<DateTime, Boolean>> dicLastLimitP = new Dictionary<int, KeyValuePair<DateTime, Boolean>>();
        [Obsolete("Motor Setting으로 바뀜")]
        protected Dictionary<int, KeyValuePair<DateTime, Boolean>> dicLastHomeM = new Dictionary<int, KeyValuePair<DateTime, Boolean>>();
        [Obsolete("Motor Setting으로 바뀜")]
        protected Dictionary<int, KeyValuePair<DateTime, Boolean>> dicLastHomeP = new Dictionary<int, KeyValuePair<DateTime, Boolean>>();
        [Obsolete("Motor Setting으로 바뀜")]
        protected Dictionary<int, KeyValuePair<DateTime, Boolean>> dicLastEnabled = new Dictionary<int, KeyValuePair<DateTime, Boolean>>();
        [Obsolete("Motor Setting으로 바뀜")]
        protected Dictionary<int, KeyValuePair<DateTime, Boolean>> dicLastMoving = new Dictionary<int, KeyValuePair<DateTime, Boolean>>();
        [Obsolete("Motor Setting으로 바뀜")]
        protected Dictionary<int, KeyValuePair<DateTime, Boolean>> dicLastHasAlarm = new Dictionary<int, KeyValuePair<DateTime, Boolean>>();
        /////////////////////////////////////////////////////////////////////
        /// 모터 제어
        /////////////////////////////////////////////////////////////////////
        public abstract void Reset();
        public abstract void PowerOn();
        public abstract void PowerOff();

        //get
        public abstract Double GetPosition(int axis); // 실제 물리량
        public abstract Double GetCommand(int axis); // 실제 물리량
        public abstract Double GetPositionInPulse(int axis); // 펄스 단위
        public abstract Double GetCommandInPulse(int axis); // 펄스 단위
        public abstract bool IsLimitM(int axis);
        public abstract bool IsLimitP(int axis);
        public abstract bool IsHomeM(int axis);
        public abstract bool IsHomeP(int axis);
        public abstract bool IsEnabled(int axis);
        public abstract bool IsMoving(int axis);
        protected void TeachLastPosition(int axis, double position)
        {
            dicLastPosition[axis] = new KeyValuePair<DateTime, double>(DateTime.Now, position);
        }
        protected void TeachLastCommand(int axis, double command)
        {
            dicLastCommand[axis] = new KeyValuePair<DateTime, double>(DateTime.Now, command);
            dicMotorItem[axis].BindingMotorItemStatus.Command = command;
        }
        protected void TeachLastPositionInPulse(int axis, double position)
        {
            dicLastPositionInPulse[axis] = new KeyValuePair<DateTime, double>(DateTime.Now, position);
            dicMotorItem[axis].BindingMotorItemStatus.PositionInPulse = position;
        }
        protected void TeachLastCommandInPulse(int axis, double command)
        {
            dicLastCommandInPulse[axis] = new KeyValuePair<DateTime, double>(DateTime.Now, command);
            dicMotorItem[axis].BindingMotorItemStatus.CommandInPulse = command;
        }
        protected void TeachLastLimitM(int axis, Boolean value)
        {
            dicLastLimitM[axis] = new KeyValuePair<DateTime, Boolean>(DateTime.Now, value);
            dicMotorItem[axis].BindingMotorItemStatus.IsLimitM = value;
        }
        protected void TeachLastLimitP(int axis, Boolean value)
        {
            dicLastLimitP[axis] = new KeyValuePair<DateTime, Boolean>(DateTime.Now, value);
            dicMotorItem[axis].BindingMotorItemStatus.IsLimitP = value;
        }
        protected void TeachLastHomeM(int axis, Boolean value)
        {
            dicLastHomeM[axis] = new KeyValuePair<DateTime, Boolean>(DateTime.Now, value);
            dicMotorItem[axis].BindingMotorItemStatus.IsHomeM= value;
        }
        protected void TeachLastHomeP(int axis, Boolean value)
        {
            dicLastHomeP[axis] = new KeyValuePair<DateTime, Boolean>(DateTime.Now, value);
            dicMotorItem[axis].BindingMotorItemStatus.IsHomeP = value;
        }
        protected void TeachLastIsEnabled(int axis, Boolean value)
        {
            dicLastEnabled[axis] = new KeyValuePair<DateTime, Boolean>(DateTime.Now, value);
            dicMotorItem[axis].BindingMotorItemStatus.Enabled = value;
        }
        protected void TeachLastIsMoving(int axis, Boolean value)
        {
            dicLastMoving[axis] = new KeyValuePair<DateTime, Boolean>(DateTime.Now, value);
            dicMotorItem[axis].BindingMotorItemStatus.IsMoving = value;
        }
        protected void TeachLastHasAlarm(int axis, Boolean value)
        {
            dicLastHasAlarm[axis] = new KeyValuePair<DateTime, Boolean>(DateTime.Now, value);
            dicMotorItem[axis].BindingMotorItemStatus.HasAlarm = value;
        }

        /// <summary>
        /// Motion System의 Output에서 IsOn의 최종 결과를 저장시킨다.
        /// </summary>
        /// <param name="port"></param>
        /// <param name="value"></param>
        protected void TeachLastIsOn(int port, Boolean value)
        {
            dicOutputItem[port].BindingOutputItemStatus.IsOn = value;
        }

        /// <summary>
        /// Motion System의 Input에서 Read 값의 최종 결과를 저장시킨다.
        /// </summary>
        /// <param name="port"></param>
        /// <param name="value"></param>
        protected void TeachLastRead(int port, Boolean value)
        {
            dicInputItem[port].BindingInputItemStatus.Read = value;
        }
        public abstract Double GetPositionError(int axis);

        public abstract void MoveCont(int axis, MoveOption option, MoveOptionData option_data);
        public abstract void SetCommand(int axis, Double pos);
        public abstract void Stop(int axis);

        public abstract void Move(int axis, Double pos, MoveOption option, MoveOptionData option_data);

        public abstract void MoveRelatively(int axis, Double distance, MoveOption option, MoveOptionData option_data);
        public void MoveR(int axis, Double distance, MoveOption option, MoveOptionData option_data)
        {
            MoveRelatively(axis, distance, option, option_data);
        }

        public virtual Boolean HasMotorAt(int axis)
        {
            return true;
        }
        public abstract void SetPosition(int axis, Double pos);

        public abstract void Enable(int axis);
        public abstract void Disable(int axis);
        public abstract void SetDefaultAccDec(int axis, Double defAccDec);
        public abstract Double GetDefaultAccDec(int axis);
        public abstract void SetMaxVelocity(int axis, Double maxVelocity);
        public abstract Double GetMaxVelocity(int axis);
        public abstract void SetSoftResolution(int axis, Double motorResolution);
        public abstract Double GetSoftResolution(int axis);
        public abstract void SetAcc(int axis, Double data);
        public abstract Double GetAcc(int axis);
        public abstract void setDec(int axis, Double data);
        public abstract Double getDec(int axis);
        public abstract Boolean HasAlarm(int axis);
        public abstract void SetMotorSort(int axis, int motorsort);
        public abstract void setAcac(int axis, Double data);
        public abstract void setInitialSpeed(int axis, Double startV);
        public abstract void ResetAlarm(int axis);
        public abstract void MoveUnitPulse(int axis, Double speed, int direction);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis1"></param>
        /// <param name="axis2"></param>
        /// <param name="speed"></param>
        /// <param name="distance1"></param>
        /// <param name="distance2"></param>
        /// <param name="_set_group">group 설정 여부 확인. true면 같은 그룹인지 확인하고 아니면 예외처리</param>
        public abstract void MoveTwoInterpolation(int axis1, int axis2, Double distance1, Double distance2, MoveOptionData option_data, Boolean _set_group = false);
        public abstract void MoveRTwoInterpolation(int axis1, int axis2, Double position1, Double position2, MoveOptionData option_data, Boolean _set_group = false);

        public abstract void MoveThreeInterpolation(int axis1, int axis2, int axis3, Double distance1, Double distance2, Double distance3, MoveOptionData option_data, Boolean _set_group = false);
        public abstract void MoveRThreeInterpolation(int axis1, int axis2, int axis3, Double position1, Double position2, Double distance3, MoveOptionData option_data, Boolean _set_group = false);


        public abstract void MoveFourInterpolation(int axis1, int axis2, int axis3, int axis4, Double distance1, Double distance2, Double distance3, Double distance4, MoveOptionData option_data, Boolean _set_group = false);
        public abstract void MoveRFourInterpolation(int axis1, int axis2, int axis3, int axis4, Double position1, Double position2, Double distance3, Double distance4, MoveOptionData option_data, Boolean _set_group = false);

        public abstract void SetSearchOffset(int axis, int pos);
        public abstract void AutoHomeSearchZPhase(int axis, double pos_init, double velocity, double acc);
        public abstract void AutoHomeSearchSensor(int axis, double pos_init, double velocity, double acc, MotorSensorType type);
        public abstract void AutoHomeSearchAbsEncoder(int axis, double pos_init, double velocity, double acc);

        protected Dictionary<int, int> dicAxisGroupMapping = new Dictionary<int, int>();
        public virtual void SetMotorGroup(int axis, int group_no)
        {
            dicAxisGroupMapping[axis] = group_no;
        }
        public virtual void UnsetMotorGroup(int axis)
        {
            if (dicAxisGroupMapping.ContainsKey(axis))
            {
                dicAxisGroupMapping.Remove(axis);
            }
        }
        public virtual Boolean IsInMotorGroup(int axis)
        {
            return dicAxisGroupMapping.ContainsKey(axis);
        }
        public virtual int GetMotorGroup(int axis)
        {
            if (!IsInMotorGroup(axis)) throw new InvalidOperationException("모터가 그룹에 속해있지 않습니다.");
            return dicAxisGroupMapping[axis];
        }

        /////////////////////////////////////////////////////////////////////
        /// IO 제어 관련
        /////////////////////////////////////////////////////////////////////
        public abstract void On(int port);
        public abstract void On(int mapped_port, Boolean _is_option_board = false, int board_index = 0);
        
        public abstract void Off(int no);
        public abstract void Off(int mapped_port, Boolean _is_option_board = false, int board_index = 0);
        
        public abstract bool IsOn(int no);
        public abstract bool IsOn(int mapped_port, Boolean _is_option_board = false, int board_index = 0);

        public abstract bool Read(int no);
        public abstract bool Read(int mapped_port, Boolean _is_option_board = false, int board_index = 0);


    }
}
