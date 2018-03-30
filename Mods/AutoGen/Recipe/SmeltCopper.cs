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

    [RequiresSkill(typeof(BasicSmeltingSkill), 2)] 
    public class SmeltCopperRecipe : Recipe
    {
        public SmeltCopperRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CopperIngotItem>(1),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CopperOreItem>(typeof(BasicSmeltingEfficiencySkill), 4, BasicSmeltingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Smelt Copper", typeof(SmeltCopperRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SmeltCopperRecipe), this.UILink(), 0.5f, typeof(BasicSmeltingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }
}