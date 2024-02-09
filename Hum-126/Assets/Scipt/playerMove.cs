
using System;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    public float speed = 5f;
  
    public void Teleport(Vector3 position, Quaternion rotation) {

        transform.position = position;
        Physics.SyncTransforms();
        
        

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position -= new Vector3(0f,0f, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
        }
    }
}
