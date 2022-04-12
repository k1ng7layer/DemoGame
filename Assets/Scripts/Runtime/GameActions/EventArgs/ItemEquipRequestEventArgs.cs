using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.GameActions
{
    public class ItemEquipRequestEventArgs
    {
        public int ItemId { get; private set; }
        public SlotType TargetSlot { get; private set; }
        public ItemEquipRequestEventArgs(int item_id, SlotType targetSlotType)
        {
            ItemId = item_id;
            TargetSlot = targetSlotType;
        }
    }
}
