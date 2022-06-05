﻿using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class SpawnRates : GlobalNPC
    {
        class SpawnRateMultiplierGlobalNPC : GlobalNPC
        {
            public override void EditSpawnRate(Terraria.Player player, ref int spawnRate, ref int maxSpawns)
            {
                if (player.FindBuffIndex(ModContent.BuffType<Buffs.War>()) != -1)
                {
                    spawnRate = (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().WarPotionSpawnrateMultiplier);
                    maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().WarPotionMaxSpawnsMultiplier);
                }
                if (player.FindBuffIndex(ModContent.BuffType<Buffs.Chaos>()) != -1)
                {
                    spawnRate = (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().ChaosPotionSpawnrateMultiplier);
                    maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().ChaosPotionMaxSpawnsMultiplier);
                }
            }
        }
    }
}
