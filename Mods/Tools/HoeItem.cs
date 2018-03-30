// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using Eco.Core.Utils;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Simulation;
using Eco.World;
using Eco.World.Blocks;

[Serialized]
[Category("Hidden")]
[Hoer]
public class HoeItem : ToolItem
{
    public override string FriendlyName { get { return "Hoe"; } }
    public override string Description  { get { return "Used to till soil and prepare it for planting."; } }

    private static IDynamicValue skilledRepairCost = new ConstantValue(1);
    public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }

    public override InteractResult OnActLeft(InteractionContext context)
    {
        if (context.HasBlock)
        {
            var abovePos = context.BlockPosition.Value + Vector3i.Up;
            var aboveBlock = World.GetBlock(abovePos);
            if (!aboveBlock.Is<Solid>() && context.Block.Is<Tillable>())
            {
                Result result = this.PlayerPlaceBlock<TilledDirtBlock>(context.BlockPosition.Value, context.Player, true);
                if (result.Success)
                {
                    var plant = EcoSim.PlantSim.GetPlant(abovePos);
                    if (plant != null)
                        EcoSim.PlantSim.DestroyPlant(plant, DeathType.Harvesting);
                }

                return (InteractResult)result;
            }

            return InteractResult.NoOp;
        }

        return base.OnActLeft(context);
    }
    static IDynamicValue caloriesBurn = new ConstantValue(1);
    public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }

    public override bool ShouldHighlight(Type block)
    {
        return Block.Is<Tillable>(block);
    }
}