using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Chat;

namespace ReducedGrinding.Items
{
	public class Rain_Potion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rain Potion");
            Tooltip.SetDefault("Toggles the rain; the amount of cloud coverage will also match it.");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.maxStack = 30;
            Item.rare = ItemRarityID.Green;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = Item.buyPrice(0, 0, 2, 0);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
        }

        public override bool CanUseItem(Terraria.Player player)
        {
            return true;
        }

        public override bool? UseItem(Terraria.Player player)
        {
			if (Main.raining)
			{
				StopRain();
				Main.cloudBGActive = 0f;
				Main.cloudBGAlpha = 0f;
				Main.numClouds = 0;
			}
			else
			{
				StartRain();
				Main.cloudBGActive = 1f;
				Main.cloudBGAlpha = 1f;
				Main.numClouds = 200;
			}
			if (Main.netMode == NetmodeID.Server)
				NetMessage.SendData(MessageID.WorldData);
            return true;
        }
       
        private static void StopRain()
        {
			if (Main.netMode == NetmodeID.Server)
                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The rain started to fade away."), new Color(0, 128, 255));
			else
				Main.NewText("The rain started to fade away.", 0, 128, 255);
            Main.rainTime = 0;
            Main.raining = false;
            Main.maxRaining = 0f;
        }

        private static void StartRain()
        {
			if (Main.netMode == NetmodeID.Server)
                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The rain started to fade in."), new Color(0, 128, 255));
			else
				Main.NewText("The rain started to fade in.", 0, 128, 255);
            int num = 86400;
            int num2 = num / 24;
            Main.rainTime = Main.rand.Next(num2 * 8, num);
            if (Main.rand.NextBool(3))
            {
                Main.rainTime += Main.rand.Next(0, num2);
            }
            if (Main.rand.NextBool(4))
            {
                Main.rainTime += Main.rand.Next(0, num2 * 2);
            }
            if (Main.rand.NextBool(5))
            {
                Main.rainTime += Main.rand.Next(0, num2 * 2);
            }
            if (Main.rand.NextBool(6))
            {
                Main.rainTime += Main.rand.Next(0, num2 * 3);
            }
            if (Main.rand.NextBool(7))
            {
                Main.rainTime += Main.rand.Next(0, num2 * 4);
            }
            if (Main.rand.NextBool(8))
            {
                Main.rainTime += Main.rand.Next(0, num2 * 5);
            }
            float num3 = 1f;
            if (Main.rand.NextBool(2))
            {
                num3 += 0.05f;
            }
            if (Main.rand.NextBool(3))
            {
                num3 += 0.1f;
            }
            if (Main.rand.NextBool(4))
            {
                num3 += 0.15f;
            }
            if (Main.rand.NextBool(5))
            {
                num3 += 0.2f;
            }
            Main.rainTime = (int)((float)Main.rainTime * num3);
            ChangeRain();
            Main.raining = true;
        }
       
        private static void ChangeRain()
        {
            if (Main.cloudBGActive >= 1f || (double)Main.numClouds > 150.0)
            {
                if (Main.rand.NextBool(3))
                {
                    Main.maxRaining = (float)Main.rand.Next(20, 90) * 0.01f;
                    return;
                }
                Main.maxRaining = (float)Main.rand.Next(40, 90) * 0.01f;
                return;
            }
            else if ((double)Main.numClouds > 100.0)
            {
                if (Main.rand.NextBool(3))
                {
                    Main.maxRaining = (float)Main.rand.Next(10, 70) * 0.01f;
                    return;
                }
                Main.maxRaining = (float)Main.rand.Next(20, 60) * 0.01f;
                return;
            }
            else
            {
                if (Main.rand.NextBool(3))
                {
                    Main.maxRaining = (float)Main.rand.Next(5, 40) * 0.01f;
                    return;
                }
                Main.maxRaining = (float)Main.rand.Next(5, 30) * 0.01f;
                return;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ItemID.Waterleaf)
                .AddIngredient(ItemID.RainCloud)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}