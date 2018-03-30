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
    public partial class CharredCornItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Charred Corn"; } }
        public override string FriendlyNamePlural               { get { return "Charred Corn"; } } 
        public override string Description                      { get { return "This piece of corn needs a good slathering of butter to crub that burnt taste."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 9, Fat = 0, Protein = 3, Vitamins = 6};
        public override float Calories                          { get { return 530; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 2)]    
    public partial class CharredCornRecipe : Recipe
    {
        public CharredCornRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CharredCornItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CornItem>(typeof(CampfireCookingEfficiencySkill), 3, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredCornRecipe), Item.Get<CharredCornItem>().UILink(), 2, typeof(CampfireCookingSpeedSkill)); 
            this.Initialize("Charred Corn", typeof(CharredCornRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}