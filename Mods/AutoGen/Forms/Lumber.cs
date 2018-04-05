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
    [Tier(2)]
    [IsForm("Floor", typeof(LumberItem))]
    public partial class LumberFloorBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("Wall", typeof(LumberItem))]
    public partial class LumberWallBlock :
        Block
    { }



    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("Cube", typeof(LumberItem))]
    [RequiresSkill(typeof(LumberConstructionSkill), 4)]
    public partial class LumberCubeBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("Roof", typeof(LumberItem))]
    [RequiresSkill(typeof(LumberConstructionSkill), 2)]
    public partial class LumberRoofBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("Column", typeof(LumberItem))]
    [RequiresSkill(typeof(LumberConstructionSkill), 4)]
    public partial class LumberColumnBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("Window", typeof(LumberItem))]
    [RequiresSkill(typeof(LumberConstructionSkill), 3)]
    public partial class LumberWindowBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("Fence", typeof(LumberItem))]
    [RequiresSkill(typeof(LumberConstructionSkill), 2)]
    public partial class LumberFenceBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("WindowT2", typeof(LumberItem))]
    [RequiresSkill(typeof(LumberConstructionSkill), 4)]
    public partial class LumberWindowT2Block :
        Block
    { }


    [RotatedVariants(typeof(LumberStairsBlock), typeof(LumberStairs90Block), typeof(LumberStairs180Block), typeof(LumberStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("Stairs", typeof(LumberItem))]
    [RequiresSkill(typeof(LumberConstructionSkill), 1)]
    public partial class LumberStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [RequiresSkill(typeof(LumberConstructionSkill), 1)]
    public partial class LumberStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [RequiresSkill(typeof(LumberConstructionSkill), 1)]
    public partial class LumberStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [RequiresSkill(typeof(LumberConstructionSkill), 1)]
    public partial class LumberStairs270Block : Block
    { }

}
