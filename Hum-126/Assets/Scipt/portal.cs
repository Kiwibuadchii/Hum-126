using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    [SerializeField] Transform _destination;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")&&other.TryGetComponent<playerMove>(out var player))
        {
            player.Teleport(_destination.position,_destination.rotation);
        }
    }

     void OnDrawGizmos() {

        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(_destination.position,.4f);
        var dirrection = _destination.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(_destination.position,dirrection);
        
    }
}
