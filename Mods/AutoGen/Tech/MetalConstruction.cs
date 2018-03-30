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
    [RequiresSkill(typeof(SmithSkill), 0)]    
    public partial class MetalConstructionSkill : Skill
    {
        public override string FriendlyName { get { return "Metal Construction"; } }
        public override string Description { get { return Localizer.Do(""); } }

        public static int[] SkillPointCost = { 1, 1, 1, 1, 1 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    [Serialized]
    public partial class MetalConstructionSkillBook : SkillBook<MetalConstructionSkill, MetalConstructionSkillScroll>
    {
        public override string FriendlyName { get { return "Metal Construction Skill Book"; } }
    }

    [Serialized]
    public partial class MetalConstructionSkillScroll : SkillScroll<MetalConstructionSkill, MetalConstructionSkillBook>
    {
        public override string FriendlyName { get { return "Metal Construction Skill Scroll"; } }
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 0)] 
    public partial class MetalConstructionSkillBookRecipe : Recipe
    {
        public MetalConstructionSkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MetalConstructionSkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(ResearchEfficiencySkill), 50, ResearchEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = new ConstantValue(30);

            this.Initialize("Metal Construction Skill Book", typeof(MetalConstructionSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}
