﻿using MacroTools;
using WarcraftLegacies.Source.Quests.CrisisSpawn;
using WarcraftLegacies.Source.Setup.FactionSetup;


namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class CrisisQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup)
    {
      var crisis = CrisisCaptainSetup.CrisisCaptain;
      var crisis2 = CrisisFootmanSetup.CrisisFootman;

      crisis.AddQuest(new QuestOldGodPick(preplacedUnitSystem));
      
      crisis.AddQuest(new QuestNzothSpawnCaptain(preplacedUnitSystem, Regions.NzothStartPosition, allLegendSetup.Cthun.Cthun));

      crisis2.AddQuest(new QuestNzothSpawnFootman(preplacedUnitSystem, Regions.NzothStartPosition, allLegendSetup.Cthun.Cthun));

    }
  }
}