using System;
using UnityEngine;


namespace AIBehaviour
{
    public enum AIState
    {
        FALLING,
        MOVING_TO_TARGET,
        IDLE,
        PATROLING,
        ATTACKING,
        DIED,
    }
    public class Tree
    {
        private Node _root = null;
        protected Transform treeOwner;
        public AIState TreeState { get; protected set; }
        public event Action OnAttackTarget;
        internal event Action<bool> OnTakingDamage;
        public event Action<Transform, bool> OnMovingToTarget;
        public event Action OnWithdrawWeapon;

     
       
        public Tree(Transform treeOwner, Node rootNode)
        {
            _root = rootNode;
            _root.SetHandlerTree(this);
            this.treeOwner = treeOwner;
        }

        public Node RootNode
        {
            get
            {
                return _root;
            }
        }
        
        protected void Start()
        {
            _root.InitializeNode();
        }
            
        public void Initialize()
        {
            Start();
        }
        public void SetOwner(Transform owner)
        {
            this.treeOwner = owner.transform;
        }
        public void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }
        internal void InvokeAttackAction()
        {
            OnAttackTarget?.Invoke();
        }
        internal void InvokeTargetChasing(Transform target, bool enabled)
        {
            OnMovingToTarget?.Invoke(target, enabled);
        } 
        public void HandleTakingDamage(bool val)
        {
            OnTakingDamage?.Invoke(val);
        }
        internal void HandleWithdrawWeapon()
        {
            OnWithdrawWeapon?.Invoke();
        }

        public void OnDestroy()
        {
            _root.OnDestroy();
        }
        /// <summary>
        /// Метод, в котором описывается дерево поведения
        /// </summary>
        /// <returns></returns>
        
    }
}
