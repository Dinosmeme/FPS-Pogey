using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : Interactable
{
    public InventoryItemData referenceItem;

    public override void OnFocus()
    {
        print("Looking at" + gameObject.name);
    }

    public override void OnInteract()
    {
        print("Interacted with" + gameObject.name);
        InventorySystem.instance.Add(referenceItem);
        print($"Added {referenceItem.name}////");
        Destroy(gameObject);
    }

    public override void OnLoseFocus()
    {
        print("Stopped looking at" + gameObject.name);
    }
}
