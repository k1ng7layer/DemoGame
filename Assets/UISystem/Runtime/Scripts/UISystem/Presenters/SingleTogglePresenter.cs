using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem.Presenters
{
    public class SingleTogglePresenter:MonoBehaviour
    {
        Toggle _toggle;
        private void Start()
        {
            Init();
        }
        void Init()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(OnSelect);
        }
        public void OnSelect(bool check)
        {
            Debug.Log("toggled");
        }
        private void OnDestroy()
        {
            _toggle.onValueChanged.RemoveListener(OnSelect);
        }
    }
}
