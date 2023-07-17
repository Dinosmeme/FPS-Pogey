using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    [SerializeField] GameObject m_slotPrefab;
    [SerializeField] GameObject m_EmptyInventoryText;

    public List<InvetorySlot> instanciatedSlots { get; private set; }

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        InventorySystem.onInventoryChangedEvent += OnUpdateInventory;
    }

    private void Awake()
    {
        instanciatedSlots = new List<InvetorySlot>();
    }

    private void OnUpdateInventory()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        instanciatedSlots.Clear();
        DrawInventory();
    }


    public void DrawInventory()
    {
        //if (InventorySystem.instance.inventory == null)
        //{
        //    m_EmptyInventoryText.gameObject.SetActive(true);     // Will Break Inventory because we have to Instanciate destroyed Object (Prefab to be created) 
        //}

        foreach (InventorySystem.InventoryItem item in InventorySystem.instance.inventory)
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
        instanciatedSlots.Add(slot);
        slot.SetSlotID(instanciatedSlots.Count);

    }

}
