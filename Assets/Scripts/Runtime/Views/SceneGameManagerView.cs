using Assets.Scripts.Runtime.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views
{
    public class SceneGameManagerView : MonoBehaviour
    {
        private static SceneGameManagerView _instance;
        bool isExecuted;
        //public static SceneGameManagerView Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = FindObjectOfType<SceneGameManagerView>();
        //            if (_instance == null)
        //            {
        //                GameObject obj = new GameObject("SceneGameManager");
        //                _instance = obj.AddComponent<SceneGameManagerView>();
        //            }
        //        }
        //        return _instance;
        //    }
        //}

        public static SceneGameManagerView Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<SceneGameManagerView>();
                    DontDestroyOnLoad(_instance);

                }
                return _instance;
            }
        }

        public PlayerController CurrentPlayer { get; private set; }

        //private Dictionary<int, AiController> animatedAiControllers = new Dictionary<int, AiController>();
        //[SerializeField] private List<EnemyView> _scenePlayers = new List<EnemyView>();
        //public List<EnemyView> scenePlayers
        //{
        //    get
        //    {
        //        return _scenePlayers;
        //    }
        //}

        public void SetCurrentPlayer(PlayerController controller)
        {
            CurrentPlayer = controller;
        }
        //public void RegisterAiController(Animator animator, AiController controller)
        //{
        //    animatedAiControllers.Add(animator.GetInstanceID(), controller);
        //}
        //public AiController GetAiController(Animator animator)
        //{
        //    if (animatedAiControllers.TryGetValue(animator.GetInstanceID(), out AiController controller))
        //    {
        //        return controller;
        //    }
        //    return default;
        //}

        public void UnRegisterAiController(Animator animator)
        {
            //animatedAiControllers.Remove(animator.GetInstanceID());
        }

        //public AiController GetAiController(Animator animator)
        //{

        //    if (animatedAiControllers.TryGetValue(animator, out AiController controller))
        //    {
        //        return controller;
        //    }
        //    return default;
        //}

        private void Update()
        {
            if (!isExecuted)
            {
                Debug.Log("Executed");
                isExecuted = true;
            }

        }

    }
}