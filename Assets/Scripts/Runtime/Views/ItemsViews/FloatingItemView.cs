using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views
{
    public class FloatingItemView:MonoBehaviour
    {
        [Header("Float settings")]
        [SerializeField] private float _frequency = 2f;
        [SerializeField] private float _height = 0.2f;
        private void Update()
        {
            this.transform.Rotate(Vector3.up * 5f, Time.deltaTime * 30f, Space.Self);
            float newY = Mathf.Sin(Time.time * _frequency);
            transform.Translate(0f, (newY * Time.deltaTime) * _height, 0f);
        }
    }
}
