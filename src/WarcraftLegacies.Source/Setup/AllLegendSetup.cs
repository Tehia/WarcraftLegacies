﻿using MacroTools;
using MacroTools.LegendSystem;
using MacroTools.Setup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Setup
{
  /// <summary>
  /// Initializes and maintains references to all <see cref="Legend"/>s.
  /// </summary>
  public sealed class AllLegendSetup : IExecutableSetupStep
  {
    private readonly PreplacedUnitSystem _preplacedUnitSystem;

    /// <summary>
    /// Contains references to all Dalaran <see cref="Legend"/>s.
    /// </summary>
    public LegendDalaran Dalaran { get; }
    
    /// <summary>
    /// Contains references to all Draenei <see cref="Legend"/>s.
    /// </summary>
    public LegendDraenei Draenei { get; }
    
    /// <summary>
    /// Contains references to all Druid <see cref="Legend"/>s.
    /// </summary>
    public LegendDruids Druids { get; }
    
    /// <summary>
    /// Contains references to all Fel Horde <see cref="Legend"/>s.
    /// </summary>
    public LegendFelHorde FelHorde { get; }
    
    /// <summary>
    /// Contains references to all Frostwolf <see cref="Legend"/>s.
    /// </summary>
    public LegendFrostwolf Frostwolf { get; }
    
    /// <summary>
    /// Contains references to all Goblin <see cref="Legend"/>s.
    /// </summary>
    public LegendGoblin Goblin { get; }
    
    /// <summary>
    /// Contains references to all Ironforge <see cref="Legend"/>s.
    /// </summary>
    public LegendIronforge Ironforge { get; }
    
    /// <summary>
    /// Contains references to all Kul Tiras <see cref="Legend"/>s.
    /// </summary>
    public LegendKultiras Kultiras { get; }
    
    /// <summary>
    /// Contains references to all Legion <see cref="Legend"/>s.
    /// </summary>
    public LegendLegion Legion { get; }
    
    /// <summary>
    /// Contains references to all Lordaeron <see cref="Legend"/>s.
    /// </summary>
    public LegendLordaeron Lordaeron { get; }
    
    /// <summary>
    /// Contains references to all Naga <see cref="Legend"/>s.
    /// </summary>
    public LegendIllidan Naga { get; }
    
    /// <summary>
    /// Contains references to all Quel'thalas <see cref="Legend"/>s.
    /// </summary>
    public LegendQuelthalas Quelthalas { get; }
    
    /// <summary>
    /// Contains references to all Scourge <see cref="Legend"/>s.
    /// </summary>
    public LegendScourge Scourge { get; }
    
    /// <summary>
    /// Contains references to all Sentinel <see cref="Legend"/>s.
    /// </summary>
    public LegendSentinels Sentinels { get; }
    
    /// <summary>
    /// Contains references to all Stormwind <see cref="Legend"/>s.
    /// </summary>
    public LegendStormwind Stormwind { get; }
    
    /// <summary>
    /// Contains references to all Warsong <see cref="Legend"/>s.
    /// </summary>
    public LegendWarsong Warsong { get; }

    public LegendTroll Troll { get; }
    public LegendCthun Cthun { get; }
    public LegendNazjatar Nazjatar { get; }
    public LegendBlackEmpire BlackEmpire { get; }
    public LegendTwilight Twilight { get; }
    public LegendGilneas Gilneas { get; }

    /// <summary>
    /// Contains references to all Neutral <see cref="Legend"/>s.
    /// </summary>
    public LegendNeutral Neutral { get; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="AllLegendSetup"/> class.
    /// </summary>
    public AllLegendSetup(SetupStepCollection setupSteps)
    {
      _preplacedUnitSystem = setupSteps.GetRequired<PreplacedUnitSystem>();
      var artifactSetup = setupSteps.GetRequired<ArtifactSetup>();
      
      Dalaran = new LegendDalaran(_preplacedUnitSystem);
      Draenei = new LegendDraenei(_preplacedUnitSystem);
      Druids = new LegendDruids(_preplacedUnitSystem);
      FelHorde = new LegendFelHorde(_preplacedUnitSystem);
      Frostwolf = new LegendFrostwolf(_preplacedUnitSystem);
      Goblin = new LegendGoblin(_preplacedUnitSystem);
      Ironforge = new LegendIronforge(_preplacedUnitSystem);
      Kultiras = new LegendKultiras(_preplacedUnitSystem);
      Legion = new LegendLegion(_preplacedUnitSystem);
      Lordaeron = new LegendLordaeron(_preplacedUnitSystem, artifactSetup);
      Naga = new LegendIllidan();
      Quelthalas = new LegendQuelthalas(_preplacedUnitSystem);
      Scourge = new LegendScourge(_preplacedUnitSystem);
      Sentinels = new LegendSentinels(_preplacedUnitSystem);
      Stormwind = new LegendStormwind(_preplacedUnitSystem);
      Troll = new LegendTroll();
      Warsong = new LegendWarsong(_preplacedUnitSystem);
      Neutral = new LegendNeutral(_preplacedUnitSystem);
      Gilneas = new LegendGilneas();
      Cthun = new LegendCthun();
      Nazjatar = new LegendNazjatar();
      BlackEmpire = new LegendBlackEmpire(_preplacedUnitSystem);
      Twilight = new LegendTwilight();
    }

    /// <summary>
    /// Registers all <see cref="Legend"/>s managed by the <see cref="AllLegendSetup"/>.
    /// </summary>
    public void Execute()
    {
      Dalaran.RegisterLegends();
      Draenei.RegisterLegends();
      Druids.RegisterLegends();
      FelHorde.RegisterLegends();
      Frostwolf.RegisterLegends();
      Goblin.RegisterLegends();
      Ironforge.RegisterLegends();
      Kultiras.RegisterLegends();
      Legion.RegisterLegends();
      Lordaeron.RegisterLegends();
      Naga.RegisterLegends();
      Quelthalas.RegisterLegends();
      Scourge.RegisterLegends(_preplacedUnitSystem);
      Sentinels.RegisterLegends();
      Stormwind.RegisterLegends();
      Warsong.RegisterLegends();
      Troll.RegisterLegends();
      Cthun.RegisterLegends();
      Nazjatar.RegisterLegends();
      BlackEmpire.RegisterLegends();
      Twilight.RegisterLegends();
      Neutral.RegisterLegends();
      Gilneas.RegisterLegends();
    }
  }
}