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
    public class CampfireTurkeyRecipe : Recipe
    {
        public CampfireTurkeyRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CharredMeatItem>(2),
               new CraftingElement<TallowItem>(1),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TurkeyCarcassItem>(typeof(CampfireCookingEfficiencySkill), 1, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Campfire Turkey", typeof(CampfireTurkeyRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CampfireTurkeyRecipe), this.UILink(), 5, typeof(CampfireCookingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}