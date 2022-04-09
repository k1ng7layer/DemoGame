using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.GameActions
{
    public class ItemCellViewEventArgs
    {
        public Image ItemImage { get; private set; }
        public Image Border { get; private set; }
        public int Id { get; private set; }
        public int Quantity { get; private set; }
        public ItemCellViewEventArgs(Image itemImage, Image border, int quantity, int id)
        {
            ItemImage = itemImage;
            Border = border;
            Id = id;
            Quantity = quantity;
        }
    }
}
