using System.Collections.Generic;
using MacroTools;
using MacroTools.Setup;
using WarcraftLegacies.Source.Mechanics.Scourge.Plague;
using WarcraftLegacies.Source.Quests.Scourge;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public sealed class ScourgeQuestSetup : IExecutableService
  {
    private readonly PreplacedUnitSystem _preplacedUnitSystem;
    private readonly AllLegendSetup _allLegendSetup;
    private readonly ArtifactSetup _artifactSetup;
    private readonly ScourgeSetup _scourgeSetup;
    private readonly LordaeronSetup _lordaeronSetup;
    private readonly LegionSetup _legionSetup;

    public ScourgeQuestSetup(ServiceCollection services)
    {
      _preplacedUnitSystem = services.GetRequired<PreplacedUnitSystem>();
      _allLegendSetup = services.GetRequired<AllLegendSetup>();
      _artifactSetup = services.GetRequired<ArtifactSetup>();
      _scourgeSetup = services.GetRequired<ScourgeSetup>();
      _lordaeronSetup = services.GetRequired<LordaeronSetup>();
      _legionSetup = services.GetRequired<LegionSetup>();
    }
    
    public void Execute()
    {
      QuestSpiderWar questSpiderWar = new(Regions.Ice_Crown,
        _preplacedUnitSystem.GetUnit(Constants.UNIT_N074_QUEEN_NEZAR_AZRET));
      QuestKelthuzadLich questKelthuzadLich = new(_allLegendSetup.Quelthalas.Sunwell, _allLegendSetup.Scourge.Kelthuzad);
      QuestKelthuzadDies questKelthuzadDies = new(questKelthuzadLich, _allLegendSetup.Scourge.Kelthuzad);
      QuestEnKilahUnlock questEnKilahUnlock = new(Regions.EnKilahUnlock);
      QuestDrakUnlock questDrakUnlock = new(Regions.DrakUnlock, _allLegendSetup.Scourge.Kelthuzad);
      QuestCultoftheDamned questCultoftheDamned = new(_allLegendSetup.Scourge.Rivendare);

      var plagueParameters = new PlagueParameters();
      plagueParameters.PlagueRects = new List<Rectangle>
      {
        Regions.Plague_1,
        Regions.Plague_2,
        Regions.Plague_3,
        Regions.Plague_4,
        Regions.Plague_5,
        Regions.Plague_6,
        Regions.Plague_7
      };
      plagueParameters.PlagueCauldronSummonParameters = new List<PlagueCauldronSummonParameter>
      {
        new(2, Constants.UNIT_UNEC_NECROMANCER_SCOURGE),
        new(2, Constants.UNIT_UACO_ACOLYTE_SCOURGE_WORKER),
        new(5, Constants.UNIT_UGHO_GHOUL_SCOURGE),
        new(2, Constants.UNIT_UCRY_CRYPT_FIEND_SCOURGE),
        new(1, Constants.UNIT_UABO_ABOMINATION_SCOURGE),
      };
      plagueParameters.PlagueCauldronUnitTypeId = Constants.UNIT_H02W_PLAGUE_CAULDRON_SCOURGE_OTHER;
      plagueParameters.Duration = 360;
      plagueParameters.AttackTargets = new List<Point>
      {
        new Point(9041, 8036),
        new Point(13825, 12471),
        new Point(9418, 5396)
      };

      QuestPlague questPlague = new(plagueParameters, _lordaeronSetup.Lordaeron, _legionSetup.Legion,
        Regions.DeathknellUnlock, Regions.StratholmeScourgeBase, Regions.CaerDarrow);

      QuestSapphiron questSapphiron = new(_preplacedUnitSystem.GetUnit(Constants.UNIT_UBDR_SAPPHIRON_CREEP),
        _allLegendSetup.Scourge.Kelthuzad);
      QuestDestroyStratholme questDestroyStratholme =
        new(_allLegendSetup.Lordaeron.Stratholme, _allLegendSetup.Lordaeron.Arthas);
      QuestLichKingArthas questLichKingArthas =
        new(_preplacedUnitSystem.GetUnit(Constants.UNIT_H00O_UTGARDE_KEEP_SCOURGE_OTHER),
          _artifactSetup.HelmOfDomination,
          _allLegendSetup.Scourge.Arthas, _allLegendSetup.Scourge.TheFrozenThrone);
      
      _scourgeSetup.Scourge.AddQuest(questSpiderWar);
      _scourgeSetup.Scourge.StartingQuest = questSpiderWar;
      _scourgeSetup.Scourge.AddQuest(questDrakUnlock);
      _scourgeSetup.Scourge.AddQuest(questEnKilahUnlock);
      _scourgeSetup.Scourge.AddQuest(questCultoftheDamned);
      _scourgeSetup.Scourge.AddQuest(questPlague);
      _scourgeSetup.Scourge.AddQuest(questSapphiron);
      _scourgeSetup.Scourge.AddQuest(questDestroyStratholme);
      _scourgeSetup.Scourge.AddQuest(questKelthuzadLich);
      _scourgeSetup.Scourge.AddQuest(questKelthuzadDies);
      _scourgeSetup.Scourge.AddQuest(questLichKingArthas);
    }
  }
}