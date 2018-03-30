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
    [RequireComponent(typeof(OnOffComponent))]                   
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(FuelSupplyComponent))]                      
    [RequireComponent(typeof(FuelConsumptionComponent))]                 
    [RequireComponent(typeof(PowerGridComponent))]              
    [RequireComponent(typeof(PowerGeneratorComponent))]         
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class CombustionGeneratorObject : 
        WorldObject    
    {
        public override string FriendlyName { get { return "Combustion Generator"; } } 

        private static Type[] fuelTypeList = new Type[]
        {
            typeof(LogItem),
            typeof(LumberItem),
            typeof(CharcoalItem),
            typeof(ArrowItem),
            typeof(BoardItem),
            typeof(CoalItem),
            typeof(PetroleumItem),
            typeof(GasolineItem),
        };

        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Power");                                 
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);                           
            this.GetComponent<FuelConsumptionComponent>().Initialize(100);                    
            this.GetComponent<PowerGridComponent>().Initialize(30, new ElectricPower());        
            this.GetComponent<PowerGeneratorComponent>().Initialize(1500);                       
            this.GetComponent<HousingComponent>().Set(CombustionGeneratorItem.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class CombustionGeneratorItem : WorldObjectItem<CombustionGeneratorObject>
    {
        public override string FriendlyName { get { return "Combustion Generator"; } } 
        public override string Description  { get { return  "Consumes most fuels to produce energy."; } }

        static CombustionGeneratorItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Industrial",
                                                    TypeForRoomLimit = "", 
        };}}
    }


    [RequiresSkill(typeof(MechanicalEngineeringSkill), 3)]
    public partial class CombustionGeneratorRecipe : Recipe
    {
        public CombustionGeneratorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CombustionGeneratorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(MechanicsAssemblyEfficiencySkill), 20, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<PistonItem>(typeof(MechanicsAssemblyEfficiencySkill), 5, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CombustionEngineItem>(typeof(MechanicsAssemblyEfficiencySkill), 1, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(30, MechanicsAssemblySpeedSkill.MultiplicativeStrategy, typeof(MechanicsAssemblySpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(CombustionGeneratorRecipe), Item.Get<CombustionGeneratorItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<CombustionGeneratorItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Combustion Generator", typeof(CombustionGeneratorRecipe));
            CraftingComponent.AddRecipe(typeof(MachineShopObject), this);
        }
    }
}