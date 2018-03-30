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
    [Weight(400)]                                          
    public partial class CrimsonSaladItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Crimson Salad"; } }
        public override string Description                      { get { return "Just in case you want to eat red things without eating meat."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 12, Fat = 8, Protein = 6, Vitamins = 22};
        public override float Calories                          { get { return 1100; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 4)]    
    public partial class CrimsonSaladRecipe : Recipe
    {
        public CrimsonSaladRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CrimsonSaladItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BasicSaladItem>(typeof(CulinaryArtsEfficiencySkill), 4, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<InfusedOilItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BeetItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<TomatoItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CrimsonSaladRecipe), Item.Get<CrimsonSaladItem>().UILink(), 15, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Crimson Salad", typeof(CrimsonSaladRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}