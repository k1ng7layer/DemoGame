using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.Interfaces
{
    public interface IStatRestorable
    {
        void InvokeRestoreHealth(float value, float time);
        void InvokeRstoreMana(float value, float time);
        void InvokeRestoreArmor(float value, float time);
    }
}
