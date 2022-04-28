using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AIBehaviour
{
    public class PatrolProfile:MonoBehaviour
    {
        [SerializeField] Transform[] _wayPoints;
        public Transform[] WayPoints => _wayPoints;
    }
}
