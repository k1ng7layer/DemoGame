using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem.Presenters
{
    public class ToggleBarPresenter:MonoBehaviour
    {
        ToggleGroup toggleGroup;
        List<Toggle> _activeToggles;

        public void Init()
        {
            toggleGroup = GetComponent<ToggleGroup>();
            var toggles = toggleGroup.GetComponentsInChildren<Toggle>();
            var activeToggles = toggleGroup.ActiveToggles();
            _activeToggles = activeToggles.ToList(); ;
            foreach (var item in toggles)
            {
                item.onValueChanged.AddListener(ToggleOn);
            }

        }

        public void ToggleOn(bool check)
        {
            foreach (var item in _activeToggles)
            {
                
            }
        }

    }
}

        
