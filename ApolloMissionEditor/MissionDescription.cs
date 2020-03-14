using ApolloCockpitTools;
using System;
using System.Collections.Generic;

namespace Apollo.Mission
{
    public class MissionDescription
    {
        public enum SpacePrograms { Mercury = 0, Gemini = 1, Apollo = 2 };
        public enum PayloadSelection { Ballast = 0, LunarModule = 1 };

        public SpacePrograms SpaceProgram { get; set; } = SpacePrograms.Apollo;
        public bool StartInOrbit = false;
        public DateTime ScheduledLaunchTime;
        public TimeSpan InitialTimeToRetrograde = TimeSpan.FromMinutes(120.0f);

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BriefingText { get; set; }
        public int FlightPlanPrefabId { get; set; }
        public float MinutesBeforeLaunch { get; set; }
        public float TargetAp { get; set; }
        public float TargetPe { get; set; }
        public float Inclination { get; set; }
        public string CommandModulePilot { get; set; }
        public string LunarModulePilot { get; set; }
        public bool DisableDefaultAudioSFX { get; set; }
        public string LoadState { get; set; }
        public float EarthRotationOffsetDegrees { get; set; }
        public PayloadSelection Payload { get; set; }

        public List<MissionCommand> MissionCommands = new List<MissionCommand>();
        public List<MissionGoals> MissionGoals = new List<MissionGoals>();
        public List<MissionActivity> MissionActivities = new List<MissionActivity>();
        internal bool Complete = false;

        public MissionDescription()
        {

        }

        public void AddCommand(MissionCommand mc)
        {
            MissionCommands.Add(mc);
        }
    }

    public class MissionActivity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public float TimeLimit { get; set; }
        public bool Started;
        public bool Completed;
        public bool Cancelled;

        public List<ActivityStep> Steps = new List<ActivityStep>();
    }

    public class ActivityStep
    {
        public enum StepGoal
        {
            WaitForSeconds_Value1
        };
        //public enum ACMEMode { HorizonScan, RateCMD, Direct, Pulse, RateCMDReEntry, ReEntry, Plat };
        //public enum PlatformMode { OFF, Cage1, SEF, OrbRate, BEF, Cage, Free };
        public StepGoal Goal { get; set; }
        public string Description { get; set; }
        //public ACMEMode FlightMode { get; set; }
        //public PlatformMode Platform { get; set; }
        public float Value1 { get; set; }
        public float Value2 { get; set; }
        public float Value3 { get; set; }
        public string Progress;
        public bool Completed;
    }

    public class MissionGoals
    {
        public enum GoalType { Splashdown, CompleteActivityWithIndex_Target1, LunarLanding }
        public GoalType Type { get; set; }
        public string Description { get; set; }
        public float Target1 { get; set; }
        public float Target2 { get; set; }
        public float Target3 { get; set; }
        public string String1 { get; set; }
        public string String2 { get; set; }
        public string Progress;
        public bool Completed;
    }

    public class MissionCommand
    {
        public enum MessageIsFrom { Commander, Pilot, MCC, LunarPilot };
        public enum Failiure { NULL }

        public enum ExecuteAction
        {
            i0000_Message = 0, // Deliver message only

            // 10 group. orbit checks
            i0010_IsAp_Value1 = 10,
            i0011_IsPe_Value1,
            i0012_IsAp_Value1_IsPe_Value2,
            i0013_IsInclination_Value1,
            i0014_WaitUntilCompletedNrOrbits,
            i0015_Orbit_TimeToPe_Value1,
            i0016_Orbit_TimeToAp_Value1,
            i0017_Orbit_TimeToRetro_Value1Seconds,
            i0018_TimeToSPSBurn_Value1Seconds,
            i0019_CheckIfApIs_Value1_YesString1_NoString2,
            i0020_GravityInfluencer_Earth,
            i0021_GravityInfluencer_Moon,

            // 50 group - radio checks
            i0050_IsAtRadioStation_String1 = 50,

            // 100 group - altitude and such
            i0100_AltitudeLess_Value1 = 100,
            i0101_AltitudeGreater_Value1,
            i0102_AtCoordinate_Value1_Value2,
            i0103_Altitude_Landing_Feet_LessThan_Value1,
            i0104_Longitude_Between_Value1_Value2,
            i0105_Latitude_Between_Value1_Value2,

            // 150 group - spacecraft specific
            i0150_Seperation_StageIC = 150,
            i0151_Seperation_StageII,
            i0152_Seperation_StageIVB,
            i0153_Seperation_StageSM,
            i0154_State_Dot05GDetected,
            i0155_State_InHiDragZone,
            i0156_State_OutsideHighDragZone,
            i0157_State_DrogueDeploy,
            i0158_State_MainDeploy,
            i0159_State_UmbillicalDisconnect,
            i0160_State_Splashdown,
            i0161_State_TowerJett,
            i0162_State_AscentComplete,
            i0163_State_CenterEngineCutoff,
            i0164_State_SPSBurning,
            i0165_State_SPSNotBurning,
            i0166_State_AnyEngineBurning,
            i0167_State_NoEnginesBurning,

            // 200 group
            i0200_CheckPin_PinID_PinPosition = 200,
            i0201_CheckKnobIdSelection_Value1,
            i0202_CheckTriggerButton,
            i0203_CheckFuse_FusePosition,
            i0204_CheckIfAGC_Program_Value1_IsRunning,

            // 300 group - LM
            i0300_LunarModule_CheckPin_PinID_PinPosition = 300,
            i0301_LunarModule_CheckFuse_FusePosition,
            i0302_LunarModule_CheckKnobIdSelection_Value1,
            i0303_LunarModule_CheckTriggerButton,
            i0304_LunarModule_CheckIfAGC_Program_Value1_IsRunning,
            i0305_LunarModule_SwitchedToLunarStayArea,
            i0306_LunarModule_LunarContact,
            i0307_LunarModule_DPSBurning_Bool1,
            i0308_LunarModule_APSBurning_Bool1,
            i0309_LunarModule_Velocity_Value1_GreaterOrLess_Bool1,
            i0310_LunarModule_DistanceToCSM_LessOrEqual_Value1_Feet,

            // 400 group - stats
            i0400_Velocity_GreaterThan_Value1_FPS = 400,
            i0401_Velocity_LessThan_Value1_FPS,

            // 500 group - auto set
            i0500_Set_PinID_to_PinPosition = 500,
            i0501_LunarModule_Set_LM_PinID_to_LM_PinPosition,

            // 750 group - PADs
            i0750_RequestTLI_PAD_LambdaValue1 = 750,

            // 1000 group
            i1000_ResetTimestamp = 1000,
            i1001_ActivityCompleted_Value1,
            i1002_StartFailiure,
            i1003_StopFailiure,
            i1004_CompleteMission,

            // 2000 group - CSM State
            // 3000 group - LM State
            i3012_LunarModule_Sequencer_IsComplete_P12Guidance = 3012,
            i3063_LunarModule_Sequencer_IsComplete_P63Guidance = 3063,
            i3064_LunarModule_Sequencer_IsComplete_P64Guidance = 3064,
            i3100_LunarModule_Sequencer_IsComplete_LunarDescent = 3100,
            i3101_LunarModule_Sequencer_IsComplete_LunarAscent,
            i3102_LunarModule_Sequencer_IsComplete_CSI,
            i3103_LunarModule_Sequencer_IsComplete_PC,
            i3104_LunarModule_Sequencer_IsComplete_CDH,
            i3105_LunarModule_Sequencer_IsComplete_TPI,
            i3106_LunarModule_Sequencer_IsComplete_TPM,
            i3107_LunarModule_Sequencer_IsComplete_TPF,
            i3108_LunarModule_Sequencer_IsComplete_DockedWithCSMAfterAscent
        }

        public ExecuteAction Action { get; set; }
        public float Timestamp { get; set; }
        public float DisplayTime { get; set; } = 5f;
        public MessageIsFrom From { get; set; } = MessageIsFrom.MCC;
        public string Message { get; set; }
        public float Value1 { get; set; }
        public float Value2 { get; set; }
        public float Value3 { get; set; }
        public string String1 { get; set; }
        public string String2 { get; set; }
        public string String3 { get; set; }
        public bool Bool1 { get; set; }
        public float ThresholdLimit { get; set; }
        public PinID PinID { get; set; }
        public PinPosition PinPosition { get; set; }
        public KnobID KnobID { get; set; }
        public TriggerButtonID ButtonId { get; set; }
        public FuseID FuseID { get; set; }
        public FusePosition FusePosition { get; set; }

        public LunarModule.CockpitTools.PinID LM_PinID { get; set; }
        public LunarModule.CockpitTools.PinPosition LM_PinPosition { get; set; }
        public LunarModule.CockpitTools.KnobID LM_KnobID { get; set; }
        public LunarModule.CockpitTools.TriggerButtonID LM_ButtonId { get; set; }
        public LunarModule.CockpitTools.FuseID LM_FuseID { get; set; }
        public LunarModule.CockpitTools.FusePosition LM_FusePosition { get; set; }

        public Failiure Fault { get; set; }
        public bool PlayAudioClip_String3 { get; set; }
        public bool Delivered;
        public bool Completed;
        public bool Priority;


        public MissionCommand()
        {

        }
    }
}