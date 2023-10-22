namespace MacroTools.Setup
{
  /// <summary>
  /// Contains setup instructions that should be executed at the start of the game.
  /// Setup steps may be dependent on other setup steps.
  /// </summary>
  public interface IExecutableService : IService
  {
    /// <summary>
    /// Executes any external tasks the setup step needs to complete. This usually involves registering objects to a
    /// manager or calling the Warcraft 3 native API.
    /// </summary>
    public void Execute();
  }
}