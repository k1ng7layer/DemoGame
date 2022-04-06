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
        private PlayerController _player;
        public PlayerHandler(PlayerConfig config)
        {
            _player = new MainPlayerController(config);
            //var playerObject = GameObject.Instantiate<PlayerView>(config.PlayerViewPrefab);
        }
        public void InitializeController()
        {
            
            _player.InitializeController();
        }

        public void OnDestroyController()
        {
            _player.OnDestroyController();
        }

        public void OnDisableController()
        {
            _player.OnDisableController();
        }

        public void OnFixedUpdateController()
        {
            _player.OnFixedUpdateController();
        }

        public void OnLateUpdateController()
        {
            _player.OnLateUpdateController();
        }

        public void OnUpdateController()
        {
            _player.OnUpdateController();
        }
    }
}
