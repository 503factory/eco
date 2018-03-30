// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Objects;
    using Gameplay.Components.Auth;
    using Gameplay.Players;
    using Shared.Math;
    using Gameplay.Items;
    using Shared.Serialization;
    using World = Eco.World.World;
    using World.Blocks;
    using Shared.Networking;

    public partial class StockpileItem : WorldObjectItem<StockpileObject>
    {
        public override bool TryPlaceObject(Player player, Vector3i position, Quaternion rotation)
        {
            Vector3i startPosition = position - new Vector3i((int)(StockpileComponent.Dimensions.x / 2f), 1, (int)(StockpileComponent.Dimensions.z / 2f));
            foreach (var offset in StockpileComponent.Dimensions.XZ.XYIter())
            {
                var worldPos = startPosition + offset.X_Z();
                if (!World.GetBlock(worldPos).Is<Solid>())
                {
                    player.SendTemporaryErrorLoc("Stockpile requires solid ground to be placed on.");
                    return false;
                }
            }
            return base.TryPlaceObject(player, position, rotation);
        }
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(StockpileComponent))]
    [RequireComponent(typeof(LinkComponent))]
    public partial class StockpileObject : WorldObject
    {
        public override string FriendlyName { get { return "Stockpile"; } }

        protected override void Initialize()
        {
            base.Initialize();
            
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(StockpileComponent.Dimensions.x * StockpileComponent.Dimensions.z);
            storage.Storage.AddRestriction(new CarriedRestriction()); // restrict stockpiles to carried items.

            this.GetComponent<PropertyAuthComponent>().Initialize(AuthModeType.Inherited);
            this.GetComponent<LinkComponent>().Initialize(7);
        }

        public override void SendInitialState(BSONObject bsonObj, INetObjectViewer viewer)
        {
            base.SendInitialState(bsonObj, viewer);
            bsonObj["noFadeIn"] = true;
        }
    }
}
