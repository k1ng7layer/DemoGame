using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers.Animation
{
    public abstract class AnimationEventManager:MonoBehaviour
    {
        protected Animator _animator;
        public abstract event Action OnWeaponDraw;
        public abstract event Action OnWeaponHide;


    }
}
