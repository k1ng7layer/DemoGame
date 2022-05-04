using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views.Environment
{
    public class StaticPlatformView:MonoBehaviour
    {
        [SerializeField] private List<Transform> _attachedPlayers = new List<Transform>();
        [SerializeField] private GameObject _holder;
        private Vector3 _tempScale;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerView>(out PlayerView player))
            {
                var trueScale = new Vector3(
                     player.transform.localScale.x / _holder.transform.lossyScale.x,
                     player.transform.localScale.y / _holder.transform.lossyScale.y,
                     player.transform.localScale.z / _holder.transform.lossyScale.z);
                //player.transform.parent = this.transform;
               
                //player.transform.sc = _tempScale;
                player.transform.SetParent(_holder.transform);
                player.transform.localScale = trueScale;








                _attachedPlayers.Add(player.transform);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            foreach (var player in _attachedPlayers)
            {
                player.SetParent(null);
            }
        }
    }
}
