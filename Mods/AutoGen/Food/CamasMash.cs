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
    public partial class CamasMashItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Camas Mash"; } }
        public override string FriendlyNamePlural               { get { return "Camas Mash"; } } 
        public override string Description                      { get { return "A mushy camas paste with some fat added for flavor and texture."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 11, Protein = 4, Vitamins = 3};
        public override float Calories                          { get { return 500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 4)]    
    public partial class CamasMashRecipe : Recipe
    {
        public CamasMashRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CamasMashItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CamasBulbItem>(typeof(CampfireCookingEfficiencySkill), 5, CampfireCookingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<TallowItem>(typeof(CampfireCookingEfficiencySkill), 2, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CamasMashRecipe), Item.Get<CamasMashItem>().UILink(), 2, typeof(CampfireCookingSpeedSkill)); 
            this.Initialize("Camas Mash", typeof(CamasMashRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}