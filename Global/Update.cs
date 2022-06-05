﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class Update : ModSystem
    {
        //Gets recording into world save
        public static bool advanceMoonPhase = false;
        public static int sundialSearchTimer = 0;
        public static int sundialX = -1;
        public static int sundialY = -1;
        public static bool nearPylon = false;
        public static bool noMoreAnglerResetsToday = false;
        public static bool dayTime = true;

        public override void PostUpdateTime()
        {
            float sleepBoost = GetInstance<IOtherConfig>().SleepBoostBase;

            if (GetInstance<IOtherConfig>().SleepBoostNoSundialMultiplier < 1)
            {
                sundialSearchTimer++;
                if (sundialSearchTimer == GetInstance<IOtherConfig>().SundialSearchSpeed * 60)
                {
                    nearPylon = false;
                    sundialX = sundialY = -1;
                    for (int i = 0; i < Main.maxTilesY; i++)
                    {
                        for (int j = 0; j < Main.maxTilesX; j++)
                        {
                            if (Main.tile[j, i].TileType == TileID.Sundial)
                            {
                                sundialX = j + 1;
                                sundialY = i + 1;
                                goto finishedSundialCheck;
                            }
                        }
                    }
                    finishedSundialCheck: { }
                }

                if (sundialX == -1)
                    sleepBoost *= GetInstance<IOtherConfig>().SleepBoostNoSundialMultiplier;
            }
            else
                sundialX = sundialY = -1;

            bool boostTime = true;
            if (Main.fastForwardTime)
                boostTime = false;
            if (Main.CurrentFrameFlags.SleepingPlayersCount != Main.CurrentFrameFlags.ActivePlayersCount)
                boostTime = false;
            if (Main.CurrentFrameFlags.SleepingPlayersCount < 1)
                boostTime = false;

            bool playerWithSleepBuff = false;

            int anglerResetChance;
            if (NPC.downedPlantBoss)
                anglerResetChance = GetInstance<CFishingConfig>().AnglerRecentChanceAfterPlantera;
            else if (Main.hardMode)
                anglerResetChance = GetInstance<CFishingConfig>().AnglerRecentChanceHardmode;
            else
                anglerResetChance = GetInstance<CFishingConfig>().AnglerRecentChanceBeforeHardmode;

            int fishermenCount = 0;
            List<int> activePlayers = new() { };

            for (int i = 0; i < 255; i++)
            {
                if (!Main.player[i].active)
                    continue;
                activePlayers.Add(i);
                if (sundialX > -1 && !nearPylon && sundialSearchTimer == GetInstance<IOtherConfig>().SundialSearchSpeed * 60)
                {
                    for (int x = -20; x <= 20; x++)
                    {
                        for (int y = -20; y <= 20; y++)
                        {
                            Point tileLocation = Main.player[i].Center.ToTileCoordinates();
                            int tilex = tileLocation.X + x;
                            int tiley = tileLocation.Y + y;
                            if (Main.tile[tilex, tiley].TileType == TileID.TeleportationPylon)
                            {
                                nearPylon = true;
                                goto finishedPylonCheck;
                            }
                        }
                    }
                    finishedPylonCheck: { }
                }
                if (boostTime && !playerWithSleepBuff && GetInstance<IOtherConfig>().SleepBoostNoPotionBuffMultiplier < 1 && Main.player[i].FindBuffIndex(ModContent.BuffType<Buffs.Sleep>()) != -1)
                    playerWithSleepBuff = true;
                if (anglerResetChance > 0 && !noMoreAnglerResetsToday && Main.anglerWhoFinishedToday.Count > 0)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        int armorType = Main.player[i].armor[j].type;
                        if (armorType == ItemID.AnglerHat || armorType == ItemID.AnglerVest || armorType == ItemID.AnglerPants)
                        {
                            fishermenCount++;
                            break;
                        }
                    }
                }

                bool equipped_to_ankh_material = false;
                for (int j = 3; j <= 9; j++)
                {
                    int accessoryType = Main.player[i].armor[j].type;

                    if (accessoryType == ItemID.Vitamins || accessoryType == ItemID.ArmorPolish || accessoryType == ItemID.AdhesiveBandage || accessoryType == ItemID.Bezoar || accessoryType == ItemID.Nazar || accessoryType == ItemID.Megaphone || accessoryType == ItemID.TrifoldMap || accessoryType == ItemID.FastClock || accessoryType == ItemID.Blindfold || accessoryType == ItemID.ArmorBracing || accessoryType == ItemID.MedicatedBandage || accessoryType == ItemID.CountercurseMantra || accessoryType == ItemID.ThePlan)
                    {
                        equipped_to_ankh_material = true;
                        break;
                    }
                }

                if (equipped_to_ankh_material)
                {
                    for (int j = 0; j < Main.player[i].inventory.Length; j++)
                    {
                        int itemType = Main.player[i].inventory[j].type;

                        if (itemType == ItemID.ArmorBracing || itemType == ItemID.Vitamins)
                            Main.player[i].ClearBuff(BuffID.Weak);

                        if (itemType == ItemID.ArmorBracing || itemType == ItemID.ArmorPolish)
                            Main.player[i].ClearBuff(BuffID.BrokenArmor);

                        if (itemType == ItemID.MedicatedBandage || itemType == ItemID.AdhesiveBandage)
                            Main.player[i].ClearBuff(BuffID.Bleeding);
                        if (itemType == ItemID.MedicatedBandage || itemType == ItemID.Bezoar)
                            Main.player[i].ClearBuff(BuffID.Poisoned);

                        if (itemType == ItemID.CountercurseMantra || itemType == ItemID.Nazar)
                            Main.player[i].ClearBuff(BuffID.Cursed);
                        if (itemType == ItemID.CountercurseMantra || itemType == ItemID.Megaphone)
                            Main.player[i].ClearBuff(BuffID.Silenced);

                        if (itemType == ItemID.ThePlan || itemType == ItemID.FastClock)
                            Main.player[i].ClearBuff(BuffID.Slow);
                        if (itemType == ItemID.ThePlan || itemType == ItemID.TrifoldMap)
                            Main.player[i].ClearBuff(BuffID.Confused);

                        if (itemType == ItemID.Blindfold)
                            Main.player[i].ClearBuff(BuffID.Darkness);
                    }
                }
            }

            if (sundialSearchTimer == GetInstance<IOtherConfig>().SundialSearchSpeed * 60)
                sundialSearchTimer = 0;

            if (boostTime)
            {
                if (playerWithSleepBuff)
                    sleepBoost *= GetInstance<IOtherConfig>().SleepBoostNoPotionBuffMultiplier;
                Main.time += (int)sleepBoost;
                foreach (int i in activePlayers)
                {
                    if (Main.player[i].FindBuffIndex(ModContent.BuffType<Buffs.Sleep>()) != -1)
                        Main.player[i].buffTime[Main.player[i].FindBuffIndex(ModContent.BuffType<Buffs.Sleep>())] -= (int)sleepBoost;
                }
            }

            if (anglerResetChance > 0 && !noMoreAnglerResetsToday && Main.anglerWhoFinishedToday.Count > 0)
            {
                if (fishermenCount <= Main.anglerWhoFinishedToday.Count)
                {
                    if (Main.rand.NextBool(anglerResetChance))
                    {
                        Main.AnglerQuestSwap();
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                        if (Main.netMode == NetmodeID.SinglePlayer)
                            Main.NewText("The Angler has another job for you!", 0, 255, 255);
                        else if (Main.netMode == NetmodeID.Server)
                            ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The Angler has another job for you!"), new Color(0, 255, 255));
                    }
                    else
                        noMoreAnglerResetsToday = true;
                }
            }

            if (Main.dayTime && dayTime != Main.dayTime)
            {
                noMoreAnglerResetsToday = false;
            }
            if (dayTime != Main.dayTime)
            {
                dayTime = Main.dayTime;
            }

            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = Mod.GetPacket();

                packet.Write((byte)ReducedGrinding.MessageType.sundialSearchTimer);
                packet.Write(sundialSearchTimer);

                packet.Write((byte)ReducedGrinding.MessageType.sundialX);
                packet.Write(sundialX);

                packet.Write((byte)ReducedGrinding.MessageType.sundialY);
                packet.Write(sundialY);

                packet.Write((byte)ReducedGrinding.MessageType.nearPylon);
                packet.Write(nearPylon);

                packet.Write((byte)ReducedGrinding.MessageType.noMoreAnglerResetsToday);
                packet.Write(noMoreAnglerResetsToday);

                packet.Write((byte)ReducedGrinding.MessageType.dayTime);
                packet.Write(dayTime);
                packet.Send();

                NetMessage.SendData(MessageID.WorldData);
            }
        }

        public override void PostUpdateWorld()
        {

            if (advanceMoonPhase)
            {
                advanceMoonPhase = false;
                Main.moonPhase++;
                if (Main.moonPhase >= 8)
                {
                    Main.moonPhase = 0;
                }

                if (Main.bloodMoon && Main.moonPhase == 4)
                    Main.bloodMoon = false;

                if (Main.netMode == NetmodeID.Server)
                {
                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.advanceMoonPhase);
                    packet.Write(Global.Update.advanceMoonPhase);
                    packet.Send();
                    NetMessage.SendData(MessageID.WorldData);
                }
            }

            //Mod luiafk = ModLoader.GetMod("Luiafk"); TODO
            //if (GetInstance<IOtherCustomNPCsConfig>().BoneMerchant && !(luiafk != null && GetInstance<IOtherCustomNPCsConfig>().BoneMerchantDisabledWhenLuiafkIsInstalled))
        }
    }
}
