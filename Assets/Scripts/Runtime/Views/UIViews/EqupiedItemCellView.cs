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
    public enum SlotType
    {
        WEAPON,
        HELMET,
        CHEST,
        BOOTS,
        GLOVES,
    }
    public class EqupiedItemCellView: SingleItemCellView, IPointerClickHandler, IBeginDragHandler, IDragHandler,IEndDragHandler, IDropHandler
    {
        public override event Action<SingleItemCellView> OnItemClick;
        public override event Action<SingleItemCellView> OnItemBegindDrag;
        public override event Action<SingleItemCellView> OnItemDrag;
        public override event Action<SingleItemCellView> OnItemEndDrag;
        public override event Action<SingleItemCellView> OnItemDrop;

        

        //public Image Border { get => _border; }
        //public Image itemImage;
        //public int Id { get; private set; }
        public override void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"Click Time = {eventData.clickTime} ");
            Debug.Log($"Click Count = {eventData.clickCount} ");
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border,  Id);
            OnItemClick?.Invoke(this);
        }
        public override void OnDrag(PointerEventData eventData)
        {
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border, Id);
            OnItemDrag?.Invoke(this);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border, Id);
            OnItemEndDrag?.Invoke(this);
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log($"BEGIN DRAG");
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border,  Id);
            OnItemBegindDrag?.Invoke(this);
        }

        public void SetItemData(Image image)
        {
            itemImage = image;
        }
            

        public override void OnDrop(PointerEventData eventData)
        {
            Debug.Log($"ON DROP");
            ItemCellViewEventArgs eventArgs = new ItemCellViewEventArgs(itemImage, Border, Id);
            OnItemDrop?.Invoke(this);
        }
        public override void SetItemData(Image image, int quantity)
        {
            Debug.Log($"SET EQUIPED ITEM DATA");
            itemImage.sprite = image.sprite;
        }
    }
}
