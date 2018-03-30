// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System.Linq;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Math;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.World.Blocks;

[Serialized]
[Solid, Wall, Road(1f)]
public class StoneRoadWorldObjectBlock : WorldObjectBlock
{
    protected StoneRoadWorldObjectBlock() { }
    public StoneRoadWorldObjectBlock(WorldObject obj) : base(obj) { }
}

[Serialized]
[Solid, Wall, Road(1f)]
public class DirtRoadWorldObjectBlock : WorldObjectBlock
{
    protected DirtRoadWorldObjectBlock() { }
    public DirtRoadWorldObjectBlock(WorldObject obj) : base(obj) { }
}

[Serialized]
[Solid, Wall, Road(1f)]
public class AsphaltRoadWorldObjectBlock : WorldObjectBlock
{
    protected AsphaltRoadWorldObjectBlock() { }
    public AsphaltRoadWorldObjectBlock(WorldObject obj) : base(obj) { }
}

[Serialized]
public abstract class BaseRampObject : WorldObject, INetObjectPriority
{
    public float Priority { get { return NetObjectPriority.Medium; } }

    // No UI
    public override InteractResult OnActInteract(InteractionContext context)
    {
        return InteractResult.NoOp;
    }
}

[Serialized]
public class DirtRampObject : BaseRampObject
{
    public override string FriendlyName { get { return "Dirt Ramp"; } }

    static DirtRampObject()
    {
        AddOccupancyList(typeof(DirtRampObject),
            Vector3i.XYZIterInclusive(new Vector3i(-3, 0, 0), new Vector3i(0, 0, 1))
                .Select(x => new BlockOccupancy(x, typeof(DirtRoadWorldObjectBlock))).ToArray());
    }

    private DirtRampObject() { }
}

[Serialized]
[ItemGroup("Road Items")]
public class DirtRampItem : WorldObjectItem<DirtRampObject>
{
    public override string FriendlyName { get { return "Dirt Ramp"; } }
    public override string Description  { get { return "4 x 2 Dirt Ramp."; } }
}

[Serialized]
public class StoneRampObject : BaseRampObject
{
    public override string FriendlyName { get { return "Stone Ramp"; } }

    static StoneRampObject()
    {
        AddOccupancyList(typeof(StoneRampObject),
            Vector3i.XYZIterInclusive(new Vector3i(-3, 0, 0), new Vector3i(0, 0, 1))
                .Select(x => new BlockOccupancy(x, typeof(StoneRoadWorldObjectBlock))).ToArray());
    }

    private StoneRampObject() { }
}

[Serialized]
[ItemGroup("Road Items")]
public class StoneRampItem : WorldObjectItem<StoneRampObject>
{
    public override string FriendlyName { get { return "Stone Ramp"; } }
    public override string Description  { get { return "4 x 2 Stone Ramp."; } }
}

[Serialized]
public class AsphaltRampObject : BaseRampObject
{
    public override string FriendlyName { get { return "Asphalt Ramp"; } }
    static AsphaltRampObject()
    {
        AddOccupancyList(typeof(AsphaltRampObject),
            Vector3i.XYZIterInclusive(new Vector3i(-3, 0, 0), new Vector3i(0, 0, 3))
                .Select(x => new BlockOccupancy(x, typeof(AsphaltRoadWorldObjectBlock))).ToArray());
    }

    private AsphaltRampObject() { }
}

[Serialized]
[ItemGroup("Road Items")]
public class AsphaltRampItem : WorldObjectItem<AsphaltRampObject>
{
    public override string FriendlyName { get { return "Asphalt Ramp"; } }
    public override string Description  { get { return "4 x 4 Asphalt Ramp."; } }
}
