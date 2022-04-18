using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.Controllers.Combat
{
    public abstract class CombatManager
    {
        public abstract event Action<int> OnAttack;
        public abstract void TryToPerformAttack();
    }
}
