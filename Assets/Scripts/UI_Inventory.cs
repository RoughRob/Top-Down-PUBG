using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{




    public GameObject[] inventorySpaces = new GameObject[] {};
    //public GameObject[] selectedSpaces = new GameObject[] { };

    public Transform dropSpace;

    public static int inventorySpace;


    public static GameObject inventoryZero;
    public static GameObject inventoryOne;
    public static GameObject inventoryTwo;
    public static GameObject inventoryThree;
    public static GameObject inventoryFour;
    public static GameObject[] inventory = new GameObject[] { inventoryZero, inventoryOne, inventoryTwo, inventoryThree, inventoryFour };

    public static int fillInventory;
    public static int selectedItem;

    public bool fullInventory;

    public GameObject Assault;
    public GameObject ShotGun;
    public GameObject Pistol;


    private void Start()
    {
        //items = GameObject.FindGameObjectsWithTag("Item");

        fillInventory = 0;
        inventorySpace = 0;

        //Debug.Log(inventory.Length);

    }


    private void Update()
    {
        //holds items in place
        //for (int i = 0; i <= inventory.Length - 1; i++)
        //{
        //    if (inventory[i] != null)
        //    {
        //        if (i == selectedItem)
        //        {
        //            //inventory[i].transform.position = selectedSpaces[i].transform.position;
        //        }
        //        else
        //        {
        //            //inventory[i].transform.position = inventorySpaces[i].transform.position;
        //        }
        //    }

        //}

        SelectedItem();


        if (Input.GetKeyDown("c"))
        {
            Drop();
        }

        //Inside = false;


    }

    private void OnTriggerStay(Collider other)
    {
        // for (int i = 0; i < items.Length; i++)
        //{
        //Debug.Log("collision");
        if (other.gameObject.tag == "Item")
        {
            //Debug.Log("press F to pick up "+ other.gameObject.name);
            if (Input.GetKeyDown("f"))
            {
                if (!fullInventory)
                {
                    PickUp(other.gameObject);
                }
                else
                {
                    Replace(other.gameObject);
                }
            }
            //Inside = false;
        }

        // }
    }

   public virtual void PickUp(GameObject pickedUp)
    {

        for (int fill = 0; fill <= inventory.Length - 1; fill++)
        {
            if (inventory[fill] == null)
            {


                inventory[fill] = pickedUp;
                Debug.Log(fill + " picked up " + inventory[fill].name);
                //pickedUp.transform.position = inventorySpaces[fill].transform.position;
                inventorySpaces[fill].GetComponent<Text>().text = inventory[fill].name;


                //if (fill == inventory.Length - 1)
                //{
                //    fullInventory = true;
                //}
                CheckFull();

                pickedUp.SetActive(false);
                return;
            }
        }

    }

    void Drop()
    {

        if (inventory[selectedItem] != null)
        {
            inventory[selectedItem].SetActive(true);
            inventory[selectedItem].transform.position = dropSpace.position;
            Debug.Log(" dropped " + inventory[selectedItem].name);

            inventory[selectedItem] = null;

            // fullInventory = false;
            CheckFull();

            checkItemName(inventory[selectedItem].name);

        }
        else
        {
            checkItemName(inventory[selectedItem].name);
        }




    }

    void Replace(GameObject toBePickedUp)
    {
        Debug.Log(" REPLACE " + inventory[selectedItem].name);
        Drop();
        PickUp(toBePickedUp);
        checkItemName(inventory[selectedItem].name);

    }

    void SelectedItem()
    {

        if (Input.GetKeyDown("1") && inventory[0] != null)
        {
            selectedItem = 0;
            Debug.Log("Selected" + selectedItem);
            checkItemName(inventory[selectedItem].name);
        }
        else if (Input.GetKeyDown("2") && inventory[1] != null)
        {
            selectedItem = 1;
            Debug.Log("Selected" + selectedItem);
            checkItemName(inventory[selectedItem].name);
        }
        else if (Input.GetKeyDown("3") && inventory[2] != null)
        {
            selectedItem = 2;
            Debug.Log("Selected" + selectedItem);
            checkItemName(inventory[selectedItem].name);
        }
        else if (Input.GetKeyDown("4") && inventory[3] != null)
        {
            selectedItem = 3;
            Debug.Log("Selected" + selectedItem);
            checkItemName(inventory[selectedItem].name);
        }
        else if (Input.GetKeyDown("5") && inventory[4] != null)
        {
            selectedItem = 4;
            Debug.Log("Selected" + selectedItem);
            checkItemName(inventory[selectedItem].name);
        }

        // Debug.Log(selectedItem);
    }


    void CheckFull()
    {
        int count = 0;

        for (int i = 0; i <= inventory.Length - 1; i++)
        {
            if (inventory[i] != null)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        if (count == inventory.Length)
        {
            fullInventory = true;
        }
        else
        {
            fullInventory = false;
        }

    }

    void checkItemName(string name)
    {
        Gun.pistol = false;
        Gun.assault = false;
        Gun.shotgun = false;

        if (name == "Assault Rifle")
        {
            Gun.assault = true;
            Assault.SetActive(true);
            Pistol.SetActive(false);
            ShotGun.SetActive(false);
        }
        else if (name == "Pistol")
        {
            Gun.pistol = true;
            Pistol.SetActive(true);
            Assault.SetActive(false);
            ShotGun.SetActive(false);
        }
        else if (name == "Shotgun")
        {
            Gun.shotgun = true;
            ShotGun.SetActive(true);
            Assault.SetActive(false);
            Pistol.SetActive(false);
        }
    }


    ////// END
}

