using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {


    //public GameObject[] items;
    //public Transform inventory0;
    //public Transform inventory1;
    //public Transform inventory2;
    //public Transform inventory3;
    //public Transform inventory4;
    public Transform[] inventorySpaces = new Transform[] {};

    public static int inventorySpace;


    public static GameObject inventoryZero;
    public static GameObject inventoryOne;
    public static GameObject inventoryTwo;
    public static GameObject inventoryThree;
    public static GameObject inventoryFour;
    public static GameObject[] inventory =  new GameObject[] {inventoryZero, inventoryOne, inventoryTwo, inventoryThree, inventoryFour};

    public static int currentInventory;
    public static int selectedInventory;

    public static bool fullInventory;

    public bool inside;

    private void Start()
    {
        //items = GameObject.FindGameObjectsWithTag("Item");
        currentInventory = 0;
        inventorySpace = 0;

        //inventoryZero = new GameObject();
        //inventoryOne = new GameObject();
        //inventoryThree = new GameObject();
        //inventoryFour = new GameObject();
        //inventoryFour = new GameObject();

        Debug.Log(inventory.Length);

    }

    private void Update()
    {
        //currentInventory
        inventory[0].transform.position = inventorySpaces[0].transform.position;
        inventory[1].transform.position = inventorySpaces[1].transform.position;
        inventory[2].transform.position = inventorySpaces[2].transform.position;
        inventory[3].transform.position = inventorySpaces[3].transform.position;
        inventory[4].transform.position = inventorySpaces[4].transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        // for (int i = 0; i < items.Length; i++)
        //{
        //Debug.Log("collision");
        if (other.gameObject.tag == "Item")
        {
            inside = true;
            //Debug.Log("press F to pick up "+ items[i].name);
            if (Input.GetKeyDown("f"))
            {
                
                //Destroy(other.gameObject);
                //other.gameObject.transform.position = inventorySpaces[currentInventory].transform.position;
                //other.gameObject.SetActive = false;
                //Debug.Log("" + inventorySpaces[currentInventory].name);
                PickUp(other.gameObject);
                
            }
        }
        else
        {
            inside = false;
        }

       // }
    }

    void PickUp(GameObject pickedUp)
    {
        
        if(currentInventory <= inventory.Length - 1)
        {

            inventory[currentInventory] = pickedUp;
            pickedUp.transform.position = inventorySpaces[currentInventory].transform.position;
            Debug.Log("" + inventory[currentInventory].name);
            currentInventory++;
            

        }
        else
        {
            
            Debug.Log("" + inventory[0].name + " " + inventory[1].name + " " + inventory[2].name + " " + inventory[3].name + " " + inventory[4].name + "");
            currentInventory = 0;
            //inventory[selectedInventory] = pickedUp;
        }
    }


}
