using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerTeleport : MonoBehaviour
{
    // Start is called before the first frame update
     public float speed = 5f;
     private Vector2 _input;
     private float _distanceToplayer;
     public Transform GameCamera;
     [SerializeField] private Transform target;
     [SerializeField] private Vector3 offset;
     [SerializeField] private Vector3 minValue,maxValue;
    //  [SerializeField] private MouseSensitivity mouseSensitivity;
    //  private CameraRotation _cameraRotation;
    //  [SerializeField] private CameraAngle cameraAngle;

    private void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
  
    // private void Awake() => _distanceToplayer  =Vector3.Distance(transform.position,target.position);
    //  public void Look(InputAction.CallbackContext context)
    // {
    //     _input = context.ReadValue<Vector2>();
    // }
    private void Update()
     {
        var CharacterRotation = GameCamera.transform.rotation;
        CharacterRotation.x = 0;
        CharacterRotation.y = 0;

        transform.rotation = CharacterRotation;
        
    //    _cameraRotation.Yaw += _input.x * mouseSensitivity.horizontal * Time.deltaTime;
    //    _cameraRotation.Pitch += _input.y * mouseSensitivity.vertical * Time.deltaTime;
    //    _cameraRotation.Pitch = Mathf.Clamp(_cameraRotation.Pitch,cameraAngle.min,cameraAngle.max);
    }

    private void LateUpdate() {
        // transform.eulerAngles = new Vector3(_cameraRotation.Pitch,_cameraRotation.Yaw,0f);
        // transform.position = target.position - transform.forward * _distanceToplayer;
     UpdateCamPos();
    }
    private void UpdateCamPos()
    {
           Vector3 desiredPos = target.TransformPoint(offset);

        Vector3 clampPosition = new Vector3(
            Mathf.Clamp(desiredPos.x,minValue.x,maxValue.x),
            Mathf.Clamp(desiredPos.y,minValue.y,maxValue.y),
            Mathf.Clamp(desiredPos.z,minValue.z,maxValue.z)
        );

        Vector3 smoothPos = Vector3.Lerp(
            transform.position, clampPosition, speed * Time.deltaTime
        );
        transform.position = smoothPos;
        transform.LookAt(target);
    }
   

  
}
// [Serializable]
// public struct MouseSensitivity
// {
//     public float horizontal;
//     public float vertical;
// }

// public struct CameraRotation
// {
//     public float Pitch;
//     public float Yaw;
// }
// [Serializable]
// public struct CameraAngle
// {
//     public float min;
//     public float max;
// }

