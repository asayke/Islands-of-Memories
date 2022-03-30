using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Combat : MonoBehaviour
{
    [SerializeField] private LayerMask _trees;
    private readonly Collider[] _colliders = new Collider[30];

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var count = Physics.OverlapSphereNonAlloc(transform.position, 1f, _colliders, _trees);
            for (int i = 0; i < count; i++)
            {
                print(count);
                var tree = _colliders[i].GetComponent<Tree>();
                tree.Damage(0.1f);
            }
        }
    }
}