using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AIBehaviour
{
    public abstract class BehaviourTreeConfig:ScriptableObject
    {
        protected Node _rootNode;
        protected Tree _tree;
        protected Transform treeOwner;
        public Tree CreateBehaviourTree(Transform treeOwner)
        {
            Node rootNode = SetupTree(treeOwner);
            Tree tree = new Tree(treeOwner,rootNode);
            return tree;
        }
        protected abstract Node SetupTree(Transform owner);
    }
}



