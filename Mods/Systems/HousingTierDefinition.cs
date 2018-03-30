// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Systems
{
    using Eco.Core.Utils;
    using Eco.Gameplay.Housing;
    using Eco.Core.Plugins.Interfaces;
    using Eco.Shared.Localization;

    public class HousingTierDefinition : IModKitPlugin, IInitializablePlugin
    {
        public void Initialize(TimedTask timer)
        {
            PlayerHousingManager.Obj.SetHousingTiers(new HousingTier[] 
            {
                new HousingTier() { TierVal = 0, SoftCap = 2f,  HardCap = 4f, DiminishingReturnPercent = .5f },
                new HousingTier() { TierVal = 1, SoftCap = 5f,  HardCap = 10f, DiminishingReturnPercent = .5f },
                new HousingTier() { TierVal = 2, SoftCap = 10f, HardCap = 20f, DiminishingReturnPercent = .5f },
                new HousingTier() { TierVal = 3, SoftCap = 15f, HardCap = 30f, DiminishingReturnPercent = .5f },
                new HousingTier() { TierVal = 4, SoftCap = 20f, HardCap = 40f, DiminishingReturnPercent = .5f }
            });
        }

        public string GetStatus() { return string.Empty; }
        public override string ToString() { return Localizer.Do("Housing Tiers"); }
    }
}