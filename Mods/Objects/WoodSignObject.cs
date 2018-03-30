// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Objects;
    using Eco.Shared.Serialization;
    using Gameplay.Components;
    using Gameplay.Components.Auth;
    
    [RequireComponent(typeof(CustomTextComponent))]
    public partial class WoodSignObject : WorldObject
    {
        protected override void PostInitialize()
        {
            this.GetComponent<PropertyAuthComponent>().Initialize(AuthModeType.Inherited);
        }
    }

    [Serialized]
    public partial class SmallWoodSignObject : WoodSignObject
    { }
}