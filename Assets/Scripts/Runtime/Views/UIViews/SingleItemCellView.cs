using Assets.Scripts.Runtime.GameActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.Views.UIViews
{
    public class SingleItemCellView : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler,IEndDragHandler, IDropHandler
    {
        public event Action<ItemCellViewEventArgs> OnItemClick;
        public event Action<ItemCellViewEventArgs> OnItemBegindDrag;
        public event Action<ItemCellViewEventArgs> OnItemDrag;
        public event Action<ItemCellViewEventArgs> OnItemEndDrag;
        public event Action<ItemCellViewEventArgs> OnItemDrop;
        [SerializeField] private Image _border;
        [SerializeField] private TextMeshProUGUI _quantityText;
        public Image Border { get => _border; }
        public Image itemImage;
        public TextMeshProUGUI QuantityText => _quantityText;
        private bool IsSelected;
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"Click Time = {eventData.clickTime} ");
            Debug.Log($"Click Count = {eventData.clickCount} ");
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border, int.Parse(QuantityText.text), Id);
            OnItemClick?.Invoke(eventArgs);
        }
        public void OnDrag(PointerEventData eventData)
        {
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border,int.Parse(QuantityText.text), Id);
            OnItemDrag?.Invoke(eventArgs);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border, int.Parse(QuantityText.text), Id);
            OnItemEndDrag?.Invoke(eventArgs);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log($"BEGIN DRAG");
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border, int.Parse(QuantityText.text), Id);
            OnItemBegindDrag?.Invoke(eventArgs);
        }

        public void SetItemData(Image image, int quantity)
        {
            itemImage = image;
            QuantityText.text = quantity.ToString();
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log($"ON DROP");
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border, int.Parse(QuantityText.text), Id);
            OnItemDrop?.Invoke(eventArgs);
        }
    }
}
