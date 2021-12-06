using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    [SerializeField] private float _timeBurning;
    [SerializeField] private ValueBar _heathBar;
    private GameObject[] _branches;

    private UIInventory _uiInventory;
    private List<GameObject> _putsBranches = new List<GameObject>();
    private ParticleSystem _particle;
    private bool ableToAdd =>  _putsBranches.Count != _branches.Length;
    private float _timeBurningData;
    
    private void Awake()
    {
        _branches = GameObject.FindGameObjectsWithTag("branch");
        print(_branches.Length);
        _particle = GetComponentInChildren<ParticleSystem>();
        foreach (var x in _branches)
            x.SetActive(false);
        _particle.Stop();
        _timeBurningData = _timeBurning;
        _uiInventory = FindObjectOfType<UIInventory>();
    }

    private void Update()
    {
        if (_putsBranches.Count != 0)
        {
            _timeBurning -= 0.05f * Time.deltaTime;
            if (_timeBurning <= 0)
            {
                _timeBurning = _timeBurningData;
                DeleteBranch();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_particle.isPlaying)
        {
            _heathBar.DecreaseValue(0.05f);
        }
    }
    
    private void DeleteBranch()
    {
        _putsBranches.Last().SetActive(false);
        _putsBranches.Remove(_putsBranches.Last());
        if (_putsBranches.Count == 0)
            _particle.Stop();
    }
    
    public void AddBranch()
    {
        if (_uiInventory.Inventory.HasItemByType(Type.Branch))
        {
            if (ableToAdd)
            {
                var branch = _branches[_branches.Length - _putsBranches.Count - 1];
                branch.SetActive(true);
                _putsBranches.Add(branch);
                if (!_particle.isPaused)
                    _particle.Play();
            }
            _uiInventory.Inventory.Remove(Type.Branch);
            var children = GameObject.FindWithTag("MainCamera").gameObject.GetComponentsInChildren<Transform>();
            if (children.Length != 0)
            {
                for (int i = 0; i < children.Length; i++)
                {
                    if (children[i] != GameObject.FindWithTag("MainCamera").transform)
                        Destroy(children[i].gameObject);
                }
            }
        }
    }
}