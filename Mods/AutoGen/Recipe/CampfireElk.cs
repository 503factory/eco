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

    [RequiresSkill(typeof(CampfireCookingSkill), 2)] 
    public class CampfireElkRecipe : Recipe
    {
        public CampfireElkRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CharredMeatItem>(7),
               new CraftingElement<TallowItem>(4),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ElkCarcassItem>(typeof(CampfireCookingEfficiencySkill), 1, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Campfire Elk", typeof(CampfireElkRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CampfireElkRecipe), this.UILink(), 10, typeof(CampfireCookingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}