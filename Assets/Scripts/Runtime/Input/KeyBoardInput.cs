using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime
{
    [CreateAssetMenu(fileName = "KeyBoardInput", menuName = "InputSystems/KeyBoardInput")]
    public class KeyBoardInput : InputTypeBase
    {
       

        private Vector3 movementVector;
        

        public override event Action<Vector3> OnMovement;
        public override event Action OnJump;
        public override event Action OnInventoryOpen;
        public override event Action OnAttack;

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                vertical = Input.GetAxisRaw("Vertical");
                horizontal = Input.GetAxisRaw("Horizontal");
                
                OnMovement?.Invoke(new Vector3(horizontal, 0f, vertical));
            }
            else
            {
                vertical = Input.GetAxisRaw("Vertical");
                horizontal = Input.GetAxisRaw("Horizontal");
                OnMovement?.Invoke(new Vector3(0f, 0f, 0f));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
                OnJump?.Invoke();
                //SceneGameManagerView.Instance.CurrentPlayer.playerInput.jump = true;
                Debug.Log($"jump button true");
            }
            else
            {
                jump = false;
                //SceneGameManagerView.Instance.CurrentPlayer.playerInput.jump = false;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                withdrawWeapon = true;
                //SceneGameManagerView.Instance.CurrentPlayer.playerInput.attack = true;
                Debug.Log($"jump button true");
            }
            else
            {
                withdrawWeapon = false;
                //SceneGameManagerView.Instance.CurrentPlayer.playerInput.attack = false;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                changeWeapon = true;
            }
            else
            {
                changeWeapon = false;
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                lockTarget = true;
                Debug.Log("seeking for target true");
            }
            else
            {
                lockTarget = false;
                Debug.Log("seeking for target false");
            }



            if (Input.GetMouseButtonDown(0))
            {
                attack = true;
                OnAttack?.Invoke();
            }
            else
            {
                attack = false;
            }






            if (Input.GetKeyDown(KeyCode.E))
            {
                use = true;
            }
            else
            {
                use = false;
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                OnInventoryOpen?.Invoke();
            }




        }

        private void Awake()
        {

        }



    }
}
