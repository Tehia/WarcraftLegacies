using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Save;
using MacroTools.Setup;

namespace WarcraftLegacies.Source.Setup
{
  public static class SetupStepCollectionExtensions
  {
    public static void ConfigureSaveManager(this SetupStepCollection setupStepCollection)
    {
      var saveManager = new SaveManager();
      setupStepCollection.AddSingleton(saveManager);
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
      setupStepCollection.AddSingleton(controlPointManager);
    }
  }
}