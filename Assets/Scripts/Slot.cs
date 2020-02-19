using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public Image icon;
    public string keypress;
    public bool active;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void OnRemove()
    {
        Inventory.instance.Remove(item);
    }


    public void SlotUseItem()
    {
        if (item != null)
            item.UseItem();
    }

    public void SlotDropItem()
    {
        if (item != null)
        {
            item.DropItem();
            ClearSlot();
        }

    }

    public void SetSlotActive()
    {
        gameObject.GetComponent<Image>().color = Color.red;

        if (item != null)
            item.SetItemActive();

        active = true;

    }

    public void SetSlotUnactive()
    {
        gameObject.GetComponent<Image>().color = new Color32(255,255,255,100);

        if(item != null)
        item.SetItemUnactive();

        active = false;
    }

}
