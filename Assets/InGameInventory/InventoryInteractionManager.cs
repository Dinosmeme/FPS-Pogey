using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInteractionManager : MonoBehaviour
{
    //[Header("Inventory Itemslot Keys")]
    //[SerializeField] private KeyCode showInventory = KeyCode.E;
    //[SerializeField] private KeyCode itemSlot_1 = KeyCode.Alpha1;
    //[SerializeField] private KeyCode itemSlot_2 = KeyCode.Alpha2;
    //[SerializeField] private KeyCode itemSlot_3 = KeyCode.Alpha3;
    //[SerializeField] private KeyCode itemSlot_4 = KeyCode.Alpha4;    // Subject to change - number of itemslots (First assumption - 5)
    //[SerializeField] private KeyCode itemSlot_5 = KeyCode.Alpha5;
    //[SerializeField] private KeyCode itemSlot_6 = KeyCode.Alpha6;
    //[SerializeField] private KeyCode itemSlot_7 = KeyCode.Alpha7;
    //[SerializeField] private KeyCode itemSlot_8 = KeyCode.Alpha8;

    public static Action<int> onSelectedSlotChange;

    void Start()
    {
        InventorySystem.onInventoryChangedEvent += OnInventoryUpdate;
    }

    private void OnInventoryUpdate()
    {
        // We need to handle Interaction Cursos visibility and availability when inventory updates
        // Edge cases: Inventory becomes empty
    }

    private void Update()
    {
        if (Input.inputString != null) {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < InventorySystem.instance.inventory.Count + 1) {
                InvetorySlot slot = InventoryManager.instance.instanciatedSlots[number - 1].gameObject.GetComponent<InvetorySlot>();
                slot.ChangeColor(number); 
            }
        }
    }

}
