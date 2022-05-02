
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Actions;

namespace UISystem.Common
{
    //Конфигурация событий
    public class UIActionConfigurator
    {
        public void Configure()
        {
            UIActionContainer.AddAction<ButtonClickAction>();
            UIActionContainer.AddAction<OpenWindowAction>();
            UIActionContainer.AddAction<GamePauseAction>();
            UIActionContainer.AddAction<ApplySettingsAction>();
            UIActionContainer.AddAction<BackToMainAction>();
            UIActionContainer.AddAction<InputPauseAction>();
            UIActionContainer.AddAction<ChangeSceneAction>();
            UIActionContainer.AddAction<UIOpenAction>();
            UIActionContainer.AddAction<UICloseAction>();
            UIActionContainer.AddAction<SwitchUIStateAction>();
        }
    }
}
