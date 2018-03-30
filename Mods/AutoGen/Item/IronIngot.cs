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

    [RequiresSkill(typeof(BasicSmeltingSkill), 2)]   
    public partial class IronIngotRecipe : Recipe
    {
        public IronIngotRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(),          
            new CraftingElement<TailingsItem>(2),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronOreItem>(typeof(BasicSmeltingEfficiencySkill), 5, BasicSmeltingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronIngotRecipe), Item.Get<IronIngotItem>().UILink(), 2, typeof(BasicSmeltingSpeedSkill));    
            this.Initialize("Iron Ingot", typeof(IronIngotRecipe));

            CraftingComponent.AddRecipe(typeof(BloomeryObject), this);
        }
    }


    [Serialized]
    [Weight(4000)]      
    [Currency]              
    public partial class IronIngotItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Iron Ingot"; } }
        public override string Description { get { return "Refined block of iron."; } }

    }

}