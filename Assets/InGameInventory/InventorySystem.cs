using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance;

    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; private set; }

    void Start()
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

    }

    public event Action onInventoryChangedEvent;

    private void Awake()
    {
        inventory = new List<InventoryItem>(); // This missed line stopped my progress for a week LMAO
        m_itemDictionary= new Dictionary<InventoryItemData, InventoryItem>();
    }

    [Serializable] 
    public class InventoryItem
    {
        public InventoryItemData data { get; private set; }
        public int stackSize { get; private set; }

        public InventoryItem(InventoryItemData source)
        {
            data = source;
            AddToStack();
        }

        public void AddToStack()
        {
            stackSize++;
        }

        public void RemoveFromStack()
        {
            stackSize--;
        }
    }

    public void Add(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)) 
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }
        onInventoryChangedEvent?.Invoke();
    }

    public void Remove(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)) 
        {
            value.RemoveFromStack();

            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }
}
