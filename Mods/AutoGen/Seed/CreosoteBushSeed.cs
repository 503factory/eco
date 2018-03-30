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
    [Yield(typeof(CreosoteBushSeedItem), typeof(DesertDrifterSkill), new float[] { 1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f })]  
    [Weight(10)]  
    public partial class CreosoteBushSeedItem : SeedItem
    {
        static CreosoteBushSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override string FriendlyName { get { return "Creosote Bush Seed"; } }
        public override string Description  { get { return "Plant to grow creosote bushes."; } }
        public override string SpeciesName  { get { return "CreosoteBush"; } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(10)]  
    public partial class CreosoteBushSeedPackItem : SeedPackItem
    {
        static CreosoteBushSeedPackItem() { }

        public override string FriendlyName { get { return "Creosote Bush Seed Pack"; } }
        public override string Description  { get { return "Plant to grow creosote bushes."; } }
        public override string SpeciesName  { get { return "CreosoteBush"; } }
    }

}