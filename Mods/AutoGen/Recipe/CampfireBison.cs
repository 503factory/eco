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

    [RequiresSkill(typeof(CampfireCookingSkill), 4)] 
    public class CampfireBisonRecipe : Recipe
    {
        public CampfireBisonRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CharredMeatItem>(16),
               new CraftingElement<TallowItem>(7),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BisonCarcassItem>(typeof(CampfireCookingEfficiencySkill), 1, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Campfire Bison", typeof(CampfireBisonRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CampfireBisonRecipe), this.UILink(), 20, typeof(CampfireCookingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}