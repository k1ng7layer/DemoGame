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
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.Views.UIViews
{
    public class LootWindowView: DefaultMenuPresenter
    {
        [SerializeField] private SingleItemCellView _singleItemCellprefab;
        private LootRepository _source;
        private List<InventoryItem> _sourceItems;
        private List<SingleItemCellView> _displayedItems;
        [SerializeField] private InventoryContentView _contentFiled;
        [SerializeField] private TextMeshProUGUI _itemNameText;
        [SerializeField] private TextMeshProUGUI _itemDescriptionText;
        [SerializeField] private Button _takeItemButton;
        private SingleItemCellView _selectedItem;
        public override void Init()
        {
            _takeItemButton.GetComponent<Button>().onClick.AddListener(OnButtonTakeClick);
            _displayedItems = new List<SingleItemCellView>();
            UIActionContainer.ResolveAction<DisplayLootItemsAction>().AddListener(DisplayItems);
            base.Init();
           
        }
        private void OnDestroy()
        {
            _takeItemButton.GetComponent<Button>().onClick.RemoveListener(OnButtonTakeClick);
            UIActionContainer.ResolveAction<DisplayLootItemsAction>().RemoveListener(DisplayItems);
        }
        public override void Open()
        {
            base.Open();
        }
        public override void Close()
        {
            foreach (var item in _displayedItems)
            {
                GameObject.Destroy(item.gameObject);
            }
            _displayedItems.Clear();
            _source = null;
            base.Close();
        }
        private void DisplayItems(DisplayLootItemsEventArgs eventArgs)
        {
            
            _source = eventArgs.SourceInventory;
            _sourceItems = eventArgs.InventoryItems;
            var contentRectTransform = _contentFiled.GetComponent<RectTransform>();
            for (int i = 0; i < _source.Loot.Count; i++)
            {
                var slot = GameObjectFactory.InstantiateObject<SingleItemCellView>(_singleItemCellprefab, Vector3.zero, contentRectTransform, Quaternion.identity);
                _displayedItems.Add(slot);
                slot.OnItemClick += OnItemClick;
            
                slot.QuantityText.text = _source.Loot[i].Quantity.ToString();
                slot.itemImage.sprite = _source.Loot[i].Item.ItemImage;
                slot.AttachedItem_ID = _source.Loot[i].Item.Id;
                slot.CellIsEmpty = false;
            }
         
        }
        private void OnItemClick(SingleItemCellView eventArgs)
        {
            _selectedItem = _displayedItems.Where(i => i.Id == eventArgs.Id).FirstOrDefault();
            if (_selectedItem != null)
                DisableBordersExcept(_selectedItem);
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
                ItemInfoRequest(singleItem);
            }
            foreach (var item in otherItems)
            {
                item.Border.gameObject.SetActive(false);
            }
        }
        private void ItemInfoRequest(SingleItemCellView singleItem)
        {
           
        }
        private void OnButtonTakeClick()
        {
            if (_selectedItem != null)
            {
                var itemInSource = _source.Loot.Find(i => i.Item.Id == _selectedItem.AttachedItem_ID);
                var itemView = _displayedItems.Find(i => i.AttachedItem_ID == itemInSource.Item.Id);
                var availableQuantity = itemInSource.Quantity;
                if(availableQuantity > 0)
                {
                    var eventArgs = new ItemAddInInventoryRequestEventArgs(itemInSource, _source);
                    UIActionContainer.ResolveAction<ItemAddInInventoryRequestAction>().Dispatch(eventArgs);
                    _displayedItems.Remove(itemView);
                    _source.RemoveItem(itemInSource);
                    GameObject.Destroy(itemView.gameObject);
                }
               



            }
        }
       
    }
}
