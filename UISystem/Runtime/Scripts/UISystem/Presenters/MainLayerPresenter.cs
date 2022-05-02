
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UISystem.Presenters
{
    public class MainLayerPresenter : MonoBehaviour
    {
        [SerializeField]
        public WindowLayerPresenter windows;
        [SerializeField]
        public PanelLayerPresenter panels;
        public string Id;
        public void Init()
        {
            windows = GetComponentInChildren<WindowLayerPresenter>();
            panels = GetComponentInChildren<PanelLayerPresenter>();
            windows.Init();
            panels.Init();
        }

        public void OpenWindow(string id)
        {
            windows.OpenNewWindow(id);
        }

        public void CloseActiveWindow()
        {
            windows.CloseActiveWindow();
        }
    }
            

}

