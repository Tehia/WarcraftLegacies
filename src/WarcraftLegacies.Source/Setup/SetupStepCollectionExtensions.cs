using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Save;
using MacroTools.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup
{
  public static class SetupStepCollectionExtensions
  {
    public static void ConfigureSaveManager(this SetupStepCollection setupStepCollection)
    {
      var saveManager = new SaveManager();
      setupStepCollection.Add(saveManager);
    }
    
    public static void ConfigureControlPointManager(this SetupStepCollection setupStepCollection)
    {
      var controlPointManager = new ControlPointManager
      {
        StartingMaxHitPoints = 1900,
        HostileStartingCurrentHitPoints = 1000,
        RegenerationAbility = Constants.ABILITY_A0UT_CP_LIFE_REGEN,
        PiercingResistanceAbility = Constants.ABILITY_A13X_MAGIC_RESISTANCE_CONTROL_POINT_TOWER,
        IncreaseControlLevelAbilityTypeId = Constants.ABILITY_A0A8_FORTIFY_CONTROL_POINTS_SHARED,
        ControlLevelSettings = new ControlLevelSettings
        {
          DefaultDefenderUnitTypeId = Constants.UNIT_H03W_CONTROL_POINT_DEFENDER_LORDAERON,
          DamageBase = 8,
          DamagePerControlLevel = 1,
          ArmorPerControlLevel = 1,
          HitPointsPerControlLevel = 70,
          ControlLevelMaximum = 30
        }
      };
      setupStepCollection.Add(controlPointManager);
    }
    
    public static void ConfigureFactions(this SetupStepCollection setupStepCollection)
    {
      var preplacedUnitSystem = setupStepCollection.GetRequired<PreplacedUnitSystem>();
      var artifactSetup = setupStepCollection.GetRequired<ArtifactSetup>();
      var allLegendSetup = setupStepCollection.GetRequired<AllLegendSetup>();
      
      ScourgeSetup.Setup(preplacedUnitSystem, artifactSetup.HelmOfDomination);
      LegionSetup.Setup(preplacedUnitSystem);
      LordaeronSetup.Setup(preplacedUnitSystem);
      DalaranSetup.Setup(preplacedUnitSystem);
      QuelthalasSetup.Setup(preplacedUnitSystem);
      SentinelsSetup.Setup(preplacedUnitSystem, allLegendSetup);
      DruidsSetup.Setup(preplacedUnitSystem, allLegendSetup);
      FelHordeSetup.Setup(preplacedUnitSystem);
      FrostwolfSetup.Setup(preplacedUnitSystem);
      WarsongSetup.Setup(preplacedUnitSystem);
      StormwindSetup.Setup();
      IronforgeSetup.Setup(preplacedUnitSystem);
      KultirasSetup.Setup(preplacedUnitSystem);
      IllidariSetup.Setup();
      GoblinSetup.Setup(preplacedUnitSystem);
      DraeneiSetup.Setup();
      ZandalarSetup.Setup(preplacedUnitSystem);
      SunfurySetup.Setup(preplacedUnitSystem);
      GilneasSetup.Setup(preplacedUnitSystem);

      CthunSetup.Setup(preplacedUnitSystem);
      NazjatarSetup.Setup(preplacedUnitSystem);
      BlackEmpireSetup.Setup(preplacedUnitSystem);
      TwilightHammerSetup.Setup(preplacedUnitSystem);
    }
  }
}