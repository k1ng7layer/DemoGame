using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UISystem.Actions
{
    public class GameAction: GameActionBase
    {
        private event Action callback;
        public string Id { get; set; }
        public void AddListener(Action handler)
        {
            callback += handler;
        }

        public void RemoveListener(Action handler)
        {
            callback -= handler;
        }

        public void Dispatch()
        {
            callback?.Invoke();
        }

    }

    public class GameAction<T>: GameActionBase
    {
        private event Action<T> callback;
        public string Id { get; set; }
        public void AddListener(Action<T> handler)
        {
            callback += handler;
        }

        public void RemoveListener(Action<T> handler)
        {
            callback -= handler;
        }

        public void Dispatch(T arg)
        {
            callback?.Invoke(arg);
        }

    }

}
