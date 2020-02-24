
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
    public int damage = 0;
    public float range = 0;
    public float fireRate = 0;
    public AudioClip audioClip;



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
        //if (Inventory.instance.heldItem != null)
            Destroy(Inventory.instance.heldItem);

        Inventory.instance.heldItem = Instantiate(this.gameobject, Inventory.instance.heldTransform.position , Inventory.instance.heldTransform.rotation);
        Inventory.instance.heldItem.transform.parent = Inventory.instance.heldTransform;


        PlayerShoot playerShoot = Inventory.instance.gameObject.transform.parent.gameObject.GetComponent<PlayerShoot>();
        if (this.ItemType == "Weapon")
        {
            PlayerShoot.weapon = this;

        }
        else
        {
            PlayerShoot.weapon = null;           
        }
    }

    public void SetItemUnactive()
    {
        Active = false;
        //if (Inventory.instance.heldItem != null)
           // Destroy(Inventory.instance.heldItem);
    }


}
