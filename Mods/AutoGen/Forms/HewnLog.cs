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
    [Tier(1)]
    [IsForm("Floor", typeof(HewnLogItem))]
    public partial class HewnLogFloorBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(1)]
    [IsForm("Wall", typeof(HewnLogItem))]
    public partial class HewnLogWallBlock :
        Block
    { }



    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(1)]
    [IsForm("Cube", typeof(HewnLogItem))]
    [RequiresSkill(typeof(HewnLogConstructionSkill), 4)]
    public partial class HewnLogCubeBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(1)]
    [IsForm("Roof", typeof(HewnLogItem))]
    [RequiresSkill(typeof(HewnLogConstructionSkill), 2)]
    public partial class HewnLogRoofBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(1)]
    [IsForm("Column", typeof(HewnLogItem))]
    [RequiresSkill(typeof(HewnLogConstructionSkill), 4)]
    public partial class HewnLogColumnBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(1)]
    [IsForm("Window", typeof(HewnLogItem))]
    [RequiresSkill(typeof(HewnLogConstructionSkill), 3)]
    public partial class HewnLogWindowBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(1)]
    [IsForm("PeatRoof", typeof(HewnLogItem))]
    [RequiresSkill(typeof(HewnLogConstructionSkill), 1)]
    public partial class HewnLogPeatRoofBlock :
        Block
    { }


    [RotatedVariants(typeof(HewnLogStairsBlock), typeof(HewnLogStairs90Block), typeof(HewnLogStairs180Block), typeof(HewnLogStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(1)]
    [IsForm("Stairs", typeof(HewnLogItem))]
    [RequiresSkill(typeof(HewnLogConstructionSkill), 1)]
    public partial class HewnLogStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(1)]
    [RequiresSkill(typeof(HewnLogConstructionSkill), 1)]
    public partial class HewnLogStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(1)]
    [RequiresSkill(typeof(HewnLogConstructionSkill), 1)]
    public partial class HewnLogStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(1)]
    [RequiresSkill(typeof(HewnLogConstructionSkill), 1)]
    public partial class HewnLogStairs270Block : Block
    { }

}
