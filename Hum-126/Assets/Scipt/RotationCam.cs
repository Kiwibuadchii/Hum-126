using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCam : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
          transform.eulerAngles += Speed * new Vector3(-Input.GetAxis("Mouse Y"),Input.GetAxis("Mouse X"),0);
                 if (Input.GetKey(KeyCode.D))
        {
            target.transform.position -= new Vector3(Speed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            target.transform.position += new Vector3(Speed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            target.transform.position -= new Vector3(0f,0f, Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            target.transform.position += new Vector3(0f, 0f, Speed * Time.deltaTime);
        }

        }
        
    }
}
