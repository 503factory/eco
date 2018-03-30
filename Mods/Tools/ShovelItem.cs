// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Core.Utils;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Plants;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Items;
    using Eco.Shared.Math;
    using Eco.Simulation;
    using Eco.World;
    using Eco.World.Blocks;

    [Category("Hidden")]
    public partial class ShovelItem : ToolItem
    {
        private static SkillModifiedValue caloriesBurn = CreateCalorieValue(20, typeof(ShovelEfficiencySkill), typeof(ShovelItem), new ShovelItem().UILink());
        public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }

        public override ClientPredictedBlockAction LeftAction { get { return ClientPredictedBlockAction.PickupBlock; } }
        public override string LeftActionDescription     { get { return "Dig"; } }

        private static IDynamicValue skilledRepairCost = new ConstantValue(1);
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (context.HasBlock)
            {
                if (context.Block is PlantBlock)
                {
                    var plant = EcoSim.PlantSim.GetPlant(context.BlockPosition.Value);
                    if (plant != null && plant is IHarvestable)
                    {
                        IHarvestable harvestable = (IHarvestable)plant;

                        if (plant.Dead)
                        {
                            EcoSim.PlantSim.DestroyPlant(plant, DeathType.Harvesting);
                            return InteractResult.Success;
                        }
                        else
                        {
                            Result result = harvestable.TryHarvest(context.Player, false);
                            if (result.Success)
                                this.BurnCalories(context.Player);
                            return (InteractResult)result;
                        }
                    }
                    else
                        return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false);
                }
                else if (context.Block.Is<Diggable>())
                {
                    if (TreeEntity.TreeRootsBlockDigging(context))
                        return InteractResult.FailureLocStr("You attempt to dig up the soil, but the roots are too strong!");
                    
                    Result result = this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, true, 1, new DirtItem());
                    if (result.Success)
                    {
                        var plant = EcoSim.PlantSim.GetPlant(context.BlockPosition.Value + Vector3i.Up);
                        if (plant != null)
                            EcoSim.PlantSim.DestroyPlant(plant, DeathType.Harvesting);
                    }

                    return (InteractResult)result;
                }
                else
                    return InteractResult.NoOp;
            }
            else
                return InteractResult.NoOp;
        }

        public override int MaxTake                         { get { return 1; } }
        public override bool ShouldHighlight(Type block)    { return Block.Is<Diggable>(block);}
    }
}