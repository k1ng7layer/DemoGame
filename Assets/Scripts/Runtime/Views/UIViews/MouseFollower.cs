using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.Views.UIViews
{
    public class MouseFollower:MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private SingleItemCellView _item;
        [SerializeField] private Camera _camera;
        private void Awake()
        {
            _canvas = this.gameObject.transform.root.GetComponent<Canvas>();
            _item = this.GetComponentInChildren<SingleItemCellView>();
            _camera = FindObjectOfType<CameraView>().GetComponent<Camera>();
        }

        public void SetItemData(Image image, int quantity)
        {
            _item.SetItemData(image, quantity);
        }
        public void SetItemData(SingleItemCellView singleItemCell)
        {
            int quantity;
            if (singleItemCell.QuantityText != null)
            {
                if (singleItemCell.QuantityText.text == string.Empty)
                {
                    quantity = 0;
                }
                else
                {
                    quantity = int.Parse(singleItemCell.QuantityText.text);
                }
            }
            else
            {
                quantity = 0;
            }
          
            _item.AttachedItem_ID = singleItemCell.AttachedItem_ID;
            _item.SetItemData(singleItemCell.itemImage, quantity);
            //_item.Id = singleItemCell.Id;
        }

        private void Update()
        {
            if(RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.GetComponent<RectTransform>(), Input.mousePosition, _canvas.worldCamera, out Vector2 position))
            {
                this.transform.position = _canvas.transform.TransformPoint(position);
            }
        }
        public void ResetPosition()
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.GetComponent<RectTransform>(), Input.mousePosition, _canvas.worldCamera, out Vector2 position))
            {
                this.transform.position = _canvas.transform.TransformPoint(position);
            }
        }
        public void ToggleFollower(bool value)
        {
            this.gameObject.SetActive(value);
        }

        public SingleItemCellView GetAttachedItem()
        {
            return _item;
        }
    }
}
            

