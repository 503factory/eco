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
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [IsForm("Floor", typeof(CorrugatedSteelItem))]
    public partial class CorrugatedSteelFloorBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [IsForm("Wall", typeof(CorrugatedSteelItem))]
    public partial class CorrugatedSteelWallBlock :
        Block
    { }



    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [IsForm("Cube", typeof(CorrugatedSteelItem))]
    [RequiresSkill(typeof(SteelConstructionSkill), 4)]
    public partial class CorrugatedSteelCubeBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [IsForm("Roof", typeof(CorrugatedSteelItem))]
    [RequiresSkill(typeof(SteelConstructionSkill), 2)]
    public partial class CorrugatedSteelRoofBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [IsForm("Column", typeof(CorrugatedSteelItem))]
    [RequiresSkill(typeof(SteelConstructionSkill), 4)]
    public partial class CorrugatedSteelColumnBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [IsForm("Window", typeof(CorrugatedSteelItem))]
    [RequiresSkill(typeof(SteelConstructionSkill), 3)]
    public partial class CorrugatedSteelWindowBlock :
        Block
    { }


    [RotatedVariants(typeof(CorrugatedSteelStairsBlock), typeof(CorrugatedSteelStairs90Block), typeof(CorrugatedSteelStairs180Block), typeof(CorrugatedSteelStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [IsForm("Stairs", typeof(CorrugatedSteelItem))]
    [RequiresSkill(typeof(SteelConstructionSkill), 1)]
    public partial class CorrugatedSteelStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [RequiresSkill(typeof(SteelConstructionSkill), 1)]
    public partial class CorrugatedSteelStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [RequiresSkill(typeof(SteelConstructionSkill), 1)]
    public partial class CorrugatedSteelStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [RequiresSkill(typeof(SteelConstructionSkill), 1)]
    public partial class CorrugatedSteelStairs270Block : Block
    { }

}
