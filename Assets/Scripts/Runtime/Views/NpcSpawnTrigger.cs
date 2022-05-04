using Assets.Scripts.Runtime.GameActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views
{
    public class NpcSpawnTrigger:MonoBehaviour
    {
        [SerializeField] private List<NpcSpawnSpot> _npcSpawnSpots;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<PlayerView>(out PlayerView view))
            {
                if (view.IsPlayer)
                {
                    //Debug.Log("21222");
                    EnemySpawnEventArgs eventArgs = new EnemySpawnEventArgs(_npcSpawnSpots);
                    ActionContainer.ResolveAction<EnemySpawnAction>().Dispatch(eventArgs);
                }
            }
                    
        }
           
          
    }
}



