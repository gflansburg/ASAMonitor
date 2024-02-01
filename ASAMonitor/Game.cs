using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAMonitor
{
    public class Game
    {
        private FileIniDataParser parser = null;
        private IniData data = null;
        private bool isDirty = false;

        public Game()
        {
            parser = new FileIniDataParser();
            parser.Parser.Configuration.AllowDuplicateKeys = true;
            parser.Parser.Configuration.AssigmentSpacer = string.Empty;
            data = parser.ReadFile(Path);
        }

        private string Path
        {
            get
            {
                return string.Format("{0}\\ShooterGame\\Saved\\Config\\WindowsServer\\Game.ini", ConfigurationSettings.ASAServerPath);
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

        public float BabyImprintingStatScaleMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["BabyImprintingStatScaleMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["BabyImprintingStatScaleMultiplier"]) : 1f);
            }
            set
            {
                if (BabyImprintingStatScaleMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["BabyImprintingStatScaleMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float BabyCuddleIntervalMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["BabyCuddleIntervalMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["BabyCuddleIntervalMultiplier"]) : 1f);
            }
            set
            {
                if (BabyCuddleIntervalMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["BabyCuddleIntervalMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float BabyCuddleGracePeriodMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["BabyCuddleGracePeriodMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["BabyCuddleGracePeriodMultiplier"]) : 1f);
            }
            set
            {
                if (BabyCuddleGracePeriodMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["BabyCuddleGracePeriodMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float BabyCuddleLoseImprintQualitySpeedMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["BabyCuddleLoseImprintQualitySpeedMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["BabyCuddleLoseImprintQualitySpeedMultiplier"]) : 1f);
            }
            set
            {
                if (BabyCuddleLoseImprintQualitySpeedMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["BabyCuddleLoseImprintQualitySpeedMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float GlobalSpoilingTimeMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["GlobalSpoilingTimeMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["GlobalSpoilingTimeMultiplier"]) : 1f);
            }
            set
            {
                if (GlobalSpoilingTimeMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["GlobalSpoilingTimeMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float GlobalItemDecompositionTimeMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["GlobalItemDecompositionTimeMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["GlobalItemDecompositionTimeMultiplier"]) : 1f);
            }
            set
            {
                if (GlobalItemDecompositionTimeMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["GlobalItemDecompositionTimeMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float GlobalCorpseDecompositionTimeMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["GlobalCorpseDecompositionTimeMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["GlobalCorpseDecompositionTimeMultiplier"]) : 1f);
            }
            set
            {
                if (GlobalCorpseDecompositionTimeMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["GlobalCorpseDecompositionTimeMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float PvPZoneStructureDamageMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["PvPZoneStructureDamageMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["PvPZoneStructureDamageMultiplier"]) : 1f);
            }
            set
            {
                if (PvPZoneStructureDamageMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["PvPZoneStructureDamageMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float CropGrowthSpeedMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["CropGrowthSpeedMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["CropGrowthSpeedMultiplier"]) : 1f);
            }
            set
            {
                if (PvPZoneStructureDamageMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["CropGrowthSpeedMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float LayEggIntervalMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["LayEggIntervalMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["LayEggIntervalMultiplier"]) : 1f);
            }
            set
            {
                if (LayEggIntervalMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["LayEggIntervalMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float PoopIntervalMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["PoopIntervalMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["PoopIntervalMultiplier"]) : 1f);
            }
            set
            {
                if (PoopIntervalMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["PoopIntervalMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float CropDecaySpeedMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["CropDecaySpeedMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["CropDecaySpeedMultiplier"]) : 1f);
            }
            set
            {
                if (CropDecaySpeedMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["CropDecaySpeedMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float MatingIntervalMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["MatingIntervalMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["MatingIntervalMultiplier"]) : 1f);
            }
            set
            {
                if (MatingIntervalMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["MatingIntervalMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float EggHatchSpeedMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["EggHatchSpeedMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["EggHatchSpeedMultiplier"]) : 1f);
            }
            set
            {
                if (EggHatchSpeedMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["EggHatchSpeedMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float BabyMatureSpeedMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["BabyMatureSpeedMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["BabyMatureSpeedMultiplier"]) : 1f);
            }
            set
            {
                if (BabyMatureSpeedMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["BabyMatureSpeedMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float BabyFoodConsumptionSpeedMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["BabyFoodConsumptionSpeedMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["BabyFoodConsumptionSpeedMultiplier"]) : 1f);
            }
            set
            {
                if (BabyFoodConsumptionSpeedMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["BabyFoodConsumptionSpeedMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float DinoTurretDamageMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["DinoTurretDamageMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["DinoTurretDamageMultiplier"]) : 1f);
            }
            set
            {
                if (DinoTurretDamageMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["DinoTurretDamageMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float DinoHarvestingDamageMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["DinoHarvestingDamageMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["DinoHarvestingDamageMultiplier"]) : 1f);
            }
            set
            {
                if (DinoHarvestingDamageMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["DinoHarvestingDamageMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float PlayerHarvestingDamageMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["PlayerHarvestingDamageMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["PlayerHarvestingDamageMultiplier"]) : 1f);
            }
            set
            {
                if (PlayerHarvestingDamageMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["PlayerHarvestingDamageMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float CustomRecipeEffectivenessMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["CustomRecipeEffectivenessMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["CustomRecipeEffectivenessMultiplier"]) : 1f);
            }
            set
            {
                if (CustomRecipeEffectivenessMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["CustomRecipeEffectivenessMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float CustomRecipeSkillMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["CustomRecipeSkillMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["CustomRecipeSkillMultiplier"]) : 1f);
            }
            set
            {
                if (CustomRecipeSkillMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["CustomRecipeSkillMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float KillXPMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["KillXPMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["KillXPMultiplier"]) : 1f);
            }
            set
            {
                if (KillXPMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["KillXPMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float HarvestXPMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["HarvestXPMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["HarvestXPMultiplier"]) : 1f);
            }
            set
            {
                if (HarvestXPMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["HarvestXPMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float CraftXPMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["CraftXPMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["CraftXPMultiplier"]) : 1f);
            }
            set
            {
                if (CraftXPMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["CraftXPMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float GenericXPMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["GenericXPMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["GenericXPMultiplier"]) : 1f);
            }
            set
            {
                if (GenericXPMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["GenericXPMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float SpecialXPMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["SpecialXPMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["SpecialXPMultiplier"]) : 1f);
            }
            set
            {
                if (SpecialXPMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["SpecialXPMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float FuelConsumptionIntervalMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["FuelConsumptionIntervalMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["FuelConsumptionIntervalMultiplier"]) : 1f);
            }
            set
            {
                if (FuelConsumptionIntervalMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["FuelConsumptionIntervalMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float ExplorerNoteXPMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["ExplorerNoteXPMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["ExplorerNoteXPMultiplier"]) : 1f);
            }
            set
            {
                if (ExplorerNoteXPMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["ExplorerNoteXPMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float BossKillXPMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["BossKillXPMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["BossKillXPMultiplier"]) : 1f);
            }
            set
            {
                if (BossKillXPMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["BossKillXPMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float AlphaKillXPMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["AlphaKillXPMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["AlphaKillXPMultiplier"]) : 1f);
            }
            set
            {
                if (AlphaKillXPMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["AlphaKillXPMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float WildKillXPMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["WildKillXPMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["WildKillXPMultiplier"]) : 1f);
            }
            set
            {
                if (WildKillXPMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["WildKillXPMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float CaveKillXPMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["CaveKillXPMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["CaveKillXPMultiplier"]) : 1f);
            }
            set
            {
                if (CaveKillXPMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["CaveKillXPMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float TamedKillXPMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["TamedKillXPMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["TamedKillXPMultiplier"]) : 1f);
            }
            set
            {
                if (TamedKillXPMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["TamedKillXPMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float UnclaimedKillXPMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["UnclaimedKillXPMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["UnclaimedKillXPMultiplier"]) : 1f);
            }
            set
            {
                if (UnclaimedKillXPMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["UnclaimedKillXPMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float SupplyCrateLootQualityMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["SupplyCrateLootQualityMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["SupplyCrateLootQualityMultiplier"]) : 1f);
            }
            set
            {
                if (SupplyCrateLootQualityMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["SupplyCrateLootQualityMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float FishingLootQualityMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["FishingLootQualityMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["FishingLootQualityMultiplier"]) : 1f);
            }
            set
            {
                if (FishingLootQualityMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["FishingLootQualityMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float CraftingSkillBonusMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["CraftingSkillBonusMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["CraftingSkillBonusMultiplier"]) : 1f);
            }
            set
            {
                if (CraftingSkillBonusMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["CraftingSkillBonusMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float BabyImprintAmountMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["BabyImprintAmountMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["BabyImprintAmountMultiplier"]) : 1f);
            }
            set
            {
                if (BabyImprintAmountMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["BabyImprintAmountMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float PerPlatformMaxStructuresMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["PerPlatformMaxStructuresMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["PerPlatformMaxStructuresMultiplier"]) : 1f);
            }
            set
            {
                if (PerPlatformMaxStructuresMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["PerPlatformMaxStructuresMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int StructureDamageRepairCooldown
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["StructureDamageRepairCooldown"]) ? Convert.ToInt32(data["/Script/ShooterGame.ShooterGameMode"]["StructureDamageRepairCooldown"]) : 180);
            }
            set
            {
                if (StructureDamageRepairCooldown != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["StructureDamageRepairCooldown"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int IncreasePvPRespawnIntervalCheckPeriod
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["IncreasePvPRespawnIntervalCheckPeriod"]) ? Convert.ToInt32(data["/Script/ShooterGame.ShooterGameMode"]["IncreasePvPRespawnIntervalCheckPeriod"]) : 300);
            }
            set
            {
                if (IncreasePvPRespawnIntervalCheckPeriod != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["IncreasePvPRespawnIntervalCheckPeriod"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public float IncreasePvPRespawnIntervalMultiplier
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["IncreasePvPRespawnIntervalMultiplier"]) ? Convert.ToSingle(data["/Script/ShooterGame.ShooterGameMode"]["IncreasePvPRespawnIntervalMultiplier"]) : 1f);
            }
            set
            {
                if (IncreasePvPRespawnIntervalMultiplier != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["IncreasePvPRespawnIntervalMultiplier"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int IncreasePvPRespawnIntervalBaseAmount
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["IncreasePvPRespawnIntervalBaseAmount"]) ? Convert.ToInt32(data["/Script/ShooterGame.ShooterGameMode"]["IncreasePvPRespawnIntervalBaseAmount"]) : 60);
            }
            set
            {
                if (IncreasePvPRespawnIntervalBaseAmount != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["IncreasePvPRespawnIntervalBaseAmount"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int ResourceNoReplenishRadiusPlayers
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["ResourceNoReplenishRadiusPlayers"]) ? Convert.ToInt32(data["/Script/ShooterGame.ShooterGameMode"]["ResourceNoReplenishRadiusPlayers"]) : 1);
            }
            set
            {
                if (ResourceNoReplenishRadiusPlayers != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["ResourceNoReplenishRadiusPlayers"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int ResourceNoReplenishRadiusStructures
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["ResourceNoReplenishRadiusStructures"]) ? Convert.ToInt32(data["/Script/ShooterGame.ShooterGameMode"]["ResourceNoReplenishRadiusStructures"]) : 1);
            }
            set
            {
                if (ResourceNoReplenishRadiusStructures != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["ResourceNoReplenishRadiusStructures"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int AutoPvEStartTimeSeconds
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["AutoPvEStartTimeSeconds"]) ? Convert.ToInt32(data["/Script/ShooterGame.ShooterGameMode"]["AutoPvEStartTimeSeconds"]) : 0);
            }
            set
            {
                if (AutoPvEStartTimeSeconds != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["AutoPvEStartTimeSeconds"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int AutoPvEStopTimeSeconds
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["AutoPvEStopTimeSeconds"]) ? Convert.ToInt32(data["/Script/ShooterGame.ShooterGameMode"]["AutoPvEStopTimeSeconds"]) : 0);
            }
            set
            {
                if (AutoPvEStopTimeSeconds != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["AutoPvEStopTimeSeconds"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int PhotoModeRangeLimit
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["PhotoModeRangeLimit"]) ? Convert.ToInt32(data["/Script/ShooterGame.ShooterGameMode"]["PhotoModeRangeLimit"]) : 3000);
            }
            set
            {
                if (PhotoModeRangeLimit != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["PhotoModeRangeLimit"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int OverrideMaxExperiencePointsPlayer
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["OverrideMaxExperiencePointsPlayer"]) ? Convert.ToInt32(data["/Script/ShooterGame.ShooterGameMode"]["OverrideMaxExperiencePointsPlayer"]) : 0);
            }
            set
            {
                if (OverrideMaxExperiencePointsPlayer != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["OverrideMaxExperiencePointsPlayer"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public int OverrideMaxExperiencePointsDino
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["OverrideMaxExperiencePointsDino"]) ? Convert.ToInt32(data["/Script/ShooterGame.ShooterGameMode"]["OverrideMaxExperiencePointsDino"]) : 0);
            }
            set
            {
                if (OverrideMaxExperiencePointsDino != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["OverrideMaxExperiencePointsDino"] = value.ToString();
                    isDirty = true;
                }
            }
        }

        public bool MaxDifficulty
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["MaxDifficulty"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["MaxDifficulty"].ToLower()) : false);
            }
            set
            {
                if (MaxDifficulty != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["MaxDifficulty"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool UseCorpseLocator
        {
            get
            {
                return (!string.IsNullOrEmpty(data["ShooterGameMode_TEMPOverrides"]["bUseCorpseLocator"]) ? Convert.ToBoolean(data["ShooterGameMode_TEMPOverrides"]["bUseCorpseLocator"].ToLower()) : true);
            }
            set
            {
                if (UseCorpseLocator != value)
                {
                    data["ShooterGameMode_TEMPOverrides"]["bUseCorpseLocator"] = value.ToVBString();
                    data["/Script/ShooterGame.ShooterGameMode"]["bUseCorpseLocator"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool DisablePhotoMode
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bDisablePhotoMode"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bDisablePhotoMode"].ToLower()) : false);
            }
            set
            {
                if (DisablePhotoMode != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bDisablePhotoMode"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool IncreasePvPRespawnInterval
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bIncreasePvPRespawnInterval"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bIncreasePvPRespawnInterval"].ToLower()) : true);
            }
            set
            {
                if (IncreasePvPRespawnInterval != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bIncreasePvPRespawnInterval"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AutoPvETimer
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bAutoPvETimer"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bAutoPvETimer"].ToLower()) : false);
            }
            set
            {
                if (AutoPvETimer != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bAutoPvETimer"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AutoPvEUseSystemTime
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bAutoPvEUseSystemTime"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bAutoPvEUseSystemTime"].ToLower()) : false);
            }
            set
            {
                if (AutoPvEUseSystemTime != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bAutoPvEUseSystemTime"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool DisableFriendlyFire
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bDisableFriendlyFire"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bDisableFriendlyFire"].ToLower()) : false);
            }
            set
            {
                if (DisableFriendlyFire != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bDisableFriendlyFire"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool FlyerPlatformAllowUnalignedDinoBasing
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bFlyerPlatformAllowUnalignedDinoBasing"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bFlyerPlatformAllowUnalignedDinoBasing"].ToLower()) : false);
            }
            set
            {
                if (FlyerPlatformAllowUnalignedDinoBasing != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bFlyerPlatformAllowUnalignedDinoBasing"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool DisableLootCrates
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bDisableLootCrates"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bDisableLootCrates"].ToLower()) : false);
            }
            set
            {
                if (DisableLootCrates != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bDisableLootCrates"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AllowCustomRecipes
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bAllowCustomRecipes"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bAllowCustomRecipes"].ToLower()) : true);
            }
            set
            {
                if (AllowCustomRecipes != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bAllowCustomRecipes"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PassiveDefensesDamageRiderlessDinos
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bPassiveDefensesDamageRiderlessDinos"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bPassiveDefensesDamageRiderlessDinos"].ToLower()) : true);
            }
            set
            {
                if (PassiveDefensesDamageRiderlessDinos != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bPassiveDefensesDamageRiderlessDinos"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PvEAllowTribeWar
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bPvEAllowTribeWar"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bPvEAllowTribeWar"].ToLower()) : true);
            }
            set
            {
                if (PvEAllowTribeWar != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bPvEAllowTribeWar"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool PvEAllowTribeWarCancel
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bPvEAllowTribeWarCancel"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bPvEAllowTribeWarCancel"].ToLower()) : true);
            }
            set
            {
                if (PvEAllowTribeWarCancel != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bPvEAllowTribeWarCancel"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool UseSingleplayerSettings
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bUseSingleplayerSettings"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bUseSingleplayerSettings"].ToLower()) : false);
            }
            set
            {
                if (UseSingleplayerSettings != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bUseSingleplayerSettings"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool ShowCreativeMode
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bShowCreativeMode"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bShowCreativeMode"].ToLower()) : false);
            }
            set
            {
                if (ShowCreativeMode != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bShowCreativeMode"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool HardLimitTurretsInRange
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bHardLimitTurretsInRange"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bHardLimitTurretsInRange"].ToLower()) : false);
            }
            set
            {
                if (HardLimitTurretsInRange != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bHardLimitTurretsInRange"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool DisableStructurePlacementCollision
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bDisableStructurePlacementCollision"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bDisableStructurePlacementCollision"].ToLower()) : true);
            }
            set
            {
                if (DisableStructurePlacementCollision != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bDisableStructurePlacementCollision"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AllowPlatformSaddleMultiFloors
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bAllowPlatformSaddleMultiFloors"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bAllowPlatformSaddleMultiFloors"].ToLower()) : true);
            }
            set
            {
                if (AllowPlatformSaddleMultiFloors != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bAllowPlatformSaddleMultiFloors"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AllowUnlimitedRespecs
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bAllowUnlimitedRespecs"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bAllowUnlimitedRespecs"].ToLower()) : true);
            }
            set
            {
                if (AllowUnlimitedRespecs != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bAllowUnlimitedRespecs"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool DisableDinoRiding
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bDisableDinoRiding"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bDisableDinoRiding"].ToLower()) : false);
            }
            set
            {
                if (DisableDinoRiding != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bDisableDinoRiding"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool DisableDinoTaming
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bDisableDinoTaming"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bDisableDinoTaming"].ToLower()) : false);
            }
            set
            {
                if (DisableDinoTaming != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bDisableDinoTaming"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AllowSpeedLeveling
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bAllowSpeedLeveling"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bAllowSpeedLeveling"].ToLower()) : false);
            }
            set
            {
                if (AllowSpeedLeveling != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bAllowSpeedLeveling"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public bool AllowFlyerSpeedLeveling
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["bAllowFlyerSpeedLeveling"]) ? Convert.ToBoolean(data["/Script/ShooterGame.ShooterGameMode"]["bAllowFlyerSpeedLeveling"].ToLower()) : false);
            }
            set
            {
                if (AllowFlyerSpeedLeveling != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["bAllowFlyerSpeedLeveling"] = value.ToVBString();
                    isDirty = true;
                }
            }
        }

        public int MaxNumberOfPlayersInTribe
        {
            get
            {
                return (!string.IsNullOrEmpty(data["/Script/ShooterGame.ShooterGameMode"]["MaxNumberOfPlayersInTribe"]) ? Convert.ToInt32(data["/Script/ShooterGame.ShooterGameMode"]["MaxNumberOfPlayersInTribe"]) : 0);
            }
            set
            {
                if (MaxNumberOfPlayersInTribe != value)
                {
                    data["/Script/ShooterGame.ShooterGameMode"]["MaxNumberOfPlayersInTribe"] = value.ToString();
                    isDirty = true;
                }
            }
        }
    }
}
