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

    [RequiresSkill(typeof(IndustrialEngineeringSkill), 2)] 
    public class MassCutWireRecipe : Recipe
    {
        public MassCutWireRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CopperWiringItem>(10),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CopperIngotItem>(typeof(IndustrialEngineeringEfficiencySkill), 20, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Mass Cut Wire", typeof(MassCutWireRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MassCutWireRecipe), this.UILink(), 5, typeof(IndustrialEngineeringSpeedSkill));
            CraftingComponent.AddRecipe(typeof(FactoryObject), this);
        }
    }
}