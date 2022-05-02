
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
    public abstract class UIWindow:GUICollection<ButtonPresenterBase>,IDisplayable
    {
        [SerializeField]
        internal bool isVisibleOnStart;
        [SerializeField]
        string _id;
        public string Id
        {
            get
            {
                return _id;
            }
        }

        protected abstract void NavigationButtonClicked(NavigationButtonPresenter button);
        protected abstract void ActionButtonClicked(ActionButtonPresenter action);

        public virtual void Close()
        {
            this.gameObject.SetActive(false);

        }

        public virtual void Open()
        {
            this.gameObject.SetActive(true);
        }

       
    }
}
