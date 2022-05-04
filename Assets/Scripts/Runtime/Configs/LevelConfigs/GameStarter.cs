using Assets.Scripts.Runtime.Controllers;
using System;
using System.Collections;
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
            StartCoroutine(LoadAsyncScene(level));
          


            

        }
        //private IEnumerator LoadAsyncScene(GameLevel gameLevel)
        //{
        //    var loader = SceneManager.LoadSceneAsync(gameLevel.sceneName);
        //    while (!loader.isDone)
        //    {
        //        yield return null;


        //    }
        //    GameObject obj = new GameObject("RootController");
        //    SceneManager.MoveGameObjectToScene(obj, SceneManager.GetSceneByName(gameLevel.sceneName));
        //    var controller = obj.AddComponent<RootController>();
        //    controller.SetUpController(gameLevel.controllersConfig);
        //    Scene scene = SceneManager.GetSceneByName(gameLevel.sceneName);

        //    //SceneManager.SetActiveScene(scene);
        //    controller.StartRootController();
        //}
        private IEnumerator LoadAsyncScene(GameLevel gameLevel)
        {
            var loader = SceneManager.LoadSceneAsync(gameLevel.sceneName);
            while (!loader.isDone)
            {
                yield return null;


            }
            GameObject obj = new GameObject("SceneStarter");
            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetSceneByName(gameLevel.sceneName));
            var starter = obj.AddComponent<SceneStarter>();
            starter.InitializeScene(gameLevel.controllersConfig);
          
        }




    }
}

        


