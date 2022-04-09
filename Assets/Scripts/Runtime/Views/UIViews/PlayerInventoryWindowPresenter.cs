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
        [SerializeField] private SingleItemCellView _singleItemCellprefab;
        [SerializeField] private TextMeshProUGUI _itemNameText;
        [SerializeField] private TextMeshProUGUI _itemDescriptionText;
        [SerializeField] private RectTransform _contentFiled;
        [SerializeField] private MouseFollower _mouseFollower;
        private List<SingleItemCellView> _displayedItems;
        private List<InventoryItem> _source;
        private SingleItemCellView _currentDraggedItem;
        public override void Init()
        {
            _displayedItems = new List<SingleItemCellView>();
            UIActionContainer.ResolveAction<DisplayInventoryItemsAction>().AddListener(DisplayItems);
            base.Init();
        }
        public override void Open()
        {
            base.Open();
        }
        public override void Close()
        {
            foreach (var obj in _displayedItems)
            {
                obj.OnItemClick -= OnItemClick;
                obj.OnItemBegindDrag -= OnItemBeginDrag;
                obj.OnItemDrag -= OnItemDrag;
                obj.OnItemEndDrag -= OnItemEndDrag;
                obj.OnItemDrop -= OnItemSwap;
                GameObject.Destroy(obj.gameObject);
            }
            _itemDescriptionText.text = string.Empty;
            _itemNameText.text = string.Empty;
            _displayedItems.Clear();
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
                slot.OnItemDrop += OnItemSwap;
                slot.Id = _source[i].Item.Id;
                slot.QuantityText.text = _source[i].Quantity.ToString();
            }
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
        private void OnItemClick(ItemCellViewEventArgs eventArgs)
        {
            var selectedItem = _displayedItems.Where(i => i.Id == eventArgs.Id).FirstOrDefault();
            DisableBordersExcept(selectedItem);
            
        }

        private void OnItemSwap(ItemCellViewEventArgs eventArgs)
        {
            var currentDragedItemIndex = _displayedItems.IndexOf(_currentDraggedItem);
            var selectedItem = _displayedItems.Where(i => i.Id == eventArgs.Id).FirstOrDefault();
            var index = _displayedItems.IndexOf(selectedItem);
            SingleItemCellView singleItem = _currentDraggedItem;
            //_displayedItems[currentDragedItemIndex] = _displayedItems[index];
            _displayedItems[currentDragedItemIndex].SetItemData(selectedItem.itemImage, int.Parse(selectedItem.QuantityText.text));
            _displayedItems[index].SetItemData(selectedItem.itemImage, int.Parse(selectedItem.QuantityText.text));




            //_displayedItems[currentDragedItemIndex].SetItemData(selectedItem.itemImage, int.Parse(selectedItem.QuantityText.text.ToString()));
            //_displayedItems[index].SetItemData(_currentDraggedItem.itemImage, int.Parse(_currentDraggedItem.QuantityText.text.ToString()));
            //currentDraggedItem.SetItemData(selectedItem.itemImage, int.Parse(selectedItem.QuantityText.text.ToString()));
          
            Debug.Log($"DROP ON = {selectedItem}");
        }
        private void OnItemBeginDrag(ItemCellViewEventArgs eventArgs)
        {
            _currentDraggedItem = _displayedItems.Where(i => i.Id == eventArgs.Id).FirstOrDefault();
            Debug.Log($"Dragged item = {_currentDraggedItem}");
            _mouseFollower.ResetPosition();
            _mouseFollower.ToggleFollower(true);
            _mouseFollower.SetItemData(eventArgs.ItemImage, eventArgs.Quantity);
        }

        private void OnItemDrag(ItemCellViewEventArgs eventArgs)
        {
           
        }
        private void OnItemEndDrag(ItemCellViewEventArgs eventArgs)
        {
            _mouseFollower.ToggleFollower(false);
        }

        private void DisplayItemInfo(SingleItemCellView singleItem)
        {

            var itemModel = _source.Where(i => i.Item.Id == singleItem.Id).FirstOrDefault();
            _itemNameText.text = itemModel.Item.Name;
            _itemDescriptionText.text = itemModel.Item.Description;

        }
    }
}

       
          
         

                



        
        

        
            
            
           

        

      
            
               

