namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;

    [Serialized]
    [RequiresSkill(typeof(CarpenterSkill), 0)]    
    public partial class WoodConstructionSkill : Skill
    {
        public override string FriendlyName { get { return "Wood Construction"; } }
        public override string Description { get { return Localizer.Do(""); } }

        public override int RequiredPoint { get { return 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    [Serialized]
    public partial class WoodConstructionSkillBook : SkillBook<WoodConstructionSkill, WoodConstructionSkillScroll>
    {
        public override string FriendlyName { get { return "Wood Construction Skill Book"; } }
    }

    [Serialized]
    public partial class WoodConstructionSkillScroll : SkillScroll<WoodConstructionSkill, WoodConstructionSkillBook>
    {
        public override string FriendlyName { get { return "Wood Construction Skill Scroll"; } }
    }

    [RequiresSkill(typeof(HewingSkill), 0)] 
    public partial class WoodConstructionSkillBookRecipe : Recipe
    {
        public WoodConstructionSkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WoodConstructionSkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HewnLogItem>(typeof(ResearchEfficiencySkill), 10, ResearchEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = new ConstantValue(5);

            this.Initialize("Wood Construction Skill Book", typeof(WoodConstructionSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}
