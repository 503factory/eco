// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Shared.Serialization;
    using Eco.Gameplay.Components.Auth;
    
    public partial class StorageChestObject : WorldObject
    {
        protected override void PostInitialize()
        {
            base.PostInitialize();
            this.GetComponent<PropertyAuthComponent>().Initialize(AuthModeType.Inherited);
            this.GetComponent<LinkComponent>().Initialize(5);
            this.GetComponent<MinimapComponent>().Initialize("Storage");
        }
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    public class BigStorageChestObject : WorldObject
    {
        public override string FriendlyName { get { return "Big Storage Chest"; } }

        protected override void Initialize()
        {
            base.Initialize();

            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(32, 8000000);
            storage.Storage.AddRestriction(new NotCarriedRestriction()); // can't store block or large items
            this.GetComponent<PropertyAuthComponent>().Initialize(AuthModeType.Inherited);
            this.GetComponent<LinkComponent>().Initialize(5);
            this.GetComponent<MinimapComponent>().Initialize("Storage");
        }
    }
}
