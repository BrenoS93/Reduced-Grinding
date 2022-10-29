﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class SpawnSmallMimic : ModPlayer
    {
        public override void PreUpdate()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (!GetInstance<IOtherConfig>().AllSpawningRegularMimics)
                {
                    return;
                }
                if (Player.chest == -1 && Player.lastChest >= 0 && Main.chest[Player.lastChest] != null && Main.chest[Player.lastChest] != null)
                {
                    int x = Main.chest[Player.lastChest].x;
                    int y = Main.chest[Player.lastChest].y;
                    SmallMimicSummonCheck(x, y);
                }
            }
        }

        public bool SmallMimicSummonCheck(int x, int y)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient || !Main.hardMode)
            {
                return false;
            }
            int chestCount = Chest.FindChest(x, y);
            if (chestCount < 0)
            {
                return false;
            }
            int keyOfLightCount = 0;
            int keyOfNightCount = 0;
            int otherItemCount = 0;
            for (int i = 0; i < 40; i++)
            {
                ushort selectedChest = Main.tile[Main.chest[chestCount].x, Main.chest[chestCount].y].TileType;
                int frame = Main.tile[Main.chest[chestCount].x, Main.chest[chestCount].y].TileFrameX / 36;
                if (TileID.Sets.BasicChest[selectedChest] && (selectedChest != 21 || frame < 5 || frame > 6) && Main.chest[chestCount].item[i] != null && Main.chest[chestCount].item[i].type > ItemID.None)
                {
                    if (Main.chest[chestCount].item[i].type == ItemID.LightKey)
                    {
                        keyOfLightCount += Main.chest[chestCount].item[i].stack;
                    }
                    else if (Main.chest[chestCount].item[i].type == ItemID.NightKey)
                    {
                        keyOfNightCount += Main.chest[chestCount].item[i].stack;
                    }
                    else
                    {
                        otherItemCount++;
                    }
                }
            }
            if (otherItemCount == 0 && keyOfLightCount == 1 && keyOfNightCount == 1)
            {
                if (TileID.Sets.BasicChest[Main.tile[x, y].TileType])
                {
                    if (Main.tile[x, y].TileFrameX % 36 != 0)
                    {
                        x--;
                    }
                    if (Main.tile[x, y].TileFrameY % 36 != 0)
                    {
                        y--;
                    }
                    int chest = Chest.FindChest(x, y);
                    for (int j = 0; j < 40; j++)
                    {
                        Main.chest[chestCount].item[j].SetDefaults(ItemID.None);
                    }
                    Chest.DestroyChest(x, y);
                    for (int k = x; k <= x + 1; k++)
                    {
                        for (int l = y; l <= y + 1; l++)
                        {
                            if (TileID.Sets.BasicChest[Main.tile[k, l].TileType])
                            {
                                Main.tile[k, l].ClearTile();
                            }
                        }
                    }
                    int number2 = 1;
                    if (Main.tile[x, y].TileType == 467)
                    {
                        number2 = 5;
                    }
                    NetMessage.SendData(MessageID.ChestUpdates, -1, -1, null, number2, x, y, 0f, chest);
                    NetMessage.SendTileSquare(-1, x, y, 3);
                }
                var source = Player.GetSource_FromThis();
                int mimicType = NPCID.Mimic;
                if (Player.ZoneSnow)
                    mimicType = NPCID.IceMimic;
                int newMimic = NPC.NewNPC(source, x * 16 + 16, y * 16 + 32, mimicType);
                Main.npc[newMimic].whoAmI = newMimic;
                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, newMimic);
                Main.npc[newMimic].BigMimicSpawnSmoke();
            }
            return false;
        }
    }
}
