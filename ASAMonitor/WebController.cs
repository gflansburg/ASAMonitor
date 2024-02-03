using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;
using Unosquare.Net;

namespace ASAMonitor
{
    internal class WebController : WebApiController
    {
        [WebApiHandler(HttpVerbs.Get, new string[] { "/", "/index.html" })]
        public Task<bool> GetIndex()
        {
            return this.StringResponseAsync(GetDefault(ConfigurationSettings.ASAConfig, new GameUserSettings(), new Game()), "text/html");
        }

        [WebApiHandler(HttpVerbs.Get, new string[] { "/login.html" })]
        public Task<bool> GetLogin()
        {
            string html = Utilities.GetEmbededWebResource("login.html");
            html = html.Replace("{Error}", string.Empty);
            return this.StringResponseAsync(html, "text/html");
        }

        [WebApiHandler(HttpVerbs.Get, new string[] { "/styles/togglebutton.css" })]
        public Task<bool> GetToogleButton()
        {
            return this.StringResponseAsync(ToggleButton.CssString("No", "Yes", new System.Web.UI.WebControls.Unit("100px")), "text/css");
        }

        private string GetDefault(ASAConfig config, GameUserSettings gus, Game game, bool redirect = true)
        {
            string html = string.Empty;
            if (redirect && (Request.Cookies["auth"] == null || Request.Cookies["auth"].Expired))
            {
                this.Redirect("/login.html");
            }
            else
            {
                html = Utilities.GetEmbededWebResource("index.html");
                html = html.Replace("{ServerStarted}", ASAMonitorForm.Instance.ServerRunning.ToString().ToLower());
                html = html.Replace("{Started}", !ASAMonitorForm.Paused ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{NoBattleEye}", config.NoBattleEye ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{ForceAllowCaveFlyers}", config.ForceAllowCaveFlyers ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{WinLiveMaxPlayers}", config.WinLiveMaxPlayers.ToString());
                html = html.Replace("{SessionName}", gus.SessionName);
                if (Request.Cookies["auth"] != null && (Request.Cookies["auth"].Value ?? "User").Equals("Admin"))
                {
                    html = html.Replace("{Passwords}", ASAMonitor.Properties.Resources.PasswordsHtml);
                    html = html.Replace("{ServerPassword}", gus.ServerPassword);
                    html = html.Replace("{ServerAdminPassword}", gus.ServerAdminPassword);
                }
                else
                {
                    html = html.Replace("{Passwords}", string.Empty);
                }
                html = html.Replace("{ShowMapPlayerLocation}", gus.ShowMapPlayerLocation ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AllowThirdPersonPlayer}", gus.AllowThirdPersonPlayer ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{FastDecayUnsnappedCoreStructures}", gus.FastDecayUnsnappedCoreStructures ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{OverrideStructurePlatformPrevention}", gus.OverrideStructurePlatformPrevention ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PreventOfflinePvP}", gus.PreventOfflinePvP ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AllowAnyoneBabyImprintCuddle}", gus.AllowAnyoneBabyImprintCuddle ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{DisableImprintDinoBuff}", gus.DisableImprintDinoBuff ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PvPDinoDecay}", gus.PvPDinoDecay ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PvPStructureDecay}", gus.PvPStructureDecay ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{OnlyAutoDestroyCoreStructures}", gus.OnlyAutoDestroyCoreStructures ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{ClampItemSpoilingTimes}", gus.ClampItemSpoilingTimes ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{ClampItemStats}", gus.ClampItemStats ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AutoDestroyDecayedDinos}", gus.AutoDestroyDecayedDinos ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PreventTribeAlliances}", gus.PreventTribeAlliances ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{ServerCrosshair}", gus.ServerCrosshair ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{RCONEnabled}", gus.RCONEnabled ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{RCONPort}", gus.RCONPort.ToString());
                html = html.Replace("{RCONServerGameLogBuffer}", gus.RCONServerGameLogBuffer.ToString());
                html = html.Replace("{PreventOfflinePvPInterval}", gus.PreventOfflinePvPInterval.ToString());
                html = html.Replace("{NewMaxStructuresInRange}", gus.NewMaxStructuresInRange.ToString());
                html = html.Replace("{StartTimeHour}", gus.StartTimeHour.ToString());
                html = html.Replace("{TribeNameChangeCooldown}", gus.TribeNameChangeCooldown.ToString());
                html = html.Replace("{AlwaysAllowStructurePickup}", gus.AlwaysAllowStructurePickup ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{StructurePickupTimeAfterPlacement}", gus.StructurePickupTimeAfterPlacement.ToString());
                html = html.Replace("{TamingSpeedMultiplier}", gus.TamingSpeedMultiplier.ToString());
                html = html.Replace("{OxygenSwimSpeedStatMultiplier}", gus.OxygenSwimSpeedStatMultiplier.ToString());
                html = html.Replace("{StructurePreventResourceRadiusMultiplier}", gus.StructurePreventResourceRadiusMultiplier.ToString());
                html = html.Replace("{PlatformSaddleBuildAreaBoundsMultiplier}", gus.PlatformSaddleBuildAreaBoundsMultiplier.ToString());
                html = html.Replace("{StructurePickupHoldDuration}", gus.StructurePickupHoldDuration.ToString());
                html = html.Replace("{AllowHideDamageSourceFromLogs}", gus.AllowHideDamageSourceFromLogs ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{RaidDinoCharacterFoodDrainMultiplier}", gus.RaidDinoCharacterFoodDrainMultiplier.ToString());
                html = html.Replace("{PvEDinoDecayPeriodMultiplier}", gus.PvEDinoDecayPeriodMultiplier.ToString());
                html = html.Replace("{KickIdlePlayersPeriod}", gus.KickIdlePlayersPeriod.ToString());
                html = html.Replace("{MaxPlatformSaddleStructureLimit}", gus.MaxPlatformSaddleStructureLimit.ToString());
                html = html.Replace("{AutoSavePeriodMinutes}", gus.AutoSavePeriodMinutes.ToString());
                html = html.Replace("{MaxTamedDinos}", gus.MaxTamedDinos.ToString());
                html = html.Replace("{ItemStackSizeMultiplier}", gus.ItemStackSizeMultiplier.ToString());
                html = html.Replace("{AllowRaidDinoFeeding}", gus.AllowRaidDinoFeeding ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{EnableExtraStructurePreventionVolumes}", gus.EnableExtraStructurePreventionVolumes ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{ShowFloatingDamageText}", gus.ShowFloatingDamageText ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{ImplantSuicideCD}", gus.ImplantSuicideCD.ToString());
                html = html.Replace("{PreventSpawnAnimations}", gus.PreventSpawnAnimations ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{CrossARKAllowForeignDinoDownloads}", gus.CrossARKAllowForeignDinoDownloads ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PreventDiseases}", gus.PreventDiseases ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{NonPermanentDiseases}", gus.NonPermanentDiseases ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{TribeLogDestroyedEnemyStructures}", gus.TribeLogDestroyedEnemyStructures ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PvEAllowStructuresAtSupplyDrops}", gus.PvEAllowStructuresAtSupplyDrops ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{UseOptimizedHarvestingHealth}", gus.UseOptimizedHarvestingHealth ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AllowMultipleAttachedC4}", gus.AllowMultipleAttachedC4 ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AllowFlyingStaminaRecovery}", gus.AllowFlyingStaminaRecovery ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AllowHitMarkers}", gus.AllowHitMarkers ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PreventDownloadSurvivors}", gus.PreventDownloadSurvivors ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PreventDownloadItems}", gus.PreventDownloadItems ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PreventDownloadDinos}", gus.PreventDownloadDinos ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PreventUploadSurvivors}", gus.PreventUploadSurvivors ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PreventUploadItems}", gus.PreventUploadItems ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PreventUploadDinos}", gus.PreventUploadDinos ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AllowCrateSpawnsOnTopOfStructures}", gus.AllowCrateSpawnsOnTopOfStructures ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{EnableCryopodNerf}", gus.EnableCryopodNerf ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{DifficultyOffset}", gus.DifficultyOffset.ToString());
                html = html.Replace("{OverrideOfficialDifficulty}", gus.OverrideOfficialDifficulty.ToString());
                html = html.Replace("{AllowFlyerCarryPvE}", gus.AllowFlyerCarryPvE ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{DontAlwaysNotifyPlayerJoined}", gus.DontAlwaysNotifyPlayerJoined ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{JoinNotifications}", gus.JoinNotifications ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{ShowStatusNotificationMessages}", gus.ShowStatusNotificationMessages ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{ServerPVE}", gus.ServerPVE ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{MaxTamedDinos_SoftTameLimit}", gus.MaxTamedDinos_SoftTameLimit.ToString());
                html = html.Replace("{MaxTamedDinos_SoftTameLimit_CountdownForDeletionDuration}", gus.MaxTamedDinos_SoftTameLimit_CountdownForDeletionDuration.ToString());
                html = html.Replace("{AllowCryoFridgeOnSaddle}", gus.AllowCryoFridgeOnSaddle ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{DisableCryopodEnemyCheck}", gus.DisableCryopodEnemyCheck ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{DisableCryopodFridgeRequirement}", gus.DisableCryopodFridgeRequirement ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{EnableCryoSicknessPVE}", gus.EnableCryoSicknessPVE ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{CryopodNerfDuration}", gus.CryopodNerfDuration.ToString());
                html = html.Replace("{CryopodNerfDamageMult}", gus.CryopodNerfDamageMult.ToString());
                html = html.Replace("{CryopodNerfIncomingDamageMultPercent}", gus.CryopodNerfIncomingDamageMultPercent.ToString());
                html = html.Replace("{XPMultiplier}", gus.XPMultiplier.ToString());
                html = html.Replace("{DayCycleSpeedScale}", gus.DayCycleSpeedScale.ToString());
                html = html.Replace("{DayTimeSpeedScale}", gus.DayTimeSpeedScale.ToString());
                html = html.Replace("{NightTimeSpeedScale}", gus.NightTimeSpeedScale.ToString());
                html = html.Replace("{HarvestAmountMultiplier}", gus.HarvestAmountMultiplier.ToString());
                html = html.Replace("{HarvestHealthMultiplier}", gus.HarvestHealthMultiplier.ToString());
                html = html.Replace("{DinoDamageMultiplier}", gus.DinoDamageMultiplier.ToString());
                html = html.Replace("{PlayerDamageMultiplier}", gus.PlayerDamageMultiplier.ToString());
                html = html.Replace("{StructureDamageMultiplier}", gus.StructureDamageMultiplier.ToString());
                html = html.Replace("{DinoResistanceMultiplier}", gus.DinoResistanceMultiplier.ToString());
                html = html.Replace("{PlayerResistanceMultiplier}", gus.PlayerResistanceMultiplier.ToString());
                html = html.Replace("{StructureResistanceMultiplier}", gus.StructureResistanceMultiplier.ToString());
                html = html.Replace("{PvEStructureDecayPeriodMultiplier}", gus.PvEStructureDecayPeriodMultiplier.ToString());
                html = html.Replace("{ResourcesRespawnPeriodMultiplier}", gus.ResourcesRespawnPeriodMultiplier.ToString());
                html = html.Replace("{PlayerCharacterWaterDrainMultiplier}", gus.PlayerCharacterWaterDrainMultiplier.ToString());
                html = html.Replace("{PlayerCharacterFoodDrainMultiplier}", gus.PlayerCharacterFoodDrainMultiplier.ToString());
                html = html.Replace("{DinoCharacterFoodDrainMultiplier}", gus.DinoCharacterFoodDrainMultiplier.ToString());
                html = html.Replace("{PlayerCharacterStaminaDrainMultiplier}", gus.PlayerCharacterStaminaDrainMultiplier.ToString());
                html = html.Replace("{DinoCharacterStaminaDrainMultiplier}", gus.DinoCharacterStaminaDrainMultiplier.ToString());
                html = html.Replace("{PlayerCharacterHealthRecoveryMultiplier}", gus.PlayerCharacterHealthRecoveryMultiplier.ToString());
                html = html.Replace("{DinoCharacterHealthRecoveryMultiplier}", gus.DinoCharacterHealthRecoveryMultiplier.ToString());
                html = html.Replace("{DinoCountMultiplier}", gus.DinoCountMultiplier.ToString());
                html = html.Replace("{NoTributeDownloads}", gus.NoTributeDownloads ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{OnlyAllowSpecifiedEngrams}", gus.OnlyAllowSpecifiedEngrams ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{ServerForceNoHUD}", gus.ServerForceNoHUD ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{GlobalVoiceChat}", gus.GlobalVoiceChat ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{ProximityChat}", gus.ProximityChat ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AlwaysNotifyPlayerLeft}", gus.AlwaysNotifyPlayerLeft ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{ServerHardcore}", gus.ServerHardcore ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{BattleNumOfTribesToStartGame}", gus.BattleNumOfTribesToStartGame.ToString());
                html = html.Replace("{TimeToCollapseROD}", gus.TimeToCollapseROD.ToString());
                html = html.Replace("{BattleAutoStartGameInterval}", gus.BattleAutoStartGameInterval.ToString());
                html = html.Replace("{BattleAutoRestartGameInterval}", gus.BattleAutoRestartGameInterval.ToString());
                html = html.Replace("{BattleSuddenDeathInterval}", gus.BattleSuddenDeathInterval.ToString());
                html = html.Replace("{DisablePvEGamma}", gus.DisablePvEGamma ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{DisableDinoDecayPvE}", gus.DisableDinoDecayPvE ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AdminLogging}", gus.AdminLogging ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{EnableDeathTeamSpectator}", gus.EnableDeathTeamSpectator ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{MessageOfTheDay}", gus.MessageOfTheDay);
                html = html.Replace("{MessageDuration}", gus.MessageDuration.ToString());
                html = html.Replace("{MaxDifficulty}", game.MaxDifficulty ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{DisablePhotoMode}", game.DisablePhotoMode ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{IncreasePvPRespawnInterval}", game.IncreasePvPRespawnInterval ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AutoPvETimer}", game.AutoPvETimer ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AutoPvEUseSystemTime}", game.AutoPvEUseSystemTime ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{DisableFriendlyFire}", game.DisableFriendlyFire ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{FlyerPlatformAllowUnalignedDinoBasing}", game.FlyerPlatformAllowUnalignedDinoBasing ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{DisableLootCrates}", game.DisableLootCrates ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AllowCustomRecipes}", game.AllowCustomRecipes ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PassiveDefensesDamageRiderlessDinos}", game.PassiveDefensesDamageRiderlessDinos ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PvEAllowTribeWar}", game.PvEAllowTribeWar ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{PvEAllowTribeWarCancel}", game.PvEAllowTribeWarCancel ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{UseSingleplayerSettings}", game.UseSingleplayerSettings ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{UseCorpseLocator}", game.UseCorpseLocator ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{ShowCreativeMode}", game.ShowCreativeMode ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{HardLimitTurretsInRange}", game.HardLimitTurretsInRange ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{DisableStructurePlacementCollision}", game.DisableStructurePlacementCollision ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AllowPlatformSaddleMultiFloors}", game.AllowPlatformSaddleMultiFloors ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AllowUnlimitedRespecs}", game.AllowUnlimitedRespecs ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{DisableDinoRiding}", game.DisableDinoRiding ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{DisableDinoTaming}", game.DisableDinoTaming ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AllowSpeedLeveling}", game.AllowSpeedLeveling ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{AllowFlyerSpeedLeveling}", game.AllowFlyerSpeedLeveling ? "checked=\"checked\"" : string.Empty);
                html = html.Replace("{StructureDamageRepairCooldown}", game.StructureDamageRepairCooldown.ToString());
                html = html.Replace("{IncreasePvPRespawnIntervalCheckPeriod}", game.IncreasePvPRespawnIntervalCheckPeriod.ToString());
                html = html.Replace("{IncreasePvPRespawnIntervalBaseAmount}", game.IncreasePvPRespawnIntervalBaseAmount.ToString());
                html = html.Replace("{ResourceNoReplenishRadiusPlayers}", game.ResourceNoReplenishRadiusPlayers.ToString());
                html = html.Replace("{ResourceNoReplenishRadiusStructures}", game.ResourceNoReplenishRadiusStructures.ToString());
                html = html.Replace("{AutoPvEStartTimeSeconds}", game.AutoPvEStartTimeSeconds.ToString());
                html = html.Replace("{AutoPvEStopTimeSeconds}", game.AutoPvEStopTimeSeconds.ToString());
                html = html.Replace("{PhotoModeRangeLimit}", game.PhotoModeRangeLimit.ToString());
                html = html.Replace("{OverrideMaxExperiencePointsPlayer}", game.OverrideMaxExperiencePointsPlayer.ToString());
                html = html.Replace("{OverrideMaxExperiencePointsDino}", game.OverrideMaxExperiencePointsDino.ToString());
                html = html.Replace("{MaxNumberOfPlayersInTribe}", game.MaxNumberOfPlayersInTribe.ToString());
                html = html.Replace("{BabyImprintingStatScaleMultiplier}", game.BabyImprintingStatScaleMultiplier.ToString());
                html = html.Replace("{BabyCuddleIntervalMultiplier}", game.BabyCuddleIntervalMultiplier.ToString());
                html = html.Replace("{BabyCuddleGracePeriodMultiplier}", game.BabyCuddleGracePeriodMultiplier.ToString());
                html = html.Replace("{BabyCuddleLoseImprintQualitySpeedMultiplier}", game.BabyCuddleLoseImprintQualitySpeedMultiplier.ToString());
                html = html.Replace("{GlobalSpoilingTimeMultiplier}", game.GlobalSpoilingTimeMultiplier.ToString());
                html = html.Replace("{GlobalItemDecompositionTimeMultiplier}", game.GlobalItemDecompositionTimeMultiplier.ToString());
                html = html.Replace("{GlobalCorpseDecompositionTimeMultiplier}", game.GlobalCorpseDecompositionTimeMultiplier.ToString());
                html = html.Replace("{PvPZoneStructureDamageMultiplier}", game.PvPZoneStructureDamageMultiplier.ToString());
                html = html.Replace("{IncreasePvPRespawnIntervalMultiplier}", game.IncreasePvPRespawnIntervalMultiplier.ToString());
                html = html.Replace("{CropGrowthSpeedMultiplier}", game.CropGrowthSpeedMultiplier.ToString());
                html = html.Replace("{LayEggIntervalMultiplier}", game.LayEggIntervalMultiplier.ToString());
                html = html.Replace("{PoopIntervalMultiplier}", game.PoopIntervalMultiplier.ToString());
                html = html.Replace("{CropDecaySpeedMultiplier}", game.CropDecaySpeedMultiplier.ToString());
                html = html.Replace("{MatingIntervalMultiplier}", game.MatingIntervalMultiplier.ToString());
                html = html.Replace("{EggHatchSpeedMultiplier}", game.EggHatchSpeedMultiplier.ToString());
                html = html.Replace("{BabyMatureSpeedMultiplier}", game.BabyMatureSpeedMultiplier.ToString());
                html = html.Replace("{BabyFoodConsumptionSpeedMultiplier}", game.BabyFoodConsumptionSpeedMultiplier.ToString());
                html = html.Replace("{DinoTurretDamageMultiplier}", game.DinoTurretDamageMultiplier.ToString());
                html = html.Replace("{DinoHarvestingDamageMultiplier}", game.DinoHarvestingDamageMultiplier.ToString());
                html = html.Replace("{PlayerHarvestingDamageMultiplier}", game.PlayerHarvestingDamageMultiplier.ToString());
                html = html.Replace("{CustomRecipeEffectivenessMultiplier}", game.CustomRecipeEffectivenessMultiplier.ToString());
                html = html.Replace("{CustomRecipeSkillMultiplier}", game.CustomRecipeSkillMultiplier.ToString());
                html = html.Replace("{KillXPMultiplier}", game.KillXPMultiplier.ToString());
                html = html.Replace("{HarvestXPMultiplier}", game.HarvestXPMultiplier.ToString());
                html = html.Replace("{CraftXPMultiplier}", game.CraftXPMultiplier.ToString());
                html = html.Replace("{GenericXPMultiplier}", game.GenericXPMultiplier.ToString());
                html = html.Replace("{SpecialXPMultiplier}", game.SpecialXPMultiplier.ToString());
                html = html.Replace("{FuelConsumptionIntervalMultiplier}", game.FuelConsumptionIntervalMultiplier.ToString());
                html = html.Replace("{ExplorerNoteXPMultiplier}", game.ExplorerNoteXPMultiplier.ToString());
                html = html.Replace("{BossKillXPMultiplier}", game.BossKillXPMultiplier.ToString());
                html = html.Replace("{AlphaKillXPMultiplier}", game.AlphaKillXPMultiplier.ToString());
                html = html.Replace("{WildKillXPMultiplier}", game.WildKillXPMultiplier.ToString());
                html = html.Replace("{CaveKillXPMultiplier}", game.CaveKillXPMultiplier.ToString());
                html = html.Replace("{TamedKillXPMultiplier}", game.TamedKillXPMultiplier.ToString());
                html = html.Replace("{UnclaimedKillXPMultiplier}", game.UnclaimedKillXPMultiplier.ToString());
                html = html.Replace("{SupplyCrateLootQualityMultiplier}", game.SupplyCrateLootQualityMultiplier.ToString());
                html = html.Replace("{FishingLootQualityMultiplier}", game.FishingLootQualityMultiplier.ToString());
                html = html.Replace("{CraftingSkillBonusMultiplier}", game.CraftingSkillBonusMultiplier.ToString());
                html = html.Replace("{BabyImprintAmountMultiplier}", game.BabyImprintAmountMultiplier.ToString());
                html = html.Replace("{PerPlatformMaxStructuresMultiplier}", game.PerPlatformMaxStructuresMultiplier.ToString());
                html = html.Replace("{Mods}", string.Join(",", config.Mods));
                StringBuilder sb = new StringBuilder();
                foreach(int id in config.Mods)
                {
                    CurseForge.Datum mod = Utilities.Mods != null ? Utilities.Mods.FirstOrDefault(m => m.id == id) : null;
                    sb.Append(string.Format("<tr><td width=\"67%\" valign=\"top\"><div class=\"formField\"><img class=\"modLogo\" src=\"{3}\"{4} /><div style=\"padding: 5px;\"><div class=\"modId\">{0}</div><{6}{7} class=\"modName\">{1}</{6}><div class=\"modCategory\">{5}</div><div class=\"modSummary\">{2}</div></div><br style=\"clear: both; height: 0;\" /></div></td><td valign=\"top\"><div class=\"formValue\"><input class=\"DeleteMod\" id=\"DeleteMod_{0}\" name=\"DeleteMod_{0}\" type=\"submit\" value=\"Remove Mod\" class=\"secondaryButton\" data-uid=\"{0}\" data-name=\"{1}\" /></div></td></tr>", id, mod != null ? mod.name.Replace("\"", "&quot;") : string.Empty, mod != null ? mod.summary : string.Empty, mod != null && mod.logo != null ? mod.logo.url : string.Empty, mod == null || mod.logo == null ? " style=\"display: none\"" : string.Empty, mod != null ? mod.categories.FirstOrDefault(c => c.id == mod.primaryCategoryId) != null ? mod.categories.FirstOrDefault(c => c.id == mod.primaryCategoryId).name : string.Empty : string.Empty, mod.links != null && !string.IsNullOrEmpty(mod.links.websiteUrl) ? "a" : "div", mod.links != null && !string.IsNullOrEmpty(mod.links.websiteUrl) ? string.Format(" href=\"{0}\" target=\"_blank\" alt=\"{1}\" title=\"{1}\"", mod.links.websiteUrl, "Visit Mod Website") : string.Empty));
                }
                html = html.Replace("{ModsList}", sb.ToString());
                html = html.Replace("{ResizeTabs}", ConfigurationSettings.MobileHideThirdParty ? "resizeTabs();" : string.Empty);
                html = html.Replace("{ ResizeTabs }", ConfigurationSettings.MobileHideThirdParty ? "resizeTabs();" : string.Empty);
                if (ConfigurationSettings.ThirdPartyEdit)
                {
                    sb = new StringBuilder();
                    int index = 4;
                    List<IniParser.Model.SectionData> sections = gus.CustomSections.OrderBy(s => s.SectionName).ToList();
                    foreach (IniParser.Model.SectionData section in sections)
                    {
                        sb.AppendLine(string.Format("<li class=\"thirdPartyMod\"><a href=\"#tab-{0}\">{1}</a></li>", index, section.SectionName.Replace("_", string.Empty).FromCamelCase()));
                        index++;
                    }
                    html = html.Replace("{CustomTabs}", sb.ToString());
                    sb = new StringBuilder();
                    index = 4;
                    foreach (IniParser.Model.SectionData section in sections)
                    {
                        sb.AppendLine(string.Format("<div id=\"tab-{0}\" class=\"tabPage\">", index));
                        sb.AppendLine(" <div class=\"form-horizontal\">");
                        List<IniParser.Model.KeyData> keys = section.Keys.OrderBy(k => k.KeyName).ToList();
                        foreach (IniParser.Model.KeyData key in keys)
                        {
                            sb.AppendLine("     <div class=\"RecordDisplay\">");
                            sb.AppendLine("         <label>");
                            sb.AppendLine(string.Format("         <span class=\"FieldName\"><label class=\"control-label\" for=\"{1}\">{0}:</label></span>", key.KeyName.Replace("_", string.Empty).FromCamelCase(), key.KeyName));
                            sb.AppendLine("         <div class=\"FormInputField\">");
                            if (key.Value.IsBool())
                            {
                                sb.AppendLine("             <div class=\"toggleButton\">");
                                sb.AppendLine(string.Format("                 <label><input id=\"{0}_{1}\" name=\"{0}_{1}\" type=\"checkbox\" {2} /><span></span></label>", section.SectionName, key.KeyName, Convert.ToBoolean(key.Value.ToLower()) ? "checked=\"checked\"" : string.Empty));
                                sb.AppendLine("             </div>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("             <input id=\"{0}_{1}\" name=\"{0}_{1}\" type=\"{3}\" {4} value=\"{2}\" />", section.SectionName, key.KeyName, key.Value, key.Value.IsDecimal() ? "number" : "text", key.Value.IsDecimal() ? " step=\"any\"" : string.Empty));
                            }
                            sb.AppendLine("             </div>");
                            sb.AppendLine("         </label>");
                            sb.AppendLine("     </div>");
                        }
                        sb.AppendLine(" </div>");
                        sb.AppendLine("</div>");
                        index++;
                    }
                    html = html.Replace("{CustomTabPages}", sb.ToString());
                }
                else
                {
                    html = html.Replace("{CustomTabs}", string.Empty);
                    html = html.Replace("{CustomTabPages}", string.Empty);
                }
            }
            return html;
        }

        [WebApiHandler(HttpVerbs.Post, new string[] { "/", "/index.html" })]
        public Task<bool> PostIndex()
        {
            ASAConfig config = ConfigurationSettings.ASAConfig;
            GameUserSettings gus = new GameUserSettings();
            Game game = new Game();
            NameValueCollection form;
            using (TextReader reader = new StreamReader(Request.InputStream))
            {
                string body = reader.ReadToEnd();
                form = HttpUtility.ParseQueryString(body);
            }
            config.ForceAllowCaveFlyers = !string.IsNullOrEmpty(form["ForceAllowCaveFlyers"]);
            config.NoBattleEye = !string.IsNullOrEmpty(form["NoBattleEye"]);
            config.WinLiveMaxPlayers = Convert.ToInt32(form["WinLiveMaxPlayers"]);
            gus.MaxPlayers = Convert.ToInt32(form["WinLiveMaxPlayers"]);
            gus.SessionName = form["SessionName"];
            if (Request.Cookies["auth"] != null && (Request.Cookies["auth"].Value ?? "User").Equals("Admin"))
            {
                gus.ServerPassword = form["ServerPassword"];
                gus.ServerAdminPassword = form["ServerAdminPassword"];
            }
            gus.ShowMapPlayerLocation = !string.IsNullOrEmpty(form["ShowMapPlayerLocation"]);
            gus.AllowThirdPersonPlayer = !string.IsNullOrEmpty(form["AllowThirdPersonPlayer"]);
            gus.FastDecayUnsnappedCoreStructures = !string.IsNullOrEmpty(form["FastDecayUnsnappedCoreStructures"]);
            gus.OverrideStructurePlatformPrevention = !string.IsNullOrEmpty(form["OverrideStructurePlatformPrevention"]);
            gus.PreventOfflinePvP = !string.IsNullOrEmpty(form["PreventOfflinePvP"]);
            gus.TamingSpeedMultiplier = Convert.ToSingle(form["TamingSpeedMultiplier"]);
            gus.AllowAnyoneBabyImprintCuddle = !string.IsNullOrEmpty(form["AllowAnyoneBabyImprintCuddle"]);
            gus.DisableImprintDinoBuff = !string.IsNullOrEmpty(form["DisableImprintDinoBuff"]);
            gus.PvPDinoDecay = !string.IsNullOrEmpty(form["PvPDinoDecay"]);
            gus.PvPStructureDecay = !string.IsNullOrEmpty(form["PvPStructureDecay"]);
            gus.OnlyAutoDestroyCoreStructures = !string.IsNullOrEmpty(form["OnlyAutoDestroyCoreStructures"]);
            gus.ClampItemSpoilingTimes = !string.IsNullOrEmpty(form["ClampItemSpoilingTimes"]);
            gus.ClampItemStats = !string.IsNullOrEmpty(form["ClampItemStats"]);
            gus.AutoDestroyDecayedDinos = !string.IsNullOrEmpty(form["AutoDestroyDecayedDinos"]);
            gus.PreventTribeAlliances = !string.IsNullOrEmpty(form["PreventTribeAlliances"]);
            gus.ServerCrosshair = !string.IsNullOrEmpty(form["ServerCrosshair"]);
            gus.RCONEnabled = !string.IsNullOrEmpty(form["RCONEnabled"]);
            gus.RCONPort = Convert.ToInt32(form["RCONPort"]);
            gus.RCONServerGameLogBuffer = Convert.ToInt32(form["RCONServerGameLogBuffer"]);
            gus.PreventOfflinePvPInterval = Convert.ToInt32(form["PreventOfflinePvPInterval"]);
            gus.NewMaxStructuresInRange = Convert.ToInt32(form["NewMaxStructuresInRange"]);
            gus.StartTimeHour = Convert.ToInt32(form["StartTimeHour"]);
            gus.TribeNameChangeCooldown = Convert.ToInt32(form["TribeNameChangeCooldown"]);
            gus.StructurePickupTimeAfterPlacement = Convert.ToInt32(form["StructurePickupTimeAfterPlacement"]);
            gus.OxygenSwimSpeedStatMultiplier = Convert.ToSingle(form["OxygenSwimSpeedStatMultiplier"]);
            gus.StructurePreventResourceRadiusMultiplier = Convert.ToSingle(form["StructurePreventResourceRadiusMultiplier"]);
            gus.PlatformSaddleBuildAreaBoundsMultiplier = Convert.ToSingle(form["PlatformSaddleBuildAreaBoundsMultiplier"]);
            gus.AlwaysAllowStructurePickup = !string.IsNullOrEmpty(form["AlwaysAllowStructurePickup"]);
            gus.StructurePickupHoldDuration = Convert.ToSingle(form["StructurePickupHoldDuration"]);
            gus.AllowHideDamageSourceFromLogs = !string.IsNullOrEmpty(form["AllowHideDamageSourceFromLogs"]);
            gus.RaidDinoCharacterFoodDrainMultiplier = Convert.ToSingle(form["RaidDinoCharacterFoodDrainMultiplier"]);
            gus.PvEDinoDecayPeriodMultiplier = Convert.ToSingle(form["PvEDinoDecayPeriodMultiplier"]);
            gus.KickIdlePlayersPeriod = Convert.ToSingle(form["KickIdlePlayersPeriod"]);
            gus.PerPlatformMaxStructuresMultiplier = Convert.ToSingle(form["PerPlatformMaxStructuresMultiplier"]);
            gus.MaxPlatformSaddleStructureLimit = Convert.ToInt32(form["MaxPlatformSaddleStructureLimit"]);
            gus.AutoSavePeriodMinutes = Convert.ToInt32(form["AutoSavePeriodMinutes"]);
            gus.MaxTamedDinos = Convert.ToInt32(form["MaxTamedDinos"]);
            gus.ItemStackSizeMultiplier = Convert.ToInt32(form["ItemStackSizeMultiplier"]);
            gus.AllowRaidDinoFeeding = !string.IsNullOrEmpty(form["AllowRaidDinoFeeding"]);
            gus.EnableExtraStructurePreventionVolumes = !string.IsNullOrEmpty(form["EnableExtraStructurePreventionVolumes"]);
            gus.ShowFloatingDamageText = !string.IsNullOrEmpty(form["ShowFloatingDamageText"]);
            gus.ImplantSuicideCD = Convert.ToInt32(form["ImplantSuicideCD"]);
            gus.PreventSpawnAnimations = !string.IsNullOrEmpty(form["PreventSpawnAnimations"]);
            gus.CrossARKAllowForeignDinoDownloads = !string.IsNullOrEmpty(form["CrossARKAllowForeignDinoDownloads"]);
            gus.PreventDiseases = !string.IsNullOrEmpty(form["PreventDiseases"]);
            gus.NonPermanentDiseases = !string.IsNullOrEmpty(form["NonPermanentDiseases"]);
            gus.TribeLogDestroyedEnemyStructures = !string.IsNullOrEmpty(form["TribeLogDestroyedEnemyStructures"]);
            gus.PvEAllowStructuresAtSupplyDrops = !string.IsNullOrEmpty(form["PvEAllowStructuresAtSupplyDrops"]);
            gus.UseOptimizedHarvestingHealth = !string.IsNullOrEmpty(form["UseOptimizedHarvestingHealth"]);
            gus.AllowMultipleAttachedC4 = !string.IsNullOrEmpty(form["AllowMultipleAttachedC4"]);
            gus.AllowFlyingStaminaRecovery = !string.IsNullOrEmpty(form["AllowFlyingStaminaRecovery"]);
            gus.AllowHitMarkers = !string.IsNullOrEmpty(form["AllowHitMarkers"]);
            gus.PreventDownloadSurvivors = !string.IsNullOrEmpty(form["PreventDownloadSurvivors"]);
            gus.PreventDownloadItems = !string.IsNullOrEmpty(form["PreventDownloadItems"]);
            gus.PreventDownloadDinos = !string.IsNullOrEmpty(form["PreventDownloadDinos"]);
            gus.PreventUploadSurvivors = !string.IsNullOrEmpty(form["PreventUploadSurvivors"]);
            gus.PreventUploadItems = !string.IsNullOrEmpty(form["PreventUploadItems"]);
            gus.PreventUploadDinos = !string.IsNullOrEmpty(form["PreventUploadDinos"]);
            gus.AllowCrateSpawnsOnTopOfStructures = !string.IsNullOrEmpty(form["AllowCrateSpawnsOnTopOfStructures"]);
            gus.EnableCryopodNerf = !string.IsNullOrEmpty(form["EnableCryopodNerf"]);
            gus.DifficultyOffset = Convert.ToSingle(form["DifficultyOffset"]);
            gus.OverrideOfficialDifficulty = Convert.ToSingle(form["OverrideOfficialDifficulty"]);
            gus.AllowFlyerCarryPvE = !string.IsNullOrEmpty(form["AllowFlyerCarryPvE"]);
            gus.DontAlwaysNotifyPlayerJoined = !string.IsNullOrEmpty(form["DontAlwaysNotifyPlayerJoined"]);
            gus.JoinNotifications = !string.IsNullOrEmpty(form["JoinNotifications"]);
            gus.ShowStatusNotificationMessages = !string.IsNullOrEmpty(form["ShowStatusNotificationMessages"]);
            gus.ServerPVE = !string.IsNullOrEmpty(form["ServerPVE"]);
            gus.MaxTamedDinos_SoftTameLimit = Convert.ToInt32(form["MaxTamedDinos_SoftTameLimit"]);
            gus.MaxTamedDinos_SoftTameLimit_CountdownForDeletionDuration = Convert.ToInt32(form["MaxTamedDinos_SoftTameLimit_CountdownForDeletionDuration"]);
            gus.AllowCryoFridgeOnSaddle = !string.IsNullOrEmpty(form["AllowCryoFridgeOnSaddle"]);
            gus.DisableCryopodEnemyCheck = !string.IsNullOrEmpty(form["DisableCryopodEnemyCheck"]);
            gus.DisableCryopodFridgeRequirement = !string.IsNullOrEmpty(form["DisableCryopodFridgeRequirement"]);
            gus.EnableCryoSicknessPVE = !string.IsNullOrEmpty(form["EnableCryoSicknessPVE"]);
            gus.CryopodNerfDuration = Convert.ToInt32(form["CryopodNerfDuration"]);
            gus.CryopodNerfDamageMult = Convert.ToSingle(form["CryopodNerfDamageMult"]);
            gus.CryopodNerfIncomingDamageMultPercent = Convert.ToInt32(form["CryopodNerfIncomingDamageMultPercent"]);
            gus.XPMultiplier = Convert.ToSingle(form["XPMultiplier"]);
            gus.DayCycleSpeedScale = Convert.ToSingle(form["DayCycleSpeedScale"]);
            gus.DayTimeSpeedScale = Convert.ToSingle(form["DayTimeSpeedScale"]);
            gus.NightTimeSpeedScale = Convert.ToSingle(form["NightTimeSpeedScale"]);
            gus.HarvestAmountMultiplier = Convert.ToSingle(form["HarvestAmountMultiplier"]);
            gus.HarvestHealthMultiplier = Convert.ToSingle(form["HarvestHealthMultiplier"]);
            gus.DinoDamageMultiplier = Convert.ToSingle(form["DinoDamageMultiplier"]);
            gus.PlayerDamageMultiplier = Convert.ToSingle(form["PlayerDamageMultiplier"]);
            gus.StructureDamageMultiplier = Convert.ToSingle(form["StructureDamageMultiplier"]);
            gus.DinoResistanceMultiplier = Convert.ToSingle(form["DinoResistanceMultiplier"]);
            gus.PlayerResistanceMultiplier = Convert.ToSingle(form["PlayerResistanceMultiplier"]);
            gus.StructureResistanceMultiplier = Convert.ToSingle(form["StructureResistanceMultiplier"]);
            gus.PvEStructureDecayPeriodMultiplier = Convert.ToSingle(form["PvEStructureDecayPeriodMultiplier"]);
            gus.ResourcesRespawnPeriodMultiplier = Convert.ToSingle(form["ResourcesRespawnPeriodMultiplier"]);
            gus.PlayerCharacterWaterDrainMultiplier = Convert.ToSingle(form["PlayerCharacterWaterDrainMultiplier"]);
            gus.PlayerCharacterFoodDrainMultiplier = Convert.ToSingle(form["PlayerCharacterFoodDrainMultiplier"]);
            gus.DinoCharacterFoodDrainMultiplier = Convert.ToSingle(form["DinoCharacterFoodDrainMultiplier"]);
            gus.PlayerCharacterStaminaDrainMultiplier = Convert.ToSingle(form["PlayerCharacterStaminaDrainMultiplier"]);
            gus.DinoCharacterStaminaDrainMultiplier = Convert.ToSingle(form["DinoCharacterStaminaDrainMultiplier"]);
            gus.PlayerCharacterHealthRecoveryMultiplier = Convert.ToSingle(form["PlayerCharacterHealthRecoveryMultiplier"]);
            gus.DinoCharacterHealthRecoveryMultiplier = Convert.ToSingle(form["DinoCharacterHealthRecoveryMultiplier"]);
            gus.DinoCountMultiplier = Convert.ToSingle(form["DinoCountMultiplier"]);
            gus.NoTributeDownloads = !string.IsNullOrEmpty(form["NoTributeDownloads"]);
            gus.OnlyAllowSpecifiedEngrams = !string.IsNullOrEmpty(form["OnlyAllowSpecifiedEngrams"]);
            gus.ServerForceNoHUD = !string.IsNullOrEmpty(form["ServerForceNoHUD"]);
            gus.GlobalVoiceChat = !string.IsNullOrEmpty(form["GlobalVoiceChat"]);
            gus.ProximityChat = !string.IsNullOrEmpty(form["ProximityChat"]);
            gus.AlwaysNotifyPlayerLeft = !string.IsNullOrEmpty(form["AlwaysNotifyPlayerLeft"]);
            gus.ServerHardcore = !string.IsNullOrEmpty(form["ServerHardcore"]);
            gus.BattleNumOfTribesToStartGame = Convert.ToInt32(form["BattleNumOfTribesToStartGame"]);
            gus.TimeToCollapseROD = Convert.ToSingle(form["TimeToCollapseROD"]);
            gus.BattleAutoStartGameInterval = Convert.ToSingle(form["BattleAutoStartGameInterval"]);
            gus.BattleAutoRestartGameInterval = Convert.ToSingle(form["BattleAutoRestartGameInterval"]);
            gus.BattleSuddenDeathInterval = Convert.ToSingle(form["BattleSuddenDeathInterval"]);
            gus.DisablePvEGamma = !string.IsNullOrEmpty(form["DisablePvEGamma"]);
            gus.DisableDinoDecayPvE = !string.IsNullOrEmpty(form["DisableDinoDecayPvE"]);
            gus.AdminLogging = !string.IsNullOrEmpty(form["AdminLogging"]);
            gus.EnableDeathTeamSpectator = !string.IsNullOrEmpty(form["EnableDeathTeamSpectator"]);
            gus.MessageOfTheDay = form["MessageOfTheDay"];
            gus.MessageDuration = Convert.ToInt32(form["MessageDuration"]);
            game.MaxDifficulty = !string.IsNullOrEmpty(form["MaxDifficulty"]);
            game.DisablePhotoMode = !string.IsNullOrEmpty(form["DisablePhotoMode"]);
            game.IncreasePvPRespawnInterval = !string.IsNullOrEmpty(form["IncreasePvPRespawnInterval"]);
            game.AutoPvETimer = !string.IsNullOrEmpty(form["AutoPvETimer"]);
            game.AutoPvEUseSystemTime = !string.IsNullOrEmpty(form["AutoPvEUseSystemTime"]);
            game.DisableFriendlyFire = !string.IsNullOrEmpty(form["DisableFriendlyFire"]);
            game.FlyerPlatformAllowUnalignedDinoBasing = !string.IsNullOrEmpty(form["FlyerPlatformAllowUnalignedDinoBasing"]);
            game.DisableLootCrates = !string.IsNullOrEmpty(form["DisableLootCrates"]);
            game.AllowCustomRecipes = !string.IsNullOrEmpty(form["AllowCustomRecipes"]);
            game.PassiveDefensesDamageRiderlessDinos = !string.IsNullOrEmpty(form["PassiveDefensesDamageRiderlessDinos"]);
            game.PvEAllowTribeWar = !string.IsNullOrEmpty(form["PvEAllowTribeWar"]);
            game.PvEAllowTribeWarCancel = !string.IsNullOrEmpty(form["PvEAllowTribeWarCancel"]);
            game.UseSingleplayerSettings = !string.IsNullOrEmpty(form["UseSingleplayerSettings"]);
            game.UseCorpseLocator = !string.IsNullOrEmpty(form["UseCorpseLocator"]);
            game.ShowCreativeMode = !string.IsNullOrEmpty(form["ShowCreativeMode"]);
            game.HardLimitTurretsInRange = !string.IsNullOrEmpty(form["HardLimitTurretsInRange"]);
            game.DisableStructurePlacementCollision = !string.IsNullOrEmpty(form["DisableStructurePlacementCollision"]);
            game.AllowPlatformSaddleMultiFloors = !string.IsNullOrEmpty(form["AllowPlatformSaddleMultiFloors"]);
            game.AllowUnlimitedRespecs = !string.IsNullOrEmpty(form["AllowUnlimitedRespecs"]);
            game.DisableDinoRiding = !string.IsNullOrEmpty(form["DisableDinoRiding"]);
            game.DisableDinoTaming = !string.IsNullOrEmpty(form["DisableDinoTaming"]);
            game.AllowFlyerSpeedLeveling = !string.IsNullOrEmpty(form["AllowFlyerSpeedLeveling"]);
            game.AllowSpeedLeveling = !string.IsNullOrEmpty(form["AllowSpeedLeveling"]);
            game.StructureDamageRepairCooldown = Convert.ToInt32(form["StructureDamageRepairCooldown"]);
            game.IncreasePvPRespawnIntervalCheckPeriod = Convert.ToInt32(form["IncreasePvPRespawnIntervalCheckPeriod"]);
            game.IncreasePvPRespawnIntervalBaseAmount = Convert.ToInt32(form["IncreasePvPRespawnIntervalBaseAmount"]);
            game.ResourceNoReplenishRadiusPlayers = Convert.ToInt32(form["ResourceNoReplenishRadiusPlayers"]);
            game.ResourceNoReplenishRadiusStructures = Convert.ToInt32(form["ResourceNoReplenishRadiusStructures"]);
            game.AutoPvEStartTimeSeconds = Convert.ToInt32(form["AutoPvEStartTimeSeconds"]);
            game.AutoPvEStopTimeSeconds = Convert.ToInt32(form["AutoPvEStopTimeSeconds"]);
            game.PhotoModeRangeLimit = Convert.ToInt32(form["PhotoModeRangeLimit"]);
            game.OverrideMaxExperiencePointsPlayer = Convert.ToInt32(form["OverrideMaxExperiencePointsPlayer"]);
            game.MaxNumberOfPlayersInTribe = Convert.ToInt32(form["MaxNumberOfPlayersInTribe"]);
            game.BabyImprintingStatScaleMultiplier = Convert.ToSingle(form["BabyImprintingStatScaleMultiplier"]);
            game.BabyCuddleIntervalMultiplier = Convert.ToSingle(form["BabyCuddleIntervalMultiplier"]);
            game.BabyCuddleGracePeriodMultiplier = Convert.ToSingle(form["BabyCuddleGracePeriodMultiplier"]);
            game.BabyCuddleLoseImprintQualitySpeedMultiplier = Convert.ToSingle(form["BabyCuddleLoseImprintQualitySpeedMultiplier"]);
            game.GlobalSpoilingTimeMultiplier = Convert.ToSingle(form["GlobalSpoilingTimeMultiplier"]);
            game.GlobalItemDecompositionTimeMultiplier = Convert.ToSingle(form["GlobalItemDecompositionTimeMultiplier"]);
            game.GlobalCorpseDecompositionTimeMultiplier = Convert.ToSingle(form["GlobalCorpseDecompositionTimeMultiplier"]);
            game.PvPZoneStructureDamageMultiplier = Convert.ToSingle(form["PvPZoneStructureDamageMultiplier"]);
            game.IncreasePvPRespawnIntervalMultiplier = Convert.ToSingle(form["IncreasePvPRespawnIntervalMultiplier"]);
            game.CropGrowthSpeedMultiplier = Convert.ToSingle(form["CropGrowthSpeedMultiplier"]);
            game.LayEggIntervalMultiplier = Convert.ToSingle(form["LayEggIntervalMultiplier"]);
            game.PoopIntervalMultiplier = Convert.ToSingle(form["PoopIntervalMultiplier"]);
            game.CropDecaySpeedMultiplier = Convert.ToSingle(form["CropDecaySpeedMultiplier"]);
            game.MatingIntervalMultiplier = Convert.ToSingle(form["MatingIntervalMultiplier"]);
            game.EggHatchSpeedMultiplier = Convert.ToSingle(form["EggHatchSpeedMultiplier"]);
            game.BabyMatureSpeedMultiplier = Convert.ToSingle(form["BabyMatureSpeedMultiplier"]);
            game.BabyFoodConsumptionSpeedMultiplier = Convert.ToSingle(form["BabyFoodConsumptionSpeedMultiplier"]);
            game.DinoTurretDamageMultiplier = Convert.ToSingle(form["DinoTurretDamageMultiplier"]);
            game.DinoHarvestingDamageMultiplier = Convert.ToSingle(form["DinoHarvestingDamageMultiplier"]);
            game.PlayerHarvestingDamageMultiplier = Convert.ToSingle(form["PlayerHarvestingDamageMultiplier"]);
            game.CustomRecipeEffectivenessMultiplier = Convert.ToSingle(form["CustomRecipeEffectivenessMultiplier"]);
            game.CustomRecipeSkillMultiplier = Convert.ToSingle(form["CustomRecipeSkillMultiplier"]);
            game.KillXPMultiplier = Convert.ToSingle(form["KillXPMultiplier"]);
            game.HarvestXPMultiplier = Convert.ToSingle(form["HarvestXPMultiplier"]);
            game.CraftXPMultiplier = Convert.ToSingle(form["CraftXPMultiplier"]);
            game.GenericXPMultiplier = Convert.ToSingle(form["GenericXPMultiplier"]);
            game.SpecialXPMultiplier = Convert.ToSingle(form["SpecialXPMultiplier"]);
            game.FuelConsumptionIntervalMultiplier = Convert.ToSingle(form["FuelConsumptionIntervalMultiplier"]);
            game.ExplorerNoteXPMultiplier = Convert.ToSingle(form["ExplorerNoteXPMultiplier"]);
            game.BossKillXPMultiplier = Convert.ToSingle(form["BossKillXPMultiplier"]);
            game.AlphaKillXPMultiplier = Convert.ToSingle(form["AlphaKillXPMultiplier"]);
            game.WildKillXPMultiplier = Convert.ToSingle(form["WildKillXPMultiplier"]);
            game.CaveKillXPMultiplier = Convert.ToSingle(form["CaveKillXPMultiplier"]);
            game.TamedKillXPMultiplier = Convert.ToSingle(form["TamedKillXPMultiplier"]);
            game.UnclaimedKillXPMultiplier = Convert.ToSingle(form["UnclaimedKillXPMultiplier"]);
            game.SupplyCrateLootQualityMultiplier = Convert.ToSingle(form["SupplyCrateLootQualityMultiplier"]);
            game.FishingLootQualityMultiplier = Convert.ToSingle(form["FishingLootQualityMultiplier"]);
            game.CraftingSkillBonusMultiplier = Convert.ToSingle(form["CraftingSkillBonusMultiplier"]);
            game.BabyImprintAmountMultiplier = Convert.ToSingle(form["BabyImprintAmountMultiplier"]);
            game.PerPlatformMaxStructuresMultiplier = Convert.ToSingle(form["PerPlatformMaxStructuresMultiplier"]);
            string mods = form["Mods"] ?? string.Empty;
            string[] modList = mods.Split(',');
            config.Mods.Clear();
            foreach (string modid in modList)
            {
                config.Mods.Add(Convert.ToInt32(modid));
            }
            if (ConfigurationSettings.ThirdPartyEdit)
            {
                foreach (IniParser.Model.SectionData section in gus.CustomSections)
                {
                    foreach (IniParser.Model.KeyData key in section.Keys)
                    {
                        if (key.Value.IsBool())
                        {
                            key.Value = !string.IsNullOrEmpty(form[string.Format("{0}_{1}", section.SectionName, key.KeyName)]) ? "True" : "False";
                        }
                        else
                        {
                            key.Value = form[string.Format("{0}_{1}", section.SectionName, key.KeyName)];
                        }
                    }
                }
            }
            if (form["Restart"] != null)
            {
                ASAMonitorForm.RestartServer();
            }
            else if (form["Reset"] != null)
            {
                config = ConfigurationSettings.ASAConfig;
                gus = new GameUserSettings();
                game = new Game();
            }
            else if (form["AddMod"] != null)
            {
                if (form["AddModId"].IsNumber())
                {
                    int id = Convert.ToInt32(form["AddModId"]);
                    if (Utilities.Mods.FirstOrDefault(m => m.id == id) != null)
                    {
                        config.Mods.Add(id);
                    }
                }
            }
            else if (!string.IsNullOrEmpty(form["DeleteModId"]) && form["DeleteMod_" + form["DeleteModId"]] != null)
            {
                config.Mods.Remove(Convert.ToInt32(form["DeleteModId"]));
            }
            else
            {
                if (form["Save"] != null)
                {
                    ConfigurationSettings.SaveConfig(config);
                    gus.Save();
                    game.Save();
                    if (!string.IsNullOrEmpty(form["RestartOnSave"]) && form["RestartOnSave"] == "true")
                    {
                        ASAMonitorForm.RestartServer();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(form["Start"]) && ASAMonitorForm.Paused)
                    {
                        ASAMonitorForm.Instance.PauseServer(false);
                    }
                    else if (string.IsNullOrEmpty(form["Start"]) && !ASAMonitorForm.Paused)
                    {
                        ASAMonitorForm.Instance.PauseServer(true);
                        ASAMonitorForm.KillServer();
                    }
                }
            }
            return this.StringResponseAsync(GetDefault(config, gus, game), "text/html");
        }

        [WebApiHandler(HttpVerbs.Post, "/modslist.html")]
        public Task<bool> PostModsList()
        {
            string html = Utilities.GetEmbededWebResource("modslist.html");
            NameValueCollection form;
            using (TextReader reader = new StreamReader(Request.InputStream))
            {
                string body = reader.ReadToEnd();
                form = HttpUtility.ParseQueryString(body);
            }
            StringBuilder sb = new StringBuilder();
            foreach (string key in form.AllKeys)
            {
                sb.AppendLine(string.Format("<input type=\"hidden\" name=\"{0}\" id=\"{0}\" value=\"{1}\" />", key, form[key]));
            }
            sb.AppendLine(string.Format("<input type=\"hidden\" name=\"ModsOrig\" id=\"ModsOrig\" value=\"{0}\" />", form["Mods"] ?? string.Empty));
            html = html.Replace("{FormFields}", sb.ToString());
            html = html.Replace("{SelectedMods}", form["Mods"] ?? string.Empty);
            return this.StringResponseAsync(html, "text/html");
        }

        [WebApiHandler(HttpVerbs.Post, "/login.html")]
        public Task<bool> PostLogin()
        {
            string html = Utilities.GetEmbededWebResource("login.html");
            using (TextReader reader = new StreamReader(Request.InputStream))
            {
                string body = reader.ReadToEnd();
                GameUserSettings gus = new GameUserSettings();
                NameValueCollection form = HttpUtility.ParseQueryString(body);
                if (form["password"].Equals(gus.ServerAdminPassword) || (ConfigurationSettings.AllowServerPasswordAccess && form["password"].Equals(gus.ServerPassword)))
                {
                    System.Net.Cookie authCookie = new System.Net.Cookie("auth", form["password"].Equals(gus.ServerAdminPassword) ? "Admin" : "User", "/");
                    authCookie.Expires = DateTime.Now + new TimeSpan(1, 0, 0);
                    Response.SetCookie(authCookie);
                    html = string.Empty;
                    this.Redirect("/index.html");
                }
                else
                {
                    html = html.Replace("{Error}", "<br /><span style=\"color: red\">Invalid Password!</span>");
                }
            }
            return this.StringResponseAsync(html, "text/html");
        }

        [WebApiHandler(HttpVerbs.Get, "/getStatus.html")]
        public Task<bool> GetStatus()
        {
            var data = new
            {
                ASAMonitorForm.Instance.ServerRunning,
                ASAMonitorForm.Paused
            };
            string json = JsonConvert.SerializeObject(data);
            return this.StringResponseAsync(json, "text/json");
        }

        [WebApiHandler(HttpVerbs.Get, "/searchMods.html")]
        public Task<bool> SearchMods()
        {
            string term = Request.QueryString["term"] ?? string.Empty;
            List<CurseForge.Datum> mods = Utilities.Mods.Where(m => m.id.ToString().Contains(term) || m.name.ToLower().Contains(term.ToLower())).ToList();
            var data = mods.Select(m => new
            {
                m.id,
                name = m.name.Trim(),
                m.summary,
                category = m.categories.FirstOrDefault(c => c.id == m.primaryCategoryId) != null ? m.categories.FirstOrDefault(c => c.id == m.primaryCategoryId).name ?? string.Empty : string.Empty,
                logo = m.logo != null ? m.logo.thumbnailUrl : string.Empty,
                sortName = string.Format("{0} ({1})", m.name, m.id),
                m.displayName,
                url = m.links != null && !string.IsNullOrEmpty(m.links.websiteUrl) ? m.links.websiteUrl : string.Empty
            }).OrderBy(m => m.name);
            string json = JsonConvert.SerializeObject(data);
            return this.StringResponseAsync(json, "text/json");
        }

        [WebApiHandler(HttpVerbs.Get, "/getModsList.html")]
        public Task<bool> GetModsList()
        {
            string selected = Request.QueryString["selected"] ?? string.Empty;
            List<int> selectedIds = selected.Split(',').Select(int.Parse).ToList();
            var data = Utilities.Mods.Select(m => new
            {
                m.id,
                name = m.name.Trim(),
                m.summary,
                category = m.categories.FirstOrDefault(c => c.id == m.primaryCategoryId) != null ? m.categories.FirstOrDefault(c => c.id == m.primaryCategoryId).name ?? string.Empty : string.Empty,
                logo = m.logo != null ? m.logo.thumbnailUrl : string.Empty,
                m.displayName,
                url = m.links != null && !string.IsNullOrEmpty(m.links.websiteUrl) ? m.links.websiteUrl : string.Empty,
                sortName = string.Format("{0} ({1})", m.name, m.id),
                selected = selectedIds.Contains(m.id)
            }).OrderBy(m => m.name);
            string json = JsonConvert.SerializeObject(data);
            return this.StringResponseAsync(json, "text/json");
        }

        [WebApiHandler(HttpVerbs.Get, "/getCategories.html")]
        public Task<bool> GetCategories()
        {
            var data = Utilities.Mods.Select(m => m.categories.FirstOrDefault(c => c.id == m.primaryCategoryId) != null ? m.categories.FirstOrDefault(c => c.id == m.primaryCategoryId).name ?? string.Empty : string.Empty).Distinct().OrderBy(c => c).ToList();
            string json = JsonConvert.SerializeObject(data);
            return this.StringResponseAsync(json, "text/json");
        }

        [WebApiHandler(HttpVerbs.Get, "/getTitles.html")]
        public Task<bool> GetTitles()
        {
            var data = Utilities.Mods.Select(m => m.name).OrderBy(c => c).ToList();
            string json = JsonConvert.SerializeObject(data);
            return this.StringResponseAsync(json, "text/json");
        }

        public WebController(IHttpContext context) : base(context)
		{
        }
    }
}
