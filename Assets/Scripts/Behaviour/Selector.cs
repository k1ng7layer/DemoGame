using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AIBehaviour
{
    public class Selector : Node
    {
        public Selector() : base() { }
        public Selector(List<Node> children) : base(children)
        {
            this._children = children;
            Debug.Log("selector created");
        }

        public override NodeState Evaluate()
        {
            foreach (Node node in _children)
            {
                //Debug.Log($"selector = {this}, selectorState = {this.state}, childName = {node.name}, state =  {node.state}");
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        continue;
                }
            }

            state = NodeState.FAILURE;
            return state;
        }

    }
}
