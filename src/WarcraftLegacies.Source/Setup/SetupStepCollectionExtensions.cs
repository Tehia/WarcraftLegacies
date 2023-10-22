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

      setupStepCollection.Add(new ScourgeSetup(preplacedUnitSystem, artifactSetup.HelmOfDomination));
      setupStepCollection.Add(new LegionSetup(preplacedUnitSystem));
      setupStepCollection.Add(new LordaeronSetup(preplacedUnitSystem));
      setupStepCollection.Add(new DalaranSetup(preplacedUnitSystem));
      setupStepCollection.Add(new QuelthalasSetup(preplacedUnitSystem));
      setupStepCollection.Add(new SentinelsSetup(preplacedUnitSystem, allLegendSetup));
      setupStepCollection.Add(new DruidsSetup(preplacedUnitSystem, allLegendSetup));
      setupStepCollection.Add(new FelHordeSetup(preplacedUnitSystem));
      setupStepCollection.Add(new FrostwolfSetup(preplacedUnitSystem));
      setupStepCollection.Add(new WarsongSetup(preplacedUnitSystem));
      setupStepCollection.Add(new StormwindSetup());
      setupStepCollection.Add(new IronforgeSetup(preplacedUnitSystem));
      setupStepCollection.Add(new KultirasSetup(preplacedUnitSystem));
      setupStepCollection.Add(new IllidariSetup());
      setupStepCollection.Add(new GoblinSetup(preplacedUnitSystem));
      setupStepCollection.Add(new DraeneiSetup());
      setupStepCollection.Add(new ZandalarSetup(preplacedUnitSystem));
      setupStepCollection.Add(new SunfurySetup(preplacedUnitSystem));
      setupStepCollection.Add(new GilneasSetup(preplacedUnitSystem));
      setupStepCollection.Add(new CthunSetup(preplacedUnitSystem));
      setupStepCollection.Add(new NazjatarSetup(preplacedUnitSystem));
      setupStepCollection.Add(new BlackEmpireSetup(preplacedUnitSystem));
      setupStepCollection.Add(new TwilightHammerSetup(preplacedUnitSystem));
    }
  }
}