using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.GameActions
{
    public class DisplayItemDescriptionEventArgs
    {
        public int Item_id { get; private set; }
        public string Description { get; private set; }
        public string ItemName { get; private set; }
        public DisplayItemDescriptionEventArgs(int item_id,string itemName, string description)
        {
            Description = description;
            Item_id = item_id;
            ItemName = itemName;
        }
    }
}
