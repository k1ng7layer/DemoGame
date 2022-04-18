using Assets.Scripts.Runtime.Models.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.Controllers.Combat
{
    public class PlayerCombatManager : CombatManager
    {
        private CombatModel _combatModel;
        public override event Action<int> OnAttack;
        public PlayerCombatManager()
        {
            _combatModel = new MeleeCombaModel();
        }

        public override void TryToPerformAttack()
        {
            _combatModel.PerformAttack();
            OnAttack?.Invoke(1);
        }
    }
}
       

