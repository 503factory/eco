
// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods
{
    using Eco.Gameplay.Systems.Chat;
    using Eco.Gameplay.Players;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Shared.Math;
    using Eco.Simulation.WorldLayers;
    using Eco.Gameplay.Objects;

    public class PollutionCommands : IChatCommandHandler
    {

        [ChatCommand("Rains tailings from the heavens to ruin the world", ChatAuthorizationLevel.Admin)]
        public static void PolluteWorld(User user)
        {
            for (int i = 0; i < 1000; i++)
            {
                World.SetBlock<TailingsBlock>(World.GetTopPos(World.GetRandomLandPos().XZ) + Vector3i.Up);
            }
        }

        [ChatCommand("Creates x PPM of air pollution", ChatAuthorizationLevel.Admin)]
        public static void PolluteCO2(User user, float ppm)
        {
            WorldLayerManager.ClimateSim.AddAirPollution(new WorldPosition3i(user.Position.XYZi), ppm);
        }

        [ChatCommand("Creates AIR POLLUTION MACHINES OF DOOM", ChatAuthorizationLevel.Admin)]
        public static void PolluteAir(User user)
        {
            for (int i = 0; i < 50; i++)
            {
                WorldObjectManager.TryToAdd(WorldObjectManager.GetTypeFromName("APGenObject"), user, World.GetTopPos(World.GetRandomLandPos().XZ) + Vector3i.Up, Quaternion.Identity);
            }
        }
    }
}