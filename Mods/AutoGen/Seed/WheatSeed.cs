namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Players;
    using System.ComponentModel;

    [Serialized]
    [Yield(typeof(WheatSeedItem), typeof(GrasslandGathererSkill), new float[] { 1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f })]  
    [Weight(10)]  
    public partial class WheatSeedItem : SeedItem
    {
        static WheatSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override string FriendlyName { get { return "Wheat Seed"; } }
        public override string Description  { get { return "Plant to grow wheat."; } }
        public override string SpeciesName  { get { return "Wheat"; } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(10)]  
    public partial class WheatSeedPackItem : SeedPackItem
    {
        static WheatSeedPackItem() { }

        public override string FriendlyName { get { return "Wheat Seed Pack"; } }
        public override string Description  { get { return "Plant to grow wheat."; } }
        public override string SpeciesName  { get { return "Wheat"; } }
    }

    [RequiresSkill(typeof(SeedProductionSkill), 1)]    
    public class WheatSeedRecipe : Recipe
    {
        public WheatSeedRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WheatSeedItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WheatItem>(typeof(SeedProductionEfficiencySkill), 2, SeedProductionEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(2, SeedProductionSpeedSkill.MultiplicativeStrategy, typeof(SeedProductionSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(WheatSeedRecipe), Item.Get<WheatSeedItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<WheatSeedItem>().UILink(), value);
            this.CraftMinutes = value;

            this.Initialize("Wheat Seed", typeof(WheatSeedRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}