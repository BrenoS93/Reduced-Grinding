using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items.LockBoxes
{
	public class Cavern_Lock_Box : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cavern Lock Box");
			Tooltip.SetDefault("It's already unlocked\nRight click to open");
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 22;
			Item.maxStack = 99;
			Item.rare = ItemRarityID.White;
			Item.value = Item.buyPrice(0, 1, 0, 0);
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{

			float dropChance = 0f;
			int testItemID = 0;
			int chosenID = 0;
			var source = player.GetSource_DropAsItem();

			if (GetInstance<GLockbBoxConfig>().LockBoxesGiveFurniture)
			{
				//Cabin Statues
				dropChance = 0.0169f;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 52;
				for (testItemID = 438; testItemID <= 441; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 443;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 446;
				for (testItemID = 448; testItemID <= 455; testItemID++)
				{

					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				for (testItemID = 457; testItemID <= 463; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				for (testItemID = 465; testItemID <= 473; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				for (testItemID = 475; testItemID <= 478; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 2672;
				for (testItemID = 3708; testItemID <= 3720; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				if (chosenID != 476 && chosenID != 477 && Main.rand.Next(10) == 0) //10% chance of being king or queen statue
					player.QuickSpawnItem(source, Main.rand.Next(476, 478));
				else
					player.QuickSpawnItem(source, chosenID);
				chosenID = 0;

				//Cabin Paintings
				dropChance = 0.0067f; //About 0.1 paintings when rolling 1 time for 15 paintings
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1427;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1428;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1442;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1443;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1474;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1480;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1495;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1496;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1498;
				for (testItemID = 1574; testItemID <= 1577; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				player.QuickSpawnItem(source, chosenID);
				chosenID = 0;
			}
			
			if (GetInstance<GLockbBoxConfig>().LockBoxesGiveNonFurniture)
			{
				//Cavern Rare Items
				if (Main.rand.Next(40) == 0)
				{
					player.QuickSpawnItem(source, 906, 1); //Lava Charm
				}
				else if (Main.rand.Next(15) == 0)
				{
					player.QuickSpawnItem(source, 997, 1); //Extractinator
				}
				else
				{
					switch (Main.rand.Next(7))
					{
						case 0:
							player.QuickSpawnItem(source, 49, 1); //Band of Regeneration
							break;
						case 1:
							player.QuickSpawnItem(source, 50, 1); //Magic Mirror
							break;
						case 2:
							player.QuickSpawnItem(source, 53, 1); //Cloud in a Bottle
							break;
						case 3:
							player.QuickSpawnItem(source, 54, 1); //Hermes Boots
							break;
						case 4:
							player.QuickSpawnItem(source, 55, 1); //Enchanted Boomerang
							break;
						case 5:
							player.QuickSpawnItem(source, 975, 1); //Shoe Spikes
							break;
						case 6:
							player.QuickSpawnItem(source, 930); //Flare Gun
							player.QuickSpawnItem(source, 931, Main.rand.Next(25, 51)); //Flares
							break;
					}
				}

				//Cavern Gold Chest Common Items
				if (Main.rand.Next(5) == 0)
					player.QuickSpawnItem(source, 43, 1); //Suspicious Looking Eye
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(source, 167, 1); //Dynamite
				if (Main.rand.Next(4) == 0)
					player.QuickSpawnItem(source, 51, Main.rand.Next(25, 51)); //Jester's Arrow
				if (Main.rand.Next(2) == 0)
				{
					switch (Main.rand.Next(4))
					{
						case 0:
							chosenID = WorldGen.silverBar;
							break;
						case 1:
							chosenID = WorldGen.goldBar;
							break;
						default:
							chosenID = 0;
							break;
					}
					player.QuickSpawnItem(source, chosenID, Main.rand.Next(3, 11));
				}
				if (Main.rand.Next(2) == 0)
				{
					switch (Main.rand.Next(2))
					{
						case 0:
							chosenID = 41; //Flaming Arrow
							break;
						case 1:
							chosenID = 279; //Throwing Knife
							break;
					}
					player.QuickSpawnItem(source, chosenID, Main.rand.Next(25, 51));
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(source, 188, Main.rand.Next(3, 6)); //Healing Potion
				if (Main.rand.Next(3) <= 1)
				{
					switch (Main.rand.Next(6))
					{
						case 0:
							chosenID = 296; //Spelunker Potion
							break;
						case 1:
							chosenID = 295; //Featherfall Potion
							break;
						case 2:
							chosenID = 299; //Night Owl Potion
							break;
						case 3:
							chosenID = 302; //Water Walking Potion
							break;
						case 4:
							chosenID = 303; //Archery Potion
							break;
						case 5:
							chosenID = 305; //Gravitation Potion
							break;
					}
					player.QuickSpawnItem(source, chosenID, Main.rand.Next(1, 3));
				}
				else
				{
					switch (Main.rand.Next(6))
					{
						case 0:
							chosenID = 301; //Thorns Potion
							break;
						case 1:
							chosenID = 302; //Water Walking Potion
							break;
						case 2:
							chosenID = 297; //Invisiblity Potion
							break;
						case 3:
							chosenID = 304; //Hunter Potion
							break;
						case 4:
							chosenID = 2329; //Dangersense Potion
							break;
						case 5:
							chosenID = 2351; //Teleportation Potion
							break;
					}
					player.QuickSpawnItem(source, chosenID, Main.rand.Next(1, 3));
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(source, 2350, Main.rand.Next(1, 3)); //Recal Potion
				if (Main.rand.Next(2) == 0)
				{
					switch (Main.rand.Next(2))
					{
						case 0:
							chosenID = 8; //Torch
							break;
						case 1:
							chosenID = 282; //Glowstick
							break;
					}
					player.QuickSpawnItem(source, chosenID, Main.rand.Next(15, 30));
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(source, 73, Main.rand.Next(2, 3)); //Gold Coin
			}
		}

	}
}