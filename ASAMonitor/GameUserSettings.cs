using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAMonitor
{
    public class GameUserSettings
    {
        private FileIniDataParser parser = null;
        private IniData data = null;
        private bool isDirty = false;

        public GameUserSettings()
        {
            parser = new FileIniDataParser();
            parser.Parser.Configuration.AllowDuplicateKeys = true;
            parser.Parser.Configuration.AssigmentSpacer = string.Empty;
            data = parser.ReadFile(Path);
        }

        public List<SectionData> CustomSections
        {
            get
            {
                List<SectionData> customSections = new List<SectionData>();
                foreach(SectionData section in data.Sections)
                {
                    if (!section.SectionName.Equals("ServerSettings", StringComparison.OrdinalIgnoreCase) && !section.SectionName.Equals("ScalabilityGroups", StringComparison.OrdinalIgnoreCase) && !section.SectionName.Equals("/Script/ShooterGame.ShooterGameUserSettings", StringComparison.OrdinalIgnoreCase) && !section.SectionName.Equals("/Script/Engine.GameUserSettings", StringComparison.OrdinalIgnoreCase) && !section.SectionName.Equals("SessionSettings", StringComparison.OrdinalIgnoreCase) && !section.SectionName.Equals("MessageOfTheDay", StringComparison.OrdinalIgnoreCase) && !section.SectionName.Equals("/Script/Engine.GameSession", StringComparison.OrdinalIgnoreCase))
                    {
                        customSections.Add(section);
                    }
                }
                return customSections;
            }
        }

        private string Path
        {
            get
            {
                return string.Format("{0}\\ShooterGame\\Saved\\Config\\WindowsServer\\GameUserSettings.ini", ConfigurationSettings.ASAServerPath);
            }
        }

        public void Save()
        {
            if (isDirty)
            {
                isDirty = false;
                parser.WriteFile(Path, data);
            }
        }

        public string SessionName
        {
            get
            {
                return (!string.IsNullOrEmpty(data["SessionSettings"]["SessionName"]) ? data["SessionSettings"]["SessionName"] : string.Empty);
            }
            set
            {
                if (ServerAdminPassword != value)
                {
                    data["SessionSettings"]["SessionName"] = value;
                    isDirty = true;
                }
            }
        }

        public int MaxPlayers
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/Engine.GameSession"]["MaxPlayers"]) ? Convert.ToInt32(data["/Script/Engine.GameSession"]["MaxPlayers"]) : 100);
            }
            set
            {
                if (MaxPlayers != value)
                {
                    data["/Script/Engine.GameSession"]["MaxPlayers"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public string ServerAdminPassword
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["ServerAdminPassword"]) ? data["ServerSettings"]["ServerAdminPassword"] : string.Empty);
            }
            set
            {
                if (ServerAdminPassword != value)
                {
                    data["ServerSettings"]["ServerAdminPassword"] = value;
                    isDirty = true;
                }
            }
        }

        public string ServerPassword
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["ServerPassword"]) ? data["ServerSettings"]["ServerPassword"] : string.Empty);
            }
            set
            {
                if (ServerPassword != value)
                {
                    data["ServerSettings"]["ServerPassword"] = value;
                    isDirty = true;
                }
            }
        }

        public bool ShowMapPlayerLocation
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["ShowMapPlayerLocation"]) ? Convert.ToBoolean(data["ServerSettings"]["ShowMapPlayerLocation"].ToLower()) : false);
            }
            set
            {
                if (ShowMapPlayerLocation != value)
                {
                    data["ServerSettings"]["ShowMapPlayerLocation"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AllowThirdPersonPlayer
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AllowThirdPersonPlayer"]) ? Convert.ToBoolean(data["ServerSettings"]["AllowThirdPersonPlayer"].ToLower()) : true);
            }
            set
            {
                if (AllowThirdPersonPlayer != value)
                {
                    data["ServerSettings"]["AllowThirdPersonPlayer"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool FastDecayUnsnappedCoreStructures
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["FastDecayUnsnappedCoreStructures"]) ? Convert.ToBoolean(data["ServerSettings"]["FastDecayUnsnappedCoreStructures"].ToLower()) : true);
            }
            set
            {
                if (FastDecayUnsnappedCoreStructures != value)
                {
                    data["ServerSettings"]["FastDecayUnsnappedCoreStructures"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool OverrideStructurePlatformPrevention
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["OverrideStructurePlatformPrevention"]) ? Convert.ToBoolean(data["ServerSettings"]["OverrideStructurePlatformPrevention"].ToLower()) : true);
            }
            set
            {
                if (OverrideStructurePlatformPrevention != value)
                {
                    data["ServerSettings"]["OverrideStructurePlatformPrevention"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PreventOfflinePvP
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PreventOfflinePvP"]) ? Convert.ToBoolean(data["ServerSettings"]["PreventOfflinePvP"].ToLower()) : true);
            }
            set
            {
                if (PreventOfflinePvP != value)
                {
                    data["ServerSettings"]["PreventOfflinePvP"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public float TamingSpeedMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["TamingSpeedMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["TamingSpeedMultiplier"]) : 1f);
            }
            set
            {
                if (TamingSpeedMultiplier != value)
                {
                    data["ServerSettings"]["TamingSpeedMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public bool AllowAnyoneBabyImprintCuddle
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AllowAnyoneBabyImprintCuddle"]) ? Convert.ToBoolean(data["ServerSettings"]["AllowAnyoneBabyImprintCuddle"].ToLower()) : true);
            }
            set
            {
                if (AllowAnyoneBabyImprintCuddle != value)
                {
                    data["ServerSettings"]["AllowAnyoneBabyImprintCuddle"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool DisableImprintDinoBuff
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DisableImprintDinoBuff"]) ? Convert.ToBoolean(data["ServerSettings"]["DisableImprintDinoBuff"].ToLower()) : false);
            }
            set
            {
                if (DisableImprintDinoBuff != value)
                {
                    data["ServerSettings"]["DisableImprintDinoBuff"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PvPDinoDecay
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PvPDinoDecay"]) ? Convert.ToBoolean(data["ServerSettings"]["PvPDinoDecay"].ToLower()) : true);
            }
            set
            {
                if (PvPDinoDecay != value)
                {
                    data["ServerSettings"]["PvPDinoDecay"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PvPStructureDecay
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PvPStructureDecay"]) ? Convert.ToBoolean(data["ServerSettings"]["PvPStructureDecay"].ToLower()) : false);
            }
            set
            {
                if (PvPStructureDecay != value)
                {
                    data["ServerSettings"]["PvPStructureDecay"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool OnlyAutoDestroyCoreStructures
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["OnlyAutoDestroyCoreStructures"]) ? Convert.ToBoolean(data["ServerSettings"]["OnlyAutoDestroyCoreStructures"].ToLower()) : true);
            }
            set
            {
                if (OnlyAutoDestroyCoreStructures != value)
                {
                    data["ServerSettings"]["OnlyAutoDestroyCoreStructures"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool ClampItemSpoilingTimes
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["ClampItemSpoilingTimes"]) ? Convert.ToBoolean(data["ServerSettings"]["ClampItemSpoilingTimes"].ToLower()) : false);
            }
            set
            {
                if (ClampItemSpoilingTimes != value)
                {
                    data["ServerSettings"]["ClampItemSpoilingTimes"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool ClampItemStats
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["ClampItemStats"]) ? Convert.ToBoolean(data["ServerSettings"]["ClampItemStats"].ToLower()) : false);
            }
            set
            {
                if (ClampItemStats != value)
                {
                    data["ServerSettings"]["ClampItemStats"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AutoDestroyDecayedDinos
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AutoDestroyDecayedDinos"]) ? Convert.ToBoolean(data["ServerSettings"]["AutoDestroyDecayedDinos"].ToLower()) : false);
            }
            set
            {
                if (AutoDestroyDecayedDinos != value)
                {
                    data["ServerSettings"]["AutoDestroyDecayedDinos"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PreventTribeAlliances
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PreventTribeAlliances"]) ? Convert.ToBoolean(data["ServerSettings"]["PreventTribeAlliances"].ToLower()) : true);
            }
            set
            {
                if (PreventTribeAlliances != value)
                {
                    data["ServerSettings"]["PreventTribeAlliances"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool ServerCrosshair
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["ServerCrosshair"]) ? Convert.ToBoolean(data["ServerSettings"]["ServerCrosshair"].ToLower()) : false);
            }
            set
            {
                if (ServerCrosshair != value)
                {
                    data["ServerSettings"]["ServerCrosshair"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool RCONEnabled
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["RCONEnabled"]) ? Convert.ToBoolean(data["ServerSettings"]["RCONEnabled"].ToLower()) : false);
            }
            set
            {
                if (RCONEnabled != value)
                {
                    data["ServerSettings"]["RCONEnabled"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public int RCONPort
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["RCONPort"]) ? Convert.ToInt32(data["ServerSettings"]["RCONPort"]) : 27020);
            }
            set
            {
                if (RCONPort != value)
                {
                    data["ServerSettings"]["RCONPort"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int PreventOfflinePvPInterval
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PreventOfflinePvPInterval"]) ? Convert.ToInt32(data["ServerSettings"]["PreventOfflinePvPInterval"]) : 800);
            }
            set
            {
                if (PreventOfflinePvPInterval != value)
                {
                    data["ServerSettings"]["PreventOfflinePvPInterval"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int StartTimeHour
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["StartTimeHour"]) ? Convert.ToInt32(data["ServerSettings"]["StartTimeHour"]) : -1);
            }
            set
            {
                if (StartTimeHour != value)
                {
                    data["ServerSettings"]["StartTimeHour"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float OxygenSwimSpeedStatMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["OxygenSwimSpeedStatMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["OxygenSwimSpeedStatMultiplier"]) : 1f);
            }
            set
            {
                if (OxygenSwimSpeedStatMultiplier != value)
                {
                    data["ServerSettings"]["OxygenSwimSpeedStatMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float StructurePreventResourceRadiusMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["StructurePreventResourceRadiusMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["StructurePreventResourceRadiusMultiplier"]) : 1f);
            }
            set
            {
                if (StructurePreventResourceRadiusMultiplier != value)
                {
                    data["ServerSettings"]["StructurePreventResourceRadiusMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int TribeNameChangeCooldown
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["TribeNameChangeCooldown"]) ? Convert.ToInt32(data["ServerSettings"]["TribeNameChangeCooldown"]) : 15);
            }
            set
            {
                if (TribeNameChangeCooldown != value)
                {
                    data["ServerSettings"]["TribeNameChangeCooldown"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float PlatformSaddleBuildAreaBoundsMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PlatformSaddleBuildAreaBoundsMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["PlatformSaddleBuildAreaBoundsMultiplier"]) : 1f);
            }
            set
            {
                if (PlatformSaddleBuildAreaBoundsMultiplier != value)
                {
                    data["ServerSettings"]["PlatformSaddleBuildAreaBoundsMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int StructurePickupTimeAfterPlacement
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["StructurePickupTimeAfterPlacement"]) ? Convert.ToInt32(data["ServerSettings"]["StructurePickupTimeAfterPlacement"]) : 30);
            }
            set
            {
                if (StructurePickupTimeAfterPlacement != value)
                {
                    data["ServerSettings"]["StructurePickupTimeAfterPlacement"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public bool AlwaysAllowStructurePickup
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AlwaysAllowStructurePickup"]) ? Convert.ToBoolean(data["ServerSettings"]["AlwaysAllowStructurePickup"].ToLower()) : true);
            }
            set
            {
                if (AlwaysAllowStructurePickup != value)
                {
                    data["ServerSettings"]["AlwaysAllowStructurePickup"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public float StructurePickupHoldDuration
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["StructurePickupHoldDuration"]) ? Convert.ToSingle(data["ServerSettings"]["StructurePickupHoldDuration"]) : 0.5f);
            }
            set
            {
                if (StructurePickupHoldDuration != value)
                {
                    data["ServerSettings"]["StructurePickupHoldDuration"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public bool AllowHideDamageSourceFromLogs
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AllowHideDamageSourceFromLogs"]) ? Convert.ToBoolean(data["ServerSettings"]["AllowHideDamageSourceFromLogs"].ToLower()) : true);
            }
            set
            {
                if (AllowHideDamageSourceFromLogs != value)
                {
                    data["ServerSettings"]["AllowHideDamageSourceFromLogs"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public float RaidDinoCharacterFoodDrainMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["RaidDinoCharacterFoodDrainMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["RaidDinoCharacterFoodDrainMultiplier"]) : 1f);
            }
            set
            {
                if (RaidDinoCharacterFoodDrainMultiplier != value)
                {
                    data["ServerSettings"]["RaidDinoCharacterFoodDrainMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float PvEDinoDecayPeriodMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PvEDinoDecayPeriodMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["PvEDinoDecayPeriodMultiplier"]) : 1f);
            }
            set
            {
                if (PvEDinoDecayPeriodMultiplier != value)
                {
                    data["ServerSettings"]["PvEDinoDecayPeriodMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float KickIdlePlayersPeriod
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["KickIdlePlayersPeriod"]) ? Convert.ToSingle(data["ServerSettings"]["KickIdlePlayersPeriod"]) : 2400f);
            }
            set
            {
                if (KickIdlePlayersPeriod != value)
                {
                    data["ServerSettings"]["KickIdlePlayersPeriod"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float PerPlatformMaxStructuresMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PerPlatformMaxStructuresMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["PerPlatformMaxStructuresMultiplier"]) : 1f);
            }
            set
            {
                if (PerPlatformMaxStructuresMultiplier != value)
                {
                    data["ServerSettings"]["PerPlatformMaxStructuresMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int MaxPlatformSaddleStructureLimit
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["MaxPlatformSaddleStructureLimit"]) ? Convert.ToInt32(data["ServerSettings"]["MaxPlatformSaddleStructureLimit"]) : 1000);
            }
            set
            {
                if (MaxPlatformSaddleStructureLimit != value)
                {
                    data["ServerSettings"]["MaxPlatformSaddleStructureLimit"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int AutoSavePeriodMinutes
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AutoSavePeriodMinutes"]) ? Convert.ToInt32(data["ServerSettings"]["AutoSavePeriodMinutes"]) : 15);
            }
            set
            {
                if (AutoSavePeriodMinutes != value)
                {
                    data["ServerSettings"]["AutoSavePeriodMinutes"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int MaxTamedDinos
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["MaxTamedDinos"]) ? Convert.ToInt32(data["ServerSettings"]["MaxTamedDinos"]) : 5500);
            }
            set
            {
                if (MaxTamedDinos != value)
                {
                    data["ServerSettings"]["MaxTamedDinos"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float ItemStackSizeMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["ItemStackSizeMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["ItemStackSizeMultiplier"]) : 1f);
            }
            set
            {
                if (ItemStackSizeMultiplier != value)
                {
                    data["ServerSettings"]["ItemStackSizeMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int RCONServerGameLogBuffer
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["RCONServerGameLogBuffer"]) ? Convert.ToInt32(data["ServerSettings"]["RCONServerGameLogBuffer"]) : 600);
            }
            set
            {
                if (RCONServerGameLogBuffer != value)
                {
                    data["ServerSettings"]["RCONServerGameLogBuffer"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public bool AllowRaidDinoFeeding
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AllowRaidDinoFeeding"]) ? Convert.ToBoolean(data["ServerSettings"]["AllowRaidDinoFeeding"].ToLower()) : true);
            }
            set
            {
                if (AllowRaidDinoFeeding != value)
                {
                    data["ServerSettings"]["AllowRaidDinoFeeding"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool EnableExtraStructurePreventionVolumes
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["EnableExtraStructurePreventionVolumes"]) ? Convert.ToBoolean(data["ServerSettings"]["EnableExtraStructurePreventionVolumes"].ToLower()) : true);
            }
            set
            {
                if (EnableExtraStructurePreventionVolumes != value)
                {
                    data["ServerSettings"]["EnableExtraStructurePreventionVolumes"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool ShowFloatingDamageText
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["ShowFloatingDamageText"]) ? Convert.ToBoolean(data["ServerSettings"]["ShowFloatingDamageText"].ToLower()) : true);
            }
            set
            {
                if (ShowFloatingDamageText != value)
                {
                    data["ServerSettings"]["ShowFloatingDamageText"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public int ImplantSuicideCD
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["ImplantSuicideCD"]) ? Convert.ToInt32(data["ServerSettings"]["ImplantSuicideCD"]) : 28800);
            }
            set
            {
                if (ImplantSuicideCD != value)
                {
                    data["ServerSettings"]["ImplantSuicideCD"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public bool PreventSpawnAnimations
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PreventSpawnAnimations"]) ? Convert.ToBoolean(data["ServerSettings"]["PreventSpawnAnimations"].ToLower()) : false);
            }
            set
            {
                if (PreventSpawnAnimations != value)
                {
                    data["ServerSettings"]["PreventSpawnAnimations"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool CrossARKAllowForeignDinoDownloads
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["CrossARKAllowForeignDinoDownloads"]) ? Convert.ToBoolean(data["ServerSettings"]["CrossARKAllowForeignDinoDownloads"].ToLower()) : false);
            }
            set
            {
                if (CrossARKAllowForeignDinoDownloads != value)
                {
                    data["ServerSettings"]["CrossARKAllowForeignDinoDownloads"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PreventDiseases
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PreventDiseases"]) ? Convert.ToBoolean(data["ServerSettings"]["PreventDiseases"].ToLower()) : false);
            }
            set
            {
                if (PreventDiseases != value)
                {
                    data["ServerSettings"]["PreventDiseases"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool NonPermanentDiseases
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["NonPermanentDiseases"]) ? Convert.ToBoolean(data["ServerSettings"]["NonPermanentDiseases"].ToLower()) : false);
            }
            set
            {
                if (NonPermanentDiseases != value)
                {
                    data["ServerSettings"]["NonPermanentDiseases"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool TribeLogDestroyedEnemyStructures
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["TribeLogDestroyedEnemyStructures"]) ? Convert.ToBoolean(data["ServerSettings"]["TribeLogDestroyedEnemyStructures"].ToLower()) : false);
            }
            set
            {
                if (TribeLogDestroyedEnemyStructures != value)
                {
                    data["ServerSettings"]["TribeLogDestroyedEnemyStructures"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PvEAllowStructuresAtSupplyDrops
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PvEAllowStructuresAtSupplyDrops"]) ? Convert.ToBoolean(data["ServerSettings"]["PvEAllowStructuresAtSupplyDrops"].ToLower()) : false);
            }
            set
            {
                if (PvEAllowStructuresAtSupplyDrops != value)
                {
                    data["ServerSettings"]["PvEAllowStructuresAtSupplyDrops"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool UseOptimizedHarvestingHealth
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["UseOptimizedHarvestingHealth"]) ? Convert.ToBoolean(data["ServerSettings"]["UseOptimizedHarvestingHealth"].ToLower()) : false);
            }
            set
            {
                if (UseOptimizedHarvestingHealth != value)
                {
                    data["ServerSettings"]["UseOptimizedHarvestingHealth"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AllowMultipleAttachedC4
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AllowMultipleAttachedC4"]) ? Convert.ToBoolean(data["ServerSettings"]["AllowMultipleAttachedC4"].ToLower()) : true);
            }
            set
            {
                if (AllowMultipleAttachedC4 != value)
                {
                    data["ServerSettings"]["AllowMultipleAttachedC4"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AllowFlyingStaminaRecovery
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AllowFlyingStaminaRecovery"]) ? Convert.ToBoolean(data["ServerSettings"]["AllowFlyingStaminaRecovery"].ToLower()) : false);
            }
            set
            {
                if (AllowFlyingStaminaRecovery != value)
                {
                    data["ServerSettings"]["AllowFlyingStaminaRecovery"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AllowHitMarkers
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AllowHitMarkers"]) ? Convert.ToBoolean(data["ServerSettings"]["AllowHitMarkers"].ToLower()) : true);
            }
            set
            {
                if (AllowHitMarkers != value)
                {
                    data["ServerSettings"]["AllowHitMarkers"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PreventDownloadSurvivors
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PreventDownloadSurvivors"]) ? Convert.ToBoolean(data["ServerSettings"]["PreventDownloadSurvivors"].ToLower()) : true);
            }
            set
            {
                if (PreventDownloadSurvivors != value)
                {
                    data["ServerSettings"]["PreventDownloadSurvivors"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PreventDownloadItems
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PreventDownloadItems"]) ? Convert.ToBoolean(data["ServerSettings"]["PreventDownloadItems"].ToLower()) : true);
            }
            set
            {
                if (PreventDownloadItems != value)
                {
                    data["ServerSettings"]["PreventDownloadItems"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PreventDownloadDinos
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PreventDownloadDinos"]) ? Convert.ToBoolean(data["ServerSettings"]["PreventDownloadDinos"].ToLower()) : true);
            }
            set
            {
                if (PreventDownloadDinos != value)
                {
                    data["ServerSettings"]["PreventDownloadDinos"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PreventUploadSurvivors
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PreventUploadSurvivors"]) ? Convert.ToBoolean(data["ServerSettings"]["PreventUploadSurvivors"].ToLower()) : false);
            }
            set
            {
                if (PreventUploadSurvivors != value)
                {
                    data["ServerSettings"]["PreventUploadSurvivors"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PreventUploadItems
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PreventUploadItems"]) ? Convert.ToBoolean(data["ServerSettings"]["PreventUploadItems"].ToLower()) : false);
            }
            set
            {
                if (PreventUploadItems != value)
                {
                    data["ServerSettings"]["PreventUploadItems"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PreventUploadDinos
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PreventUploadDinos"]) ? Convert.ToBoolean(data["ServerSettings"]["PreventUploadDinos"].ToLower()) : false);
            }
            set
            {
                if (PreventUploadDinos != value)
                {
                    data["ServerSettings"]["PreventUploadDinos"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AllowCrateSpawnsOnTopOfStructures
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AllowCrateSpawnsOnTopOfStructures"]) ? Convert.ToBoolean(data["ServerSettings"]["AllowCrateSpawnsOnTopOfStructures"].ToLower()) : false);
            }
            set
            {
                if (AllowCrateSpawnsOnTopOfStructures != value)
                {
                    data["ServerSettings"]["AllowCrateSpawnsOnTopOfStructures"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool EnableCryopodNerf
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["EnableCryopodNerf"]) ? Convert.ToBoolean(data["ServerSettings"]["EnableCryopodNerf"].ToLower()) : false);
            }
            set
            {
                if (EnableCryopodNerf != value)
                {
                    data["ServerSettings"]["EnableCryopodNerf"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public float DifficultyOffset
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DifficultyOffset"]) ? Convert.ToSingle(data["ServerSettings"]["DifficultyOffset"]) : 0f);
            }
            set
            {
                if (DifficultyOffset != value)
                {
                    data["ServerSettings"]["DifficultyOffset"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float OverrideOfficialDifficulty
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["OverrideOfficialDifficulty"]) ? Convert.ToSingle(data["ServerSettings"]["OverrideOfficialDifficulty"]) : 5f);
            }
            set
            {
                if (OverrideOfficialDifficulty != value)
                {
                    data["ServerSettings"]["OverrideOfficialDifficulty"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public bool AllowFlyerCarryPvE
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AllowFlyerCarryPvE"]) ? Convert.ToBoolean(data["ServerSettings"]["AllowFlyerCarryPvE"].ToLower()) : true);
            }
            set
            {
                if (AllowFlyerCarryPvE != value)
                {
                    data["ServerSettings"]["AllowFlyerCarryPvE"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool DontAlwaysNotifyPlayerJoined
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DontAlwaysNotifyPlayerJoined"]) ? Convert.ToBoolean(data["ServerSettings"]["DontAlwaysNotifyPlayerJoined"].ToLower()) : false);
            }
            set
            {
                if (DontAlwaysNotifyPlayerJoined != value)
                {
                    data["ServerSettings"]["DontAlwaysNotifyPlayerJoined"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool ShowStatusNotificationMessages
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameUserSettings"]["bShowStatusNotificationMessages"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameUserSettings"]["bShowStatusNotificationMessages"].ToLower()) : true);
            }
            set
            {
                if (ShowStatusNotificationMessages != value)
                {
                    data["/Script/ShooterGame.ShooterGameUserSettings"]["bShowStatusNotificationMessages"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool JoinNotifications
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameUserSettings"]["bJoinNotifications"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameUserSettings"]["bJoinNotifications"].ToLower()) : false);
            }
            set
            {
                if (JoinNotifications != value)
                {
                    data["/Script/ShooterGame.ShooterGameUserSettings"]["bJoinNotifications"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool ServerPVE
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["ServerPVE"]) ? Convert.ToBoolean(data["ServerSettings"]["ServerPVE"].ToLower()) : false);
            }
            set
            {
                if (ServerPVE != value)
                {
                    data["ServerSettings"]["ServerPVE"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public int MaxTamedDinos_SoftTameLimit
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["MaxTamedDinos_SoftTameLimit"]) ? Convert.ToInt32(data["ServerSettings"]["MaxTamedDinos_SoftTameLimit"]) : 5500);
            }
            set
            {
                if (MaxTamedDinos_SoftTameLimit != value)
                {
                    data["ServerSettings"]["MaxTamedDinos_SoftTameLimit"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int MaxTamedDinos_SoftTameLimit_CountdownForDeletionDuration
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["MaxTamedDinos_SoftTameLimit_CountdownForDeletionDuration"]) ? Convert.ToInt32(data["ServerSettings"]["MaxTamedDinos_SoftTameLimit_CountdownForDeletionDuration"]) : 604800);
            }
            set
            {
                if (MaxTamedDinos_SoftTameLimit_CountdownForDeletionDuration != value)
                {
                    data["ServerSettings"]["MaxTamedDinos_SoftTameLimit_CountdownForDeletionDuration"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public bool AllowCryoFridgeOnSaddle
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AllowCryoFridgeOnSaddle"]) ? Convert.ToBoolean(data["ServerSettings"]["AllowCryoFridgeOnSaddle"].ToLower()) : false);
            }
            set
            {
                if (AllowCryoFridgeOnSaddle != value)
                {
                    data["ServerSettings"]["AllowCryoFridgeOnSaddle"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool DisableCryopodEnemyCheck
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DisableCryopodEnemyCheck"]) ? Convert.ToBoolean(data["ServerSettings"]["DisableCryopodEnemyCheck"].ToLower()) : false);
            }
            set
            {
                if (DisableCryopodEnemyCheck != value)
                {
                    data["ServerSettings"]["DisableCryopodEnemyCheck"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool DisableCryopodFridgeRequirement
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DisableCryopodFridgeRequirement"]) ? Convert.ToBoolean(data["ServerSettings"]["DisableCryopodFridgeRequirement"].ToLower()) : false);
            }
            set
            {
                if (DisableCryopodFridgeRequirement != value)
                {
                    data["ServerSettings"]["DisableCryopodFridgeRequirement"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool EnableCryoSicknessPVE
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["EnableCryoSicknessPVE"]) ? Convert.ToBoolean(data["ServerSettings"]["EnableCryoSicknessPVE"].ToLower()) : false);
            }
            set
            {
                if (EnableCryoSicknessPVE != value)
                {
                    data["ServerSettings"]["EnableCryoSicknessPVE"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public int CryopodNerfDuration
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["CryopodNerfDuration"]) ? Convert.ToInt32(data["ServerSettings"]["CryopodNerfDuration"]) : 0);
            }
            set
            {
                if (CryopodNerfDuration != value)
                {
                    data["ServerSettings"]["CryopodNerfDuration"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float CryopodNerfDamageMult
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["CryopodNerfDamageMult"]) ? Convert.ToSingle(data["ServerSettings"]["CryopodNerfDamageMult"]) : 0.01f);
            }
            set
            {
                if (CryopodNerfDamageMult != value)
                {
                    data["ServerSettings"]["CryopodNerfDamageMult"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int CryopodNerfIncomingDamageMultPercent
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["CryopodNerfIncomingDamageMultPercent"]) ? Convert.ToInt32(data["ServerSettings"]["CryopodNerfIncomingDamageMultPercent"]) : 0);
            }
            set
            {
                if (CryopodNerfIncomingDamageMultPercent != value)
                {
                    data["ServerSettings"]["CryopodNerfIncomingDamageMultPercent"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float NewMaxStructuresInRange
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["NewMaxStructuresInRange"]) ? Convert.ToSingle(data["ServerSettings"]["NewMaxStructuresInRange"]) : 6000f);
            }
            set
            {
                if (NewMaxStructuresInRange != value)
                {
                    data["ServerSettings"]["NewMaxStructuresInRange"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float XPMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["XPMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["XPMultiplier"]) : 1f);
            }
            set
            {
                if (XPMultiplier != value)
                {
                    data["ServerSettings"]["XPMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float DayCycleSpeedScale
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DayCycleSpeedScale"]) ? Convert.ToSingle(data["ServerSettings"]["DayCycleSpeedScale"]) : 1f);
            }
            set
            {
                if (DayCycleSpeedScale != value)
                {
                    data["ServerSettings"]["DayCycleSpeedScale"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float DayTimeSpeedScale
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DayTimeSpeedScale"]) ? Convert.ToSingle(data["ServerSettings"]["DayTimeSpeedScale"]) : 1f);
            }
            set
            {
                if (DayTimeSpeedScale != value)
                {
                    data["ServerSettings"]["DayTimeSpeedScale"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float NightTimeSpeedScale
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["NightTimeSpeedScale"]) ? Convert.ToSingle(data["ServerSettings"]["NightTimeSpeedScale"]) : 1f);
            }
            set
            {
                if (NightTimeSpeedScale != value)
                {
                    data["ServerSettings"]["NightTimeSpeedScale"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float HarvestAmountMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["HarvestAmountMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["HarvestAmountMultiplier"]) : 1f);
            }
            set
            {
                if (HarvestAmountMultiplier != value)
                {
                    data["ServerSettings"]["HarvestAmountMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float HarvestHealthMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["HarvestHealthMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["HarvestHealthMultiplier"]) : 1f);
            }
            set
            {
                if (HarvestHealthMultiplier != value)
                {
                    data["ServerSettings"]["HarvestHealthMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float DinoDamageMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DinoDamageMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["DinoDamageMultiplier"]) : 1f);
            }
            set
            {
                if (DinoDamageMultiplier != value)
                {
                    data["ServerSettings"]["DinoDamageMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float PlayerDamageMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PlayerDamageMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["PlayerDamageMultiplier"]) : 1f);
            }
            set
            {
                if (PlayerDamageMultiplier != value)
                {
                    data["ServerSettings"]["PlayerDamageMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float StructureDamageMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["StructureDamageMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["StructureDamageMultiplier"]) : 1f);
            }
            set
            {
                if (StructureDamageMultiplier != value)
                {
                    data["ServerSettings"]["StructureDamageMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float PlayerResistanceMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PlayerResistanceMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["PlayerResistanceMultiplier"]) : 1f);
            }
            set
            {
                if (PlayerResistanceMultiplier != value)
                {
                    data["ServerSettings"]["PlayerResistanceMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float DinoResistanceMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DinoResistanceMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["DinoResistanceMultiplier"]) : 1f);
            }
            set
            {
                if (DinoResistanceMultiplier != value)
                {
                    data["ServerSettings"]["DinoResistanceMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float StructureResistanceMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["StructureResistanceMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["StructureResistanceMultiplier"]) : 1f);
            }
            set
            {
                if (StructureResistanceMultiplier != value)
                {
                    data["ServerSettings"]["StructureResistanceMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float PvEStructureDecayPeriodMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PvEStructureDecayPeriodMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["PvEStructureDecayPeriodMultiplier"]) : 1f);
            }
            set
            {
                if (PvEStructureDecayPeriodMultiplier != value)
                {
                    data["ServerSettings"]["PvEStructureDecayPeriodMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float ResourcesRespawnPeriodMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["ResourcesRespawnPeriodMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["ResourcesRespawnPeriodMultiplier"]) : 1f);
            }
            set
            {
                if (ResourcesRespawnPeriodMultiplier != value)
                {
                    data["ServerSettings"]["ResourcesRespawnPeriodMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float PlayerCharacterWaterDrainMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PlayerCharacterWaterDrainMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["PlayerCharacterWaterDrainMultiplier"]) : 1f);
            }
            set
            {
                if (PlayerCharacterWaterDrainMultiplier != value)
                {
                    data["ServerSettings"]["PlayerCharacterWaterDrainMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float PlayerCharacterFoodDrainMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PlayerCharacterFoodDrainMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["PlayerCharacterFoodDrainMultiplier"]) : 1f);
            }
            set
            {
                if (PlayerCharacterFoodDrainMultiplier != value)
                {
                    data["ServerSettings"]["PlayerCharacterFoodDrainMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float DinoCharacterFoodDrainMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DinoCharacterFoodDrainMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["DinoCharacterFoodDrainMultiplier"]) : 1f);
            }
            set
            {
                if (DinoCharacterFoodDrainMultiplier != value)
                {
                    data["ServerSettings"]["DinoCharacterFoodDrainMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float PlayerCharacterStaminaDrainMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PlayerCharacterStaminaDrainMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["PlayerCharacterStaminaDrainMultiplier"]) : 1f);
            }
            set
            {
                if (PlayerCharacterStaminaDrainMultiplier != value)
                {
                    data["ServerSettings"]["PlayerCharacterStaminaDrainMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float DinoCharacterStaminaDrainMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DinoCharacterStaminaDrainMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["DinoCharacterStaminaDrainMultiplier"]) : 1f);
            }
            set
            {
                if (DinoCharacterStaminaDrainMultiplier != value)
                {
                    data["ServerSettings"]["DinoCharacterStaminaDrainMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float PlayerCharacterHealthRecoveryMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["PlayerCharacterHealthRecoveryMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["PlayerCharacterHealthRecoveryMultiplier"]) : 1f);
            }
            set
            {
                if (PlayerCharacterHealthRecoveryMultiplier != value)
                {
                    data["ServerSettings"]["PlayerCharacterHealthRecoveryMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float DinoCharacterHealthRecoveryMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DinoCharacterHealthRecoveryMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["DinoCharacterHealthRecoveryMultiplier"]) : 1f);
            }
            set
            {
                if (DinoCharacterHealthRecoveryMultiplier != value)
                {
                    data["ServerSettings"]["DinoCharacterHealthRecoveryMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float DinoCountMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DinoCountMultiplier"]) ? Convert.ToSingle(data["ServerSettings"]["DinoCountMultiplier"]) : 1f);
            }
            set
            {
                if (DinoCountMultiplier != value)
                {
                    data["ServerSettings"]["DinoCountMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public bool NoTributeDownloads
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["NoTributeDownloads"]) ? Convert.ToBoolean(data["ServerSettings"]["NoTributeDownloads"].ToLower()) : true);
            }
            set
            {
                if (NoTributeDownloads != value)
                {
                    data["ServerSettings"]["NoTributeDownloads"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool OnlyAllowSpecifiedEngrams
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["OnlyAllowSpecifiedEngrams"]) ? Convert.ToBoolean(data["ServerSettings"]["OnlyAllowSpecifiedEngrams"].ToLower()) : false);
            }
            set
            {
                if (OnlyAllowSpecifiedEngrams != value)
                {
                    data["ServerSettings"]["OnlyAllowSpecifiedEngrams"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool ServerForceNoHUD
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["ServerForceNoHUD"]) ? Convert.ToBoolean(data["ServerSettings"]["ServerForceNoHUD"].ToLower()) : false);
            }
            set
            {
                if (ServerForceNoHUD != value)
                {
                    data["ServerSettings"]["ServerForceNoHUD"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool GlobalVoiceChat
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["GlobalVoiceChat"]) ? Convert.ToBoolean(data["ServerSettings"]["GlobalVoiceChat"].ToLower()) : false);
            }
            set
            {
                if (GlobalVoiceChat != value)
                {
                    data["ServerSettings"]["GlobalVoiceChat"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool ProximityChat
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["ProximityChat"]) ? Convert.ToBoolean(data["ServerSettings"]["ProximityChat"].ToLower()) : false);
            }
            set
            {
                if (ProximityChat != value)
                {
                    data["ServerSettings"]["ProximityChat"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AlwaysNotifyPlayerLeft
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AlwaysNotifyPlayerLeft"]) ? Convert.ToBoolean(data["ServerSettings"]["AlwaysNotifyPlayerLeft"].ToLower()) : true);
            }
            set
            {
                if (AlwaysNotifyPlayerLeft != value)
                {
                    data["ServerSettings"]["AlwaysNotifyPlayerLeft"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool ServerHardcore
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["ServerHardcore"]) ? Convert.ToBoolean(data["ServerSettings"]["ServerHardcore"].ToLower()) : false);
            }
            set
            {
                if (ServerHardcore != value)
                {
                    data["ServerSettings"]["ServerHardcore"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public int BattleNumOfTribesToStartGame
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["BattleNumOfTribesToStartGame"]) ? Convert.ToInt32(data["ServerSettings"]["BattleNumOfTribesToStartGame"]) : 15);
            }
            set
            {
                if (BattleNumOfTribesToStartGame != value)
                {
                    data["ServerSettings"]["BattleNumOfTribesToStartGame"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float TimeToCollapseROD
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["TimeToCollapseROD"]) ? Convert.ToSingle(data["ServerSettings"]["TimeToCollapseROD"]) : 9000f);
            }
            set
            {
                if (TimeToCollapseROD != value)
                {
                    data["ServerSettings"]["TimeToCollapseROD"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float BattleAutoStartGameInterval
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["BattleAutoStartGameInterval"]) ? Convert.ToSingle(data["ServerSettings"]["BattleAutoStartGameInterval"]) : 300f);
            }
            set
            {
                if (BattleAutoStartGameInterval != value)
                {
                    data["ServerSettings"]["BattleAutoStartGameInterval"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float BattleAutoRestartGameInterval
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["BattleAutoRestartGameInterval"]) ? Convert.ToSingle(data["ServerSettings"]["BattleAutoRestartGameInterval"]) : 45f);
            }
            set
            {
                if (BattleAutoRestartGameInterval != value)
                {
                    data["ServerSettings"]["BattleAutoRestartGameInterval"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float BattleSuddenDeathInterval
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["BattleSuddenDeathInterval"]) ? Convert.ToSingle(data["ServerSettings"]["BattleSuddenDeathInterval"]) : 1200f);
            }
            set
            {
                if (BattleSuddenDeathInterval != value)
                {
                    data["ServerSettings"]["BattleSuddenDeathInterval"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public bool DisablePvEGamma
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DisablePvEGamma"]) ? Convert.ToBoolean(data["ServerSettings"]["DisablePvEGamma"].ToLower()) : false);
            }
            set
            {
                if (DisablePvEGamma != value)
                {
                    data["ServerSettings"]["DisablePvEGamma"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool DisableDinoDecayPvE
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["DisableDinoDecayPvE"]) ? Convert.ToBoolean(data["ServerSettings"]["DisableDinoDecayPvE"].ToLower()) : true);
            }
            set
            {
                if (DisableDinoDecayPvE != value)
                {
                    data["ServerSettings"]["DisableDinoDecayPvE"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AdminLogging
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["AdminLogging"]) ? Convert.ToBoolean(data["ServerSettings"]["AdminLogging"].ToLower()) : true);
            }
            set
            {
                if (AdminLogging != value)
                {
                    data["ServerSettings"]["AdminLogging"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool EnableDeathTeamSpectator
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ServerSettings"]["EnableDeathTeamSpectator"]) ? Convert.ToBoolean(data["ServerSettings"]["EnableDeathTeamSpectator"].ToLower()) : true);
            }
            set
            {
                if (EnableDeathTeamSpectator != value)
                {
                    data["ServerSettings"]["EnableDeathTeamSpectator"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public string MessageOfTheDay
        {
            get
            {
                return (!string.IsNullOrEmpty(data["MessageOfTheDay"]["Message"]) ? data["MessageOfTheDay"]["Message"] : string.Empty);
            }
            set
            {
                if (MessageOfTheDay != value)
                {
                    data["MessageOfTheDay"]["Message"] = value;
                    isDirty = true;
                }
            }
        }

        public int MessageDuration
        {
            get
            {
                return (!string.IsNullOrEmpty(data["MessageOfTheDay"]["Duration"]) ? Convert.ToInt32(data["MessageOfTheDay"]["Duration"]) : 10);
            }
            set
            {
                if (MessageDuration != value)
                {
                    data["MessageOfTheDay"]["Duration"] = value.ToString();
                    isDirty = true;
                }
            }
        }
    }
}
