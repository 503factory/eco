namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    
    [Serialized]    
    [RequireComponent(typeof(PipeComponent))]                    
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(CraftingComponent))]               
    [RequireComponent(typeof(PowerGridComponent))]              
    [RequireComponent(typeof(PowerConsumptionComponent))]                     
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class FactoryObject : 
        WorldObject    
    {
        public override string FriendlyName { get { return "Factory"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Crafting");                                 
            this.GetComponent<PowerConsumptionComponent>().Initialize(1000);                      
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());        
            this.GetComponent<HousingComponent>().Set(FactoryItem.HousingVal);                                


            var tankList = new List<LiquidTank>();
            
            tankList.Add(new LiquidProducer("Chimney", typeof(SmogItem), 100,
                    null,                                                                
                    this.Occupancy.Find(x => x.Name == "ChimneyOut"),   
                        (float)(0.3f * SmogItem.SmogItemsPerCO2PPM) / TimeUtil.SecondsPerHour)); 
            
            
            
            this.GetComponent<PipeComponent>().Initialize(tankList);

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class FactoryItem : WorldObjectItem<FactoryObject>
    {
        public override string FriendlyName { get { return "Factory"; } } 
        public override string Description  { get { return  "A complex set of machinery for creating equally complex things."; } }

        static FactoryItem()
        {
            
            
            
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Industrial",
                                                    TypeForRoomLimit = "", 
        };}}
    }


    [RequiresSkill(typeof(IndustrialEngineeringSkill), 0)]
    public partial class FactoryRecipe : Recipe
    {
        public FactoryRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FactoryItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ConcreteItem>(typeof(IndustrialEngineeringEfficiencySkill), 25, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ElectricMotorItem>(typeof(IndustrialEngineeringEfficiencySkill), 6, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ServoItem>(typeof(IndustrialEngineeringEfficiencySkill), 10, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SteelItem>(typeof(IndustrialEngineeringEfficiencySkill), 30, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(180, IndustrialEngineeringSpeedSkill.MultiplicativeStrategy, typeof(IndustrialEngineeringSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(FactoryRecipe), Item.Get<FactoryItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<FactoryItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Factory", typeof(FactoryRecipe));
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }
}