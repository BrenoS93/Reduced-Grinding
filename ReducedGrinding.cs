﻿/* To debug, use:
 * using static Terraria.ModLoader.ModContent;
 * GetInstance<ReducedGrinding>().Logger.Debug("");
 * 
 * To turn into a string use:
 * Value.ToString()
 * 
 * To show text in chat use:
 * Main.NewText(string);
 */

using System.IO;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ReducedGrinding
{

    class ReducedGrinding : Mod
    {
        public static int FishCoin;

        public override void Load()
        {
            FishCoin = CustomCurrencyManager.RegisterCurrency(new Currencies.FishCoinCurrency(ModContent.ItemType<Items.FishCoin>(), 9999L, "Fish Coin"));

            ModLoader.TryGetMod("Wikithis", out Mod wikithis);
            if (wikithis != null && !Main.dedServ)
            {
                wikithis.Call("AddModURL", this, "terrariamods.fandom.com$Reduced_Grinding");
            }
        }

        internal enum MessageType : byte
        {
            advanceMoonPhase,
            advanceDifficulty,
            anglerQuests,
            dayTime,
            instantInvasion,
            travelingMerchantDiceRolls,
            chatMerchantItems,
            anglerResetTimer
        }

        //NOTE: You can test 2 players on 1 PC using the start-tModLoader.bat files.
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            MessageType msgType = (MessageType)reader.ReadByte();
            switch (msgType)
            {
                case MessageType.advanceMoonPhase:
                    Global.Update.advanceMoonPhase = reader.ReadBoolean();
                    break;
                case MessageType.advanceDifficulty:
                    Global.Update.advanceDifficulty = reader.ReadBoolean();
                    break;
                case MessageType.anglerQuests:
                    Global.Update.anglerQuests = reader.ReadInt32();
                    break;
                case MessageType.dayTime:
                    Global.Update.dayTime = reader.ReadBoolean();
                    break;
                case MessageType.instantInvasion:
                    Global.Update.instantInvasion = reader.ReadBoolean();
                    break;
                case MessageType.travelingMerchantDiceRolls:
                    Global.Update.travelingMerchantDiceRolls = reader.ReadInt32();
                    break;
                case MessageType.chatMerchantItems:
                    Global.Update.chatMerchantItems = reader.ReadBoolean();
                    break;
                case MessageType.anglerResetTimer:
                    Global.Update.anglerResetTimer = reader.ReadInt32();
                    break;
                default:
                    Logger.WarnFormat("Reduced Grinding: Unknown Message type: {0}", msgType);
                    break;
            }
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
            }
        }
    }

    class ReducedGrindingSave : ModSystem
    {
        public static bool usingCalamity = false;

        public override void OnWorldUnload()
        {
            Global.Update.anglerQuests = 1;
            Global.Update.dayTime = true;
            Global.Update.travelingMerchantDiceRolls = 0;
        }

        public override void OnWorldLoad()
        {
            Global.Update.anglerQuests = 1;
            Global.Update.dayTime = true;
            Global.Update.travelingMerchantDiceRolls = 0;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag["anglerQuests"] = Global.Update.anglerQuests;
            tag["dayTime"] = Global.Update.dayTime;
            tag["travelingMerchantDiceRolls"] = Global.Update.travelingMerchantDiceRolls;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            if (!tag.TryGet("anglerQuests", out Global.Update.anglerQuests))
            {
                Global.Update.anglerQuests = 1;
            }
            if (!tag.TryGet("dayTime", out Global.Update.dayTime))
            {
                Global.Update.dayTime = true;
            }
            if (!tag.TryGet("travelingMerchantDiceRolls", out Global.Update.travelingMerchantDiceRolls))
            {
                Global.Update.travelingMerchantDiceRolls = 0;
            }
        }

        public override void OnModLoad()
        {
            if (ModLoader.TryGetMod("CalamityMod", out _))
            {
                usingCalamity = true;
            }
        }
    }
}
