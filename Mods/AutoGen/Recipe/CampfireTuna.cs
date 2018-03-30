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
    public class CampfireTunaRecipe : Recipe
    {
        public CampfireTunaRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CharredFishItem>(3),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TunaItem>(typeof(CampfireCookingEfficiencySkill), 1, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Campfire Tuna", typeof(CampfireTunaRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CampfireTunaRecipe), this.UILink(), 10, typeof(CampfireCookingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}