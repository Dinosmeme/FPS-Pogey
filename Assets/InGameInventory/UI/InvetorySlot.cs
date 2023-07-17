using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvetorySlot : MonoBehaviour
{
    [SerializeField] private Image m_icon;

    [SerializeField] private Image m_slotSelectImage;
    [SerializeField] private Color selectedColor, notSelectedColor;

    [SerializeField] public TextMeshProUGUI m_label;

    [SerializeField] GameObject m_stackObj;

    [SerializeField] TextMeshProUGUI m_stackLabel;

    private int slotID;
    private int askedID;

    private void Start()
    {
        InventoryInteractionManager.onSelectedSlotChange += SelectedSlotChange;
    }

    public void Set(InventorySystem.InventoryItem item) // TODO: remove InventoryItem Class from InventorySystem (if possible)
    {
        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;
        if (item.stackSize <= 1)
        {
            m_stackObj.SetActive(false);
            return;
        }

        m_stackLabel.text = item.stackSize.ToString();

    }

    public void SetSlotID(int ID)
    {
        slotID = ID;
    }

    private void SelectedSlotChange(int ID)
    {
        ChangeColor(askedID);
    }

    public void ChangeColor(int ID)
    {
        if (slotID == ID) {
            m_slotSelectImage.color = selectedColor;
        }
        else
        {
            m_slotSelectImage.color = notSelectedColor;
        }
    }
}
