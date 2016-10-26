using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

public List<Item> items = new List<Item>();
void Awake()
    {
        items.Add(new Item("Key", 0, "It opens doors", 0, 0, Item.ItemType.Key));

    }
}
