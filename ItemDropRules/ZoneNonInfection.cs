using Terraria.GameContent.ItemDropRules;

namespace ReducedGrinding.Common.ItemDropRules.Conditions
{
    public class ZoneNonInfection : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            if (info.IsInSimulation)
            {
                return false;
            }

            if (info.player.ZoneCrimson)
            {
                return false;
            }

            if (info.player.ZoneHallow)
            {
                return false;
            }

            if (info.player.ZoneCorrupt)
            {
                return false;
            }

            return true;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return "Not in the Corruption, Crimson, or Hallow";
        }
    }
}
