using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Interfaces;

namespace Assets.Scripts.Runtime.GameActions
{
    public class ActionContainer
    {
        private static Dictionary<Type, IGameAction> Actions = new Dictionary<Type, IGameAction>();

        public static void AddAction<SType>() where SType : IGameAction, new()
        {

            IGameAction type = new SType();
            Type actionType = typeof(SType);
            Actions.Add(actionType, type);
        }

        public static SType ResolveAction<SType>() where SType : IGameAction
        {
            Type actionType = typeof(SType);
            IGameAction result;
            if (Actions.TryGetValue(actionType, out result))
            {
                return (SType)result;
            }
            return default;
        }
    }
}
