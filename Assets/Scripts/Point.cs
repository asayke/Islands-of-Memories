using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private Color _color = Color.red;
    [SerializeField] private float GIZMO_RANGE = 0.25f;
    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        //Gizmos.DrawCube(transform.position, new Vector3(GIZMO_RANGE, GIZMO_RANGE, GIZMO_RANGE));
        Gizmos.DrawSphere(transform.position, GIZMO_RANGE);
    }
}
