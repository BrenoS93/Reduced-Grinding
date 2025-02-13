using ReducedGrinding.Configuration;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items
{
    public class MoonWatch : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 19);
        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (Main.bloodMoon)
            {
                Main.NewText("The Moon Watch doesn't work during the Blood Moon.", 255, 127, 127);
            }

            if (player.whoAmI == Main.myPlayer)
            {
                Global.Update.advanceMoonPhase = true;
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.advanceMoonPhase);
                    packet.Write(Global.Update.advanceMoonPhase);
                    packet.Send();
                }
                SoundEngine.PlaySound(SoundID.Item4); //Crystal Ball
            }

            return true;
        }

        public override void AddRecipes()
        {
            if (GetInstance<HOtherModdedItemsConfig>().MoonWatch > 0)
            {
                Recipe recipe = Recipe.Create(Type);
                recipe.AddTile(TileID.Tables);
                recipe.AddTile(TileID.Chairs);
                recipe.AddIngredient(ItemID.FallenStar);
                recipe.AddIngredient(ItemID.Chain);
                if (GetInstance<HOtherModdedItemsConfig>().MoonWatch == 1)
                {
                    recipe.AddIngredient(ItemID.GoldBar);
                    recipe.Register();

                    recipe = Recipe.Create(Type);
                    recipe.AddIngredient(ItemID.PlatinumBar);
                    recipe.Register();
                }
                else if (GetInstance<HOtherModdedItemsConfig>().MoonWatch == 2)
                {
                    recipe.AddIngredient(ItemID.DemoniteBar);
                    recipe.Register();

                    recipe = Recipe.Create(Type);
                    recipe.AddIngredient(ItemID.CrimtaneBar);
                    recipe.Register();
                }
                else if (GetInstance<HOtherModdedItemsConfig>().MoonWatch == 3)
                {
                    recipe.AddIngredient(ItemID.HellstoneBar);
                    recipe.Register();
                }
            }
        }
    }
}
