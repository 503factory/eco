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
    public class CampfireSalmonRecipe : Recipe
    {
        public CampfireSalmonRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CharredFishItem>(2),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SalmonItem>(typeof(CampfireCookingEfficiencySkill), 1, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Campfire Salmon", typeof(CampfireSalmonRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CampfireSalmonRecipe), this.UILink(), 5, typeof(CampfireCookingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}