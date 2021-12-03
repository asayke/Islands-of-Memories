using System;
using UnityEngine;

public class SelectHandler : MonoBehaviour
{
    [SerializeField] private GameObject _prompts;
    [SerializeField] private UIInventory _inventory;
    private void Update()
    {
        //Часть для вызова подсказки на забор предмета.
        var ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit,4f))
        {
            if (hit.transform.CompareTag("Selectable"))
            {
                _prompts.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    var dropItem = hit.transform.GetComponent<DropItem>();
                    _inventory.Inventory.TryToAdd(new Item(dropItem.ItemInfo));
                    var parent = hit.transform.parent;
                    if (parent != null)
                        Destroy(parent.gameObject);
                    Destroy(hit.transform.gameObject);
                }
            }
            else _prompts.SetActive(false);
        } else _prompts.SetActive(false);
        
        
    }
}