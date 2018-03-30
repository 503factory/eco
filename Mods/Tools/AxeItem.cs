// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;

    [Category("Hidden")]
    public partial class AxeItem
    {
        private static SkillModifiedValue caloriesBurn;
        private static SkillModifiedValue damage;
        static AxeItem()
        {
            string axeUiLink = new AxeItem().UILink();
            caloriesBurn = CreateCalorieValue(20, typeof(LoggingSkill), typeof(AxeItem), new LocString(axeUiLink));
            damage = CreateDamageValue(1, typeof(LoggingSkill), typeof(AxeItem), new LocString(axeUiLink));
        }
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }

        public override IDynamicValue CaloriesBurn   { get { return caloriesBurn; } }
        public override SkillModifiedValue Damage    { get { return damage; } }
        
        public override string LeftActionDescription { get { return "Chop"; } }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (context.HasBlock)
            {
                var block = World.GetBlock(context.BlockPosition.Value);
                if (block.Is<TreeDebris>())
                {
                    InventoryChangeSet changes = new InventoryChangeSet(context.Player.User.Inventory, context.Player.User);
                    changes.AddItems<WoodPulpItem>(5);
                    return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 3, null, changes);
                }
                else
                    return InteractResult.NoOp;
            }
            else
                return base.OnActLeft(context);
        }

        public override bool ShouldHighlight(Type block)
        {
            return Block.Is<TreeDebris>(block);
        }
    }
}