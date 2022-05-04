using Assets.Scripts.Runtime.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Runtime.Configs.LevelConfigs
{
    public class GameStarter:MonoBehaviour
    {
        [SerializeField] private RootAsset _rootAsset;
        private int _currentLevelIndex;
        private void Start()
        {
            DontDestroyOnLoad(this.gameObject);
            StartNewGame();
        }
        private void LoadScene()
        {
            
        }

        public void StartNewGame()
        {
            StartLevel(0);
        }
            
        public void StartNextLevel()
        {
            StartLevel(_currentLevelIndex++);
        }
        private void StartLevel(int index)
        {
            var level = _rootAsset.sceneData.gameLevels[index];
            SceneManager.LoadSceneAsync(level.sceneName);
            //GameObject gameObject = new GameObject("RootController");
            //var rootController = Instantiate(gameObject).AddComponent<RootController>();
            //SceneManager.MoveGameObjectToScene(rootController,)
            //rootController.StartRootController(level.controllersConfig);
            _currentLevelIndex = 1;
        }
            
    }
}

        


