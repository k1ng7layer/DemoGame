using UnityEngine;

namespace Assets.Scripts.Runtime.Views
{
    public class NpcSpawnSpot:MonoBehaviour
    {
        [SerializeField] public bool _spawned;
        [SerializeField] private NpcView _spawnPrefab;
        public bool Spawned => _spawned;
        public NpcView Prefab => _spawnPrefab;
    }
}
