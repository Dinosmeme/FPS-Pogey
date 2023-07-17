using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvetorySlot : MonoBehaviour
{
    [SerializeField] private Image m_icon;

    [SerializeField] TextMeshProUGUI m_label;

    [SerializeField] GameObject m_stackObj;

    [SerializeField] TextMeshProUGUI m_stackLabel;


    public void Set(InventorySystem.InventoryItem item) // TODO: remove InventoryItem Class from InventorySystem (if possible)
    {
        print(item.data.displayName);
        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;
        if (item.stackSize <= 1)
        {
            m_stackObj.SetActive(false);
            return;
        }

        m_stackLabel.text = item.stackSize.ToString();

    }
    
}
