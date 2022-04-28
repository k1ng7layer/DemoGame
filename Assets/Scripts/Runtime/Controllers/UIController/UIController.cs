using Assets.Scripts.Runtime.Configs;
using Assets.Scripts.Runtime.GameActions;
using Assets.Scripts.Runtime.GameActions.EventArgs;
using Assets.Scripts.Runtime.Views.UIViews;
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
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.Controllers
{
    public class UIController : IController
    {

        [SerializeField] MainLayerPresenter MainLayer;
      
        private UIActionConfigurator ActionConfigurator { get; set; }
        private Scene _currentScene;
        private Canvas _mainCanvas;
        private static Canvas _playerIndicatorsCanvas;
        public static Canvas PlayerIndicatorsCanvas => _playerIndicatorsCanvas;



        private bool _isInventoryOpen;
        private UIConfig ui_Config;
        private MouseFollower _mouseFollower;
        //public UIController(Canvas mainCanvas, Canvas indicators)
        //{
        //    _mainCanvas = mainCanvas;
        //    _indicatorsCanvas = indicators;
        //}
        public UIController(UIConfig uIConfig)
        {
            ui_Config = uIConfig;
            CreateUIObjects();
        }
        private void CreateUIObjects()
        {
            GameObject mainCanvas = new GameObject("MenuCanvas");
            _mainCanvas = mainCanvas.AddComponent<Canvas>();
            mainCanvas.AddComponent<GraphicRaycaster>();
            _mainCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            var mainCanvasScaler = mainCanvas.AddComponent<CanvasScaler>();
            mainCanvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            mainCanvasScaler.referenceResolution = new Vector2(1920, 1080);
            _playerIndicatorsCanvas = GameObject.Instantiate<Canvas>(ui_Config.indicatorsCanvas);
            //GameObject indicatorsCanvas = new GameObject("IndicatorCanvas");
            //_indicatorsCanvas = indicatorsCanvas.AddComponent<Canvas>();
            //indicatorsCanvas.AddComponent<GraphicRaycaster>();
            //_indicatorsCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            //var indicatorCanvasScaler = indicatorsCanvas.AddComponent<CanvasScaler>();
            //indicatorCanvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            //indicatorCanvasScaler.referenceResolution = new Vector2(1920, 1080);
        }

            



           
            
            
            
        private void ConfigureActions()
        {
            UIActionContainer.ResolveAction<SwitchUIStateAction>().AddListener(DisableIndicators);
            UIActionContainer.ResolveAction<OpenLootWindowAction>().AddListener(OpenLootWindow);
            UIActionContainer.ResolveAction<CloseLootWindowAction>().AddListener(CloseWindow);
            ActionContainer.ResolveAction<OpenPlayerInventoryAction>().AddListener(OpenPlayerInventoryWindow);
            //SceneGameManagerView.Instance.CurrentPlayer.playerInput.OnInventoryOpen += OpenPlayerInventoryWindow;
        }
        public void OnDestroyController()
        {
            UIActionContainer.ResolveAction<SwitchUIStateAction>().RemoveListener(DisableIndicators);
            UIActionContainer.ResolveAction<OpenLootWindowAction>().RemoveListener(OpenLootWindow);
            UIActionContainer.ResolveAction<CloseLootWindowAction>().RemoveListener(CloseWindow);
            ActionContainer.ResolveAction<OpenPlayerInventoryAction>().RemoveListener(OpenPlayerInventoryWindow);
        }
        private void DisableIndicators()
        {
            if (_playerIndicatorsCanvas != null)
            {
                if (_playerIndicatorsCanvas.gameObject.activeSelf)
                    _playerIndicatorsCanvas.gameObject.SetActive(false);
                else _playerIndicatorsCanvas.gameObject.SetActive(true);
            }
        }
        private void OpenWindow(string id)
        {
            MainLayer.OpenWindow(id);
        }
        private void CloseWindow()
        {
            MainLayer.CloseActiveWindow();
        }
        private void OpenLootWindow(OpenLootWindowEventArgs eventArgs)
        {
            OpenWindow("lootWindow");
            DisplayLootItemsEventArgs displayArgs = new DisplayLootItemsEventArgs(eventArgs.Loot, ui_Config.singleItemCellPrefab.gameObject, _mouseFollower);
            UIActionContainer.ResolveAction<DisplayLootItemsAction>().Dispatch(displayArgs);
        }
        private void OpenPlayerInventoryWindow(OpenLootWindowEventArgs eventArgs)
        {
            if (_isInventoryOpen)
            {
                CloseWindow();
                _isInventoryOpen = false;
            }
            else
            {
                OpenWindow("inventoryWindow");
                DisplayPlayerInventoryEventArgs inventoryDisplayArgs = new DisplayPlayerInventoryEventArgs(eventArgs.Loot, _mouseFollower);
                UIActionContainer.ResolveAction<DisplayInventoryItemsAction>().Dispatch(inventoryDisplayArgs);
                _isInventoryOpen = true;
            }
                
        }
        public void InitializeController()
        {
           
            //_mainCanvas = UISettings.Instance.MainCanvas;
            ActionConfigurator = new UIActionConfigurator();
            //ActionConfigurator.Configure();
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
            List<UIWindow> uiWindows = ui_Config.windows ?? throw new ArgumentNullException("в массив windows в UISettings должен содержать хотя бы одно значение");
            var uiBars = ui_Config.uIActionBars;

            if (uiWindows != null)
            {
                foreach (var window in uiWindows)
                {
                    GameObjectFactory.InstantiateObject<UIWindow>(window, windowsLayer.transform, false);
                }
            }

            if (uiBars != null)
            {
                foreach (var bar in uiBars)
                {
                    GameObjectFactory.InstantiateObject<UIActionBar>(bar, panelLayer.transform, false);
                }
            }

            if (MainLayer != null)
            {
                MainLayer.Init();
            }

            //_indicatorsCanvas = UISettings.Instance.IndicatorsCanvas;
            _mouseFollower = GameObjectFactory.InstantiateObject<MouseFollower>(ui_Config.mouseFollowerPrefab, _mainCanvas.transform);
            _mouseFollower.ToggleFollower(false);
            ConfigureActions();
        }
        public void OnUpdateController()
        {

        }
        public void OnFixedUpdateController()
        {

        }
        public void OnDisableController()
        {

        }
        public void OnLateUpdateController()
        {

        }
    }
}



















