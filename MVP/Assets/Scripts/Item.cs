using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public string itemDescription;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
          //adding text to

            for(int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == false)
                {
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    inventory.isFull[i] = true;
                    Destroy(gameObject);
                    Debug.Log("Picked up");
                    break;
                }
            }
        }
    }
}
