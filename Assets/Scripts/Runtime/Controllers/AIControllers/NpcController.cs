using Assets.Scripts.Runtime.GameActions;
using Assets.Scripts.Runtime.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers.AIControllers 
{
    public class NpcController:IController
    {
        private List<NpcPresenter> _currentNpcs;
        public NpcController()
        {
            _currentNpcs = new List<NpcPresenter>();
        }

        public void InitializeController()
        {
            ActionContainer.ResolveAction<EnemySpawnAction>().AddListener(HandleSpawnRequest);
            ClearAllNpc();
            //Находим всех НПС, расставленных на сцене вручную
            var scenePlayers = GameObject.FindObjectsOfType<NpcView>().ToList();
            foreach (var player in scenePlayers)
            {
                NpcPresenter npc = new NpcPresenter(player);
                npc.OnDeath += UnRegisterNpcPresenter;
                RegisterNpcPresenter(npc);
            }
            foreach (var npc in _currentNpcs)
            {
                npc.InitializeController();
            }
        }
        
        private void RegisterNpcPresenter(NpcPresenter npc)
        {
            _currentNpcs.Add(npc);
        }
        private void UnRegisterNpcPresenter(NpcPresenter npc)
        {
           
            if (_currentNpcs.Contains(npc))
                _currentNpcs.Remove(npc);
            npc.OnDestroyController();
        }
      
        private void HandleSpawnRequest(EnemySpawnEventArgs eventArgs)
        {
            foreach (var npc in eventArgs.SpawnSpots)
            {
                if (npc._spawned == false)
                {
                    var npcView = SpawnNpcGameObject(npc.transform, npc.Prefab);
                    NpcPresenter npcPresenter = new NpcPresenter(npcView);
                    RegisterNpcPresenter(npcPresenter);
                    npcPresenter.InitializeController();
                    npc._spawned = true;
                }
               
            }
        }
        private NpcView SpawnNpcGameObject(Transform spawnPosition, NpcView prefab)
        {
            var npc = GameObjectFactory.InstantiateObject<NpcView>(prefab, spawnPosition.position,Quaternion.identity);
            return npc;
        }
        private void ClearAllNpc()
        {
            _currentNpcs.Clear();
        }
        public void OnDestroyController()
        {
            ActionContainer.ResolveAction<EnemySpawnAction>().RemoveListener(HandleSpawnRequest);
        }

        public void OnDisableController()
        {
            
        }

        public void OnFixedUpdateController()
        {
            foreach (var npc in _currentNpcs)
            {
                npc.OnFixedUpdateController();
            }
        }

        public void OnLateUpdateController()
        {
            
        }

        public void OnUpdateController()
        {
            foreach (var npc in _currentNpcs)
            {
                npc.OnUpdateController();
            }
        }

       
    }
}
