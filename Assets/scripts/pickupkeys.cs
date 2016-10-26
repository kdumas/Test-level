using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pickupkeys: MonoBehaviour {
    private ItemDatabase database;
    static public List<Item> inventory = new List<Item>();


    void OnTriggerEnter(Collider Player) {
        if (Player.gameObject.CompareTag("Player"))
        {

            AddItem(0);
            Destroy(gameObject);
        }
    }

    void AddItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == null)
            {
                if (id < 0)
                {
                    inventory[i] = new Item();
                    break;
                }
                for (int j = 0; j < database.items.Count; j++)
                {
                    if (database.items[j].itemID == id)
                        inventory[i] = database.items[j];
                }
                break;
            }
        }
    }
}