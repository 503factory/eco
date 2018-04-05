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
    [IsForm("Floor", typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteFloorBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [IsForm("Wall", typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteWallBlock :
        Block
    { }



    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [IsForm("Cube", typeof(ReinforcedConcreteItem))]
    [RequiresSkill(typeof(CementConstructionSkill), 4)]
    public partial class ReinforcedConcreteCubeBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [IsForm("Roof", typeof(ReinforcedConcreteItem))]
    [RequiresSkill(typeof(CementConstructionSkill), 2)]
    public partial class ReinforcedConcreteRoofBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [IsForm("Column", typeof(ReinforcedConcreteItem))]
    [RequiresSkill(typeof(CementConstructionSkill), 4)]
    public partial class ReinforcedConcreteColumnBlock :
        Block
    { }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [IsForm("Window", typeof(ReinforcedConcreteItem))]
    [RequiresSkill(typeof(CementConstructionSkill), 3)]
    public partial class ReinforcedConcreteWindowBlock :
        Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteStairsBlock), typeof(ReinforcedConcreteStairs90Block), typeof(ReinforcedConcreteStairs180Block), typeof(ReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [IsForm("Stairs", typeof(ReinforcedConcreteItem))]
    [RequiresSkill(typeof(CementConstructionSkill), 1)]
    public partial class ReinforcedConcreteStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [RequiresSkill(typeof(CementConstructionSkill), 1)]
    public partial class ReinforcedConcreteStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [RequiresSkill(typeof(CementConstructionSkill), 1)]
    public partial class ReinforcedConcreteStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tier(3)]
    [RequiresSkill(typeof(CementConstructionSkill), 1)]
    public partial class ReinforcedConcreteStairs270Block : Block
    { }

}
