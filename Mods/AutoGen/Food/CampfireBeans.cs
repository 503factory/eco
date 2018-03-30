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
    [Weight(100)]                                          
    public partial class CampfireBeansItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Campfire Beans"; } }
        public override string FriendlyNamePlural               { get { return "Campfire Beans"; } } 
        public override string Description                      { get { return "A mushy mixture that can serve somewhat as a replacement protein in a meatless diet."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 2, Fat = 6, Protein = 8, Vitamins = 0};
        public override float Calories                          { get { return 500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 1)]    
    public partial class CampfireBeansRecipe : Recipe
    {
        public CampfireBeansRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CampfireBeansItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BeansItem>(typeof(CampfireCookingEfficiencySkill), 5, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CampfireBeansRecipe), Item.Get<CampfireBeansItem>().UILink(), 2, typeof(CampfireCookingSpeedSkill)); 
            this.Initialize("Campfire Beans", typeof(CampfireBeansRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}