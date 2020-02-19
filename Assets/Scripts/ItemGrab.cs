
using UnityEngine;

public class ItemGrab : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if(wasPickedUp)
        Destroy(gameObject);
    }


}