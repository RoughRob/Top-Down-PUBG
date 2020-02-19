using UnityEngine;

public class Inventory_UI : MonoBehaviour {

    public Transform itemsParent;

    Inventory inventory;


   Slot[] slots;
    Slot activeSlot;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<Slot>();
        activeSlot = slots[0];
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("1"))
        {
            clearSelect();
            slots[0].SetSlotActive();
        }
        if (Input.GetKeyDown("2"))
        {
            clearSelect();
            slots[1].SetSlotActive();
        }
        if (Input.GetKeyDown("3"))
        {
            clearSelect();
            slots[2].SetSlotActive();
        }
        if (Input.GetKeyDown("4"))
        {
            clearSelect();
            slots[3].SetSlotActive();
        }
        if (Input.GetKeyDown("5"))
        {
            clearSelect();
            slots[4].SetSlotActive();
        }


        if (Input.GetKeyDown("c"))
        {
            foreach(Slot s in slots)
            {
                if (s.active == true)
                    s.SlotDropItem();
            }

        }

    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    void clearSelect()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetSlotUnactive();
        }
    }

    //void setActiveSlot(int slotNum)
    //{
    //    //for (int i = 0; i < slots.Length; i++)
    //    //{
    //    //    if(slots[i].active == true)
    //    //    slots[i] = activeSlot;
    //    //    Debug.Log("slot " + activeSlot.ToString() + " set as active slot");

    //        slots[slotNum].active = true;
    //    //}
    //}



}
