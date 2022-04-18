using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.Runtime.Controllers.Animation
{
    [Serializable]
    public class TestUnityEvent:UnityEvent
    {
        public void Register(int index,object targetObject,System.Reflection.MethodInfo method)
        {
            RegisterPersistentListener(index, targetObject, method);
        }
    }
}
