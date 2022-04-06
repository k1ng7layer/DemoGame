using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Configs
{
    [CreateAssetMenu(fileName ="new root asset", menuName ="Configs/RootConfig")]
    public class RootAsset:ScriptableObject
    {
        //public PlayerConfig playerConfig;
        public ControllersConfig controllersConfig;

    }
}
