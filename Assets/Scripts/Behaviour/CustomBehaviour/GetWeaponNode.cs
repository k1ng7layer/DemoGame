using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBehaviour
{
    public class GetWeaponNode:Node
    {
        public override NodeState Evaluate()
        {
            return NodeState.RUNNING;
        }
    }
}
