
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Actions;
using UISystem.Common;
using UnityEngine;

namespace UISystem.Presenters
{
    public class PauseMenuWindow : DefaultMenuPresenter
    {





        protected override void ActionButtonClicked(ActionButtonPresenter action)
        {
            UIActionContainer.ResolveAction<ButtonClickAction>().Dispatch();
        }

        protected override void NavigationButtonClicked(NavigationButtonPresenter buttonPresenter)
        {
            Debug.Log("Clicccked");
            UIActionContainer.ResolveAction<OpenWindowAction>().Dispatch(buttonPresenter.Target);
        }
            
        public override void Init()
        {
            base.Init();
            var buttons = base.GetAllObjects();
            foreach (var btn in buttons)
            {
                btn.OnClick += NavigationButtonClicked;
            }
            
        }

     
    }
}
           
            


