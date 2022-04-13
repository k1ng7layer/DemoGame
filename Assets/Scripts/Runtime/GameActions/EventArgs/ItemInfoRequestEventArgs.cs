using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.GameActions
{
    public class ItemInfoRequestEventArgs
    {
        public int ItemId { get; private set; }
        public ItemInfoRequestEventArgs(int id)
        {
            ItemId = id;
        }
    }
}
