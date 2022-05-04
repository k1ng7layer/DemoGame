using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Runtime.Extensions;

namespace Assets.Scripts.Runtime.Controllers.Animation
{
    public class ChestAnimationEventManager:MonoBehaviour
    {
        [SerializeField] private AnimationClip _chestOpenClip;
        [SerializeField] private float _chestOpenEventTiming;
        private Animator _animator;
        public event Action OnChestOpenedAction;

        private void Awake()
        {
            _animator = this.GetOrCreateComponent<Animator>();
            AnimationEvent openEvent = new AnimationEvent();
            openEvent.time = _chestOpenEventTiming;
            openEvent.intParameter = _animator.GetInstanceID();
            openEvent.functionName = "OnChestOpened";
            _chestOpenClip.AddEvent(openEvent);
        }
        private void OnChestOpened(int animatorHashCode)
        {
            if (this._animator.GetInstanceID() == animatorHashCode)
            {
                Debug.Log($"CHEST IS OPENED, ANIMATOR ID = {animatorHashCode} ");
                OnChestOpenedAction?.Invoke();
            }
                
        }
           
    }
}
