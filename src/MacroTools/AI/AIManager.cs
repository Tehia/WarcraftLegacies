using MacroTools.Extensions;
using MacroTools.FactionSystem;

namespace MacroTools.AI
{
  /// <summary>Manages all computer AI.</summary>
  public static class AIManager
  {
    /// <summary>Registers a <see cref="Faction"/> to the <see cref="AIManager"/>, allowing it to be managed as an AI.</summary>
    public static void Register(Faction faction) => faction.Player?.StartAIScript(faction.AIScriptPath);
  }
}