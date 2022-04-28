using Assets.Scripts.Runtime.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Runtime.Models
{
    public abstract class TargetChaseModel
    {
     
       
        public abstract void ChaseTarget(Transform target, bool enable);


        public abstract void UpdateModel();
       

    }
}
