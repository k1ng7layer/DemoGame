using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime
{
    public abstract class InputTypeBase : ScriptableObject
    {
        public abstract event Action<Vector3> OnMovement;
        public abstract event Action OnJump;
        public abstract event Action OnInventoryOpen;
        public abstract event Action OnAttack;
        public abstract event Action OnDrawWeapon;
        public abstract event Action OnUseButtonPressed;
        public float vertical { get; protected set; }
        public float horizontal { get; protected set; }
        public bool jump;
        public bool attack;
        public bool withdrawWeapon;
        public bool changeWeapon;
        public bool lockTarget;
        public bool use;
        public abstract void OnUpdate();
    }
}
