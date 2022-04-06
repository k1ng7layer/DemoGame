using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views
{
    [Serializable]
    public class CameraView : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] float _x_angle;
        [SerializeField] float _y_angle;
        [SerializeField] float _z_angle;
        [SerializeField] Vector3 _offset;

        public float Speed { get => _speed; }
        public float X_Angle { get => _x_angle; }
        public float Y_Angle { get => _y_angle; }
        public float Z_Angle { get => _z_angle; }
        public Vector3 Offset { get => _offset; }
    }
}