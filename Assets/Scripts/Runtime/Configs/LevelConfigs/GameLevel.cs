using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Configs.LevelConfigs
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "Config/LevelConfigs/GameLevel")]
    public class GameLevel:GameScene
    {
        public ControllersConfig controllersConfig;
    }
}
