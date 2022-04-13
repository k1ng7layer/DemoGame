using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Runtime.Views.UIViews
{
    public class InventoryContentView : MonoBehaviour, IDropHandler
    {
        public event Action OnContentViewItemDrop;
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("On Item Drop On ContentField");
            OnContentViewItemDrop?.Invoke();
        }
    }
}
