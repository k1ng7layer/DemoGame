using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AIBehaviour
{
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }
    public class Node
    {
        protected Tree Handler { get; private set; }
        public string name;
        public NodeState state;
        internal Node parent;
        protected List<Node> _children = new List<Node>();
        private Dictionary<string, NodeData> _nodeData = new Dictionary<string, NodeData>(); 
        
        public Node()
        {
            parent = null;
        }
        public Node(List<Node> children, Tree handler)
        {
            _children = new List<Node>();
            _nodeData = new Dictionary<string, NodeData>();
            Handler = handler;
            Debug.Log($"Attaching = {children[0]}");
            foreach (var child in children)
            {
                Attach(child);
            }
        }
        public Node(List<Node> children)
        {
            _children = new List<Node>();
            _nodeData = new Dictionary<string, NodeData>();
            
            Debug.Log($"Attaching = {children[0]}");
            foreach (var child in children)
            {
                Attach(child);
            }
        }
        internal virtual void InitializeNode()
        {
            foreach (var child in _children)
            {
                child.InitializeNode();
            }
        }
        private void Attach(Node node)
        {
            node.parent = this;
            node.SetHandlerTree(Handler);
            _children.Add(node);
        }
        public virtual NodeState Evaluate()
        {
            return NodeState.FAILURE;
        }
        public virtual NodeState EvaluatePhysics()
        {
            return NodeState.FAILURE;
        }
        internal void SetHandlerTree(Tree handler)
        {
            Handler = handler;
            foreach (var child in _children)
            {
                child.SetHandlerTree(handler);
            }
        }
        public void SetData(string key, NodeData data)
        {
            _nodeData.Add(key, data); 
        }

        public NodeData GetData(string key)
        {
            if(_nodeData.TryGetValue(key, out NodeData nodeData))
            {
                return nodeData;
            }
            Node node = parent;
            while (node!=null)
            {
                nodeData = node.GetData(key);
                if (nodeData != null)
                    return nodeData;
                node = node.parent;
            }
            return null;
        }

        public bool ClearData(string key)
        {
            if (_nodeData.ContainsKey(key))
                _nodeData.Remove(key);
            Node node = parent;
            while (node!=null)
            {
                bool cleared = node.ClearData(key);
                if (cleared)
                    return true;
                node = node.parent;
            }
            return false;
        }

        internal virtual void OnDestroy()
        {
            foreach (var node in _children)
            {
                node.OnDestroy();
            }
        }
    }

      
}
