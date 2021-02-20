﻿using ProjectEarthServerAPI.Models.Features;

namespace ProjectEarthServerAPI.Util
{
    public class UtilityBlockUtils
    {
        public static UtilityBlocksResponse ReadUtilityBlocks(string playerId)
        {
            return GenericUtils.ParseJsonFile<UtilityBlocksResponse>(playerId, "utilityBlocks");
        }

        public static bool WriteUtilityBlocks(string playerId, UtilityBlocksResponse obj)
        {
            return GenericUtils.WriteJsonFile(playerId, obj, "utilityBlocks");
        }

        public static bool UpdateUtilityBlocks(string playerId,int slot, CraftingSlotInfo job)
        {
            var currentUtilBlocks = ReadUtilityBlocks(playerId);
            currentUtilBlocks.result.crafting[slot.ToString()] = job;
            currentUtilBlocks.result.crafting["2"].streamVersion = job.streamVersion;
            currentUtilBlocks.result.crafting["3"].streamVersion = job.streamVersion;

            WriteUtilityBlocks(playerId, currentUtilBlocks);

            return true;
        }

    }
}