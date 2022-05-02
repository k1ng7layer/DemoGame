
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Actions;
using UISystem.Common;

namespace UISystem.Presenters
{
    public class DefaultMenuPresenter : UIWindow
    {
        //Течение игрвого времени
        public float timeScale;
        public override void Init()
        {
            base.Init();

            foreach (var btn in registeredObjects.Values)
            {
                if (btn.GetType().Equals(typeof(NavigationButtonPresenter)))
                {
                    btn.OnClick += NavigationButtonClicked;
                }

            }
            if (!isVisibleOnStart)
                Close();
        }
        public override void Open()
        {
            base.Open();
            UIActionContainer.ResolveAction<UIOpenAction>().Dispatch(timeScale);
        }
        protected override void ActionButtonClicked(ActionButtonPresenter action)
        {

        }

        protected override void NavigationButtonClicked(NavigationButtonPresenter button)
        {
            UIActionContainer.ResolveAction<OpenWindowAction>().Dispatch(button.Target);
        }
    }
}
