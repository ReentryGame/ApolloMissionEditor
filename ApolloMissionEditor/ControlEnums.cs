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
        InstPwrCntrlCB1, InstPwrCntrlCB2, InstPwrCntrlCB3, InstPwrCntrlCB4, UprightSystem1, UprightSystem2, SIVLMSepPyroA, SIVLMSepPyroB
    };
    public enum FusePosition
    {
        NULL, Open, Closed
    }
    public enum KnobID
    {
        NULL, FCTestSelector, DCIndicatorSelector, ACIndicatorSelector, FDAIPowerSelector, SCSElectronicsPWR, RCSIndicatorSelector, IntegralLeft, IntegralCenter, IntegralRight,
        FloodLeft, FloodInside, FloodRight, BMAGPWR1, BMAGPWR2, EMSSelector, PrimaryRCSGlycolPumps, ChargeBatterySelector, ECSIndicatorSelector, HighGainPitch, HighGainYaw,
        WheelSqA, WheelSqB, WheelCabinTemp, SPSGimbalTrimPitch, SPSGimbalTrimYaw, VHFAntennaSelector
    };

    public enum TriggerButtonID
    {
        NULL, AGCVerb, AGCNoun, AGCPluss, AGCMinus, AGC0, AGC1, AGC2, AGC3, AGC4, AGC5, AGC6, AGC7, AGC8, AGC9, AGCClear, AGCPro, AGCKeyRel, AGCEntr, AGCRset,
        Liftoff, NoAutoAbort, LESMotorFire, CanardDeploy, CSMLVSep, APEXCoverJett, DrogueDeploy, MainDeploy, CMRCSHeDump, GDCAlign, SPSDirectUllage, SPSThrustOn,
        EMS_Increase, EMS_Decrease, EMS_IncreaseFast, EMS_DecreaseFast, MasterCaution, Abort
    };
}