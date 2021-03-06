using Assets.Scripts.Runtime.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Interfaces
{
    public interface IUsable
    {
        void Use();
        void Use(Transform user);
        void Use(IStatRestorable user);
    }
}
