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

    [RequiresSkill(typeof(CampfireCookingSkill), 3)] 
    public class CampfireWolfRecipe : Recipe
    {
        public CampfireWolfRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CharredMeatItem>(3),
               new CraftingElement<TallowItem>(2),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WolfCarcassItem>(typeof(CampfireCookingEfficiencySkill), 1, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Campfire Wolf", typeof(CampfireWolfRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CampfireWolfRecipe), this.UILink(), 2, typeof(CampfireCookingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}