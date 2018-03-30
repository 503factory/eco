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

    [RequiresSkill(typeof(BasicCraftingSkill), 0)]   
    public partial class HewnLogRecipe : Recipe
    {
        public HewnLogRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<HewnLogItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(HewnLogProcessingEfficiencySkill), 2, HewnLogProcessingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(HewnLogRecipe), Item.Get<HewnLogItem>().UILink(), 0.2f, typeof(HewnLogProcessingSpeedSkill));    
            this.Initialize("Hewn Log", typeof(HewnLogRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [Tier(1)]                                          
    [RequiresSkill(typeof(HewnLogProcessingEfficiencySkill), 0)]   
    public partial class HewnLogBlock :
        Block           
    { }

    [Serialized]
    [MaxStackSize(15)]                           
    [Weight(10000)]      
    [Currency]              
    public partial class HewnLogItem :
    BlockItem<HewnLogBlock>
    {
        public override string FriendlyName { get { return "Hewn Log"; } }
        public override string Description { get { return "A log hewn and shaped to be a building material."; } }


        private static Type[] blockTypes = new Type[] {
            typeof(HewnLogStacked1Block),
            typeof(HewnLogStacked2Block),
            typeof(HewnLogStacked3Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class HewnLogStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class HewnLogStacked2Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class HewnLogStacked3Block : PickupableBlock { } //Only a wall if it's all 4 HewnLog
}