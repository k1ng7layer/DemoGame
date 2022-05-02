
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Interfaces;
using UISystem.Presenters;
using UnityEngine;

namespace UISystem.Common
{
    public class UIActionBar : GUICollection<ButtonPresenterBase>, IDisplayable
    {
       [SerializeField]
        string _id;
        public string Id
        {
            get
            {
                return _id;
            }
        }
                   

        public void Close()
        {
            
        }

        public void Open()
        {
           
        }
    }
}
