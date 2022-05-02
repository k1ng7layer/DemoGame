using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Interfaces;
using UnityEngine;

namespace UISystem.Common
{
    public class GUICollection<T>:MonoBehaviour where T:IDisplayable
    {
        public Dictionary<string, T> registeredObjects = new Dictionary<string, T>();

        public virtual void Init()
        {
            var objects = GetComponentsInChildren<T>();
            foreach (var obj in objects)
            {
                RegisterUIElement(obj);
            }
        }
        public void RegisterUIElement(T element)
        {
            T res;
            if (!registeredObjects.TryGetValue(element.Id, out res))
            {
                registeredObjects.Add(element.Id, element);
            }
        }
                

        public void RemoveUIElement(T element)
        {
            T res;
            if (registeredObjects.TryGetValue(element.Id, out res))
            {
                registeredObjects.Remove(res.Id);
            }

        }

        public IEnumerable<T> GetAllObjects()
        {
            return registeredObjects.Values;
        }

        public T FindUI(string Id)
        {
            T res;
            if (registeredObjects.TryGetValue(Id, out res))
            {
                return res;
            }
            return default;
        }

        public void Hide(string Id)
        {
            var ui = FindUI(Id);
            if (ui != null)
            {

                gameObject.SetActive(false);
            }
        }

        public void Show(string Id)
        {
            var ui = FindUI(Id);
            if (ui != null)
            {
                gameObject.SetActive(true);
            }
        }

    }
}
