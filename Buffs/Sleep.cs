using Terraria;
using Terraria.ModLoader;

namespace ReducedGrinding.Buffs
{
    public class Sleep : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Sleep");
            Description.SetDefault("Increases time rate while sleeping.");
        }
    }
}