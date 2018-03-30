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
    public partial class RiceSludgeItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Rice Sludge"; } }
        public override string Description                      { get { return "Sometimes when you try and make rice, you just add too much water. Some people might call this porridge, but that would indicate intention."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 10, Fat = 0, Protein = 4, Vitamins = 4};
        public override float Calories                          { get { return 450; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 2)]    
    public partial class RiceSludgeRecipe : Recipe
    {
        public RiceSludgeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RiceSludgeItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RiceItem>(typeof(CampfireCookingEfficiencySkill), 10, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RiceSludgeRecipe), Item.Get<RiceSludgeItem>().UILink(), 2, typeof(CampfireCookingSpeedSkill)); 
            this.Initialize("Rice Sludge", typeof(RiceSludgeRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}