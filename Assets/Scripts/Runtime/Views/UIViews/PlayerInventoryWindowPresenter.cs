using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.GameActions;
using Assets.Scripts.Runtime.GameActions.EventArgs;
using Assets.Scripts.Runtime.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UISystem.Common;
using UISystem.Presenters;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views.UIViews
{
     
    public class PlayerInventoryWindowPresenter : DefaultMenuPresenter
    {
        [Header("Static items")]
        [SerializeField] SingleItemCellView _equipedWeaponItemCell;
        [SerializeField] SingleItemCellView _equipedHelmetItemCell;
        [SerializeField] SingleItemCellView _equipedBootsItemCell;
        [SerializeField] SingleItemCellView _equipedChestItemCell;
        [SerializeField] SingleItemCellView _equipedGlovesItemCell;

        [SerializeField] private SingleItemCellView _singleItemCellprefab;
        [SerializeField] private TextMeshProUGUI _itemNameText;
        [SerializeField] private TextMeshProUGUI _itemDescriptionText;
        [SerializeField] private RectTransform _contentFiled;
        [SerializeField] private MouseFollower _mouseFollower;
        public event Action<OnItemSwapEventArgs> OnItemSwap;


        private List<SingleItemCellView> _displayedItems;
        private List<InventoryItem> _source;
        private SingleItemCellView _currentDraggedItem;
        public override void Init()
        {
            _displayedItems = new List<SingleItemCellView>();
            UIActionContainer.ResolveAction<DisplayInventoryItemsAction>().AddListener(DisplayItems);
            UIActionContainer.ResolveAction<ItemEquipAction>().AddListener(ItemEquipHandle);
            
            base.Init();
        }
        public override void Open()
        {
            
            base.Open();
            Debug.Log($"Opening 22222222222");
            _equipedWeaponItemCell.OnItemDrop += ItemEquipRequest;
            _equipedHelmetItemCell.OnItemDrop += ItemEquipRequest;
            _equipedBootsItemCell.OnItemDrop += ItemEquipRequest;
        }
        public override void Close()
        {
            foreach (var obj in _displayedItems)
            {
                obj.OnItemClick -= OnItemClick;
                obj.OnItemBegindDrag -= OnItemBeginDrag;
                obj.OnItemDrag -= OnItemDrag;
                obj.OnItemEndDrag -= OnItemEndDrag;
                obj.OnItemDrop -= ItemSwapRequest;
                GameObject.Destroy(obj.gameObject);
            }
            //_equipedWeaponItemCell.OnItemDrop -= OnItemSwap;
            _itemDescriptionText.text = string.Empty;
            _itemNameText.text = string.Empty;
            _displayedItems.Clear();
            Debug.Log($"Closing 22222222222");
            base.Close();
        } 
        private void DisplayItems(DisplayPlayerInventoryEventArgs eventArgs)
        {
            _mouseFollower = eventArgs.MouseFollower;
            _source = eventArgs.InventoryItems;
            for (int i = 0; i < _source.Count; i++)
            {
                var slot = GameObjectFactory.InstantiateObject<SingleItemCellView>(_singleItemCellprefab, Vector3.zero, _contentFiled, Quaternion.identity);
                _displayedItems.Add(slot);
                slot.OnItemClick += OnItemClick;
                slot.OnItemBegindDrag += OnItemBeginDrag;
                slot.OnItemDrag += OnItemDrag;
                slot.OnItemEndDrag += OnItemEndDrag;
                slot.OnItemDrop += ItemSwapRequest;
                slot.Id = _source[i].Item.Id;
                slot.QuantityText.text = _source[i].Quantity.ToString();
                slot.itemImage.sprite = _source[i].Item.ItemImage;
            }
            //var stackableItems = eventArgs.InventoryItems.Where(i=>i.Item.IsStackable==true).ToList();
            //for (int i = 0; i < stackableItems.Count; i++)
            //{
            //    var slot = GameObjectFactory.InstantiateObject<SingleItemCellView>(_singleItemCellprefab, Vector3.zero, _contentFiled, Quaternion.identity);
            //    _displayedItems.Add(slot);
            //    slot.OnItemClick += OnItemClick;
            //    slot.OnItemBegindDrag += OnItemBeginDrag;
            //    slot.OnItemDrag += OnItemDrag;
            //    slot.OnItemEndDrag += OnItemEndDrag;
            //    slot.OnItemDrop += ItemSwapRequest;
            //    slot.Id = _source[i].Item.Id;
            //    slot.QuantityText.text = _source[i].Quantity.ToString();
            //    slot.itemImage.sprite = _source[i].Item.ItemImage;
            //}
            //var notStackableItems = eventArgs.InventoryItems.Where(i => i.Item.IsStackable == false).ToList();
            //foreach (var item in notStackableItems)
            //{
            //    for (int i = 0; i < item.Quantity; i++)
            //    {
            //        var slot = GameObjectFactory.InstantiateObject<SingleItemCellView>(_singleItemCellprefab, Vector3.zero, _contentFiled, Quaternion.identity);
            //        _displayedItems.Add(slot);
            //        slot.OnItemClick += OnItemClick;
            //        slot.OnItemBegindDrag += OnItemBeginDrag;
            //        slot.OnItemDrag += OnItemDrag;
            //        slot.OnItemEndDrag += OnItemEndDrag;
            //        slot.OnItemDrop += ItemSwapRequest;
            //        slot.Id = item.Item.Id;
            //        slot.QuantityText.text = "";
            //        slot.itemImage.sprite = item.Item.ItemImage;
            //    }
            //}

        }
        private void DisableBordersExcept(SingleItemCellView singleItem)
        {
            var otherItems = _displayedItems.Where(i => i.Id != singleItem.Id);
            if (singleItem.Border.gameObject.activeSelf)
            {
                _itemDescriptionText.text = string.Empty;
                _itemNameText.text = string.Empty;
                singleItem.Border.gameObject.SetActive(false);
            }
            else
            {
                singleItem.Border.gameObject.SetActive(true);
                DisplayItemInfo(singleItem);
            }
            foreach (var item in otherItems)
            {
                item.Border.gameObject.SetActive(false);
            }
        }
        //private void OnItemClick(ItemCellViewEventArgs eventArgs)
        //{
        //    var selectedItem = _displayedItems.Where(i => i.Id == eventArgs.Id).FirstOrDefault();
        //    if(selectedItem!=null)
        //        DisableBordersExcept(selectedItem);
        //}
        private void OnItemClick(SingleItemCellView eventArgs)
        {
            var selectedItem = _displayedItems.Where(i => i.Id == eventArgs.Id).FirstOrDefault();
            if (selectedItem != null)
                DisableBordersExcept(selectedItem);
        }


        //private void OnItemSwap(ItemCellViewEventArgs eventArgs)
        //{
        //    var currentDragedItemIndex = _displayedItems.IndexOf(_currentDraggedItem);
        //    var item2 = _displayedItems.Where(i => i.Id == eventArgs.Id).FirstOrDefault();
        //    var index = _displayedItems.IndexOf(item2);
        //    _displayedItems[currentDragedItemIndex].SetItemData(item2.itemImage, int.Parse(item2.QuantityText.text));
        //    _currentDraggedItem.Id = item2.Id;
        //    item2.SetItemData(_mouseFollower.GetAttachedItem().itemImage, int.Parse(_mouseFollower.GetAttachedItem().QuantityText.text));
        //    item2.Id = _mouseFollower.GetAttachedItem().Id;
        //    Debug.Log($"DROP ON = {item2}");
        //}
        //private void OnItemSwap(ItemCellViewEventArgs eventArgs)
        //{
        //    var currentDragedItemIndex = _displayedItems.IndexOf(_currentDraggedItem);
        //    var item2 = _displayedItems.Where(i => i.Id == eventArgs.Id).FirstOrDefault();
        //    if (item2 != null&&item2.GetInstanceID()!=_currentDraggedItem.GetInstanceID()&&!item2.IsStatic)
        //    {
        //        Debug.Log($"DROP ITEM {_currentDraggedItem.Id} ON INVENTORY ITEM = {item2.Id}");
        //        ////var index = _displayedItems.IndexOf(item2);
        //        _displayedItems[currentDragedItemIndex].Id = item2.Id;
        //        _displayedItems[currentDragedItemIndex].SetItemData(item2.itemImage, int.Parse(item2.QuantityText.text));
        //        item2.Id = _mouseFollower.GetAttachedItem().Id;
        //        item2.SetItemData(_mouseFollower.GetAttachedItem().itemImage, int.Parse(_mouseFollower.GetAttachedItem().QuantityText.text));


        //    }
        //    else if (item2.IsStatic)
        //    {
        //        Debug.Log($"DROP ITEM {_currentDraggedItem.Id} ON INVENTORY ITEM = {item2.Id}");
        //        item2.Id = _mouseFollower.GetAttachedItem().Id;
        //        item2.SetItemData(_mouseFollower.GetAttachedItem().itemImage, int.Parse(_mouseFollower.GetAttachedItem().QuantityText.text));
        //    }


        //}

        //private void ItemSwap(SingleItemCellView eventArgs)
        //{
        //    Debug.Log($"DROP ITEM {_currentDraggedItem.Id} ON INVENTORY ITEM = {eventArgs.Id}");
        //    var currentDragedItemIndex = _displayedItems.IndexOf(_currentDraggedItem);

        //    if (eventArgs.GetInstanceID() != _currentDraggedItem.GetInstanceID() && !eventArgs.IsStatic)
        //    {
        //        Debug.Log($"DROP ITEM {_currentDraggedItem.Id} ON INVENTORY ITEM = {eventArgs.Id}");

        //        _displayedItems[currentDragedItemIndex].Id = eventArgs.Id;
        //        _displayedItems[currentDragedItemIndex].SetItemData(eventArgs.itemImage, int.Parse(eventArgs.QuantityText.text));
        //        eventArgs.Id = _mouseFollower.GetAttachedItem().Id;
        //        eventArgs.SetItemData(_mouseFollower.GetAttachedItem().itemImage, int.Parse(_mouseFollower.GetAttachedItem().QuantityText.text));
        //    }
        //    else if (eventArgs.IsStatic)
        //    {
        //        //var currentDragedItemIndex = _displayedItems.IndexOf(_currentDraggedItem);
        //        Debug.Log($"DROP ITEM {_currentDraggedItem.Id} ON INVENTORY ITEM = {eventArgs.Id}");
        //        eventArgs.Id = _mouseFollower.GetAttachedItem().Id;
        //        eventArgs.SetItemData(_mouseFollower.GetAttachedItem().itemImage, 0);
        //         var itemQuantity = _source[currentDragedItemIndex].Quantity - 1;
        //        _source[currentDragedItemIndex] = _source[currentDragedItemIndex].ChangeQuantity(itemQuantity);
        //        var itemView = _displayedItems.Where(i => i.Id == _source[currentDragedItemIndex].Item.Id).FirstOrDefault();
        //        itemView.QuantityText.text = _source[currentDragedItemIndex].Quantity.ToString();
        //    }
        //}

        //ЭТОТ РАБОЧИЙ
        //private void ItemSwap(SingleItemCellView arg)
        //{
        //    Debug.Log($"DROP ITEM {_currentDraggedItem.Id} ON INVENTORY ITEM = {arg.Id}");
        //    var currentDragedItemIndex = _displayedItems.IndexOf(_currentDraggedItem);

        //    if (arg.GetInstanceID() != _currentDraggedItem.GetInstanceID() && !arg.IsStatic)
        //    {
        //        Debug.Log($"DROP ITEM {_currentDraggedItem.Id} ON INVENTORY ITEM = {arg.Id}");

        //        _displayedItems[currentDragedItemIndex].Id = arg.Id;
        //        _displayedItems[currentDragedItemIndex].SetItemData(arg.itemImage, int.Parse(arg.QuantityText.text));
        //        arg.Id = _mouseFollower.GetAttachedItem().Id;
        //        arg.SetItemData(_mouseFollower.GetAttachedItem().itemImage, int.Parse(_mouseFollower.GetAttachedItem().QuantityText.text));
        //    }
        //    else if (arg.IsStatic)
        //    {
        //        //var currentDragedItemIndex = _displayedItems.IndexOf(_currentDraggedItem);
        //        Debug.Log($"DROP ITEM {_currentDraggedItem.Id} ON INVENTORY ITEM = {arg.Id}");
        //        arg.Id = _mouseFollower.GetAttachedItem().Id;
        //        arg.SetItemData(_mouseFollower.GetAttachedItem().itemImage, 0);
        //        //var itemQuantity = _source[currentDragedItemIndex].Quantity - 1;
        //        //_source[currentDragedItemIndex] = _source[currentDragedItemIndex].ChangeQuantity(itemQuantity);
        //        //var itemView = _displayedItems.Where(i => i.Id == _source[currentDragedItemIndex].Item.Id).FirstOrDefault();
        //        //itemView.QuantityText.text = _source[currentDragedItemIndex].Quantity.ToString();
        //    }
        //    //var currentDragedItemIndex = _displayedItems.IndexOf(_currentDraggedItem);
        //    var swappingItemIndex = _displayedItems.IndexOf(arg);
        //    OnItemSwapEventArgs itemCell = new OnItemSwapEventArgs(currentDragedItemIndex, swappingItemIndex);
        //    UIActionContainer.ResolveAction<SwapInventoryItemsAction>().Dispatch(itemCell);
        //    OnItemSwap?.Invoke(itemCell);
        //}

        private void ItemSwapRequest(SingleItemCellView arg)
        {
            var currentDragedItemIndex = _displayedItems.IndexOf(_currentDraggedItem);
            var swappingItemIndex = _displayedItems.IndexOf(arg);
            OnItemSwapEventArgs itemCell = new OnItemSwapEventArgs(currentDragedItemIndex, swappingItemIndex);
            UIActionContainer.ResolveAction<SwapInventoryItemsAction>().Dispatch(itemCell);
            OnItemSwap?.Invoke(itemCell);
            //_displayedItems[currentDragedItemIndex].Id = arg.Id;
            //_displayedItems[currentDragedItemIndex].SetItemData(arg.itemImage, int.Parse(arg.QuantityText.text));
            //arg.Id = _mouseFollower.GetAttachedItem().Id;
            //arg.SetItemData(_mouseFollower.GetAttachedItem().itemImage, int.Parse(_mouseFollower.GetAttachedItem().QuantityText.text));
            SwapUIItems(_currentDraggedItem,arg, equipAction:false);

        }

        private void ItemEquipRequest(SingleItemCellView arg)
        {
            ItemEquipRequestEventArgs eventArgs = new ItemEquipRequestEventArgs(_currentDraggedItem.Id,arg.TypeOfSlot);
            UIActionContainer.ResolveAction<ItemEquipRequestAction>().Dispatch(eventArgs);
        }
        private void SwapUIItems(SingleItemCellView source, SingleItemCellView target, bool equipAction)
        {
          
            if (equipAction)
            {
                target.SetItemData(source.itemImage, 0);
            }
            else
            {
                source.Id = target.Id;
                source.SetItemData(target.itemImage, int.Parse(target.QuantityText.text));
                target.Id = _mouseFollower.GetAttachedItem().Id;
                target.SetItemData(_mouseFollower.GetAttachedItem().itemImage, int.Parse(_mouseFollower.GetAttachedItem().QuantityText.text));
            }
          
        }
           

        private void ItemEquipHandle(ItemEquipEventArgs eventArgs)
        {
            Debug.Log("ITEM EQUIPED");
            switch (eventArgs.Slot)
            {
                case SlotType.WEAPON:
                    SwapUIItems(_mouseFollower.GetAttachedItem(), _equipedWeaponItemCell, equipAction:true);
                    break;
                case SlotType.HELMET:
                    SwapUIItems(_mouseFollower.GetAttachedItem(), _equipedHelmetItemCell, equipAction:true);
                    break;
                case SlotType.CHEST:
                    SwapUIItems(_mouseFollower.GetAttachedItem(), _equipedChestItemCell, equipAction:true);
                    break;
                case SlotType.BOOTS:
                    SwapUIItems(_mouseFollower.GetAttachedItem(), _equipedBootsItemCell, equipAction:true);
                    break;
                case SlotType.GLOVES:
                    SwapUIItems(_mouseFollower.GetAttachedItem(), _equipedGlovesItemCell, equipAction:true);
                    break;
                default:
                    break;
            }
        }
            
            

            


        private void UpdateItemView(int itemId)
        {

        }







        private void OnItemBeginDrag(SingleItemCellView eventArgs)
        {
            _currentDraggedItem = _displayedItems.Where(i => i.Id == eventArgs.Id).FirstOrDefault();

            Debug.Log($"BEGIN DRAG INVENTORY ITEM = {_currentDraggedItem.Id}");
            _mouseFollower.ResetPosition();
            _mouseFollower.ToggleFollower(true);
            _mouseFollower.SetItemData(_currentDraggedItem);
        }
            

        private void OnItemDrag(SingleItemCellView eventArgs)
        {

        }
        private void OnItemEndDrag(SingleItemCellView eventArgs)
        {
            _mouseFollower.ToggleFollower(false);
        }

        //private void OnItemBeginDrag(ItemCellViewEventArgs eventArgs)
        //{
        //    _currentDraggedItem = _displayedItems.Where(i => i.Id == eventArgs.Id).FirstOrDefault();
        //    Debug.Log($"BEGIN DRAG INVENTORY ITEM = {_currentDraggedItem.Id}");
        //    _mouseFollower.ResetPosition();
        //    _mouseFollower.ToggleFollower(true);
        //    //_mouseFollower.SetItemData(eventArgs.ItemImage, eventArgs.Quantity);
        //    _mouseFollower.SetItemData(_currentDraggedItem);
        //}

        //private void OnItemDrag(ItemCellViewEventArgs eventArgs)
        //{

        //}
        //private void OnItemEndDrag(ItemCellViewEventArgs eventArgs)
        //{
        //    _mouseFollower.ToggleFollower(false);
        //}
        private void DisplayItemInfo(SingleItemCellView singleItem)
        {

            var itemModel = _source.Where(i => i.Item.Id == singleItem.Id).FirstOrDefault();
            _itemNameText.text = itemModel.Item.Name;
            _itemDescriptionText.text = itemModel.Item.Description;

        }
        private void OnDestroy()
        {
            UIActionContainer.ResolveAction<DisplayInventoryItemsAction>().RemoveListener(DisplayItems);
            UIActionContainer.ResolveAction<ItemEquipAction>().RemoveListener(ItemEquipHandle);
        }
        //private void DisplayItemInfo(SingleItemCellView singleItem)
        //{

        //    var itemModel = _source.Where(i => i.Item.Id == singleItem.Id).FirstOrDefault();
        //    _itemNameText.text = itemModel.Item.Name;
        //    _itemDescriptionText.text = itemModel.Item.Description;

        //}
    }
}
          
           






       
          
         

                



        
        

        
            
            
           

        

      
            
               

