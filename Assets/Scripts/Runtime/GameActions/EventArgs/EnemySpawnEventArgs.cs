using Assets.Scripts.Runtime.SpawnSystem;
using Assets.Scripts.Runtime.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.GameActions.EventArgs
{
    public class EnemySpawnEventArgs
    {
        public List<EnemySpawnSpot> SpawnSpots { get; }
        public PlayerView caller;
        public EnemySpawnEventArgs(List<EnemySpawnSpot> spawnSpots, PlayerView view)
        {
            SpawnSpots = spawnSpots;
            caller = view;
        }
    }
}
