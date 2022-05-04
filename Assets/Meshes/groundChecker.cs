using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundChecker : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _playerCollider;
    [SerializeField] private LayerMask layerMask;
    private static groundChecker _groundChecker;
    public bool IsGrounded;
    public static groundChecker Instance
    {
        get
        {
            if (_groundChecker == null)
            {
                _groundChecker = FindObjectOfType<groundChecker>();
            }
            return _groundChecker;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    public  bool GroundCheck()
    {

        if (Physics.CheckSphere(new Vector3(_rb.transform.position.x, _playerCollider.bounds.center.y - _playerCollider.bounds.size.y / 2, _rb.transform.position.z), 0.01f, layerMask))
        {

            IsGrounded = true;
            return true;
        }
        else
        {

            IsGrounded = false;
            return false;
        }

    }
}
