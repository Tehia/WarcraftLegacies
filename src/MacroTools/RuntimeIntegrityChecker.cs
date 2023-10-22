using MacroTools.ControlPointSystem;
using MacroTools.FactionSystem;
using MacroTools.Setup;
using static War3Api.Common;

namespace MacroTools
{
  /// <summary>
  /// Performs basic checks during runtime to ensure that the map is configured correctly.
  /// </summary>
  public sealed class RuntimeIntegrityChecker : IExecutableService
  {
    private readonly FactionManager _factionManager;

    public RuntimeIntegrityChecker(ServiceCollection services)
    {
      _factionManager = services.GetRequired<FactionManager>();
    }
    
    /// <inheritdoc />
    public void Execute()
    {
      NoNeutralPassiveVulnerableControlPoints();
      CheckUndefeatedResearchNames();
      CheckQuestResearchNames();
    }

    private void NoNeutralPassiveVulnerableControlPoints()
    {
      foreach (var controlPoint in ControlPointManager.Instance.GetAllControlPoints())
        if (controlPoint.Owner == Player(PLAYER_NEUTRAL_PASSIVE) && !BlzIsUnitInvulnerable(controlPoint.Unit))
          Logger.LogWarning($"{controlPoint.Name} is owned by Neutral Passive and is not invulnerable.");
    }
    
    private void CheckUndefeatedResearchNames()
    {
      foreach (var faction in _factionManager.GetAllFactions())
      {
        if (faction.UndefeatedResearch == 0)
          continue;
        
        var intendedName = $"{faction.Name} exists";
        var actualName = GetObjectName(faction.UndefeatedResearch);
        if (actualName != intendedName)
          Logger.LogWarning($"{faction.Name}'s {nameof(faction.UndefeatedResearch)} should be named {intendedName} but it is instead named {actualName}.");
      }
    }
    
    private void CheckQuestResearchNames()
    {
      foreach (var faction in _factionManager.GetAllFactions())
      {
        foreach (var quest in faction.GetAllQuests())
        {
          if (quest.ResearchId == 0)
            continue;
          
          var intendedName = $"Quest Completed: {quest.Title}";
          var actualName = GetObjectName(quest.ResearchId);
          if (!actualName.Equals(intendedName))
            Logger.LogWarning(
              $"{quest.Title}'s {nameof(quest.ResearchId)} should be named {intendedName} but it is instead named {actualName}.");
        }
      }
    }
  }
}