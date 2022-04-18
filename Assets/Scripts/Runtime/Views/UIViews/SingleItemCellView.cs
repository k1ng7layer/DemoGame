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
        public virtual event Action<SingleItemCellView> OnItemClick;
        public virtual event Action<SingleItemCellView> OnItemBegindDrag;
        public virtual event Action<SingleItemCellView> OnItemDrag;
        public virtual event Action<SingleItemCellView> OnItemEndDrag;
        public virtual event Action<SingleItemCellView> OnItemDrop;
        [SerializeField] private Image _border;
        [SerializeField] private Image _defaultImage;
        [SerializeField] private TextMeshProUGUI _quantityText;
        public bool IsStatic;
        public bool IsActive;
        public SlotType TypeOfSlot;
        public bool CellIsEmpty { get; set; }

        public Image Border { get => _border; }
        public Image itemImage;
        public Image DefaultImage => _defaultImage;
        public TextMeshProUGUI QuantityText => _quantityText;
        private bool IsSelected;
  
        public int Id => GetInstanceID();
        public int AttachedItem_ID;

        

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            //Debug.Log($"Click Time = {eventData.clickTime} ");
            //Debug.Log($"Click Count = {eventDats.clickCount} ");
            int quantity;
            if (QuantityText.text == string.Empty)
            {
                quantity = 0;
            }
            else
            {
                quantity = int.Parse(QuantityText.text);
            }
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border, quantity, Id);
            OnItemClick?.Invoke(this);
            
        }
        public virtual void OnDrag(PointerEventData eventData)
        {
            int quantity;
            if (QuantityText.text == string.Empty)
            {
                quantity = 0;
            }
            else
            {
                quantity = int.Parse(QuantityText.text);
            }
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border, quantity, Id);
            OnItemDrag?.Invoke(this);
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            int quantity;
            if (QuantityText.text == string.Empty)
            {
                quantity = 0;
            }
            else
            {
                quantity = int.Parse(QuantityText.text);
            }
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border, quantity, Id);
            OnItemEndDrag?.Invoke(this);
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log($"BEGIN DRAG");
            int quantity;
            if (QuantityText.text == string.Empty)
            {
                quantity = 0;
            }
            else
            {
                quantity = int.Parse(QuantityText.text);
            }
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border, quantity, Id);
            OnItemBegindDrag?.Invoke(this);
        }

        public virtual void SetItemData(Image image, int quantity)
        {
            itemImage.sprite = image.sprite;
            QuantityText.text = quantity.ToString();
        }
        public void ResetData()
        {
            itemImage.sprite = DefaultImage.sprite;
            CellIsEmpty = true;
        }
        public virtual void SetItemData(Image image, int quantity, SlotType slotType)
        {
            itemImage.sprite = image.sprite;
            QuantityText.text = quantity.ToString();
            TypeOfSlot = slotType;
        }

        public virtual void OnDrop(PointerEventData eventData)
        {
            Debug.Log($"ON DROP");
            int quantity;
            if (QuantityText.text == string.Empty)
            {
                quantity = 0;
            }
            else
            {
                quantity = int.Parse(QuantityText.text);
            }
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border, quantity, Id);
            OnItemDrop?.Invoke(this);
        }
    }
}
