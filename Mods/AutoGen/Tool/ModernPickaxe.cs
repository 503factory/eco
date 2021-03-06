namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(SteelworkingSkill), 1)]   
    [RepairRequiresSkill(typeof(SteelworkingSkill), 3)]
    public partial class ModernPickaxeRecipe : Recipe
    {
        public ModernPickaxeRecipe()
        {
            this.Products = new CraftingElement[] { new CraftingElement<ModernPickaxeItem>() };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FiberglassItem>(typeof(SteelworkingEfficiencySkill), 20, SteelworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SteelItem>(typeof(SteelworkingEfficiencySkill), 30, SteelworkingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernPickaxeRecipe), Item.Get<ModernPickaxeItem>().UILink(), 0.5f, typeof(SteelworkingSpeedSkill));
            this.Initialize("Modern Pickaxe", typeof(ModernPickaxeRecipe));
            CraftingComponent.AddRecipe(typeof(FactoryObject), this);
        }
    }
    [Serialized]
    [Weight(1000)]
    [Category("Tool")]
    public partial class ModernPickaxeItem : PickaxeItem
    {

        public override string FriendlyName { get { return "Modern Pickaxe"; } }
        private static SkillModifiedValue caloriesBurn = CreateCalorieValue(10, typeof(MiningEfficiencySkill), typeof(ModernPickaxeItem), new ModernPickaxeItem().UILink());
        public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }

        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(20, SteelworkingSkill.MultiplicativeStrategy, typeof(SteelworkingSkill), Localizer.Do("repair cost"));
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }


        public override float DurabilityRate { get { return DurabilityMax / 2000f; } }
        
        public override Item RepairItem         {get{ return Item.Get<SteelItem>(); } }
        public override int FullRepairAmount    {get{ return 20; } }
    }
}