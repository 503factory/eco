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
    [Tier(4)]
    [IsForm("Floor", typeof(FlatSteelItem))]
    public partial class FlatSteelFloorBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [IsForm("Wall", typeof(FlatSteelItem))]
    public partial class FlatSteelWallBlock :
        Block
    { }



    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [IsForm("Cube", typeof(FlatSteelItem))]
    [RequiresSkill(typeof(SteelConstructionSkill), 4)]
    public partial class FlatSteelCubeBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [IsForm("Roof", typeof(FlatSteelItem))]
    [RequiresSkill(typeof(SteelConstructionSkill), 2)]
    public partial class FlatSteelRoofBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [IsForm("Column", typeof(FlatSteelItem))]
    [RequiresSkill(typeof(SteelConstructionSkill), 4)]
    public partial class FlatSteelColumnBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [IsForm("Window", typeof(FlatSteelItem))]
    [RequiresSkill(typeof(SteelConstructionSkill), 3)]
    public partial class FlatSteelWindowBlock :
        Block
    { }


    [RotatedVariants(typeof(FlatSteelStairsBlock), typeof(FlatSteelStairs90Block), typeof(FlatSteelStairs180Block), typeof(FlatSteelStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [IsForm("Stairs", typeof(FlatSteelItem))]
    [RequiresSkill(typeof(SteelConstructionSkill), 1)]
    public partial class FlatSteelStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [RequiresSkill(typeof(SteelConstructionSkill), 1)]
    public partial class FlatSteelStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [RequiresSkill(typeof(SteelConstructionSkill), 1)]
    public partial class FlatSteelStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [RequiresSkill(typeof(SteelConstructionSkill), 1)]
    public partial class FlatSteelStairs270Block : Block
    { }

}
