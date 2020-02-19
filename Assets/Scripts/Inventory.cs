using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory instance;
    public Transform drop;

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

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {

            if(items.Count >= space)
            {
                Debug.Log("not enough space");
                return false;
            }

            items.Add(item);

            if(onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
        }

        return true;
    }

    public bool Remove(Item item)
    {
        if (item == null)
            return false;

;
        Instantiate(item.gameobject, drop.position, drop.rotation);

    items.Remove(item);
        Debug.Log("removed " + item.name);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();

        return true;
    }

}
