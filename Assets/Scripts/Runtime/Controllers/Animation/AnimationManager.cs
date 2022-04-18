using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers.Animation
{
    public abstract class AnimationManager
    {
        protected Animator _animator;
        public AnimationManager(Animator animator)
        {
            _animator = animator;
        }
    }
}
