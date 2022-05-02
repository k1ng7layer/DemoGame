using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UISystem.Common
{
    [CreateAssetMenu(fileName = "new ui preset", menuName ="UI/UIConfig")]
    public class LevelUIConfig:ScriptableObject
    {
        public string levelId;
        public List<UIWindow> windows = new List<UIWindow>();
        public List<UIActionBar> uIActionBars = new List<UIActionBar>();
    }
}
