using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers.CameraControllers
{
    
    public class ObstacleAvoider
    {
        private Vector3 _cameraObstacleCheckOffset = new Vector3(0f, 1f, 0f);
        private GameObject _camera;
        private Transform _target;
        private Color _currentObstacleColor;
        private MeshRenderer _currentObstacleRenderer;
        private bool _transIsRun = false;
        private List<MeshRenderer> _obstacles = new List<MeshRenderer>();
        public ObstacleAvoider(GameObject cameraObj, Transform target)
        {
            _camera = cameraObj;
            _target = target;
        }
        public void MakeObstacleTransparent(float checkFrequency = 1)
        {
            Debug.DrawLine(_camera.transform.position, _target.transform.position + _cameraObstacleCheckOffset);
            LayerMask mask = LayerMask.GetMask("Ground");
            if (Time.frameCount % checkFrequency == 0)
            {
                if (Physics.Linecast(_camera.transform.position, _target.transform.position + _cameraObstacleCheckOffset, out RaycastHit info, mask, QueryTriggerInteraction.Ignore))
                {
                    _obstacles.Add(info.transform.GetComponent<MeshRenderer>());
                    _currentObstacleRenderer = info.transform.GetComponentInParent<MeshRenderer>();
                    _currentObstacleColor = _currentObstacleRenderer.material.color;
                    if (!_transIsRun)
                        RootController.Instance.RunCoroutine(MakeColorTransparent(_currentObstacleRenderer.material));
                }
                else
                {
                    if (_currentObstacleRenderer != null)
                    {
                        RootController.Instance.StopMyCoroutine(MakeColorTransparent(_currentObstacleRenderer.material));
                        _currentObstacleColor.a = 1f;
                        _currentObstacleRenderer.material.color = _currentObstacleColor;
                        _currentObstacleRenderer = null;
                    }
                }
            }
        }

        private IEnumerator MakeColorTransparent(Material material)
        {
            _transIsRun = true;
            while (material.color.a >= 0.2f&& _currentObstacleRenderer!=null)
            {
                _currentObstacleColor.a -= 0.1f;
                material.color = _currentObstacleColor;
                yield return new WaitForSeconds(0.1f);
            }
            _transIsRun = false;
        }
    }

}
                        
              
                   
                   



                 

               

