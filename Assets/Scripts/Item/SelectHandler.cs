using System;
using UnityEngine;

public class SelectHandler : MonoBehaviour
{
    [SerializeField] private GameObject _prompts;
    [SerializeField] private UIInventory _inventory;
    [SerializeField] private CampFire _campFire;
    private void Update()
    {
        //Часть для вызова подсказки на забор предмета.
        var ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit,5f))
        {
            if (hit.transform.CompareTag("Selectable"))
            {
                _prompts.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    var dropItem = hit.transform.GetComponent<DropItem>();
                    _inventory.Inventory.TryToAdd(new Item(dropItem.ItemInfo,1));
                    var parent = hit.transform.parent;
                    if (parent != null)
                        Destroy(parent.gameObject);
                    Destroy(hit.transform.gameObject);
                }
            }
            else if (hit.transform.CompareTag("CampFire"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                    _campFire.AddBranch();
            }
            else _prompts.SetActive(false);
        } else _prompts.SetActive(false);
    }
}