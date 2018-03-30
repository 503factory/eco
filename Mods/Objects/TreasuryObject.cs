// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using Eco.Gameplay.Components;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;

[Serialized]
[RequireComponent(typeof(TreasuryComponent))]
public class TreasuryObject : WorldObject
{
    public override string FriendlyName { get { return "Treasury"; } }
}
