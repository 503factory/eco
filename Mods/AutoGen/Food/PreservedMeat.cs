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
    [Weight(500)]                                          
    public partial class PreservedMeatItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Preserved Meat"; } }
        public override string FriendlyNamePlural               { get { return "Preserved Meat"; } } 
        public override string Description                      { get { return "Smoked meat."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 11, Protein = 14, Vitamins = 7};
        public override float Calories                          { get { return 600; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 1)]    
    public partial class PreservedMeatRecipe : Recipe
    {
        public PreservedMeatRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PreservedMeatItem>(),
               
               new CraftingElement<TallowItem>(1), 
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PreparedMeatItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<HuckleberryExtractItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PreservedMeatRecipe), Item.Get<PreservedMeatItem>().UILink(), 20, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Preserved Meat", typeof(PreservedMeatRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}