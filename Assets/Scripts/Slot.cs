using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public Image icon;
    public string keypress;
    public bool active;

    Item itemX;

    private void Start()
    {
        itemX = Item.itemInstance;
    }

    public void AddItem(Item newItem)
    {
        itemX = newItem;

        icon.sprite = itemX.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        itemX = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void OnRemove()
    {
        Inventory.instance.Remove(itemX);
    }


    public void SlotUseItem()
    {
        if (itemX != null)
            itemX.UseItem();
    }

    public void SlotDropItem()
    {
        if (itemX != null)
        {
            itemX.DropItem();
            ClearSlot();
        }

    }

    public void SetSlotActive()
    {
        gameObject.GetComponent<Image>().color = Color.red;

        if (itemX != null)
            itemX.SetItemActive();

        active = true;

    }

    public void SetSlotUnactive()
    {
        gameObject.GetComponent<Image>().color = new Color32(255,255,255,100);

        if(itemX != null)
        itemX.SetItemUnactive();

        active = false;
    }

}
