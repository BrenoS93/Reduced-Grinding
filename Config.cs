using System.ComponentModel;
using Terraria.ModLoader.Config;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace ReducedGrinding
{

    [Label("Enemy Drop")]
    public class AEnemyDropConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Boss Loot")]

        [Label("[i:1313] Book of Skulls")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBookofSkullsIncrease;

        [Label("[i:1294] Picksaw")]
        [Range(0, 10000)]
        [DefaultValue(3)]
        public int LootPicksawIncrease;

        [Label("[i:1182] Seedling")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int LootSeedlingIncrease;

        [Label("[i:1169] Bone Key")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSkeletronBoneKey;

        [Label("[i:1299] Binoculars")]
        [Range(0, 10000)]
        [DefaultValue(3)]
        public int LootBinocularsIncrease;

        [Label("[i:3060] Bone Rattle")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int LootBoneRattleIncrease;

        [Label("[i:3373] Boss Mask")]
        [Range(0, 10000)]
        [DefaultValue(10)]
        public int LootBossMaskIncrease;

        [Label("[i:3595] Boss Trophy")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBossTrophyIncrease;

        [Label("[i:994] Eater's Bone")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int LootEatersBoneIncrease;

        [Label("[i:2673] Truffle Worm")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int LootFishronTruffleworm;

        [Label("[i:2609] Fishron Wings")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int LootFishronWingsIncrease;

        [Label("[i:2502] Honeyed Goggles")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int LootHoneyedGogglesIncrease;

        [Label("[i:3063] Moon Lord Weapons")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int LootMoonLordEachWeaponIncrease;

        [Label("[i:1170] Nectar")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int LootNectarIncrease;

        [Label("[i:1305] The Axe")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int LootTheAxeIncrease;

        [Header("Non-Boss Loot")]

        [Label("[i:1533] Biome Key Increase")]
        [Range(0, 10000)]
        [DefaultValue(2500)]
        public int LootBiomeKeyIncrease;

        [Tooltip("Chance that an enemy will drop a chest that can be obtained from the biome you are currently in (water enemies will also have this chance to drop Water Chest and Spider Nest enemies will also have this chance to drop Web Covered Chest.")]
        [Label("[i:831] Chest Drop From a Matching Biome")]
        [Range(0, 10000)]
        [DefaultValue(100)]
        public int AllEnemiesLootBiomeMatchingFoundOnlyChestDrop;

        [Label("[i:1322] Magma Stone From Hellbat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int HellBatLootMagmaStoneIncrease;

        [Label("[i:1322] Magma Stone From Lavabat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LavaBatLootMagmaStoneIncrease;

        [Label("[i:885] Adhesive Bandage")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAdhesiveBandageIncrease;

        [Label("[i:3821] Ale Tosser")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int LootAleTosserIncrease;

        [Label("[i:3289] Amarok")]
        [Range(0, 10000)]
        [DefaultValue(150)]
        public int LootAmarokIncrease;

        [Label("[i:3794] Ancient Cloth")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientClothIncrease;

        [Label("[i:961] Ancient Cobalt Breastplate")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientCobaltBreastplateIncrease;

        [Label("[i:960] Ancient Cobalt Helmet")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientCobaltHelmetIncrease;

        [Label("[i:962] Ancient Cobalt Leggings")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientCobaltLeggingsIncrease;

        [Label("[i:955] Ancient Gold Helmet")]
        [Range(0, 10000)]
        [DefaultValue(66)]
        public int LootAncientGoldHelmetIncrease;

        [Label("[i:3771] Ancient Horn")]
        [Range(0, 10000)]
        [DefaultValue(33)]
        public int LootAncientHornIncrease;

        [Label("[i:954] Ancient Iron Helmet")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientIronHelmetIncrease;

        [Label("[i:959] Ancient Necro Helmet")]
        [Range(0, 10000)]
        [DefaultValue(357)]
        public int LootAncientNecroHelmetIncrease;

        [Label("[i:958] Ancient Shadow Greeves")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientShadowGreavesIncrease;

        [Label("[i:956] Ancient Shadow Helmet")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientShadowHelmetIncrease;

        [Label("[i:957] Ancient Shadow Scalemail")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientShadowScalemailIncrease;

        [Label("[i:886] Armor Polish")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootArmorPolishIncrease;

        [Label("[i:1959] Baby Grinch's Mischief Whistle")]
        [Range(0, 10000)]
        [DefaultValue(0.20)]
        public int LootBabyGrinchsMischiefWhistleIncrease;

        [Label("[i:1324] Bananarang")]
        [Range(0, 10000)]
        [DefaultValue(3)]
        public int LootBananarangIncrease;

        [Label("[i:723] Beam Sword")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBeamSwordIncrease;

        [Label("[i:887] Bezoar")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBezoarIncrease;

        [Label("[i:963] Black Belt")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBlackBeltIncrease;

        [Label("[i:236] Black Lens")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBlackLensIncrease;

        [Label("[i:3260] Blessed Apple")]
        [Range(0, 10000)]
        [DefaultValue(151)]
        public int LootBlessedAppleIncrease;

        [Label("[i:888] Blindfold")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBlindfoldIncrease;

        [Label("[i:1825] Bloody Machete")]
        [Range(0, 10000)]
        [DefaultValue(666)]
        public int LootBloodyMacheteAndBladedGlovesIncrease;

        [Label("[i:1517] Bone Feather")]
        [Range(0, 10000)]
        [DefaultValue(128)]
        public int LootBoneFeatherIncrease;

        [Label("[i:1320] Bone Pickaxe")]
        [Range(0, 10000)]
        [DefaultValue(12)]
        public int LootBonePickaxeIncrease;

        [Label("[i:1166] Bone Sword")]
        [Range(0, 10000)]
        [DefaultValue(196)]
        public int LootBoneSwordIncrease;

        [Label("[i:932] Bone Ward")]
        [Range(0, 10000)]
        [DefaultValue(167)]
        public int LootBoneWandIncrease;

        [Label("[i:2771] Brain Scrambler")]
        [Range(0, 10000)]
        [DefaultValue(100)]
        public int LootBrainScramblerIncrease;

        [Label("[i:1520] Broken Bat Wing")]
        [Range(0, 10000)]
        [DefaultValue(14)]
        public int LootBrokenBatWingIncrease;

        [Label("[i:243] Bunny Hood")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBunnyHoodIncrease;

        [Label("[i:3282] Cascade")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int LootCascadeIncrease;

        [Label("[i:3012] Chain Guillotines")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootChainGuillotinesIncrease;

        [Label("[i:1325] Chain Knife")]
        [Range(0, 10000)]
        [DefaultValue(370)]
        public int LootChainKnifeIncrease;

        [Label("[i:3351] Classy Cane")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int LootClassyCane;

        [Label("[i:3014] Clinger Staff")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootClingerStaffIncrease;

        [Label("[i:1307] Clothier Voodoo Doll")]
        [Range(0, 10000)]
        [DefaultValue(21)]
        public int LootClothierVoodooDollIncrease;

        [Label("[i:751] Cloud (From Harpies)")]
        [Range(0, 10000)]
        [DefaultValue(1)]
        public int LootCloudFromHarpies;

        [Label("[i:393] Compass")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootCompassIncrease;

        [Label("[i:554] Cross Necklace")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootCrossNecklaceIncrease;

        [Label("[i:3051] Crystal Vile Shard")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootCrystalVileShardIncrease;

        [Label("[i:3029] Daedalus Stormbow")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootDaedalusStormbowIncrease;

        [Label("[i:527] Dark Shard")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootDarkShardIncrease;

        [Label("[i:3007] Dart Pistol")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootDartPistolIncrease;

        [Label("[i:3008] Dart Rifle")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootDartRifleIncrease;

        [Label("[i:1327] Death Sickle")]
        [Range(0, 10000)]
        [DefaultValue(40)]
        public int LootDeathSickleIncrease;

        [Label("[i:272] Demon Sythe")]
        [Range(0, 10000)]
        [DefaultValue(47)]
        public int LootDemonScytheIncrease;

        [Label("[i:18] Depth Meter")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootDepthMeterIncrease;

        [Label("[i:3347] Desert Fossil (From Dune Splicer)")]
        [Range(0, 10000)]
        [DefaultValue(1)]
        public int LootDesertFossilFromDuneSplicer;

        [Label("[i:3795] Desert Spirit Lamp")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootDesertSpiritLampIncrease;

        [Label("[i:268] Diving Helmet")]
        [Range(0, 10000)]
        [DefaultValue(33)]
        public int LootDivingHelmetIncrease;

        [Label("[i:437] Dual Hook")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootDualHookIncrease;

        [Label("[i:1943] Elf Hat")]
        [Range(0, 10000)]
        [DefaultValue(120)]
        public int LootElfHatIncrease;

        [Label("[i:1945] Elf Pants")]
        [Range(0, 10000)]
        [DefaultValue(120)]
        public int LootElfPantsIncrease;

        [Label("[i:1944] Elf Shirt")]
        [Range(0, 10000)]
        [DefaultValue(120)]
        public int LootElfShirtIncrease;

        [Label("[i:804] Eskimo Coat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootEskimoCoatIncrease;

        [Label("[i:803] Eskimo Hood")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootEskimoHoodIncrease;

        [Label("[i:805] Eskimo Pants")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootEskimoPantsIncrease;

        [Label("[i:3349] Exotic Scimitar")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int LootExoticScimitarIncrease;

        [Label("[i:1278] Eye Patch")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootEyePatchIncrease;

        [Label("[i:1311] Eye Spring")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootEyeSpringIncrease;

        [Label("[i:889] Fast Clock")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootFastClockBaseIncrease;

        [Label("[i:1871] Festive Wings")]
        [Range(0, 10000)]
        [DefaultValue(20)]
        public int LootFestiveWingsIncrease;

        [Label("[i:3013] Fetid Baghnakhs")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootFetidBaghnakhsIncrease;

        [Label("[i:1518] Fire Feather")]
        [Range(0, 10000)]
        [DefaultValue(27)]
        public int LootFireFeatherIncrease;

        [Label("[i:3016] Flesh Knuckles")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootFleshKnucklesIncrease;

        [Label("[i:3030] Flying Knife")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootFlyingKnifeIncrease;

        [Label("[i:726] Frost Staff")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootFrostStaffIncrease;

        [Label("[i:1253] Frozen Turtle Shell")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int LootFrozenTurtleShellIncrease;

        [Label("[i:1906] Giant Bow")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootGiantBowIncrease;

        [Label("[i:1516] Giant Harpy Feather")]
        [Range(0, 10000)]
        [DefaultValue(200)]
        public int LootGiantHarpyFeatherIncrease;

        [Label("[i:1704] Gold Furniture")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootGoldenFurnitureIncrease;

        [Label("[i:327] Golden Key")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootGoldenKeyIncrease;

        [Label("[i:1774] Goodie Bag")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootGoodieBagIncrease;

        [Label("[i:867] Green Cap (For non-Andrew Guide)")]
        [Range(0, 10000)]
        [DefaultValue(1)]
        public int LootGreenCapForNonAndrewGuide;

        [Label("[i:3548] Happy Grenade")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int LootHappyGrenadeIncrease;

        [Label("[i:160] Harpoon")]
        [Range(0, 10000)]
        [DefaultValue(133)]
        public int LootHarpoonIncrease;

        [Label("[i:3290] Hel-Fire")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int LootHelFireIncrease;

        [Label("[i:1124] Hive Block (From Hornet and Moss Hornets after Defeating Queen Bee)")]
        [Range(0, 10000)]
        [DefaultValue(1)]
        public int LootHiveBlockFromHornetsAndMossHornetsAfterQueenBeDowned;

        [Label("[i:118] Hook")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootHookIncrease;

        [Label("[i:1306] Sickle")]
        [Range(0, 10000)]
        [DefaultValue(909)]
        public int LootIceSickleIncrease;

        [Label("[i:3022] Illuminant Hook")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootIlluminantHookIncrease;

        [Label("[i:1303] Jellyfish Necklace")]
        [Range(0, 10000)]
        [DefaultValue(25)]
        public int LootJellyfishNecklaceIncrease;

        [Label("[i:1314] KO Cannon")]
        [Range(0, 10000)]
        [DefaultValue(1000)]
        public int LootKOCannonIncrease;

        [Label("[i:671] Keybrand")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootKeybrandIncrease;

        [Label("[i:3291] Kraken")]
        [Range(0, 10000)]
        [DefaultValue(133)]
        public int LootKrakenIncrease;

        [Label("[i:3784] Lamia Clothes")]
        [Range(0, 10000)]
        [DefaultValue(100)]
        public int LootLamiaClothesIncrease;

        [Label("[i:3006] Life Drain")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootLifeDrainIncrease;

        [Label("[i:528] Light Shard")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootLightShardIncrease;

        [Label("[i:1293] Lihzahrd Power Cell")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootLihzahrdPowerCellIncrease;

        [Label("[i:2701] Living Fire Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootLivingFireBlockIncrease;

        [Label("[i:1172] Lizard Egg")]
        [Range(0, 10000)]
        [DefaultValue(111)]
        public int LootLizardEggIncrease;

        [Label("[i:517] Magic Dagger")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMagicDaggerIncrease;

        [Label("[i:1321] Magic Quiver")]
        [Range(0, 10000)]
        [DefaultValue(27)]
        public int LootMagicQuiverIncrease;

        [Label("[i:1266] Magnet Sphere")]
        [Range(0, 10000)]
        [DefaultValue(588)]
        public int LootMagnetSphereIncrease;

        [Label("[i:3772] Mandible Blade")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMandibleBladeIncrease;

        [Label("[i:682] Marrow")]
        [Range(0, 10000)]
        [DefaultValue(22)]
        public int LootMarrowIncrease;

        [Label("[i:996] Meat Grinder")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMeatGrinderIncrease;

        [Label("[i:890] Megaphone")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMegaphoneBaseIncrease;

        [Label("[i:116] Meteorite")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMeteoriteIncrease;

        [Label("[i:88] Mining Helmet")]
        [Range(0, 10000)]
        [DefaultValue(4)]
        public int LootMiningHelmetIncrease;

        [Label("[i:411] Mining Pants")]
        [Range(0, 10000)]
        [DefaultValue(3)]
        public int LootMiningPantsIncrease;

        [Label("[i:410] Mining Shirt")]
        [Range(0, 10000)]
        [DefaultValue(3)]
        public int LootMiningShirtIncrease;

        [Label("[i:3213] Money Trough")]
        [Range(0, 10000)]
        [DefaultValue(25)]
        public int LootMoneyTroughIncrease;

        [Label("[i:485] Moon Charm")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMoonCharmIncrease;

        [Label("[i:2801] Moon Mask")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMoonMaskIncrease;

        [Label("[i:900] Moon Stone")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMoonStoneIncrease;

        [Label("[i:2770] Mothron Wings")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int LootMothronWingsIncrease;

        [Label("[i:870] Mummy Costume")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMummyCostumeIncrease;

        [Label("[i:891] Nazar")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootNazarIncrease;

        [Label("[i:1244] Nimbus Rod")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootNimbusRodIncrease;

        [Label("[i:1323] Obsidian Rose")]
        [Range(0, 10000)]
        [DefaultValue(33)]
        public int LootObsidianRoseIncrease;

        [Label("[i:3350] Paintball Gun")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int LootPaintballGunIncrease;

        [Label("[i:938] Paladin�s Shield")]
        [Range(0, 10000)]
        [DefaultValue(3)]
        public int LootPaladinsShieldIncrease;

        [Label("[i:3757] Pedguin�s Suit")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootPedguinssuitIncrease;


        [Label("[i:535] Philosopher�s Stone")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootPhilosophersStoneIncrease;

        [Label("[i:1315] Pirate Map")]
        [Range(0, 10000)]
        [DefaultValue(67)]
        public int LootPirateMapIncrease;

        [Label("[i:244] Plumber�s Hat")]
        [Range(0, 10000)]
        [DefaultValue(21)]
        public int LootPlumbersHatIncrease;

        [Label("[i:3781] Pocket Mirror")]
        [Range(0, 10000)]
        [DefaultValue(10)]
        public int LootPocketMirrorIncrease;

        [Label("[i:1869] Present")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootPresentIncrease;

        [Label("[i:3106] Psycho Knife")]
        [Range(0, 10000)]
        [DefaultValue(9)]
        public int LootPsychoKnifeIncrease;

        [Label("[i:3015] Putrid Scent")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootPutridScentIncrease;

        [Label("[i:1135] Rain Armor")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootRainArmorIncrease;

        [Label("[i:662] Rainbow Brick Max Increase")]
        [Range(0, 1000)]
        [Slider]
        [DefaultValue(0)]
        public int LootRainbowBlockDropMaxIncrease;

        [Label("[i:662] Rainbow Brick Min Increase")]
        [Range(0, 1000)]
        [Slider]
        [DefaultValue(0)]
        public int LootRainbowBlockDropMinIncrease;

        [Label("[i:3285] Rally")]
        [Range(0, 10000)]
        [DefaultValue(16)]
        public int LootRallyIncrease;

        [Label("[i:1914] Reindeer Bells")]
        [Range(0, 10000)]
        [DefaultValue(11)]
        public int LootReindeerBellsIncrease;

        [Label("[i:1300] Rifle Scope")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootRifleScopeIncrease;

        [Label("[i:263] Robot Hat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootRobotHatIncrease;

        [Label("[i:759] Rocket Launcher")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootRocketLauncherIncrease;

        [Range(0, 10000)]
        [Label("[i:1326] Rod of Discord")]
        [DefaultValue(7)]
        public int LootRodofDiscordIncrease;

        [Range(0, 10000)]
        [Label("[i:1514] SWAT Helmet")]
        [DefaultValue(0)]
        public int LootSWATHelmetIncrease;

        [Label("[i:1277] Sailor Hat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSailorHatIncrease;

        [Label("[i:1280] Sailor Pants")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSailorPantsIncrease;

        [Label("[i:1279] Sailor Shirt")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSailorShirtIncrease;

        [Label("[i:216] Shackle")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootShackleIncrease;

        [Label("[i:169] Min Sand (From Dune Splicer)")]
        [Range(1, 1000)]
        [Slider]
        [DefaultValue(20)]
        public int LootMinSandFromDuneSplicer;

        [Label("[i:169] Max Sand (From Dune Splicer)")]
        [Range(1, 1000)]
        [Slider]
        [DefaultValue(50)]
        public int LootMaxSandFromDuneSplicer;

        [Label("[i:169] Min Sand (From Tomb Crawler)")]
        [Range(1, 1000)]
        [Slider]
        [DefaultValue(0)]
        public int LootMinSandFromTombCrawler;

        [Label("[i:169] Max Sand (From Tomb Crawler)")]
        [Range(1, 1000)]
        [Slider]
        [DefaultValue(0)]
        public int LootMaxSandFromTombCrawler;

        [Label("[i:1274] Skull")]
        [Range(0, 10000)]
        [DefaultValue(21)]
        public int LootSkullIncrease;

        [Label("[i:1309] Slime Staff")]
        [Range(0, 10000)]
        [DefaultValue(13)]
        public int LootSlimeStaffIncrease;

        [Label("[i:1309] Slime Staff configuration affects Surface Slimes")]
        [DefaultValue(false)]
        public bool SlimeStaffIncreaseToSurfaceSlimes;

        [Label("[i:1309] Slime Staff configuration affects Underground Slimes")]
        [DefaultValue(false)]
        public bool SlimeStaffIncreaseToUndergroundSlimes;

        [Label("[i:1309] Slime Staff configuration affects Cavern Slimes")]
        [DefaultValue(false)]
        public bool SlimeStaffIncreaseToCavernSlimess;

        [Label("[i:1309] Slime Staff configuration affects Ice Spiked Slimes")]
        [DefaultValue(true)]
        public bool SlimeStaffIncreaseToIceSpikedSlimes;
        [Label("[i:1309] Slime Staff configuration affects Spiked Jungle Slimes")]
        [DefaultValue(true)]
        public bool SlimeStaffIncreaseToSpikedJungleSlimes;

        [Label("[i:1254] Sniper Rifle")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSniperRifleIncrease;

        [Label("[i:951] Snowball Launcher")]
        [Range(0, 10000)]
        [DefaultValue(75)]
        public int LootSnowballLauncherIncrease;

        [Label("[i:520] Soul of Light")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSoulofLightIncrease;

        [Label("[i:521] Soul of Night")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSoulofNightIncrease;

        [Label("[i:532] Star Cloak")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootStarCloakIncrease;

        [Label("[i:3352] Stylish Scissors")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int LootStylishScissorsIncrease;

        [Label("[i:2802] Sun Mask")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSunMaskIncrease;

        [Label("[i:977] Tabi")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTabiIncrease;

        [Label("[i:679] Tactical Shotgun")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTacticalShotgunIncrease;

        [Label("[i:3095] Tally Counter")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTallyCounterIncrease;

        [Label("[i:1521] Tattered Bee Wing")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTatteredBeeWingIncrease;

        [Label("[i:3020] Tendon Hook")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTendonHookIncrease;

        [Label("[i:536] Titan Glove")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTitanGloveIncrease;

        [Label("[i:1312] Toy Sled")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int LootToySledIncrease;

        [Label("[i:893] Trifold Map")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTrifoldMapIncrease;

        [Label("[i:1328] Turtle Shell")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int LootTurtleShellIncrease;

        [Label("[i:1243] Umbrella Hat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootUmbrellaHatIncrease;

        [Label("[i:856] Unicorn on a Stick")]
        [Range(0, 10000)]
        [DefaultValue(25)]
        public int LootUnicornonaStickIncrease;

        [Label("[i:1265] Uzi")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootUziIncrease;

        [Label("[i:879] Viking Helmet")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootVikingHelmetIncrease;

        [Label("[i:892] Vitamins")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int LootVitaminsIncrease;

        [Label("[i:215] Whoopie Cushion")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootWhoopieCushionIncrease;

        [Label("[i:1183] Wisp in a Bottle")]
        [Range(0, 10000)]
        [DefaultValue(159)]
        public int LootWispinaBottleIncrease;

        [Label("[i:3023] Worm Hook")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootWormHookIncrease;

        [Label("[i:3286] Yelets")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootYeletsIncrease;

        [Label("[i:1304] Zombie Arm")]
        [Range(0, 10000)]
        [DefaultValue(63)]
        public int LootZombieArmIncrease;

        [Label("[i:905] Coin Gun")]
        [Tooltip("This is multiplied by 4 for Pirate Captain and 16 for Pirate Ship")]
        [Range(0, 10000)]
        [DefaultValue(370)]
        public int PirateLootCoinGunBaseIncrease;

        [Label("[i:672] Cutlass")]
        [Tooltip("This is multiplied by 4 for Pirate Captain and 16 for Pirate Ship")]
        [Range(0, 10000)]
        [DefaultValue(85)]
        public int PirateLootCutlassBaseIncrease;

        [Label("[i:854] Discount Card")]
        [Tooltip("This is multiplied by 4 for Pirate Captain and 16 for Pirate Ship")]
        [Range(0, 10000)]
        [DefaultValue(222)]
        public int PirateLootDiscountCardBaseIncrease;

        [Label("[i:3033] Gold Ring")]
        [Tooltip("This is multiplied by 4 for Pirate Captain and 16 for Pirate Ship")]
        [Range(0, 10000)]
        [DefaultValue(233)]
        public int PirateLootGoldRingBaseIncrease;

        [Label("[i:855] Lucky Coin")]
        [Tooltip("This is multiplied by 4 for Pirate Captain and 16 for Pirate Ship")]
        [Range(0, 10000)]
        [DefaultValue(257)]
        public int PirateLootLuckyCoinBaseIncrease;

        [Label("[i:2584] Pirate Staff")]
        [Tooltip("This is multiplied by 4 for Pirate Captain and 16 for Pirate Ship")]
        [Range(0, 10000)]
        [DefaultValue(222)]
        public int PirateLootPirateStaffBaseIncrease;

        [Label("[i:1825] Bloody Machete and [i:1827] Bladed Glove drop from non-weak enemies.")]
        [Tooltip("Makes it so their drop chance isn't limited to enemies with low defense, damage, and coin drop.")]
        [DefaultValue(true)]
        public bool LootBloodyMacheteAndBladedGlovesAreNotLimitedByDamageAndDefense;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Crate and Other Grab Bag Drops")]
    public class BGrabBagConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("[i:3205] Dungeon Crate")]

        [Label("[i:2192] Bone Welder")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int CrateDungeonBoneWelder;

        [Header("[i:2336] Golden Crate")]

        [Label("[i:3064] Enchanted Sundial")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int CrateEnchantedSundialGoldenIncrease;

        [Label("[i:187] Flipper")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateFlippersGolden;

        [Label("[i:863] Water Walking Boots")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateWaterWalkingBootsGolden;

        [Header("[i:2335] Iron Crate")]

        [Label("[i:3064] Enchanted Sundial")]
        [Range(0, 10000)]
        [DefaultValue(22)]
        public int CrateEnchantedSundialIronIncrease;

        [Label("[i:187] Fipper")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateFlippersIron;

        [Label("[i:863] Water Walking Boots")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateWaterWalkingBootsIron;

        [Header("[i:2334] Wooden Crate")]

        [Label("[i:3064] Enchanted Sundial")]
        [Range(0, 10000)]
        [DefaultValue(94)]
        public int CrateEnchantedSundialWoodenIncrease;

        [Label("[i:187] Flipper")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateFlippersWooden;

        [Label("[i:863] Water Walking Boots")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateWaterWalkingBootsWooden;

        [Label("[i:285] Aglet")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateWoodenAgletIncrease;

        [Label("[i:953] Climbing Claws")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateWoodenClimbingClawsIncrease;

        [Label("[i:3084] Radar")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateWoodenRadarIncrease;

        [Header("[i:3208] Jungle Crate")]

        [Label("[i:212] Anklet of the Wind")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateJungleAnkeltOfTheWindIncrease;

        [Label("[i:211] Feral Claws")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateJungleFeralClawsIncrease;

        [Label("[i:3017] Flower Boots")]
        [Range(0, 10000)]
        [DefaultValue(4)]
        public int CrateJungleFlowerBoots;

        [Label("[i:933] Leaf Wand")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateJungleLeafWand;

        [Label("[i:2196] Living Loom")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateJungleLivingLoom;

        [Label("[i:3360] Mahogany Wand")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateJungleLivingMahoganyWand;

        [Label("[i:832] Living Wood Wand")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateJungleLivingWoodWand;

        [Label("[i:3361] Rich Mahogany Leaf Wand")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateJungleRichMahoganyLeafWand;

        [Label("[i:753] Seaweed")]
        [Range(0, 10000)]
        [DefaultValue(4)]
        public int CrateJungleSeaweed;

        [Label("[i:213] Staff of Regrowth")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateJungleStaffOfRegrowth;

        [Header("[i:3206] Sky Crate")]
        [Label("[i:2197] Sky Mill")]
        [Range(0, 10000)]
        [DefaultValue(3)]
        public int CrateSkySkyMill;

        [Header("[i:1869] Present")]

        [Label("[i:586] Candy Cane Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentCandyCaneBlock;

        [Label("[i:1915] Candy Cane Hook")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentCandyCaneHook;

        [Label("[i:1917] Candy Cane Pickaxe")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentCandyCanePickaxe;

        [Label("[i:1909] Candy Cane Sword")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentCandyCaneSword;

        [Label("[i:1911] Christmas Pudding")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentChristmasPudding;

        [Label("[i:1922] Coal")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentCoal;

        [Label("[i:1927] Dog Whistle")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentDogWhistle;

        [Label("[i:1912] Eggnog")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentEggnog;

        [Label("[i:1918] Fruitcake Chakram")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentFruitcakeChakram;

        [Label("[i:1920] Ginderbread Cookie")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentGingerbreadCookie;

        [Label("[i:591] Green Candy Cane Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentGreenCandyCaneBlock;

        [Label("[i:1921] Hand Warmer")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentHandWarmer;

        [Label("[i:602] Snow Glow (Hardmode only)")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentHardmodeSnowGlobe;

        [Label("[i:1908] Holly")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentHolly;

        [Label("[i:1933] Mrs. Clause Costume")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentMrsClausCostume;

        [Label("[i:1936] Parka Outfit")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentParkaOutfit;

        [Label("[i:1872] Pine Tree Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentPineTreeBlock;

        [Label("[i:1870] Red Ryder (with Musket Balls)")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentRedRyderPlusMusketBall;

        [Label("[i:1907] Reindeer Antlers")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentReindeerAntlers;

        [Label("[i:1938] Snow Hat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentSnowHat;

        [Label("[i:1913] Star Anise")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentStarAnise;

        [Label("[i:1919] Sugar Cookie")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentSugarCookie;

        [Label("[i:1923] Toolbox")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentToolbox;

        [Label("[i:1940] Tree Costume")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentTreeCostume;

        [Label("[i:1939] Ugly Sweater")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentUglySweater;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Extra Chances for Angler Quest Rewards")]
    public class CAnglerQuestRewardsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("[i:2374] Earring")]
        [Range(0, 10000)]
        [DefaultValue(40)]
        public int QuestAnglerEarringIncrease;

        [Label("[i:2367] Angler Hat")]
        [Range(0, 10000)]
        [DefaultValue(20)]
        public int QuestAnglerHatIncrease;

        [Label("[i:2369] Angler Pants")]
        [Range(0, 10000)]
        [DefaultValue(20)]
        public int QuestAnglerPantsIncrease;

        [Label("[i:2368] Angler Vest")]
        [Range(0, 10000)]
        [DefaultValue(20)]
        public int QuestAnglerVestIncrease;

        [Label("[i:2435] Coralstone Block")]
        [Range(0, 10000)]
        [DefaultValue(25)]
        public int QuestCoralstoneBlockIncrease;

        [Label("[i:2490] Furniture")]
        [Range(0, 10000)]
        [DefaultValue(25)]
        public int QuestDecorativeFurnitureIncrease;

        [Label("[i:2498] Fish Costume")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int QuestFishCostumeIncrease;

        [Label("[i:2360] Fish Hook")]
        [Range(0, 10000)]
        [DefaultValue(30)]
        public int QuestFishHookIncrease;

        [Label("[i:3120] Fisherman's Pocket Guide")]
        [Range(0, 10000)]
        [DefaultValue(40)]
        public int QuestFishermansGuideIncrease;

        [Label("[i:3183] Golden Bug Net")]
        [Range(0, 10000)]
        [DefaultValue(83)]
        public int QuestGoldenBugNetIncrease;

        [Label("[i:2294] Golden Fishing Rod")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int QuestGoldenFishingRodIncrease;

        [Label("[i:3031] Bottomless Bucket (Hardcore only)")]
        [Range(0, 10000)]
        [DefaultValue(25)]
        public int QuestHardcoreBottomlessBucketIncrease;

        [Label("[i:2494] Fin Wings (Hardcore only)")]
        [Range(0, 10000)]
        [DefaultValue(25)]
        public int QuestHardcoreFinWingsIncrease;

        [Label("[i:2422] Hotline Fishing Hook (Hardcore only)")]
        [Range(0, 10000)]
        [DefaultValue(12)]
        public int QuestHardcoreHotlineFishingHookIncrease;

        [Label("[i:3032] Super Absorbant Sponge (Hardcore only)")]
        [Range(0, 10000)]
        [DefaultValue(12)]
        public int QuestHardcoreSuperAbsorbantSpongeIncrease;

        [Label("[i:2373] High Test Fishing Line")]
        [Range(0, 10000)]
        [DefaultValue(40)]
        public int QuestHighTestFishingLineIncrease;

        [Label("[i:2419] Mermaid Costume")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int QuestMermaidCostumeIncrease;

        [Label("[i:3096] Sextant")]
        [Range(0, 10000)]
        [DefaultValue(40)]
        public int QuestSextantIncrease;

        [Label("[i:2375] Tackle Box")]
        [Range(0, 10000)]
        [DefaultValue(40)]
        public int QuestTackleBoxIncrease;

        [Label("[i:2448] Trophy")]
        [Range(0, 10000)]
        [DefaultValue(11)]
        public int QuestTrophyIncrease;

        [Label("[i:3037] Weather Radio")]
        [Range(0, 10000)]
        [DefaultValue(40)]
        public int QuestWeatherRadioIncrease;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Extractinator Override Chances")]
    public class DExtractinatorConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("This mod will try to change the [i:997] Extractinator result with the chances below. It will go through each item below from vanilla's rarest to least    rarest drops (for ties: highest to lowest value). If it sucessfully changes, it will stop going through the chances and give the changed item. If it fails all chances, then the item wont change. Chances below are (1 / config_setting), 0 disables it.")]

        [Tooltip("If this chance fails, then this mod wont try to change the item using all of the chances below.")]
        [Label("Chance to roll for item change")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorChangesItem;

        [Label("[i:3380] Sturdy Fossil (only for Desert Fossil)")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesFossilOre;

        [Header("This chance is divided by 3 if the block used is [i:424]Silt or [i:1103]Slush.")]
        [Label("[i:1242] Amber Mosquito")]
        [Range(0, 10000)]
        [DefaultValue(103)]
        public int ExtractinatorGivesAmberMosquito;

        [Header("This chance is divided by 2 if the block used is [i:424]Silt or [i:1103]Slush.")]
        [Label("[i:999] Amber")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesAmber;

        [Header("These chances are divided by 2 if the block used is [i:3347]Desert Fossil.")]
        [Label("[i:181] Amethyst")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesAmethyst;

        [Label("[i:180] Topaz")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesTopaz;

        [Label("[i:177] Sapphire")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesSapphire;

        [Label("[i:179] Emerald")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesEmerald;

        [Label("[i:178] Ruby")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesRuby;

        [Label("[i:182] Diamond")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesDiamond;

        [Header("The block used doesn't affect these chances.")]
        [Label("[i:71] Copper Coin")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesCopperCoin;

        [Label("[i:72] Silver Coin")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesSilverCoin;

        [Label("[i:73] Gold Coin")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesGoldCoin;

        [Label("[i:74] Platinum Coin")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesPlatinumCoin;

        [Label("[i:12] Copper Ore")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesCopperOre;

        [Label("[i:699] Tin Ore")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesTinOre;

        [Label("[i:11] Iron Ore")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesIronOre;

        [Label("[i:700] Lead Ore")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesLeadOre;

        [Label("[i:14] Silver Ore")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesSilverOre;

        [Label("[i:701] Tungsten Ore")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesTungstenOre;

        [Label("[i:13] Gold Ore")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesGoldOre;

        [Label("[i:702] Platinum Ore")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int ExtractinatorGivesPlatinumOre;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Traveling and Stationary Merchant")]
    public class ETravelingAndStationaryMerchantConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        //[Tooltip("The chance of the Traveling Merchant spawning each morning is this amount when you have all permanent vanilla and Reduced Grinding NPCs.")]
        [Header("Stationary Merchant:\n\nThis NPC sells everything the Traveling Merchant has a chance to sell, but there's a catch. By default, his prices are higher, especially when the Traveling Merchant is away. Also by default, the rarer the item, the more expensive the item is. The price for each item will get modified by the configurations below.")]
        [Label("Spawns")]
        [DefaultValue(true)]
        public bool StationaryMerchant;

        [Label("Base Multiplier When Merchant Present")]
        [Increment(.01f)]
        [Range(1f, 10f)]
        [DefaultValue(4f)]
        public float S_MerchantPriceMultiplierDuringSale;

        [Label("Base Multiplier When Merchant Away")]
        [Increment(.01f)]
        [Range(1f, 10f)]
        [DefaultValue(8f)]
        public float S_MerchantPriceMultiplier;

        [Tooltip("The Traveling Merchant Shop has 6 Rarity Tiers. The price each item in the Stationary Merchant's shop will be multiplied by 1 + ((Rarity_Tier - 1) * This_Configuration)")]
        [Label("Rarity Fee Rate")]
        [Increment(.1f)]
        [Range(0f, 10f)]
        [DefaultValue(1f)]
        public float S_MerchantRarityFee;

        [Header("Traveling Merchant")]
        [Tooltip("This is an additional chance of the Traveling Merchant spawning each morning. This chance is" +
            "\ngreatly decreased by permanent vanilla and Reduced Grinding NPC's that you don't have.")]
        [Label("Base Extra Spawn Spawn Chance")]
        [Range(0, 10000)]
        [DefaultValue(1.0f)]
        public float BaseMorningTMerchantSpawnChance;

        [Header("Traveling Merchant Shop Item Chance Increases")]
        [Label("[i:3055] Acorns")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantAcornsIncrease;

        [Label("[i:2177] Ammo Box")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantAmmoBoxIncrease;

        [Label("[i:1987] Angel Halo")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantAngelHaloIncrease;

        [Label("[i:2271] Arcane Rune Wall")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantArcaneRuneWallIncrease;

        [Label("[i:3309] Black Counter Weight")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantBlackCounterweightIncrease;

        [Label("[i:2262] Blue Dynasty Shingles")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantBlueDynastyShinglesIncrease;

        [Label("[i:3634] Blue Team Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantBlueTeamBlockIncrease;

        [Label("[i:3639] Blue Team Platform")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantBlueTeamPlatformIncrease;

        [Label("[i:2214] Brick Layer")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantBrickLayerIncrease;

        [Label("[i:2865] Castle Marsberg")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantCastleMarsbergIncrease;

        [Label("[i:2219] Celestial Magnet")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantCelestialMagnetIncrease;

        [Label("[i:2258] Chalice")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantChaliceIncrease;

        [Label("[i:3262] Code 1")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantCode1Increase;

        [Label("[i:3284] Code 2")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantCode2Increase;

        [Label("[i:3056] Cold Snap")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantColdSnapIncrease;

        [Label("[i:3628] Companion Cube")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantCompanionCubeIncrease;

        [Label("[i:2284] Crimson Cloak")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantCrimsonCapeIncrease;

        [Label("[i:3057] Cursed Saint")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantCursedSaintIncrease;

        [Label("[i:3119] DPS Meter")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantDPSMeterIncrease;

        [Label("[i:2276] Diamond Ring")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantDiamondRingIncrease;

        [Label("[i:2260] Dynasty Wood")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantDynastyWoodIncrease;

        [Label("[i:2215] Extendo Grip")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantExtendoGripIncrease;

        [Label("[i:2242] Fancy Dishes")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantFancyDishesIncrease;

        [Label("[i:1988] Fez")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantFezIncrease;

        [Label("[i:2270] Gatligator")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantGatligatorIncrease;

        [Label("[i:2277] Gi")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantGiIncrease;

        [Label("[i:3633] Green Team Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantGreenTeamBlockIncrease;

        [Label("[i:3638] Green Team Platform")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantGreenTeamPlatformIncrease;

        [Label("[i:2279] Gypsy Robe")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantGypsyRobeIncrease;

        [Label("[i:2273] Katana")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantKatanaIncrease;

        [Label("[i:2278] Kimono")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantKimonoIncrease;

        [Label("[i:2282] Leopard Skin")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantLeopardSkinIncrease;

        [Label("[i:3118] Lifeform Analyzer")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantLifeformAnalyzerIncrease;

        [Label("[i:2275] Magic Hat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantMagicHatIncrease;

        [Label("[i:2866] Martia Lisa")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantMartiaLisaIncrease;

        [Tooltip("Normaly, not sold by the Traveling Merchant")]
        [Label("[i:3102] Metal Detector")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantMetalDetector;

        [Label("[i:2285] Mysterious Cape")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantMysteriousCapeIncrease;

        [Label("[i:3596] Not a Kid Nor a Squid")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantNotAKidNorASquidIncrease;

        [Label("[i:2267] Pad Thai")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPadThaiIncrease;

        [Label("[i:2216] Paint Sprayer")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPaintSprayerIncrease;

        [Label("[i:2268] Pho")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPhoIncrease;

        [Label("[i:3636] Pink Team Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPinkTeamBlockIncrease;

        [Label("[i:3641] Pink Team Platform")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPinkTeamPlatformIncrease;

        [Label("[i:2217] Portable Cement Mixer")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPortableCementMixerIncrease;

        [Label("[i:3624] Presserator")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPresseratorIncrease;

        [Label("[i:2223] Pulse Bow")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPulseBowIncrease;

        [Label("[i:2286] Red Cape")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantRedCapeIncrease;

        [Label("[i:2261] Red Dynasty Shingles")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantRedDynastyShinglesIncrease;

        [Label("[i:3621] Red Team Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantRedTeamBlockIncrease;

        [Label("[i:3622] Red Team Platform")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantRedTeamPlatformIncrease;

        [Label("[i:2269] Revelover")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantRevolverIncrease;

        [Label("[i:2266] Sake")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantSakeIncrease;

        [Label("[i:2296] Sitting Duck�s Fishing Pole")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantSittingDucksFishingPoleIncrease;

        [Label("[i:3058] Snowfellas")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantSnowfellasIncrease;

        [Label("[i:3099] Stopwatch")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantStopwatchIncrease;

        [Label("[i:3059] The Season")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantTheSeasonIncrease;

        [Label("[i:2867] The Truth is Up There")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantTheTruthIsUpThereIncrease;

        [Label("[i:2281] Tiger Skin")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantTigerSkinIncrease;

        [Label("[i:2274] Ultrabright Torch")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantUltraBrightTorchIncrease;

        [Label("[i:2272] Water Gun")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantWaterGunIncrease;

        [Label("[i:3637] White Team Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantWhiteTeamBlockIncrease;

        [Label("[i:3642] White Team Platform")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantWhiteTeamPlatformIncrease;

        [Label("[i:2287] Winter Cape")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantWinterCapeIncrease;

        [Label("[i:3314] Yellow Counterweight")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantYellowCounterweightIncrease;

        [Label("[i:3635] Yellow Team Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantYellowTeamBlockIncrease;

        [Label("[i:3640] Yellow Team Platform")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantYellowTeamPlatformIncrease;

        [Label("[i:2283] Zebra Skin")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantZebraSkinIncrease;

        [Label("Increased Christmas Item chances requires Christmas")]
        [DefaultValue(true)]
        public bool TravelingMerchantAlwaysXMasForConfigurations;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Vanilla NPCs")]
    public class FOtherVanillaNPCConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("All NPCs Sell Their Death Loot")]
        [DefaultValue(false)]
        public bool AllNPCsSellTheirDeathLoot;

        [Header("Mechanic Sells")]
        [Label("[i:539] Dart Trap and [i:147]Spikes After Skeleton Defeated")]
        [DefaultValue(true)]
        public bool MechanicSellsDartTrapAndSpikesAfterSkeletronDefeated;

        [Label("[i:3722] Geyzer After Wall of Flesh Defeated")]
        [DefaultValue(true)]
        public bool MechanicSellsGeyserAfterWallofFleshDefeated;

        [Header("Witch Doctor Sells")]
        [Label("[i:1146] Lihzahrd Traps After Golem Defeated")]
        [DefaultValue(true)]
        public bool WitchDoctorSellsLihzahrdTrapsAfterGolemDefeated;

        [Label("[i:1150] Wooden Spikes After Golem Defeated")]
        [DefaultValue(true)]
        public bool WitchDoctorSellsWoodenSpikesAfterGolemDefeated;

        [Label("[i:3017] Flower Boots")]
        [DefaultValue(false)]
        public bool WitchDoctorSellsFlowerBoots;

        [Label("[i:2204] Honey Dispenser")]
        [DefaultValue(false)]
        public bool WitchDoctorSellsHoneyDispenser;

        [Label("[i:2338] Seaweed")]
        [DefaultValue(false)]
        public bool WitchDoctorSellsSeaweed;

        [Label("[i:213] Staff of Regrowth")]
        [DefaultValue(false)]
        public bool WitchDoctorSellsStaffofRegrowth;

        [Header("Merchant Sells")]
        [Label("[i:410] All Mining Gear;")]
        [DefaultValue(true)]
        public bool MerchantSellsAllMiningGear;

        [Label("[i:987] Blizzard In A Bottle When In Snow")]
        [DefaultValue(false)]
        public bool MerchantSellsBlizzardInABottleWhenInSnow;

        [Label("[i:53] Cloud In A Bottle When In Sky")]
        [DefaultValue(false)]
        public bool MerchantSellsCloudInABottleWhenInSky;

        [Label("[i:669] Fish Item")]
        [DefaultValue(false)]
        public bool MerchantSellsFishItem;

        [Label("[i:934] Pyramid Items")]
        [DefaultValue(false)]
        public bool MerchantSellsPyramidItems;

        [Label("[i:857] Sandstorm In A Bottle When In Desert")]
        [DefaultValue(false)]
        public bool MerchantSellsSandstormInABottleWhenInDesert;

        [Label("[i:290] Swiftness Potion")]
        [DefaultValue(true)]
        public bool MerchantSellsSwiftnessPotion;

        [Header("Tax Collector")]
        [Label("[i:73] Tax Requirement for Tax Alert")]
        [Tooltip("Once the Tax Collector has this much money collected, he will let the player know each morning. Set to 0 to disable.")]
        [Range(0, 100000)]
        [Slider]
        [DefaultValue(50000)]
        public int TaxCollectorTaxRequiredToChatTaxatMorningAndNight;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Lock Boxes")]
    public class GLockbBoxConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        [Header("These are custom lockboxes that have a chance to drop from all enemies. The type of lockbox depends on either the enemy killed or the biome you're in. The lockbox gives loot that you would normally get from a chest of the matching biome and possibly furniture from the structures that the chest would be found in.")]
        [Label("Lockboxes Give Furniture")]
        [DefaultValue(true)]
        public bool LockBoxesGiveFurniture;

        [Label("Lock Boxes Give Non-Furniture")]
        [DefaultValue(true)]
        public bool LockBoxesGiveNonFurniture;

        [Label("$Mods.ReducedGrinding.Common.CavernLockboxLable")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int CavernModdedCavernLockBoxLoot;

        [Label("$Mods.ReducedGrinding.Common.DungeonBiomeLockboxLabel")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int DungeonModdedBiomeLockBoxLoot;


        [Tooltip("Required stack size of a single biome key type needed to open Biome Lockboxes. The type is randomly choosen from\n" +
            "available keys in inventory that meet this required size. The rare item obtained will match the key used to open it.")]
        [Label("Required [i:1533]Biome Key stack size to open Biome Lockboxes")]
        [Range(1, 99)]
        [DefaultValue(3)]
        public int BiomeLockboxKeysRequired;


        [Tooltip("Comes in 3 forms (no matter what dungeon your world has): Blue Dungeon, Green Dungeon, and Pink Dungeon.")]
        [Label("$Mods.ReducedGrinding.Common.DungeonFurnitureLockboxLabel")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int DungeonFurnitureLockBoxLoot;

        [Label("$Mods.ReducedGrinding.Common.ShadowLockboxLable")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int HellBiomeModdedShadowLockBoxLoot;

        [Label("$Mods.ReducedGrinding.Common.LihzahrdLockboxLable")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int JungleTempleLihzahrd_Lock_Box;

        [Tooltip("Drops in Underground Desert and Sandstorms")]
        [Label("$Mods.ReducedGrinding.Common.PyramidLockBoxLable")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int SandstormAndUndergroundDesertPyramidLockBoxLoot;

        [Label("$Mods.ReducedGrinding.Common.SkywareLockBoxLable")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int SkyModdedSkywareLockBoxLoot;

        [Label("$Mods.ReducedGrinding.Common.WebCoveredLockboxLable")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int SpiderNestWebCoveredLockBoxLoot;

        [Label("$Mods.ReducedGrinding.Common.LivingWoodLockBoxLable")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int SurfaceModdedLivingWoodLockBoxLoot;

        [Label("$Mods.ReducedGrinding.Common.IvyLockBoxLable")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int UndergroundJungleBiomeModdedIvyLockBoxLoot;

        [Label("$Mods.ReducedGrinding.Common.IceLockBoxLable")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int UndergroundSnowBiomeModdedIceLockBoxLoot;

        [Tooltip("Drops from water enemies.")]
        [Label("$Mods.ReducedGrinding.Common.WaterLockBoxLable")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int WaterEnemyModdedWaterLockBoxLoot;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Other Modded Items")]
    public class HOtherModdedItemsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Tooltip("Summons Plantera")]
        [Label("$Mods.ReducedGrinding.Common.PlanteraBulbLable")]
        [DefaultValue(true)]
        public bool DryadSellsPlanteraBulbAfterPlanteraDefeated;

        [Tooltip("Ends the Goblin Invasion")]
        [Label("$Mods.ReducedGrinding.Common.GoblinRetreatOrderLable")]
        [DefaultValue(true)]
        public bool GoblinTinkererSellsGoblinRetreatOrder;

        [Tooltip("Allows crafting golden critters")]
        [Label("$Mods.ReducedGrinding.Common.GoldReflectionMirror")]
        [DefaultValue(false)]
        public bool MerchantSellsGoldReflectionMirrorForCraftingGoldCrittersItem;

        [Tooltip("Ends the Pirate Invasion")]
        [Label("$Mods.ReducedGrinding.Common.PirateRetreatOrder")]
        [DefaultValue(true)]
        public bool PirateSellsPirateRetreatOrder;

        [Tooltip("Advances the Moon Phase")]
        [Label("$Mods.ReducedGrinding.Common.MoonBall")]
        [DefaultValue(true)]
        public bool WizardSellsMoonBall;

        [Tooltip("Starts a Martian Invasion")]
        [Label("$Mods.ReducedGrinding.Common.MartianCall")]
        [Range(0, 10000)]
        [DefaultValue(1)]
        public int MartianSaucerMartianCallDrop;

        [Header("[i:300] Battle Potion")]
        [Tooltip("The vanilla multiplier will be multiplied further by this amount")]
        [Label("Max Spawns Extra Multiplier")]
        [Increment(0.0001f)]
        [Range(1f, 100f)]
        [DefaultValue(1f)]
        public float BattlePotionMaxSpawnsMultiplier;

        [Tooltip("The vanilla multiplier will be multiplied further by this amount")]
        [Label("Spawn Rate Extra Multiplier")]
        [Increment(.0001f)]
        [Range(1f, 100f)]
        [DefaultValue(1f)]
        public float BattlePotionSpawnrateMultiplier;

        [Header("$Mods.ReducedGrinding.Common.WarPotion")]
        [Label("War Buff Max Spawns Multiplier")]
        [Increment(.0001f)]
        [Range(1f, 100f)]
        [DefaultValue(10f)]
        public float WarPotionMaxSpawnsMultiplier;

        [Label("War Buff Spawn Rate Multiplier")]
        [Increment(.0001f)]
        [Range(1f, 100f)]
        [DefaultValue(10f)]
        public float WarPotionSpawnrateMultiplier;

        [Header("$Mods.ReducedGrinding.Common.ChaosPotion")]
        [Label("Chaos Buff Max Spawns Multiplier")]
        [Increment(.0001f)]
        [Range(1f, 100f)]
        [DefaultValue(20f)]
        public float ChaosPotionMaxSpawnsMultiplier;

        [Label("Chaos Buff Spawn Rate Multiplier")]
        [Increment(.0001f)]
        [Range(1f, 100f)]
        [DefaultValue(20f)]
        public float ChaosPotionSpawnrateMultiplier;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Other Custom NPCs")]
    public class IOtherCustomNPCsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Tooltip("Permanent version of the Skeleton Merchant")]
        [Label("Bone Merchant")]
        [DefaultValue(false)]
        public bool BoneMerchant;

        [Label("Bone Merchant Disabled When Luiafk Is Installed")]
        [DefaultValue(false)]
        public bool BoneMerchantDisabledWhenLuiafkIsInstalled;

        [Tooltip("Permanent version of Santa Claus")]
        [Label("Christmas Elf")]
        [DefaultValue(true)]
        public bool ChristmasElf;

        [Tooltip("Sells what's needed to fight the next Vanilla boss (you can still aquire these items normally)")]
        [Label("Loot Merchant")]
        [DefaultValue(false)]
        public bool LootMerchant;

        [Tooltip("Sells vanilla chests that are normally limited. Note: This mod allows you to aquire these chests through monster drops.")]
        [Label("Chest Salesman")]
        [DefaultValue(false)]
        public bool ChestSalesman;

        [Label("Chest Salesman Pre-Hardmode Chests Require Hardmode Activated")]
        [DefaultValue(false)]
        public bool ChestSalesmanPreHardmodeChestsRequireHardmodeActivated;

        [Header("Chest Salesman Sells")]
        [Label("[i:1529] Biome Chests")]
        [DefaultValue(true)]
        public bool ChestSalesmanSellsBiomeChests;

        [Label("[i:306] Gold Chest")]
        [DefaultValue(true)]
        public bool ChestSalesmanSellsGoldChest;

        [Label("[i:681] Ice Chest")]
        [DefaultValue(true)]
        public bool ChestSalesmanSellsIceChest;

        [Label("[i:680] Ivy Chest")]
        [DefaultValue(true)]
        public bool ChestSalesmanSellsIvyChest;

        [Label("[i:680] Lihzahrd Chest")]
        [DefaultValue(true)]
        public bool ChestSalesmanSellsLihzahrdChest;

        [Label("[i:831] Living Wood Chest")]
        [DefaultValue(false)]
        public bool ChestSalesmanSellsLivingWoodChest;

        [Label("[i:1298] Water Chest")]
        [DefaultValue(true)]
        public bool ChestSalesmanSellsOceanChest;

        [Label("[i:328] Shadow Chest")]
        [DefaultValue(true)]
        public bool ChestSalesmanSellsShadowChest;

        [Label("[i:838] SkywareChest")]
        [DefaultValue(true)]
        public bool ChestSalesmanSellsSkywareChest;

        [Label("[i:952] Web Covered Chest")]
        [DefaultValue(true)]
        public bool ChestSalesmanSellsWebCoveredChest;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }
}
