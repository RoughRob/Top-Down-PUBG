using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory instance;
    public Transform drop;

    public Transform heldTransform;
    public GameObject heldItem;

    #region Singleton
    public void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more that one inventory instance");
            return;
        }

        instance = this;

    }
    #endregion

    public int space = 5;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;


    public Item Item0 = null;
    public Item Item1 = null;
    public Item Item2 = null;
    public Item Item3 = null;
    public Item Item4 = null;

    public Item[] items; //Item0, instance.Item1, instance.Item2, instance.Item3, instance.Item4 };

    Item itemX;

    private void Start()
    {
        itemX = Item.itemInstance;
        items = new Item[5];
        //for (int i = 0; i < 5; i++)
        //{
        //    Debug.Log(items.Length.ToString());
        //    items[i] = null;//ScriptableObject.CreateInstance("Item") as Item;
        //}
    }

    public bool Add(Item itemX)
    {

        if (!itemX.isDefaultItem)
        {

            //if (items.Length >= space)
            //{
            //    Debug.Log("not enough space");
            //    return false;
            //}

            Debug.Log("in add " + items.Length.ToString() + " " + items.ToString());
            if (checkfull() && Inventory_UI.activeSlot.active == true)
            {
                Replace(itemX);
            }
            else if(checkfull() && Inventory_UI.activeSlot.active == false)
            {

            }
            else
            {

                for (int i = 0; i < items.Length; i++)
                {
                    //items.Add(item);
                    Debug.Log("attemped to add");
                    if (items[i] == null)
                    {
                        items[i] = itemX;
                        Debug.Log("Item added to inventory " + items[i].name);
                        break;
                    }
                }
            }


            if(onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
        }

        return true;
    }

    public bool Remove(Item itemX)
    {
        if (itemX == null)
            return false;

        Instantiate(itemX.gameobject, drop.position, drop.rotation);


        for (int i = 0; i < items.Length; i++)
        {
            //items.Add(item);
            if (items[i] != null && Inventory_UI.slots[i].active) //    items[i].Active == true
            {
                items[i] = null;
            }
        }
        //items.Remove(item);
        Debug.Log("removed " + itemX.name);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();

        return true;
    }

    public bool checkfull()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
                return false;
        }

        return true;

    }

    public void Replace(Item item)
    {
        Inventory_UI.activeSlot.SlotDropItem();
        Add(item);
    }

}
