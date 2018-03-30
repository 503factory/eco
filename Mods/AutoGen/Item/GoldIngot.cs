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

    [RequiresSkill(typeof(BasicSmeltingSkill), 3)]   
    public partial class GoldIngotRecipe : Recipe
    {
        public GoldIngotRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GoldIngotItem>(),          
            new CraftingElement<TailingsItem>(2),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GoldOreItem>(typeof(BasicSmeltingEfficiencySkill), 5, BasicSmeltingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(GoldIngotRecipe), Item.Get<GoldIngotItem>().UILink(), 2, typeof(BasicSmeltingSpeedSkill));    
            this.Initialize("Gold Ingot", typeof(GoldIngotRecipe));

            CraftingComponent.AddRecipe(typeof(BloomeryObject), this);
        }
    }


    [Serialized]
    [Weight(4000)]      
    [Currency]              
    public partial class GoldIngotItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Gold Ingot"; } }
        public override string Description { get { return "A shiny, refined gold ingot."; } }

    }

}