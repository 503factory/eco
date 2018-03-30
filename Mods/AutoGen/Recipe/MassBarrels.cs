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

    [RequiresSkill(typeof(IndustrialEngineeringSkill), 3)] 
    public class MassBarrelsRecipe : Recipe
    {
        public MassBarrelsRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<BarrelItem>(5),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(IndustrialEngineeringEfficiencySkill), 10, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Mass Barrels", typeof(MassBarrelsRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MassBarrelsRecipe), this.UILink(), 5, typeof(IndustrialEngineeringSpeedSkill));
            CraftingComponent.AddRecipe(typeof(FactoryObject), this);
        }
    }
}