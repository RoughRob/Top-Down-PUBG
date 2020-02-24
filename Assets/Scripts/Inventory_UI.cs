using UnityEngine;

public class Inventory_UI : MonoBehaviour {

    public Transform itemsParent;

    Inventory inventory;


   public static Slot[] slots;
    public static Slot activeSlot;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        //slots[0].active = true;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<Slot>();
        slots[0].SetSlotActive();
        activeSlot = slots[0];

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("1"))
        {


            slots[0].SetSlotActive();
            activeSlot = slots[0];
            clearSelect(0);
        }
        if (Input.GetKeyDown("2"))
        {
            slots[1].SetSlotActive();
            activeSlot = slots[1];
            clearSelect(1);
        }
        if (Input.GetKeyDown("3"))
        {

            slots[2].SetSlotActive();
            activeSlot = slots[2];
            clearSelect(2);
        }
        if (Input.GetKeyDown("4"))
        {
            slots[3].SetSlotActive();
            activeSlot = slots[3];
            clearSelect(3);
        }
        if (Input.GetKeyDown("5"))
        {

            slots[4].SetSlotActive();
            activeSlot = slots[4];
            clearSelect(4);
        }


        if (Input.GetKeyDown("c"))
        {
            //foreach(Slot s in slots)
            //{
            //    if (s.active == true)
            //        s.SlotDropItem();
            //}

            activeSlot.SlotDropItem();

        }

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    activeSlot.SlotUseItem();
        //}

    }

    void UpdateUI()
    {
        for(int i = 0; i < inventory.items.Length; i++)
        {
            //if(i < inventory.items.Length)
            if (inventory.items[i] != null)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    void clearSelect(int skip)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i != skip)
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
