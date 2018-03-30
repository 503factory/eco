namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(BasicCraftingSkill), 3)]   
    public partial class BowRecipe : Recipe
    {
        public BowRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BowItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(typeof(BasicCraftingEfficiencySkill), 4, BasicCraftingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<PlantFibersItem>(typeof(BasicCraftingEfficiencySkill), 20, BasicCraftingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = new ConstantValue(5);
            this.Initialize("Bow", typeof(BowRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }


}