using Assets.Scripts.Runtime.SpawnSystem;
using Assets.Scripts.Runtime.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.GameActions
{
    public class EnemySpawnEventArgs
    {
        public List<NpcSpawnSpot> SpawnSpots { get; private set; }
        
        public EnemySpawnEventArgs(List<NpcSpawnSpot> spawnSpots)
        {
            SpawnSpots = spawnSpots;
        }
    }
}
            
