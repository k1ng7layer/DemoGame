using Assets.Scripts.Runtime.Controllers.Combat;
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
      
        public abstract event Action OnWeaponDraw;
        public abstract event Action OnWeaponHide;
        public abstract event Action<AttackType> OnStartDealingDamage;
        public abstract event Action OnEndDealingDamage;
       


    }
}
