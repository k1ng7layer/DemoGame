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
        [SerializeField] private int _direction;
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private bool _enableRotation;
        private void Update()
        {

            //if (_direction == 0)
            //{
            //    this.transform.Rotate(Vector3.up * 5f, Time.deltaTime * 30f, Space.Self);
            //    float newY = Mathf.Sin(Time.time * _frequency);
            //    transform.Translate(0f, (newY * Time.deltaTime) * _height, 0f);
            //}
            //else if (_direction == 1)
            //{
            //    //this.transform.Rotate(Vector3.up * 5f, Time.deltaTime * 30f, Space.Self);
            //    float newY = Mathf.Sin(Time.time * _frequency);
            //    transform.Translate((newY * Time.deltaTime) * _height, 0f, 0f);
            //}
            //else if (_direction == 2)
            //{
            //    this.transform.Rotate(Vector3.up * 5f, Time.deltaTime * 30f, Space.Self);
            //    float newY = Mathf.Sin(Time.time * _frequency);
            //    transform.Translate(0f, 0f, (newY * Time.deltaTime) * _height);
            //}

        }
        private void FixedUpdate()
        {
            //if (_direction == 0)
            //{
            //    this.transform.Rotate(Vector3.up * 5f, Time.fixedDeltaTime * 30f, Space.Self);
            //    float newY = Mathf.Sin(Time.time * _frequency);
            //    transform.Translate(0f, (newY * Time.fixedDeltaTime) * _height, 0f);
            //}
            //else if (_direction == 1)
            //{
            //    //this.transform.Rotate(Vector3.up * 5f, Time.deltaTime * 30f, Space.Self);
            //    float newY = Mathf.Sin(Time.time * _frequency);
            //    transform.Translate((newY * Time.fixedDeltaTime) * _height, 0f, 0f);
            //}
            //else if (_direction == 2)
            //{
            //    this.transform.Rotate(Vector3.up * 5f, Time.fixedDeltaTime * 30f, Space.Self);
            //    float newY = Mathf.Sin(Time.time * _frequency);
            //    transform.Translate(0f, 0f, (newY * Time.fixedDeltaTime) * _height);
            //}



            if (_direction == 0)
            {
                if (_enableRotation)
                    this.transform.Rotate(Vector3.up * 5f, Time.fixedDeltaTime * 30f, Space.Self);

                float newY = Mathf.Sin(Time.time * _frequency);
                transform.Translate(0f, (newY * Time.fixedDeltaTime) * _height, 0f);
            }
            else if (_direction == 1)
            {
                if(_enableRotation)
                    this.transform.Rotate(Vector3.up * 5f, Time.deltaTime * 30f, Space.Self);

                float newY = Mathf.Sin(Time.time * _frequency);
                transform.Translate((newY * Time.fixedDeltaTime) * _height, 0f, 0f);
                Vector3 pos = new Vector3((newY * Time.fixedDeltaTime) * _height, 0f, 0f);
                //_rb.MovePosition(transform.position + pos * Time.fixedDeltaTime);
            }
            else if (_direction == 2)
            {
                if (_enableRotation)
                    this.transform.Rotate(Vector3.up * 5f, Time.deltaTime * 30f, Space.Self);

                float newY = Mathf.Sin(Time.time * _frequency);
                transform.Translate(0f, 0f, (newY * Time.deltaTime) * _height);
            }
        }
    }
}
