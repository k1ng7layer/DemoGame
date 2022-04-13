using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.GameActions
{
    public class ItemDescriptionRequestEventArgs
    {
        public int Item_id { get; private set; }
        public ItemDescriptionRequestEventArgs(int id)
        {
            Item_id = id;
        }
    }
}
