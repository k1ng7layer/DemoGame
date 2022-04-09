using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers
{
    public class GameObjectFactory : MonoBehaviour
    {
        public static T InstantiateObject<T>(T Object) where T : MonoBehaviour
        {
            var obj = Instantiate<T>(Object);
            return obj;
        }

        public static T InstantiateObject<T>(T Object, Transform parent) where T : MonoBehaviour
        {
            var obj = Instantiate<T>(Object, parent);
            return obj;
        }
        public static T InstantiateObject<T>(T Object, Transform parent, bool worldPositionStays) where T : MonoBehaviour
        {
            var obj = Instantiate<T>(Object, parent, worldPositionStays);
            return obj;
        }


        public static T InstantiateObject<T>(T Object, Vector3 position, Transform parent, Quaternion rotation) where T : MonoBehaviour
        {
            var obj = Instantiate<T>(Object, position, rotation, parent);
            return obj;
        }


        public static T InstantiateObject<T>(T Object, Vector3 position, Quaternion rotation) where T : MonoBehaviour
        {
            var obj = Instantiate<T>(Object, position, rotation);
            return obj;
        }
    }
}
