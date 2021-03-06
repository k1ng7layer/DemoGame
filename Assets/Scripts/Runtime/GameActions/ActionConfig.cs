using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Actions;
using UISystem.Common;

namespace Assets.Scripts.Runtime.GameActions
{
    public static class ActionConfig
    {
        private static bool _isConfigured;
        public static void ConfigureActions()
        {
            if (!_isConfigured)
            {
                ActionContainer.AddAction<EnemySpawnAction>();
                ActionContainer.AddAction<OpenPlayerInventoryAction>();
                ActionContainer.AddAction<ChangeCameraTargetAction>();
                UIActionContainer.AddAction<DisplayInventoryItemsAction>();
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
                UIActionContainer.AddAction<OpenLootWindowAction>();
                UIActionContainer.AddAction<CloseLootWindowAction>();
                UIActionContainer.AddAction<DisplayLootItemsAction>();
                UIActionContainer.AddAction<SwapInventoryItemsAction>();
                UIActionContainer.AddAction<ItemEquipAction>();
                UIActionContainer.AddAction<ItemEquipRequestAction>();
                UIActionContainer.AddAction<DisplayItemDescriptionAction>();
                UIActionContainer.AddAction<ItemDescriptonRequestAction>();
                UIActionContainer.AddAction<HideEquipedItemAction>();
                UIActionContainer.AddAction<ItemAddInInventoryRequestAction>();
            }
            _isConfigured = true;
        }
    }
}

                
                


