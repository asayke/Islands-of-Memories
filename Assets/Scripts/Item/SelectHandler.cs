using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectHandler : MonoBehaviour
{
    [SerializeField] private GameObject _prompts;
    [SerializeField] private UIInventory _inventory;
    [SerializeField] private CampFire _campFire;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _player;
    private Collider[] _findedColliders = new Collider[50];
    [SerializeField] private GameObject _text;

    private void FixedUpdate()
    {
        var count = Physics.OverlapSphereNonAlloc(_player.position, 6f, _findedColliders, _layerMask);
        if (count > 0)
        {
            Collider nearlesObj = _findedColliders[0];
            _text.transform.position = new Vector3(nearlesObj.transform.position.x,nearlesObj.transform.position.y + 1f, nearlesObj.transform.position.z);
            _text.transform.DOScale(new Vector3(-1, 1, 1), 0.15f);
            if (Input.GetKeyDown(KeyCode.E))
            {
                var dropItem = nearlesObj.GetComponent<DropItem>();
                 _inventory.Inventory.TryToAdd(new Item(dropItem.ItemInfo,1));
                var parent = nearlesObj.transform.parent;
                if (parent != null)
                    Destroy(parent.gameObject);
                _text.transform.DOScale(new Vector3(0, 0, 0), 0.15f);
                Destroy(nearlesObj.transform.gameObject);
            }
        }
        else
        {
            _text.transform.DOScale(new Vector3(0, 0, 0), 0.15f); 
        }
    }


    // private void Update()
    // {
    //     //Часть для вызова подсказки на забор предмета.
    //     if (Physics.Raycast(ray, out var hit,5f))
    //     {
    //         if (hit.transform.CompareTag("Selectable"))
    //         {
    //             _prompts.SetActive(true);
    //             if (Input.GetKeyDown(KeyCode.E))
    //             {
    //                 var dropItem = hit.transform.GetComponent<DropItem>();
    //                 _inventory.Inventory.TryToAdd(new Item(dropItem.ItemInfo,1));
    //                 var parent = hit.transform.parent;
    //                 if (parent != null)
    //                     Destroy(parent.gameObject);
    //                 Destroy(hit.transform.gameObject);
    //             }
    //         }
    //         else if (hit.transform.CompareTag("CampFire"))
    //         {
    //             if (Input.GetKeyDown(KeyCode.E))
    //                 _campFire.AddBranch();
    //         }
    //         else _prompts.SetActive(false);
    //     } else _prompts.SetActive(false);
    // }
}