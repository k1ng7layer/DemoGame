
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Interfaces;
using UnityEngine;

namespace UISystem.Presenters
{
    public abstract class ButtonPresenterBase:MonoBehaviour, IDisplayable
    {
        [SerializeField]
        string _id;
        public virtual string Id
        {
            get
            {
                return _id;
            }
        }
        public virtual event Action<NavigationButtonPresenter> OnClick;
        public abstract void Click();

        public void Close()
        {
            
        }

        public void Open()
        {
            
        }
    }
}
