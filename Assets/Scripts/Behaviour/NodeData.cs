using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AIBehaviour
{
    public class NodeData
    {
        public Transform Target { get; private set; }
        public NodeData(Transform target)
        {
            Target = target;
        }
    }
}
