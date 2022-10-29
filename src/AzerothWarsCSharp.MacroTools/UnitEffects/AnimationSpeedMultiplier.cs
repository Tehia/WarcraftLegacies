﻿using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.UnitEffects
{
  public sealed class AnimationSpeedMultiplier : UnitEffect
  {
    private readonly float _multiplier;

    public AnimationSpeedMultiplier(int unitTypeId, float multiplier) : base(unitTypeId)
    {
      _multiplier = multiplier;
    }

    public override void OnConstruction()
    {
      SetUnitTimeScale(GetConstructedStructure(), _multiplier);
    }
  }
}