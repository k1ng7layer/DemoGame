using Assets.Scripts.Runtime.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.Views.UIViews
{
    public class HpBarView:MonoBehaviour
    {
        private Camera _camera;
        private Slider _slider;

        public event Action OnZeroHpAction;

        
        public void LateUpdate()
        {
            transform.LookAt(transform.position + _camera.transform.forward);
        }
        public void Initialize()
        {
            _camera = RootController.Instance.cameraController.CameraObject;
            if (this.TryGetComponent<Slider>(out Slider slider))
            {
                _slider = slider;

            }
        }
        public void SetMaxHealth(float health)
        {
            _slider.maxValue = health; 
            _slider.value = _slider.maxValue;
        }
        public void SetHealth(float value)
        {
            _slider.value = value;
            if (_slider.value <= 0)
            {
                OnZeroHpAction?.Invoke();
            }
        }
    }
}
