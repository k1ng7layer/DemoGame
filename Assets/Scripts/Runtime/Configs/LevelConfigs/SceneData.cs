using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Configs.LevelConfigs
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "Config/LevelConfigs/SceneData")]
    public class SceneData:ScriptableObject
    {
        public List<GameLevel> gameLevels = new List<GameLevel>();
        public int currentLevel;
    }

}
