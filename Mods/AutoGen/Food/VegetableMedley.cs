namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    
    [Serialized]
    [Weight(300)]                                          
    public partial class VegetableMedleyItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Vegetable Medley"; } }
        public override string Description                      { get { return "An eclectic arrangement of vegetables."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 5, Protein = 3, Vitamins = 10};
        public override float Calories                          { get { return 900; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

}