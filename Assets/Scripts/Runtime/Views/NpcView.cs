using AIBehaviour;
using Assets.Scripts.Runtime.Configs;
using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.Views.UIViews;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views
{
    public class NpcView:PlayerView
    {
        [SerializeField] BehaviourTreeConfig _behaviourTreeConfig;
        [SerializeField] GameObject _hpBarViewPrefab;
        [SerializeField] Canvas _statusCanvasPrefab;
        [SerializeField] private NpcConfig _npcConfig;
        public HpBarView HpBar { get; private set; }
        private Canvas _statusCanvas;
        public NpcConfig Config => _npcConfig;
        private void Start()
        {
            
        }

        public void CreateGraphics()
        {
            _statusCanvas = GameObject.Instantiate<Canvas>(_npcConfig.StatusCanvasPrefab, this.transform);
            var healthbar = Instantiate(_npcConfig.HpBarViewPrefab, _statusCanvas.transform);
            HpBar = healthbar.AddComponent<HpBarView>();
            HpBar.Initialize();
            HpBar.SetMaxHealth(Config.MaxHp);
        }
    }
}

        

     
        
