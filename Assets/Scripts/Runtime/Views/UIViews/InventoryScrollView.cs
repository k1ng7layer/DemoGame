using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Runtime.Views.UIViews
{
    public class InventoryScrollView : MonoBehaviour, IDropHandler
    {
        public event Action OnContentViewItemDrop;
        public void OnDrop(PointerEventData eventData)
        {
            OnContentViewItemDrop?.Invoke();
        }
    }
}
