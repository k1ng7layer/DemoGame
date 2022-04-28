using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Extensions
{
    public static class ComponentExtension
    {
        public static T GetOrCreateComponent<T>(this UnityEngine.Component component) where T : Component
        {
            if (!component.gameObject.TryGetComponent<T>(out T requestedComponent))
            {
                requestedComponent = component.gameObject.AddComponent<T>();
            }
            else
            {
                requestedComponent = component.gameObject.GetComponent<T>();
            }
            return requestedComponent;
        }
    }
}
      

