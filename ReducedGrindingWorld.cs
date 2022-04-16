using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Terraria;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using System;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding
{
	public class ReducedGrindingWorld : ModWorld
    {
		//Gets recording into world save
		public static bool advanceMoonPhase = false;
		public static bool skipToDay = false;
		public static bool skipToNight = false;
        public static bool skippedToDayOrNight = false;
		
        public override TagCompound Save()
        {
			return new TagCompound
			{
				{"skippedToDayOrNight", skippedToDayOrNight}
			};
        }

        public override void Load(TagCompound tag)
        {
			skippedToDayOrNight = tag.GetBool("skippedToDayOrNight");
        }

		public override void PostUpdate()
		{
			Player player = Main.player[Main.myPlayer];

			int playerCoinAmount = 0;
			foreach (Item i in player.inventory)
			{
				switch (i.type)
				{
					case ItemID.CopperCoin:
						playerCoinAmount += 1 * i.stack;
						break;
					case ItemID.SilverCoin:
						playerCoinAmount += 100 * i.stack;
						break;
					case ItemID.GoldCoin:
						playerCoinAmount += 10000 * i.stack;
						break;
					case ItemID.PlatinumCoin:
						playerCoinAmount += 1000000 * i.stack;
						break;
				}
			}

			bool anyPlayerHasCelestialBeacon = false;
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					if (Main.player[i].HasItem(mod.ItemType("Celestial_Beacon")))
						anyPlayerHasCelestialBeacon = true;
				}
			}

			if (NPC.MoonLordCountdown > 1 && anyPlayerHasCelestialBeacon)
				NPC.MoonLordCountdown = 1;

			if (Main.time % 600 == 0 && !NPC.downedMoonlord)
			{
				for (int i = 0; i < Main.npc.Length; i++)
				{
					if (Main.npc[i].type == NPCID.MoonLordCore && !anyPlayerHasCelestialBeacon)
					{
						Main.player[(int)Player.FindClosest(Main.npc[i].position, Main.npc[i].width, Main.npc[i].height)].QuickSpawnItem(mod.ItemType("Celestial_Beacon"));
						break;
					}
				}
			}

			if (advanceMoonPhase)
			{
				advanceMoonPhase = false;
				Main.moonPhase++;
				if (Main.moonPhase >= 8)
				{
					Main.moonPhase = 0;
				}
				if (Main.netMode == NetmodeID.Server)
				{
					var netMessage = mod.GetPacket();
					netMessage.Write((byte)ReducedGrindingMessageType.advanceMoonPhase);
					netMessage.Write(ReducedGrindingWorld.advanceMoonPhase);
					netMessage.Send();

					NetMessage.SendData(7);
				}
			}

			if (skipToNight)
			{
				if (Main.sundialCooldown > 0)
					ReducedGrindingWorld.skippedToDayOrNight = true;
				Main.time = 54000;
				skipToDay = false;
				skipToNight = false;
				//Force Traveling Merchant despawn in order to prevent exploiting.
				int travelingMerchantTarget = -1;
				for (int i = 0; i < 200; i++)
				{
					if (Main.npc[i].active && Main.npc[i].type == NPCID.TravellingMerchant)
					{
						travelingMerchantTarget = i;
						break;
					}
				}
				if (travelingMerchantTarget > -1)
				{
					string fullName = Main.npc[travelingMerchantTarget].FullName;
					if (Main.netMode == NetmodeID.SinglePlayer)//0)
						Main.NewText(Lang.misc[35].Format(fullName), 50, 125);
					else if (Main.netMode == NetmodeID.Server)//2)
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.misc[35].Key, Main.npc[travelingMerchantTarget].GetFullNetName()), new Color(50, 125, 255));
					Main.npc[travelingMerchantTarget].active = false;
					Main.npc[travelingMerchantTarget].netSkip = -1;
					Main.npc[travelingMerchantTarget].life = 0;
					NetMessage.SendData(23, -1, -1, null, travelingMerchantTarget);
				}
				if (Main.netMode == NetmodeID.Server) //Server
				{
					var netMessage = mod.GetPacket();
					netMessage.Write((byte)ReducedGrindingMessageType.skipToNight);
					netMessage.Write(ReducedGrindingWorld.skipToNight);

					netMessage.Write((byte)ReducedGrindingMessageType.skipToDay);
					netMessage.Write(ReducedGrindingWorld.skipToDay);
					netMessage.Send();

					NetMessage.SendData(7);
				}
			}

			if (skipToDay)
			{
				if (Main.sundialCooldown > 0)
					ReducedGrindingWorld.skippedToDayOrNight = true;
				Main.time = 32400;
				skipToDay = false;
				skipToNight = false;
				if (Main.netMode == NetmodeID.Server)
				{
					var netMessage = mod.GetPacket();
					netMessage.Write((byte)ReducedGrindingMessageType.skipToNight);
					netMessage.Write(ReducedGrindingWorld.skipToNight);

					netMessage.Write((byte)ReducedGrindingMessageType.skipToDay);
					netMessage.Write(ReducedGrindingWorld.skipToDay);
					netMessage.Send();

					NetMessage.SendData(7);
				}
			}

			if (Main.dayTime && skippedToDayOrNight)
			{
				Main.sundialCooldown++;
				skippedToDayOrNight = false;
			}

			//There are 21 stationary vanilla NPCs (excluding Guide and Santa) as of 5/26/2017; 15 Pre-Hardmode and 6 Hardmode.
			float TownNPCs = 0f;
			float TownNPCsMax = 15f;
			float TownHardmodeNPCs = 0f;
			float TownHardmodeNPCsMax = 6f;
			bool travelingMerchantExists = false;
			bool stationaryMerchantExists = false;
			bool tryToSpawnTravelingMerchant = true;

			Mod luiafk = ModLoader.GetMod("Luiafk");
			if (GetInstance<IOtherCustomNPCsConfig>().BoneMerchant && !(luiafk != null && GetInstance<IOtherCustomNPCsConfig>().BoneMerchantDisabledWhenLuiafkIsInstalled))
				TownNPCsMax++;
			if (GetInstance<IOtherCustomNPCsConfig>().ChestSalesman)
				TownNPCsMax++;
			if (GetInstance<ETravelingAndStationaryMerchantConfig>().StationaryMerchant)
				TownNPCsMax++;
			if (GetInstance<IOtherCustomNPCsConfig>().LootMerchant)
				TownNPCsMax++;
			if (GetInstance<IOtherCustomNPCsConfig>().ChristmasElf)
				TownHardmodeNPCsMax++;

			for (int i = 0; i < Terraria.Main.npc.Length; i++) //Do once for each NPC in the world
			{
				if (Terraria.Main.npc[i].townNPC == true)
				{
					if (Terraria.Main.npc[i].type == NPCID.TravellingMerchant)
					{
						travelingMerchantExists = true;
						tryToSpawnTravelingMerchant = false;
					}
					if (Terraria.Main.npc[i].type == mod.NPCType("StationaryMerchant"))
						stationaryMerchantExists = true;
					if (
						Terraria.Main.npc[i].type == NPCID.Merchant ||
						Terraria.Main.npc[i].type == NPCID.Nurse ||
						Terraria.Main.npc[i].type == NPCID.Demolitionist ||
						Terraria.Main.npc[i].type == NPCID.DyeTrader ||
						Terraria.Main.npc[i].type == NPCID.Dryad ||
						Terraria.Main.npc[i].type == NPCID.DD2Bartender ||
						Terraria.Main.npc[i].type == NPCID.ArmsDealer ||
						Terraria.Main.npc[i].type == NPCID.Stylist ||
						Terraria.Main.npc[i].type == NPCID.Painter ||
						Terraria.Main.npc[i].type == NPCID.Angler ||
						Terraria.Main.npc[i].type == NPCID.GoblinTinkerer ||
						Terraria.Main.npc[i].type == NPCID.WitchDoctor ||
						Terraria.Main.npc[i].type == NPCID.Clothier ||
						Terraria.Main.npc[i].type == NPCID.Mechanic ||
						Terraria.Main.npc[i].type == NPCID.PartyGirl ||
						(Terraria.Main.npc[i].type == mod.NPCType("BoneMerchant") && GetInstance<IOtherCustomNPCsConfig>().BoneMerchant) ||
						(Terraria.Main.npc[i].type == mod.NPCType("ChestSalesman") && GetInstance<IOtherCustomNPCsConfig>().ChestSalesman) ||
						(Terraria.Main.npc[i].type == mod.NPCType("StationaryMerchant") && GetInstance<ETravelingAndStationaryMerchantConfig>().StationaryMerchant) ||
						(Terraria.Main.npc[i].type == mod.NPCType("LootMerchant") && GetInstance<IOtherCustomNPCsConfig>().LootMerchant)
					)
						TownNPCs++;
					else if (
						Terraria.Main.npc[i].type == NPCID.Wizard ||
						Terraria.Main.npc[i].type == NPCID.TaxCollector ||
						Terraria.Main.npc[i].type == NPCID.Truffle ||
						Terraria.Main.npc[i].type == NPCID.Pirate ||
						Terraria.Main.npc[i].type == NPCID.Steampunker ||
						Terraria.Main.npc[i].type == NPCID.Cyborg ||
						(Terraria.Main.npc[i].type == mod.NPCType("Christmas Elf") && GetInstance<IOtherCustomNPCsConfig>().ChristmasElf)
					)
					{
						TownHardmodeNPCs++;
					}
				}
			}

			float TownNPCPercent = (TownNPCs / TownNPCsMax + TownHardmodeNPCs / TownHardmodeNPCsMax) / 2;

			if (!Main.fastForwardTime && Main.dayTime && Main.time < 27000.0)
			{
				int alltownNPCs = 0;
				for (int j = 0; j < 200; j++)
				{
					if (Main.npc[j].active && Main.npc[j].townNPC && Main.npc[j].type != 37 && Main.npc[j].type != 453)
					{
						alltownNPCs++;
					}
				}
				if (alltownNPCs >= 2)
				{
					if (tryToSpawnTravelingMerchant)
					{
						tryToSpawnTravelingMerchant = false;
						if (!Main.fastForwardTime && Main.dayTime && Main.time < 27000.0)
						{
							int chanceRoll = (int)(27000.0 / (double)Main.dayRate);
							chanceRoll *= 4;
							for (int i = 0; i < 3; i++)
							{
								if (Main.rand.Next(chanceRoll) == 0)
								{
									tryToSpawnTravelingMerchant = true;
									break;
								}
							}
						}
					}
					if (tryToSpawnTravelingMerchant && Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().BaseMorningTMerchantSpawnChance * Math.Pow(TownNPCPercent, 2))
						WorldGen.SpawnTravelNPC();
				}
			}
		}
	}
}
