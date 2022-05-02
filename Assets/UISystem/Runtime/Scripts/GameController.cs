using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Controllers;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController:MonoBehaviour
    {
        UIController UIController;
        //StateController State { get; set; }
        private void Awake()
        {
            UIController = FindObjectOfType<UIController>();
          
        }
        private void Start()
        {
            UIController.InitializeController();
        }

          
    }
}

        
