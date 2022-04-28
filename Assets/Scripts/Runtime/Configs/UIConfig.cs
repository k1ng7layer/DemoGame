using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Common;
using UnityEngine;

namespace Assets.Scripts.Runtime.Configs
{
    [CreateAssetMenu(fileName = "new controllers config", menuName = "Configs/UIConfig")]
    public class UIConfig:ScriptableObject
    {
        public SingleItemCellView singleItemCellPrefab;
        [Header("UI Objects Prefabs")]
        public List<UIWindow> windows;
        public List<UIActionBar> uIActionBars;

        public MouseFollower mouseFollowerPrefab;
        public Canvas indicatorsCanvas;
    }
}
