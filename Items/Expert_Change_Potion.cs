using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria;

namespace ReducedGrinding.Items
{
	public class Expert_Change_Potion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Expert Change Potion");
			Tooltip.SetDefault("Switches World Difficulty.");
		}
		
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 30;
			item.maxStack = 30;
			item.rare = 0;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.value = (Config.ExpertChangePotionMushroomCost * 250 + Config.ExpertChangePotionGlowingMushroomCost * 10) * 285 / 100;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return true;
		}

		public override bool UseItem(Player player)
		{
			if (Main.netMode == 2) // Server
			{
				if (Main.expertMode)
					NetMessage.BroadcastChatMessage(NetworkText.FromKey("World difficulty is now Normal Mode."), new Color(255, 255, 0));
				else
					NetMessage.BroadcastChatMessage(NetworkText.FromKey("World difficulty is now Expert Mode."), new Color(207, 136, 255));
			}
			else if (Main.netMode == 0) // Single Player
			{
				if (Main.expertMode)
					Main.NewText("World difficulty is now Normal Mode.", 255, 255, 0);
				else
					Main.NewText("World difficulty is now Expert Mode.", 207, 136, 255);
			}
			Main.expertMode = (!Main.expertMode);
			return true;
		}
	
		public override void AddRecipes()
		{

			if (Config.ExpertChangePotionRecipe_SET_TO_FALSE_IF_YOU_THINK_PLAYERS_MIGHT_ABUSE_THIS)
			{
				ModRecipe recipe = new ModRecipe(mod);
				if (Config.ExpertChangePotionMushroomCost > 0)
					recipe.AddIngredient(ItemID.Mushroom, Config.ExpertChangePotionMushroomCost);
				if (Config.ExpertChangePotionGlowingMushroomCost > 0)
					recipe.AddIngredient(ItemID.GlowingMushroom, Config.ExpertChangePotionGlowingMushroomCost);
				recipe.AddIngredient(ItemID.BottledWater, 1);
				recipe.AddTile(TileID.Bottles);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		
		}
	}
}