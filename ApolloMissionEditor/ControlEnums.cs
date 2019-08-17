using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloCockpitTools
{
    public enum PinID
    {
        NULL, FC1MNA, FC2MNA, FC3MNA, FC1MNB, FC2MNB, FC3MNB, Inverter1MNA, Inverter2MNB, Inverter3MNAMNB, ACBus1Inv1, ACBus1Inv2, ACBus1Inv3, ACBus2Inv1, ACBus2Inv2, ACBus2Inv3,
        FC1Htr, FC2Htr, FC3Htr, FC1ReactantShutoff, FC2ReactantShutoff, FC3ReactantShutoff, FCReacsValves, CryoH2Htr1, CryoH2Htr2, CryoO2Htr1, CryoO2Htr2, CryoH2Fan1, CryoH2Fan2,
        CryoO2Fan1, CryoO2Fan2, FCRadiator1, FCRadiator2, FCRadiator3, FC1Purge, FC2Purge, FC3Purge, H2PurgeLineHtr, GnNOpticsPWR, GnNIMUPWR, PrplntDumpAuto, TwoEngOut, LVRates, TwrJett1, TwrJett2,
        LVSPSIndaPc, LVSPSIncSIISIV_GP1, CMCAtt, IMUCage, Guidance, SII_SIVBStage, EDS, GNLightACPWR, FDAIScale, FDAISelect, FDAISource, ATTSet, AutoRCSA1, AutoRCSA2, AutoRCSA3, AutoRCSA4,
        AutoRCSB1, AutoRCSB2, AutoRCSB3, AutoRCSB4, AutoRCSC1, AutoRCSC2, AutoRCSC3, AutoRCSC4, AutoRCSD1, AutoRCSD2, AutoRCSD3, AutoRCSD4, SigCondDriverBiasPWR1, SigCondDriverBiasPWR2,
        RCSCommand, RotCntlPWR_Normal1, RotCntlPWR_Normal2, RotCntlPWR_Direct1, RotCntlPWR_Direct2, TransCntlPWR, SCCont, EDSPower, SMRCSHe1A, SMRCSHe1B, SMRCSHe1C, SMRCSHe1D, SMRCSHe2A,
        SMRCSHe2B, SMRCSHe2C, SMRCSHe2D, SMRCSPrplnt1A, SMRCSPrplnt1B, SMRCSPrplnt1C, SMRCSPrplnt1D, SMRCSPrplnt2A, SMRCSPrplnt2B, SMRCSPrplnt2C, SMRCSPrplnt2D, CMPrplntT1, CMPrplntT2,
        SM_RCSIndSel, SM_RCS_Heater_A, SM_RCS_Heater_B, SM_RCS_Heater_C, SM_RCS_Heater_D, AttRate, AttDeadband, AttCycleLimiter, AttManualRoll, AttManualPitch, AttManualYaw, CMCMode,
        BMAGRoll, BMAGPitch, BMAGYaw, TVCPitch, TVCYaw, TVCGimbalMotorsPitch1, TVCGimbalMotorsPitch2, TVCGimbalMotorsYaw1, TVCGimbalMotorsYaw2, TVCGimbalDrivePitch, TVCGimbalDriveYaw,
        TVCServo1, TVCServo2, EventTimerP1_DirectionReset, EventTimerP1_StartStop, EventTimerP1_ModifyMin, EventTimerP1_ModifySec, SPSDirectOn, SPSdVThrustA, SPSdVThrustB, SPSHeVlv1, SPSHeVlv2,
        SPSPSIInd, SPSLineHtrs, SPSTest, SPSOxidFlow, SPSOxidPrimAux, SPSPUGMode, TM_Hrs, TM_Min, TM_Sec, SIVB_LMSep, EMSSetting, EMS_GTA, CM_SM_Sep1, CM_SM_Sep2, CW_Mode, CW_CSM_SM, CW_PWR, CW_LampTest,
        MSNTimerStart, RCSTransfer, CM_RCS_Press, RCSLogic, CM_RCS_Heaters, ELSLogic, ELSAuto, SeqLogic1, SeqLogic2, PyroArmA, PyroArmB, FloatBag1, FloatBag2, FloatBag3, CMRCSPrplntDump, CMRCSPrplntPurge,
        GlycolEvapTempInAuto, O2PressInd, CabinFan1, CabinFan2, SuitCircHeatExch, H2OAccumAuto, H2OAccumPWR, PotH2OHtr, GlycolEvapH2OFlow, H2OWaterQtyInd, SecCoolLoopEvap, SecCoolPumpAC,
        GycolEvapSteamPressAuto, GycolEvapSteamPressMod, CabinTempAuto, FuelCellPumpA, FuelCellPumpB, FuelCellPumpC, BatteryChargerAC, RadiatorFlowContPower, RadiatorFlowContSelector,
        RadiatorManSel, RadiatorHeaterPrimary, RadiatorHeaterSecondary, Radio1Mode, Radio1PadComm, Radio1SBand, Radio1Power, Radio1Intercom, Radio1VHF, Radio1AudioControl, Radio1Suit, Radio1VHFRange,
        Radio2Mode, Radio2PadComm, Radio2SBand, Radio2Power, Radio2Intercom, Radio2VHF, Radio2AudioControl, Radio2Suit, HighGainTrack, HighGainBeam, HighGainServoPwr, HighGainServoSel,
        SBandNormalXpndr, SBandNormalPwrAmplSel, SBandNormalPwrAmplStr, SBandNormalModeVoiceRelay, SBandNormalModePCMKey, SBandNormalModeRng, SBandAUXTapeDNVoiceBU, SBandAUXTVSCI, UpTlmDataDNVoicedBU, UpTlmCmd,
        SBandAntennaOmniABC, SBandAntennaOmniDHiG, SqA_VHFAmA, SqA_VHFAmB, SqA_RcvOnly, SqA_VHFBcn, SqA_VHFRanging, SqB_TapeRec_ANLG_LM, SqB_PlayMode, SqB_TapeSpool, SqB_PwrSCE, SqB_PwrPMP, SqB_PCMBitRate,
        DockingProbeExtend, DockingProbeRetractPrim, DockingProbeRetractSec, ExtLightRUNEVA, ExtLightRNDZ, TunnelLights, LMPower, UpTlm_IU, UpTlm_CM, LogicPower23, Dot05gAllowed, EMSRoll,
        SPSGauging, TelecomGroup1, TelecomGroup2, SuitCompressor1, SuitCompressor2, MainChuteRelease, NonEssBus, MainBusTieAC, MainBusTieBC, MNAUndervoltSensor, MNBUndervoltSensor,
        ORDEAL_FDAI1, ORDEAL_FDAI2, ORDEAL_Mode, ORDEAL_Lighting, ORDEAL_Slew, ORDEAL_Location, CSMLMSep1, CSMLMSep2, XLunarInject
    };
    public enum PinPosition { NULL, Left, Middle, Right, Up, Down };
    public enum FuseID
    {
        NULL, FC1Reacs, FC2Reacs, FC3Reacs, FC1BusCont, FC2BusCont, FC3BusCont, InvCtrl1, InvCtrl2, InvCtrl3, CryoH2Htr1, CryoH2Htr2, CryoO2Htr1, CryoO2Htr2,
        CryoFan10A, CryoFan10B, CryoFan10C, CryoFan20A, CryoFan20B, CryoFan20C, O2VACIONPumpMNA, O2VACIONPumpMNB, FC1Radiator, FC2Radiator, FC3Radiator, FC1Purge, FC2Purge, FC3Purge,
        CMCMNA, CMCMNB, IMUMNA, IMUMNB, OSSMNA, OSSMNB, GnNPWRAC1, GnNPWRAC2, SCSAC1, SCSAC2, Controller1DirectMNA, Controller1DirectMNB, Controller2DirectMNA, Controller2DirectMNB,
        ACRollMNA, ACRollMNB, BDRollMNA, BDRollMNB, PitchMNA, PitchMNB, YawMNA, YawMNB, RCSLogicMNA, RCSLogicMNB, PrplntIsolMNA, PrplntIsolMNB, ControllerAutoMNA, ControllerAutoMNB,
        QuadAHeaters, QuadBHeaters, QuadCHeaters, QuadDHeaters, SPSHeVlvMNA, SPSHeVlvMNB, SPSPilotVlvMNA, SPSPilotVlvMNB, DirectUllageMNA, DirectUllageMNB, TVCAC1, TVCAC2,
        CMHtr1, CMHtr2, SeqLogic1, SeqLogic2, PyroArmA, PyroArmB, FloatBag1, FloatBag2, FloatBag3, ELSBatA, ELSBatB, CabinFan1A, CabinFan1B, CabinFan1C, CabinFan2A, CabinFan2B, CabinFan2C,
        SecCoolLoopAC1, SecCoolLoopAC2, WasteH2OUrineDumpMNA, WasteH2OUrineHtrMNB, XducerSecCoolLoopMNA, XducerSecCoolLoopMNB, WastePotH2OMNA, WastePotH2OMNB, XducerPressGroup1MNA, XducerPressGroup1MNB,
        XducerPressGroup2MNA, XducerPressGroup2MNB, XducerTempMNA, XducerTempMNB, PotWaterHtrMNA, PotWaterHtrMNB, WaterAccumulatorMNA, WaterAccumulatorMNB, EPSSensorDCMNA, EPSSensorDCMNB,
        EPSSensorAC1, EPSSensorAC2, CnWSDCMNA, CnWSDCMNB, EPSSensorUnitDCMNA, EPSSensorUnitDCMNB, EPSSensorUnitAC1, EPSSensorUnitAC2, BatteryRelayBus_BatA, BatteryRelayBus_BatB,
        BatteryChargerMainAC, BatteryChargerMNA, BatteryChargerMNB, BatteryChargeA, BatteryChargeB, RadiatorControllerAC1, RadiatorControllerAC2, RadiatorControllerHtrMNA, RadiatorControllerHtrMNB,
        RadiatorHtrsOvldBatA, RadiatorHtrsOvldBatB, SCSSystemMNA, SCSSystemMNB, SCSLogic12MNA, SCSLogic12MNB, SCSLogic34MNA, SCSLogic34MNB, EMSMNA, EMSMNB, DockProbeMNA, DockProbeMNB,
        MainABatBusA, MainABatC, MainBBatC, MainBBatBusB, FlgtPstLndBatBusA, FlgtPstLndBatBusB, FlgtPstLndBatC, FlgtPstLndMainA, FlgtPstLndMainB, InvPwr1MainA, InvPwr2MainB, InvPwr3MainA, InvPwr3MainB,
        PyroA_BatBusAToPyroBusTie, PyroA_SeqA, PyroB_BatBusBToPyroBusTie, PyroB_SeqB, BatAPwrEntPstLnd, BatBPwrEntPstLnd, BatCPwrEntPstLnd, BatCToBatBusA, BatCToBatBusB, BatCBatChargerEDS2,
        InstPwrCntrlCB1, InstPwrCntrlCB2, InstPwrCntrlCB3, InstPwrCntrlCB4, UprightSystem1, UprightSystem2, SIVLMSepPyroA, SIVLMSepPyroB, PrimaryGlycolToRadiators, PLVentFLTPL,
        EDSBatA, EDSBatB, EDSBatC, ORDEALAC2, ORDEALMNB, LM_PWR_1_MNA, LM_PWR_2_MNB
    };
    public enum FusePosition
    {
        NULL, Open, Closed
    }
    public enum KnobID
    {
        NULL, FCTestSelector, DCIndicatorSelector, ACIndicatorSelector, FDAIPowerSelector, SCSElectronicsPWR, RCSIndicatorSelector, IntegralLeft, IntegralCenter, IntegralRight,
        FloodLeft, FloodInside, FloodRight, BMAGPWR1, BMAGPWR2, EMSSelector, PrimaryRCSGlycolPumps, ChargeBatterySelector, ECSIndicatorSelector, HighGainPitch, HighGainYaw,
        WheelSqA, WheelSqB, WheelCabinTemp, SPSGimbalTrimPitch, SPSGimbalTrimYaw, VHFAntennaSelector, LM_CM_PSI_DiffSelector, CM_LM_DoorHatch
    };

    public enum TriggerButtonID
    {
        NULL, AGCVerb, AGCNoun, AGCPluss, AGCMinus, AGC0, AGC1, AGC2, AGC3, AGC4, AGC5, AGC6, AGC7, AGC8, AGC9, AGCClear, AGCPro, AGCKeyRel, AGCEntr, AGCRset,
        Liftoff, NoAutoAbort, LESMotorFire, CanardDeploy, CSMLVSep, APEXCoverJett, DrogueDeploy, MainDeploy, CMRCSHeDump, GDCAlign, SPSDirectUllage, SPSThrustOn,
        EMS_Increase, EMS_Decrease, EMS_IncreaseFast, EMS_DecreaseFast, MasterCaution, Abort
    };
}

namespace LunarModule.CockpitTools
{
    public enum PinID
    {
        NULL, P14_EDVolts, P14_Inverter, P14_DescentBat1LMPHiV, P14_DescentBat1LMPLoV, P14_DescentBat2LMP, P14_DescentBat3CDR, P14_DescentBat4CDRHiV, P14_DescentBat4CDRLoV, P14_DescentBatLunarCDR, P14_DescentBatLunarLMP,
        P14_DesBayDeadface, P14_AscentBat5NormalLMPFeed, P14_AscentBat5BackupCDRFeed, P14_AscentBat6NormalCDRFeed, P14_AscentBat6BackupLMPFeed, P14_UplinkSquelch,
        P02_SysA_ASCFeed1, P02_SysA_ASCFeed2, P02_SysA_Q1, P02_SysA_Q2, P02_SysA_Q3, P02_SysA_Q4, P02_SysB_ASCFeed1, P02_SysB_ASCFeed2, P02_SysB_Q1, P02_SysB_Q2, P02_SysB_Q3, P02_SysB_Q4, P02_Crossfeed, P02_MainSOV_SysA, P02_MainSOV_SysB, P02_ACAProp,
        P03_RCS_Heaters_Q1, P03_RCS_Heaters_Q2, P03_RCS_Heaters_Q3, P03_RCS_Heaters_Q4,
        P01_AttTransFourTwoJetMode, P08_DesPropulsion_FuelVent, P08_DesPropulsion_OxidVent, P08_DesPrplnt_IsolVlv, P08_MasterArm, P08_DesVent, P08_ASCHeSel,
        P08_LandingGearDeploy, P08_HePRESS_RCS, P08_HePRESS_DesStart, P08_HePRESS_Ascent, P08_Stage, P08_StageRelay,
        P01_PrplntQtyMon, P01_PrplntTempMon, P01_AscentHeReg1, P01_AscentHeReg2, P01_DescentHeReg1, P01_DescentHeReg2, P03_DesEngCmdOvrd, P03_EngGmbl, P01_EngineThrustCont_ThrCont_ThrCont, P01_EngineThrustCont_ManThrot, P01_EngineThrustCont_EngArm, P01_EngineThrustCont_BalCpl,
        P03_DeadBand, P03_GyroTest_Attitude, P03_GyroTest_Rate, P03_AttitudeControl_Roll, P03_AttitudeControl_Pitch, P03_AttitudeControl_Yaw, P03_ModeControl_PGNS, P03_ModeControl_AGS, P03_IMUCage,
        P01_GuidCont, P01_ModeSel, P01_RngAltMon, P01_RateErrMon, P01_AltitudeMon, P01_RateScale, P01_ACAProp, P01_ShfTrun, P02_RateErrMon, P02_AltitudeMon,
        P03_LandingAnt, P03_RadarTest, P03_SlewRate, P03_Slew, P03_EventTimer_CountDir_Reset, P03_EventTimer_TimerCount, P03_EventTimer_SlewCountMin, P03_EventTimer_SlewCountSec, P03_SidePanels, P03_Lighting_Flood_OvhdFwd, P03_Lighting_Exterior, P03_XPointerScale,
        P08_Audio_Replay, P08_Coas, P08_Audio_SBand, P08_Audio_ICS, P08_Audio_VHFA, P08_Audio_VHFB, P08_Audio_CommMode, P08_Audio_AudioCont,
        P12_Audio_Replay, P12_Audio_SBand, P12_Audio_ICS, P12_Audio_AudioCont, P12_Audio_CommMode, P12_Audio_VHFA, P12_Audio_VHFB, P12_Audio_UpdataLink,
        P12_Comm_Modulate, P12_Comm_XmitRcvr, P12_Comm_PwrAmpl, P12_Comm_FuncVoice, P12_Comm_FuncPCM, P12_Comm_Range, P12_Comm_VHF_A_Xmtr, P12_Comm_VHF_A_Rcvr, P12_Comm_VHF_B_Xmtr, P12_Comm_VHF_B_Rcvr, P12_Comm_TelemetryBiomed, P12_Comm_TelemetryPCM, P12_Comm_TrackMode, P12_Comm_Recorder,
        P06_AGS_Status, P04_CDR_ACA, P04_CDR_TTCA, P04_LMP_ACA, P04_LMP_TTCA,
        P05_MissionTimer_TimerCont, P05_MissionTimer_Hours, P05_MissionTimer_Min, P05_MissionTimer_Sec,
        P05_Lighting_Sidepanels, P05_Lighting_Integral, P05_Lighting_Num, P05_Lighting_Anun, P05_DesRate, P01_XPointerScale,
        ORDEAL_FDAI1, ORDEAL_FDAI2, ORDEAL_Mode, ORDEAL_Lighting, ORDEAL_Slew, ORDEAL_Location

    };
    public enum PinPosition { NULL, Left, Middle, Right, Up, Down };

    public enum FuseID
    {
        NULL, P16_BatFeedTieA, P16_BatFeedTieB, P16_CrossTieBalLoad, P16_CrossTieBus, P16_XLunarBusTie, P16_DesECACont, P16_DesECA, P16_AscECACont, P16_AscECA, P16_Inv2, P16_DCBusVolt, P16_Disp,
        P11_ACBusBBusTieInv1, P11_ACBusBBusTieInv2, P11_ACBusABusTieInv1, P11_ACBusABusTieInv2, P11_ACBusAACBusVolt,
        P11_BatFeedTieA, P11_BatFeedTieB, P11_CrossTieBalLoad, P11_CrossTieBus, P11_XLunarBusTie, P11_DesECACont, P11_DesECA, P11_AscECACont, P11_AscECA, P11_Inv1, P11_DCBusVolt,
        P16_Heaters_RCSAB2_Q1, P16_Heaters_RCSAB2_Q2, P16_Heaters_RCSAB2_Q3, P16_Heaters_RCSAB2_Q4, P16_Camr_Seq, P16_Heaters_SBandAnt, P16_Heaters_Disp,
        P16_Propul_ASCHe_Reg, P16_Propul_PQGS, P16_Propul_Disp, P16_RCSSysB_MainSov, P16_RCSSysB_PQGSDisp, P16_RCSSysB_TempPressDispFlags, P16_RCSSysB_Crossfeed,
        P16_RCSSysB_Q4, P16_RCSSysB_Q3, P16_RCSSysB_Q2, P16_RCSSysB_Q1, P16_RCSSysB_IsolVlv, P16_RCSSysB_ASCFeed2, P16_RCSSysB_ASCFeed1,
        P16_FltDisp_LMP_XPntr, P16_FltDisp_LMPFDAI, P16_LTG_Flood, P16_LTG_Track, P16_LTG_AnunDockCompnt, P16_LTG_MasterAlarm, P16_ED_LogicPwrB,
        P16_StabCont_AEA, P16_StabCont_EngArm, P16_StabCont_ASA, P16_StabCont_AELD, P16_StabCont_ATCA, P16_StabCont_AbortStage, P16_StabCont_ATCA_AGS, P16_StabCont_DesEngOvrd,
        P16_Inst_CWEA, P16_Inst_SigSensor, P16_Inst_PCMTE, P16_Inst_SigCondr2, P16_ECS_SuitFlowCont, P16_ECS_CO2_Sensor, P16_ECS_DivertVlv, P16_ECS_CabinRepress, P16_ECS_CabinFanCont,
        P16_ECS_LCGPump, P16_ECS_GlycolPumpSec, P16_ECS_Disp, P16_SuitFan_dP, P16_ECS_SuitFan2,
        P16_Comm_TV, P16_Comm_PMP, P16_Comm_SBandAnt, P16_Comm_PrimSBand_XMTR_RCVR, P16_Comm_PrimSBand_PWPAmppl, P16_Comm_VHFB_RCVR, P16_Comm_VHFA_XMTR, P16_Comm_LMP_Audio, P16_Comm_Disp,
        P11_ACBusB_LMPWindHtr, P11_ACBusB_HePQGS_PropDisp, P11_ACBusB_SBandAnt, P11_ACBusB_Ordeal, P11_ACBusB_AGS, P11_ACBusB_LMPFDAI, P11_ACBusB_NumLtg, P11_ACBusB_AOTLMP,
        P11_ACBusA_CDRWindHtr, P11_ACBusA_TapeRcdr, P11_ACBusA_AOTLAMP, P11_ACBusA_RNDZRdr, P11_ACBusA_DecaGmbl, P11_ACBusA_IntglLtg, P11_ACBusA_CDRFDAI, P11_ACBusA_GASTA, P11_ACBusA_RngRtAltRt,
        P11_FlightDisplays_Ordeal, P11_FlightDisplays_COAS, P11_FlightDisplays_CDRFDAI, P11_FlightDisplays_GASTA, P11_FlightDisplays_RngRtAltRt, P11_FlightDisplays_CNDRXPntr,
        P11_FlightDisplays_MissionTimer, P11_FlightDisplays_Thrust,
        P11_RCSSysA_ASCFeed1, P11_RCSSysA_ASCFeed2, P11_RCSSysA_ISOLVlv, P11_RCSSysA_Q1TCA, P11_RCSSysA_Q2TCA, P11_RCSSysA_Q3TCA, P11_RCSSysA_Q4TCA, P11_RCSSysA_MainSov,
        P11_Prop_DESHeRegVent, P11_Heaters_RndzRdr_STB, P11_Heaters_RndzRdrOpr, P11_Heaters_LdgRdr, P11_Heaters_DockWindow, P11_Heaters_AOT, P11_Inst_SigCondr1,
        P11_StabCont_AEA, P11_StabCont_AbortStage, P11_StabCont_ATCA_PGNS, P11_StabCont_AELD, P11_StabCont_EngCont, P11_StabCont_AttDirCont, P11_StabCont_EngStartOvrd,
        P11_StabCont_DecaPWR, P11_ED_LdgGearFlag, P11_ED_LogicPWRA, P11_LTG_Util, P11_LTG_AnunDockCompnt,
        P11_PGNS_IMU_OPR, P11_PGNS_IMU_STBY, P11_PGNS_LGC_DSKY, P11_PGNS_RndzRdr, P11_PGNS_LdgRdr, P11_PGNS_SigStrDisp, P11_COMM_CDRAudio, P11_COMM_VHFARcvr, P11_COMM_VHFBXMTR,
        P11_COMM_SecSBand_PWRAmpl, P11_COMM_SecSBand_XMTR_RCVR, P11_COMM_UpDataLink,
        P11_ECS_GlycolPump_AutoTrnsfr, P11_ECS_GlycolPump_1, P11_ECS_GlycolPump_2, P11_ECS_CabinFan1, P11_ECS_SuitFan1, P11_Heaters_Q1, P11_Heaters_Q2, P11_Heaters_Q3, P11_Heaters_Q4
    };
    public enum FusePosition
    {
        NULL, Open, Closed
    }
    public enum GaugeID
    {
        NULL, P14_Volts, P14_Amps, P02_RCSSysQty_A, P02_RCSSysQty_B, P02_RCSPress_A, P02_RCSPress_B, P02_RCSTemp_A, P02_RCSTemp_B, P03_TempMonitor,
        P01_MainProp_Thrust_Eng, P01_MainProp_Thrust_Cmd, P01_MainProp_Temp_Fuel, P01_MainProp_Temp_Oxid, P01_MainProp_Press_Fuel, P01_MainProp_Press_Oxid,
        P02_PartPressCO2, P02_ECS_Press_Cabin, P02_ECS_Press_Suit, P02_ECS_Temp_Cabin, P02_ECS_Temp_Suit, P02_Qty_H2O, P02_Qty_O2, P02_Glycol_PSIA, P02_Glycol_F, P03_RadarStrength,
        P12_PitchDegs, P12_YawDegs, P12_SignalStrength
    };
    public enum KnobID
    {
        NULL, P14_EPSPowerTempMon, P02_TempPressMon, P03_TempMonitor, P01_HeliumMon, P03_TestMonitor, P03_RndzRadar_Tracker, P03_LampToneTest, P03_FloodLightDimmer,
        P02_Glycol, P02_SuitFan, P02_O2_H2O_Qty_Mon, P05_FloodOvhdFwd, P05_AnunNum, P05_Integral, P12_Pitch, P12_Yaw, P12_SBand, P12_VHF,
        ECS_CabinRepress, ECS_PLSS_Fill, ECS_PressRegA, ECS_PressRegB, ECS_O2_Des, ECS_O2_Asc1, ECS_O2_Asc2, ECS_SuitIslo_CDR, ECS_SuitIsol_LMP, ECS_SecEvapFlow, ECS_PriEvapFlowNo2, ECS_DesH2O, ECS_PriEvapFlowNo1, ECS_SuitTemp, ECS_ASC_H2O,
        ECS_LiquidGarmentCooling, ECS_SuitCircuitRelief, ECS_CabinGasReturn, ECS_WaterTankSelector, TTCAThrottleJets
    };
    public enum TriggerButtonID
    {
        NULL, AGSButton1, P05_StartEngine, P06_StopEngine, P05_StopEngine, P01_MasterAlarm, P02_MasterAlarm,
        LGCVerb, LGCNoun, LGCPlus, LGCNeg, LGC0, LGC1, LGC2, LGC3, LGC4, LGC5, LGC6, LGC7, LGC8, LGC9, LGCClr, LGCPro, LGCKeyRel, LGCEntr, LGCRset,
        P05_Transl, P01_Abort, P01_AbortStage, AGSButton0, AGSButton2, AGSButton3, AGSButton4, AGSButton5, AGSButton6, AGSButton7, AGSButton8, AGSButton9, AGSButtonHold, AGSButtonCLR, AGSButtonReadOut, AGSButtonEntr, AGSButtonPos, AGSButtonNeg
    };
}