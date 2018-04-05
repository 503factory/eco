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
    [IsForm("Floor", typeof(BrickItem))]
    public partial class BrickFloorBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("Wall", typeof(BrickItem))]
    public partial class BrickWallBlock :
        Block
    { }



    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("Cube", typeof(BrickItem))]
    [RequiresSkill(typeof(BrickConstructionSkill), 4)]
    public partial class BrickCubeBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("Roof", typeof(BrickItem))]
    [RequiresSkill(typeof(BrickConstructionSkill), 2)]
    public partial class BrickRoofBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("Column", typeof(BrickItem))]
    [RequiresSkill(typeof(BrickConstructionSkill), 4)]
    public partial class BrickColumnBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("Window", typeof(BrickItem))]
    [RequiresSkill(typeof(BrickConstructionSkill), 3)]
    public partial class BrickWindowBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("Aqueduct", typeof(BrickItem))]
    [RequiresSkill(typeof(BrickConstructionSkill), 2)]
    public partial class BrickAqueductBlock :
        Block
    { }


    [RotatedVariants(typeof(BrickStairsBlock), typeof(BrickStairs90Block), typeof(BrickStairs180Block), typeof(BrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [IsForm("Stairs", typeof(BrickItem))]
    [RequiresSkill(typeof(BrickConstructionSkill), 1)]
    public partial class BrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [RequiresSkill(typeof(BrickConstructionSkill), 1)]
    public partial class BrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [RequiresSkill(typeof(BrickConstructionSkill), 1)]
    public partial class BrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(2)]
    [RequiresSkill(typeof(BrickConstructionSkill), 1)]
    public partial class BrickStairs270Block : Block
    { }

}
