// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Items;
using Eco.Shared.Serialization;
using Eco.World;
using Eco.World.Blocks;

[Serialized]
[Category("Hidden")]
[CanMakeBlockForm(new[] {"Wall", "Floor", "Roof", "Stairs", "Window", "Fence", "Aqueduct", "Cube", "Column"})]
public class HammerItem : ToolItem
{
    public override string Description                    { get { return "Destroys constructed materials."; } }
    public override string FriendlyName                   { get { return "Hammer"; } }

    private static IDynamicValue skilledRepairCost = new ConstantValue(1);
    public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }

    public override ClientPredictedBlockAction LeftAction { get { return ClientPredictedBlockAction.PickupBlock; } }
    public override string LeftActionDescription          { get { return "Pick Up"; } }

    public override InteractResult OnActLeft(InteractionContext context)
    {
        if (context.HasBlock)
        {
            if (context.Block.Is<Constructed>())
                return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, true, 1);
            else if (context.Block is WorldObjectBlock)
            {
                ((WorldObjectBlock)context.Block).WorldObjectHandle.Object.PickUp(context.Player);
                this.BurnCalories(context.Player);
                return InteractResult.Success;
            }
            else
                return InteractResult.NoOp;
        }
        else if (context.Target is WorldObject)
        {
            (context.Target as WorldObject).PickUp(context.Player);
            this.BurnCalories(context.Player);
            return InteractResult.Success;
        }
        else
            return InteractResult.NoOp;
    }

    static IDynamicValue caloriesBurn = new ConstantValue(1);
    public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }

    public override bool ShouldHighlight(Type block)
    {
        return Block.Is<Constructed>(block);
    }
}