using Assets.Scripts.Runtime.Controllers.Animation;
using Assets.Scripts.Runtime.GameActions;
using Assets.Scripts.Runtime.Interfaces;
using Assets.Scripts.Runtime.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Common;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views.ItemsViews
{
    [RequireComponent(typeof(Animator))]
    public class ChestView : MonoBehaviour, IUsable
    {
        [SerializeField] private InventoryDTO _inventoryDataObject;
        private List<InventoryItem> _inventoryItems;
        private LootRepository _lootRepository;
        private ChestAnimationEventManager _eventManager;
        private Transform _currentUser;
        [Header("Camera Offset params")]
        [SerializeField] float _x_angle;
        [SerializeField] float _y_angle;
        [SerializeField] float _z_angle;
        [SerializeField] Vector3 _offset;
        [SerializeField] private GameObject _cameraSpot;



        private Animator _animator;
        private bool _isOpen;
        private void Awake()
        {
            _eventManager = this.GetComponent<ChestAnimationEventManager>();
            _eventManager.OnChestOpenedAction += OpenLootWindow;
        }
        private void OnDisable()
        {
            _eventManager.OnChestOpenedAction -= OpenLootWindow;
        }
        private void Start()
        {
            if (TryGetComponent<Animator>(out Animator animator))
            {
                _animator = animator;
            }
            else
            {
                _animator = gameObject.AddComponent<Animator>();
            }
            if(_inventoryDataObject!=null)
                _lootRepository = new LootRepository(_inventoryDataObject);
            else
            {
                throw new ArgumentNullException("_inventoryDataObject","InventoryDTO cannot be null! Use empty InventoryDTO instead");
            }
        }

        public void Use()
        {
            
        }

        private void Open()
        {
            var args = new ChangeCameraTargetEventArgs(_cameraSpot.transform, new Vector3(_x_angle,_y_angle,_z_angle), _offset);
            ActionContainer.ResolveAction<ChangeCameraTargetAction>().Dispatch(args);
            _animator.SetBool("Open", true);
            _isOpen = true;
        }

        private void Close()
        {
            var args = new ChangeCameraTargetEventArgs(_currentUser, true);
            UIActionContainer.ResolveAction<CloseLootWindowAction>().Dispatch();
            ActionContainer.ResolveAction<ChangeCameraTargetAction>().Dispatch(args);
            _animator.SetBool("Open", false);
            _isOpen = false;
        }

        private void OpenLootWindow()
        {
            UIActionContainer.ResolveAction<OpenLootWindowAction>().Dispatch(new OpenLootWindowEventArgs(_lootRepository, _inventoryItems));
        }
        public void Use(IStatRestorable user)
        {
            
        }

        public void Use(Transform user)
        {
            _currentUser = user;
            if (_isOpen)
                Close();
            else
                Open();
        }
    }
}
           
