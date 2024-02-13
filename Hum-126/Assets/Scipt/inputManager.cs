using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

 public class InputManager : MonoBehaviour
    {

        private PlayerController playerController;

        private PlayerLook look;
        
         private PlayerInput PlayerInput;
         private PlayerInput.OnFootActions onFoot ;

        public Vector2 Move{get;private set;}
        public Vector2 Look{get;private set;}

        private InputActionMap _currentMap;

        private InputAction _moveAction;

        private InputAction _lookAction;

         void Awake() {
            // _currentMap = PlayerInput.currentActionMap;
            // _moveAction = _currentMap.FindAction("Move");
            // _lookAction = _currentMap.FindAction("Look");

            // _moveAction.performed += onMove;
            // _lookAction.performed += onLook;


            // _moveAction.canceled += onMove;
            // _lookAction.canceled += onLook;
            PlayerInput = new PlayerInput();
            onFoot = PlayerInput.OnFoot;
            playerController = GetComponent<PlayerController>();
            look = GetComponent<PlayerLook>();
            onFoot.Jump.performed += ctx => playerController.Jump();
        }

         void FixedUpdate() {
            playerController.ProcessMove(onFoot.Move.ReadValue<Vector2>());
        }

       private void LateUpdate() {
        look.ProocessLook(onFoot.Look.ReadValue<Vector2>());
       }
       

        private void OnEnable() {
            onFoot.Enable();
        }
        private void OnDisable() {
            onFoot.Disable();
        }

     
    }

