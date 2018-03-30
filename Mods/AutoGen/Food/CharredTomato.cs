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
    public partial class CharredTomatoItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Charred Tomato"; } }
        public override string Description                      { get { return "The blackened char on this tomato would contrast well with the red skin if there was any unburt surface left."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 3, Protein = 4, Vitamins = 5};
        public override float Calories                          { get { return 510; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 2)]    
    public partial class CharredTomatoRecipe : Recipe
    {
        public CharredTomatoRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CharredTomatoItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TomatoItem>(typeof(CampfireCookingEfficiencySkill), 3, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredTomatoRecipe), Item.Get<CharredTomatoItem>().UILink(), 3, typeof(CampfireCookingSpeedSkill)); 
            this.Initialize("Charred Tomato", typeof(CharredTomatoRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}