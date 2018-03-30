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

    [RequiresSkill(typeof(PaperSkill), 1)]   
    public partial class DeedRecipe : Recipe
    {
        public DeedRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DeedItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(PaperEfficiencySkill), 10, PaperEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DeedRecipe), Item.Get<DeedItem>().UILink(), 1, typeof(PaperSpeedSkill));    
            this.Initialize("Deed", typeof(DeedRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }


}