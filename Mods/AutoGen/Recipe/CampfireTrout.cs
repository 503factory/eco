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
    public class CampfireTroutRecipe : Recipe
    {
        public CampfireTroutRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CharredFishItem>(1),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TroutItem>(typeof(CampfireCookingEfficiencySkill), 1, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Campfire Trout", typeof(CampfireTroutRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CampfireTroutRecipe), this.UILink(), 3, typeof(CampfireCookingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}