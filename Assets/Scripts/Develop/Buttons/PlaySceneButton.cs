using Assets.Scripts.Runtime.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Develop.Buttons
{
    public class PlaySceneButton:MonoBehaviour
    {
        private Button _button;
        private RootController _rootController;
        private bool _started;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Play);
        }
        public void Play()
        {
            _rootController = FindObjectOfType<RootController>();
            if (_rootController != null)
            {
                _rootController.StartRootController();
                _started = true;
            }
        }
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Play);
        }
    }
            
}
                
