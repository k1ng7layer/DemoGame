using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AIBehaviour
{
    public class Sequence:Node
    {
       
        public Sequence(List<Node> children):base(children)
        {
            this._children = children;
            Debug.Log("seqeunce created");
        }
        public override NodeState Evaluate()
        { 
            bool childIsRunnig = false;
            foreach (var child in _children)
            {
                Debug.Log($"sequense = {this}, sequenceState = {this.state}, child = {child.name}, state =  {child.state}");
                switch (child.Evaluate())
                {
                    case NodeState.RUNNING:
                        childIsRunnig = true;
                        continue;
                       
                    case NodeState.SUCCESS:
                        continue;
                       
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
               
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }
            if (childIsRunnig)
            {
                state = NodeState.RUNNING;
                return state;
            }
            else
            {
                state = NodeState.SUCCESS;
                return state;
            }
            return childIsRunnig ? NodeState.RUNNING : NodeState.SUCCESS;
        }
    }
}
