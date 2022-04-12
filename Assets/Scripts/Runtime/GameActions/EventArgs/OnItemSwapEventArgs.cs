using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.GameActions
{
    public class OnItemSwapEventArgs
    {
        public int ItemA_Index { get; private set; }
        public int ItemB_Index { get; private set; }
        public OnItemSwapEventArgs(int itemA_Index, int itemB_Index)
        {
            ItemA_Index = itemA_Index;
            ItemB_Index = itemB_Index;
        }
    }
}
