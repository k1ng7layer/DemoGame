using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.GameActions
{
    public class ItemEquipEventArgs
    {
        public int ItemId { get; private set; }
        public SlotType Slot { get; private set; }
        public ItemEquipEventArgs(int itemId, SlotType slotType)
        {
            ItemId = itemId;
            Slot = slotType;
        }
    }
}
