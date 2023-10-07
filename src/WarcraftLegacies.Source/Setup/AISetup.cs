using MacroTools.AI;
using MacroTools.FactionSystem;

namespace WarcraftLegacies.Source.Setup
{
  public static class AISetup
  {
    public static void Setup()
    {
      foreach (var faction in FactionManager.GetAllFactions())
        AIManager.Register(faction);
    }
  }
}