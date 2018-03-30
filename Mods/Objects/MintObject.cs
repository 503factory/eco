// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Shared.Serialization;

    [RequireComponent(typeof(MintComponent))]
    public partial class MintObject : WorldObject
    {
    }

    [MaxStackSize(1)]
    public partial class MintItem : WorldObjectItem<MintObject>
    {
        [Serialized] Guid mintID = Guid.NewGuid();


        public override void OnPickup(WorldObject placed)
        {
            this.mintID = placed.GetComponent<MintComponent>().CurrencyId;
        }

        public override void OnWorldObjectPlaced(WorldObject placedObject)
        {
            placedObject.GetComponent<MintComponent>().InitializeCurrency(this.mintID);
            base.OnWorldObjectPlaced(placedObject);
        }

        [Tooltip(120)] public string Tooltip()
        {
            var currency = EconomyManager.Currency.GetCurrency(this.mintID);
            var currencyText = currency != null ? currency.UILink() : "<None>";
            return "Currency associated with this mint: " + currencyText;
        }
    }
}