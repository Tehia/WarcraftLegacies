using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Save;
using MacroTools.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup
{
  public static class SetupStepCollectionExtensions
  {
    public static void ConfigureSaveManager(this ServiceCollection serviceCollection)
    {
      var saveManager = new SaveManager();
      serviceCollection.Add(saveManager);
    }

    public static void ConfigureControlPointManager(this ServiceCollection serviceCollection)
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
      serviceCollection.Add(controlPointManager);
    }

    public static void ConfigureFactions(this ServiceCollection services)
    {
      services.Add(new ScourgeSetup(services));
      services.Add(new LegionSetup(services));
      services.Add(new LordaeronSetup(services));
      services.Add(new DalaranSetup(services));
      services.Add(new QuelthalasSetup(services));
      services.Add(new SentinelsSetup(services));
      services.Add(new DruidsSetup(services));
      services.Add(new FelHordeSetup(services));
      services.Add(new FrostwolfSetup(services));
      services.Add(new WarsongSetup(services));
      services.Add(new StormwindSetup(services));
      services.Add(new IronforgeSetup(services));
      services.Add(new KultirasSetup(services));
      services.Add(new IllidariSetup(services));
      services.Add(new GoblinSetup(services));
      services.Add(new DraeneiSetup(services));
      services.Add(new ZandalarSetup(services));
      services.Add(new SunfurySetup(services));
      services.Add(new GilneasSetup(services));
      services.Add(new CthunSetup(services));
      services.Add(new NazjatarSetup(services));
      services.Add(new BlackEmpireSetup(services));
      services.Add(new TwilightHammerSetup(services));
    }
  }
}