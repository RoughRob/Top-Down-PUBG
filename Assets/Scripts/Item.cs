
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
[System.Serializable]
public class Item : ScriptableObject {

    public static Item itemInstance;

    #region Singleton
    public void Awake()
    {
        if (itemInstance != null)
        {
            Debug.Log("more that one inventory instance");
            return;
        }

        itemInstance = this;

    }
    #endregion

    new public string name = "New Item";
    public string ItemType;
    public Sprite icon = null;
    public GameObject gameobject;
    public bool isDefaultItem = false;
    public bool Active = false;

    //type Weapon
    public int damage;
    public float range;



    public virtual void UseItem()
    {
        Debug.Log("Using" + name);

        if(ItemType == "Weapon")
        {
            if(PlayerShoot.weapon == null)
            PlayerShoot.weapon = this;

            //PlayerShoot.Shoot();

        }
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
