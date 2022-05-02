using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UISystem.Common
{
    public class UISettings:MonoBehaviour
    {
        private static UISettings _instance;
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private Canvas _indicaorsCanvas;
        public GameObject _lootCellPrefab;
        public LevelUIConfig levelUIConfig;
        public Canvas MainCanvas
        {
            get
            {
                return _mainCanvas;
            }
        }
        public Canvas IndicatorsCanvas
        {
            get
            {
                return _indicaorsCanvas;
            }
        }
        public static UISettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<UISettings>();
                }
                return _instance;
            }
        }
        public bool loadFromResources;
           
    }
}
