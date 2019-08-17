using System;
using System.Collections.Generic;
using Apollo;
using ApolloCockpitTools;

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
        public bool DisableDefaultAudioSFX { get; set; } = false;
        public string LoadState { get; set; } = "";

        public PayloadSelection Payload { get; set; } = PayloadSelection.LunarModule;

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
        public enum GoalType { Splashdown, CompleteActivityWithIndex_Target1 }
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
            Message = 0, // Deliver message only

            // 10 group. orbit checks
            IsAp_Value1 = 10,
            IsPe_Value1,
            IsAp_Value1_IsPe_Value2,
            IsInclination_Value1,
            WaitUntilCompletedNrOrbits,
            Orbit_TimeToPe_Value1,
            Orbit_TimeToAp_Value1,
            Orbit_TimeToRetro_Value1Seconds,
            TimeToSPSBurn_Value1Seconds,
            CheckIfApIs_Value1_YesString1_NoString2,

            // 50 group - radio checks
            IsAtRadioStation_String1 = 50,

            // 100 group - altitude and such
            AltitudeLess_Value1 = 100,
            AltitudeGreater_Value1,
            AtCoordinate_Value1_Value2,
            Altitude_Landing_Feet_LessThan_Value1,
            Longitude_Between_Value1_Value2,
            Latitude_Between_Value1_Value2,

            // 150 group - spacecraft specific
            Seperation_StageIC = 150,
            Seperation_StageII,
            Seperation_StageIVB,
            Seperation_StageSM,
            State_Dot05GDetected,
            State_InHiDragZone,
            State_OutsideHighDragZone,
            State_DrogueDeploy,
            State_MainDeploy,
            State_UmbillicalDisconnect,
            State_Splashdown,
            State_TowerJett,
            State_AscentComplete,
            State_CenterEngineCutoff,
            State_SPSBurning,
            State_SPSNotBurning,
            State_AnyEngineBurning,
            State_NoEnginesBurning,

            // 200 group
            CheckPin_PinID_PinPosition = 200,
            CheckKnobIdSelection_Value1,
            CheckTriggerButton,
            CheckFuse_FusePosition,
            CheckIfAGC_Program_Value1_IsRunning,

            // 300 group - LM
            LunarModule_CheckPin_PinID_PinPosition = 300,
            LunarModule_CheckFuse_FusePosition,
            LunarModule_CheckKnobIdSelection_Value1,
            LunarModule_CheckTriggerButton,
            LunarModule_CheckIfAGC_Program_Value1_IsRunning,
            LunarModule_SwitchedToLunarStayArea,
            LunarModule_LunarContact,

            // 400 group - stats
            Velocity_GreaterThan_Value1_FPS = 400,
            Velocity_LessThan_Value1_FPS,

            // 500 group
            Set_PinID_to_PinPosition = 500,
            Set_LM_PinID_to_LM_PinPosition,

            // 750 group - PADs
            RequestTLI_PAD_LambdaValue1 = 750,

            // 1000 group
            ResetTimestamp = 1000,
            ActivityCompleted_Value1,
            StartFailiure,
            StopFailiure,
            CompleteMission
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