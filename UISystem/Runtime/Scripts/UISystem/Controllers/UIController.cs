
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Actions;
using UISystem.Common;
using UISystem.Presenters;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UISystem.Controllers
{
    public class UIController:MonoBehaviour
    {

        [SerializeField] MainLayerPresenter MainLayer;
        private Canvas _indicatorsCanvas;
        private UIActionConfigurator ActionConfigurator { get; set; }
        private Scene _currentScene;
        private Canvas _mainCanvas;
       
    
     
        private void Awake()
        {
            _currentScene = SceneManager.GetActiveScene();
        }
  
        public void InitializeController()
        {
            _mainCanvas = UISettings.Instance.MainCanvas;
            ActionConfigurator = new UIActionConfigurator();
            ActionConfigurator.Configure();
            //Создание объектов на сцене
            GameObject mainLayer = new GameObject("MainLayerPresenter");
            GameObject windowsLayer = new GameObject("WindowsLayer");
            GameObject panelLayer = new GameObject("PanelsLayer");

            //Установка родителей
            mainLayer.transform.SetParent(_mainCanvas.transform);
            windowsLayer.transform.SetParent(mainLayer.transform);
            panelLayer.transform.SetParent(mainLayer.transform);
            //Добавление необходимых компонентов
            MainLayer = mainLayer.AddComponent<MainLayerPresenter>();
            var mainLayerRT = mainLayer.AddComponent<RectTransform>();
            var windowsLayerRT = windowsLayer.AddComponent<RectTransform>();
            var panelLayerRT = panelLayer.AddComponent<RectTransform>();
            windowsLayer.AddComponent<WindowLayerPresenter>();
            panelLayer.AddComponent<PanelLayerPresenter>();
            //Настройка MainLayer
            mainLayerRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0f, 0f);
            mainLayerRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0f, 0f);
            mainLayerRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0f, 0f);
            mainLayerRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0f, 0f);
            mainLayerRT.anchorMax = new Vector2(1f, 1f);
            mainLayerRT.anchorMin = Vector2.zero;
            mainLayerRT.localScale = Vector3.one;
            mainLayerRT.anchoredPosition = Vector2.zero;

            //Настройка WindowsLayer
            windowsLayerRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0f, 0f);
            windowsLayerRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0f, 0f);
            windowsLayerRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0f, 0f);
            windowsLayerRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0f, 0f);
            
            windowsLayerRT.anchorMax = new Vector2(1f, 1f);
            windowsLayerRT.anchorMin = Vector2.zero;
            windowsLayerRT.anchoredPosition = Vector2.zero;
            windowsLayerRT.localScale = Vector3.one;

            //Настройка PanelLayer
            panelLayerRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0f, 0f);
            panelLayerRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0f, 0f);
            panelLayerRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0f, 0f);
            panelLayerRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0f, 0f);

            panelLayerRT.anchorMax = new Vector2(1f, 1f);
            panelLayerRT.anchorMin = Vector2.zero;
            panelLayerRT.anchoredPosition = Vector2.zero;
            panelLayerRT.localScale = Vector3.one;
            //Загрузка окон и панелей интерфейса
            var uiWindows = UISettings.Instance.levelUIConfig.windows;
            var uiBars = UISettings.Instance.levelUIConfig.uIActionBars;

            if (uiWindows != null)
            {
                foreach (var window in uiWindows)
                {
                    Instantiate<UIWindow>(window, windowsLayer.transform, false);
                }
            }
                   
            if (uiBars != null)
            {
                foreach (var bar in uiBars)
                {
                    Instantiate<UIActionBar>(bar, panelLayer.transform,false);
                }
            }

            if (MainLayer != null)
            {
                MainLayer.Init();
            }

            _indicatorsCanvas = UISettings.Instance.IndicatorsCanvas;
            UIActionContainer.ResolveAction<SwitchUIStateAction>().AddListener(DisableIndicators);
        }

                  
           

        private void DisableIndicators()
        {
            if (_indicatorsCanvas != null)
            {
                if (_indicatorsCanvas.gameObject.activeSelf)
                    _indicatorsCanvas.gameObject.SetActive(false);
                else _indicatorsCanvas.gameObject.SetActive(true);
            }
        }
           
    }
}
         
           


            



          




            




        






          


          



           













           
            

       
           


