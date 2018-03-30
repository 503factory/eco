namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;

    [RequiresSkill(typeof(CampfireCookingSkill), 1)] 
    public class CampfireHareRecipe : Recipe
    {
        public CampfireHareRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CharredMeatItem>(1),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HareCarcassItem>(typeof(CampfireCookingEfficiencySkill), 1, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Campfire Hare", typeof(CampfireHareRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CampfireHareRecipe), this.UILink(), 1, typeof(CampfireCookingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}