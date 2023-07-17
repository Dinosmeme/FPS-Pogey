using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] GameObject m_slotPrefab;

    public void Start()
    {
        InventorySystem.onInventoryChangedEvent += OnUpdateInventory;
    }

    private void OnUpdateInventory()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        DrawInventory();
    }


    public void DrawInventory()
    {
        foreach(InventorySystem.InventoryItem item in InventorySystem.instance.inventory)
        {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventorySystem.InventoryItem item)
    {
        GameObject obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(transform, false);

        InvetorySlot slot = obj.GetComponent<InvetorySlot>();
        slot.Set(item);

    }

}
