using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
public class ItemTaker : MonoBehaviour
{

    [SerializeField] private int _range;
    private void Update()
    {
        // if (Input.GetKey(KeyCode.E))
        // {
        //     var directionRay = transform.TransformDirection(Vector3.forward);
        //     if (Physics.Raycast(transform.position, directionRay, out var hit, _range))
        //     {
        //         Debug.DrawLine(transform.position, hit.point, Color.green);
        //         if (hit.collider.gameObject.CompareTag("Use"))
        //             Destroy(hit.collider.gameObject);
        //     }
        // }
    }
}


