using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.Controllers.Combat
{
    public interface IHittable
    {
        void BeginTakeDamage(List<DamageUnit> damageUnits);
        
        void EndTakingDamage();
       
    }
}
