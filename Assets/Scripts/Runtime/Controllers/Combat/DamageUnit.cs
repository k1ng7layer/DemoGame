using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.Controllers.Combat
{
    public struct DamageUnit
    {
        public DamageType DamageType { get; private set; }
        public float DamagePoints { get; private set; }
        public float DamageMultiplier { get; private set; }

        public DamageUnit(DamageType damageType, float damagePoints, float multiplier)
        {
            DamageType = damageType;
            DamagePoints = damagePoints;
            DamageMultiplier = multiplier;
        }

    }
}
