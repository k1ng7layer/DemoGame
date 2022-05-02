

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Actions;
using UISystem.Common;

namespace UISystem.Presenters
{
    public class SceneNavigationButtonPresenter : ButtonPresenterBase
    {
        public string targetScene;
        public override void Click()
        {
            UIActionContainer.ResolveAction<ChangeSceneAction>().Dispatch(targetScene);
        }
    }
}
