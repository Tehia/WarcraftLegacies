using MacroTools.FactionSystem;
using MacroTools.Setup;

namespace WarcraftLegacies.Source.Setup
{
  public sealed class TeamSetup : IService{
    public static Team Legion { get; private set; }
    public static Team Alliance { get; private set; }
    public static Team NorthAlliance { get; private set; }
    public static Team SouthAlliance { get; private set; }
    public static Team Horde { get; private set; }
    public static Team NightElves { get; private set; }
    public static Team Outland { get; private set; }
    public static Team Gilneas { get; private set; }
    public static Team ScarletCrusade { get; private set; }
    public static Team Scourge { get; private set; }
    public static Team Crisis { get; private set; }
    public static Team Draenei { get; private set; }
    public static Team Oldgods { get; private set; }


    public static void Setup( ){
      Alliance = new Team("Alliance")
      {
        VictoryMusic = "HeroicVictory"
      };
      _factionManager.Register(Alliance);

      NorthAlliance = new Team("North Alliance")
      {
        VictoryMusic = "HeroicVictory"
      };
      _factionManager.Register(NorthAlliance);

      SouthAlliance = new Team("South Alliance")
      {
        VictoryMusic = "HeroicVictory"
      };
      _factionManager.Register(SouthAlliance);

      Legion = new Team("Burning Legion")
      {
        VictoryMusic = "DarkVictory"
      };
      _factionManager.Register(Legion);

      Horde = new Team("Horde")
      {
        VictoryMusic = "DarkVictory"
      };
      _factionManager.Register(Horde);
      
      NightElves = new Team("Night Elves")
      {
        VictoryMusic = "HeroicVictory"
      };
      _factionManager.Register(NightElves);

      Outland = new Team("Outland")
      {
        VictoryMusic = "DarkVictory"
      };
      _factionManager.Register(Outland);
      
      Gilneas = new Team("Gilneas")
      {
        VictoryMusic = "HeroicVictory"
      };
      _factionManager.Register(Gilneas);
      
      ScarletCrusade = new Team("Scarlet Crusade")
      {
        VictoryMusic = "DarkVictory"
      };
      _factionManager.Register(ScarletCrusade);
      
      Scourge = new Team("Northrend")
      {
        VictoryMusic = "DarkVictory"
      };
      _factionManager.Register(Scourge);

      Crisis = new Team("Crisis")
      {
        VictoryMusic = "DarkVictory"
      };
      _factionManager.Register(Crisis);

      Oldgods = new Team("Old Gods")
      {
        VictoryMusic = "DarkVictory"
      };
      _factionManager.Register(Oldgods);

      Draenei = new Team("Draenei")
      {
        VictoryMusic = "HeroicVictory"
      };
      _factionManager.Register(Draenei);
    }

  }
}
