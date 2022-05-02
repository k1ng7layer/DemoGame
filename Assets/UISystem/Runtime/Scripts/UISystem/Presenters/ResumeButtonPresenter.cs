
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Actions;
using UISystem.Common;

namespace UISystem.Presenters
{
    public class ResumeButtonPresenter:ActionButtonPresenter
    {
        public override void Click()
        {
            base.Click();
            UIActionContainer.ResolveAction<SwitchUIStateAction>().Dispatch();
        }
    }
}
