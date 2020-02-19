
using UnityEngine;

public class ItemDrop : Interactable {


    public Item item;

    public override void Interact()
    {
        base.Interact();

        Drop();
    }

    void Drop()
    {
        Debug.Log("dropping " + item.name);
        bool wasDropped = Inventory.instance.Remove(item);

        if (wasDropped)
            Instantiate(gameObject);
    }


}
