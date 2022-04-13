using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Runtime.Configs.InventoryConfig
{
    public class WeaponTransformData
    {
        public Vector3 DefaultPosition { get; private set; }
        public Vector3 ArmedPosition { get; private set; }
        public Vector3 DefaultRotation { get; private set; }
        public Vector3 ArmedRotation { get; private set; }
        public Vector3 DefaultScale { get; private set; }
        public Vector3 ArmedScale { get; private set; }
        public WeaponTransformData(Vector3 defaultPosition, Vector3 armedPosition, Vector3 defaultRotation, Vector3 armedRotation, Vector3 defaultScale, Vector3 armedScale)
        {
            DefaultPosition = defaultPosition;
            ArmedPosition = armedPosition;
            DefaultRotation = defaultRotation;
            ArmedRotation = armedRotation;
            DefaultScale = defaultScale;
            ArmedScale = armedScale;
        }
    }
}

