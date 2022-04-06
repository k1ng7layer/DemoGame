using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime
{
    public interface IController
    {
        void InitializeController();
        void OnUpdateController();
        void OnFixedUpdateController();
        void OnDestroyController();
        void OnDisableController();
        void OnLateUpdateController();
    }
}
