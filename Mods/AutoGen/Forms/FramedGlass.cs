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
    [IsForm("Floor", typeof(FramedGlassItem))]
    public partial class FramedGlassFloorBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [IsForm("Wall", typeof(FramedGlassItem))]
    public partial class FramedGlassWallBlock :
        Block
    { }



    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [IsForm("Cube", typeof(FramedGlassItem))]
    [RequiresSkill(typeof(GlassConstructionSkill), 4)]
    public partial class FramedGlassCubeBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [IsForm("Roof", typeof(FramedGlassItem))]
    [RequiresSkill(typeof(GlassConstructionSkill), 2)]
    public partial class FramedGlassRoofBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [IsForm("Column", typeof(FramedGlassItem))]
    [RequiresSkill(typeof(GlassConstructionSkill), 4)]
    public partial class FramedGlassColumnBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [IsForm("Window", typeof(FramedGlassItem))]
    [RequiresSkill(typeof(GlassConstructionSkill), 3)]
    public partial class FramedGlassWindowBlock :
        Block
    { }


    [RotatedVariants(typeof(FramedGlassStairsBlock), typeof(FramedGlassStairs90Block), typeof(FramedGlassStairs180Block), typeof(FramedGlassStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [IsForm("Stairs", typeof(FramedGlassItem))]
    [RequiresSkill(typeof(GlassConstructionSkill), 1)]
    public partial class FramedGlassStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [RequiresSkill(typeof(GlassConstructionSkill), 1)]
    public partial class FramedGlassStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [RequiresSkill(typeof(GlassConstructionSkill), 1)]
    public partial class FramedGlassStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(4)]
    [RequiresSkill(typeof(GlassConstructionSkill), 1)]
    public partial class FramedGlassStairs270Block : Block
    { }

}
