
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject gameobject;
    public bool isDefaultItem = false;
    public bool Active = false;



    public virtual void UseItem()
    {
        Debug.Log("Using" + name);
    }

    public void DropItem()
    {
        Inventory.instance.Remove(this);
    }

    public void RemoveItemFromInventory()
    {
        Inventory.instance.Remove(this);
    }

    public void SetItemActive()
    {
        Active = true;
    }

    public void SetItemUnactive()
    {
        Active = false;
    }
}
