using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views.Environment
{
    public class FloatingPlatformView:FloatingItemView
    {
        [SerializeField] private List<Transform> _attachedPlayers = new List<Transform>();
        [SerializeField] private GameObject _holder;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerView>(out PlayerView player))
            {
                var trueScale = new Vector3(
                     player.transform.localScale.x / _holder.transform.lossyScale.x,
                     player.transform.localScale.y / _holder.transform.lossyScale.y,
                     player.transform.localScale.z / _holder.transform.lossyScale.z);
                player.transform.SetParent(_holder.transform);
                player.transform.localScale = trueScale;
                _attachedPlayers.Add(player.transform);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            
            if (other.TryGetComponent<PlayerView>(out PlayerView player))
            {
                player.transform.SetParent(null);
                _attachedPlayers.Remove(player.transform);
            }
        }
    }
}
                







