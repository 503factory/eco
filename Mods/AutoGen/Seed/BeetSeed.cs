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
    [Yield(typeof(BeetSeedItem), typeof(GrasslandGathererSkill), new float[] { 1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f })]  
    [Weight(10)]  
    public partial class BeetSeedItem : SeedItem
    {
        static BeetSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override string FriendlyName { get { return "Beet Seed"; } }
        public override string Description  { get { return "Plant to grow beets."; } }
        public override string SpeciesName  { get { return "Beets"; } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(10)]  
    public partial class BeetSeedPackItem : SeedPackItem
    {
        static BeetSeedPackItem() { }

        public override string FriendlyName { get { return "Beet Seed Pack"; } }
        public override string Description  { get { return "Plant to grow beets."; } }
        public override string SpeciesName  { get { return "Beets"; } }
    }

    [RequiresSkill(typeof(SeedProductionSkill), 2)]    
    public class BeetSeedRecipe : Recipe
    {
        public BeetSeedRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BeetSeedItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BeetItem>(typeof(SeedProductionEfficiencySkill), 2, SeedProductionEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(2, SeedProductionSpeedSkill.MultiplicativeStrategy, typeof(SeedProductionSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(BeetSeedRecipe), Item.Get<BeetSeedItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<BeetSeedItem>().UILink(), value);
            this.CraftMinutes = value;

            this.Initialize("Beet Seed", typeof(BeetSeedRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}