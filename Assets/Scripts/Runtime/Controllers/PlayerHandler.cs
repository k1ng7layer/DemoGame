using Assets.Scripts.Runtime.Configs;
using Assets.Scripts.Runtime.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers
{
    public class PlayerHandler:IController
    {
        private bool _isDead;
        private PlayerController _player;
        public PlayerHandler(PlayerConfig config)
        {
            _player = new MainPlayerController(config);
            //var playerObject = GameObject.Instantiate<PlayerView>(config.PlayerViewPrefab);
        }
        public void InitializeController()
        {
            _player.InitializeController();
            _player.OnPlayerDeath += HandleDeath;
        }
        public void OnDestroyController()
        {
            _player.OnPlayerDeath -= HandleDeath;
            _player.OnDestroyController();
        }

        private void HandleDeath()
        {
            _isDead = true;
        }
     
            

        public void OnDisableController()
        {
            _player.OnDisableController();
        }

        public void OnFixedUpdateController()
        {
            if (!_isDead)
                _player.OnFixedUpdateController();
        }

        public void OnLateUpdateController()
        {
            if (!_isDead)
                _player.OnLateUpdateController();
        }

        public void OnUpdateController()
        {
            if (!_isDead)
                _player.OnUpdateController();
        }
    }
}
