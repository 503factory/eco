using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Mods
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Core.Agents;
    using Eco.Core.Serialization;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.World;
    using Eco.Gameplay.Items;
    using Eco.Gameplay;

    public class TrashCommand : IChatCommandHandler
    {
        [ChatCommand("Trash selected item", ChatAuthorizationLevel.User)]
        public static void Trash(User user)
        {
            ItemStack selectedItemStack = user.Inventory.Toolbar.SelectedStack;
            if (selectedItemStack != null && selectedItemStack.Item != null)
                user.Inventory.Toolbar.TryRemoveItems(selectedItemStack);
        }
        
        [ChatCommand("Trash carried item", ChatAuthorizationLevel.User)]
        public static void TrashCarried(User user)
        {
            user.Inventory.Carried.Clear(user);
        }
    }
}
