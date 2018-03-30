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

    [RequiresSkill(typeof(IndustrialEngineeringSkill), 1)] 
    public class MassGearProductionRecipe : Recipe
    {
        public MassGearProductionRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<GearItem>(15),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(IndustrialEngineeringEfficiencySkill), 20, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Mass Gear Production", typeof(MassGearProductionRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MassGearProductionRecipe), this.UILink(), 5, typeof(IndustrialEngineeringSpeedSkill));
            CraftingComponent.AddRecipe(typeof(FactoryObject), this);
        }
    }
}