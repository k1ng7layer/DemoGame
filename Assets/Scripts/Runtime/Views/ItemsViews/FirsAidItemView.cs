using Assets.Scripts.Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views.ItemsViews
{
    public class FirsAidItemView:FloatingItemView, IUsable
    {
        [SerializeField] private float _healthGain;
        [SerializeField] private float _restoreTime;
       

        public void Use()
        {
            Destroy(this.gameObject);
        }

        public void Use(IStatRestorable user)
        {
            user.InvokeRestoreHealth(_healthGain, _restoreTime);
            Destroy(this.gameObject);
        }

        public void Use(Transform user)
        {
            
        }
    }
}
