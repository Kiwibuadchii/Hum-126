
using System;
using UnityEngine;
// using UnityTutorial.Manager;

using UnityEngine.InputSystem;
    public class PlayerController : MonoBehaviour
    {

        private CharacterController controller;
        private Vector3 playerVelocity;
        public float speed = 5f;
        private bool IsGrounded;
        public float Gravity = -9.8f;
        public float JumpHeight = 3f;

        private bool isRunning;

        [SerializeField] private Transform Camera;
        [SerializeField] private float UpperLimit = -40f;
        [SerializeField] private float BottomLimit = 70f;

        [SerializeField] private float MouseSensitivity = 21.9f;
        private Rigidbody _playerRigid;

        private Camera _maincamera;
        private CharacterController _characterController;

        private InputManager _inputManager;
      
        private bool _hasAnimator;
        private int _xVelHash;
        private int _yVelHash;
        private Vector2 _currentVelocity;

        private float _xRotation;
        Vector3 desiredDirection;

        private const float _Speed = 2f;
        public PlayerInput input;
        private Animator animator;
        

        private void Awake() {
            input = new PlayerInput();
            
        }

        void Start() {
            _hasAnimator = TryGetComponent<Animator>(out animator);
            // animator = GetComponent<Animator>();
            _playerRigid = GetComponent<Rigidbody>();
            _inputManager = GetComponent<InputManager>();

            _xVelHash = Animator.StringToHash("X_value");
            _yVelHash = Animator.StringToHash("Y_value");
            _characterController = GetComponent<CharacterController>();
        }



    private void Update() {
         IsGrounded = _characterController.isGrounded;
       }

        // private void LateUpdate() {
        //     CameraMovement();
        // }
        public void ProcessMove(Vector2 input)
        {
            Vector3 moveDirection = Vector3.zero;
            moveDirection.x = input.x;
            moveDirection.z = input.y;
            _characterController.Move(transform.TransformDirection(moveDirection)*speed*Time.deltaTime);
            playerVelocity.y += Gravity * Time.deltaTime;
            if(IsGrounded && playerVelocity.y<0)
                playerVelocity.y = -2;
            _characterController.Move(playerVelocity * Time.deltaTime);
            animator.SetFloat(_xVelHash,moveDirection.x);
            animator.SetFloat(_yVelHash,moveDirection.z);
            Debug.Log(playerVelocity.x);
        }
        public void Jump()
        {
            if(IsGrounded)
            {
                playerVelocity.y = Mathf.Sqrt(JumpHeight*-3.0f*Gravity);
            }
        }
      

  
          public void Teleport(Vector3 position, Quaternion rotation) {

         transform.position = position;
        Physics.SyncTransforms();
        
        

    }
  

    }

