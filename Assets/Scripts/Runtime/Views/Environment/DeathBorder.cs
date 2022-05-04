using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views.Environment
{
    public class DeathBorder:MonoBehaviour
    {
        [SerializeField] private Transform _spawPoint;
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<MainPlayerView>(out MainPlayerView mainPlayer))
            {
                mainPlayer.transform.position = _spawPoint.position;
            }
        }
    }
}
