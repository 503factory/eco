namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;



    [Serialized]
    [Weight(10000)]      
    [Currency]              
    public partial class NuclearFuelItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Nuclear Fuel"; } }
        public override string FriendlyNamePlural { get { return "Nuclear Fuel"; } } 
        public override string Description { get { return "Unstable nucler fuel."; } }

    }

}