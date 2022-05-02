using Assets.Scripts.Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views
{
    public class MainPlayerView:PlayerView, IStatRestorable
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IUsable>(out IUsable usable))
            {
                usable.Use(this);
            }
        }
        public void InvokeRestoreHealth(float value, float time)
        {
            InvokeHealthRestore(value, time);
        }

        public void InvokeRstoreMana(float value, float time)
        {

        }

        public void InvokeRestoreArmor(float value, float time)
        {

        }
    }
}
