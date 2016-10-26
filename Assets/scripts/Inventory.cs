using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public int slotsX, slotsY;
    public GUISkin skin;
    static public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    private bool showInventory;
    private ItemDatabase database;
    private string tooltip;
    private bool draggingItem;
    private Item draggedItem;
    private int prevIndex;
    private bool showTooltip;
    public List<Item> items = new List<Item>();



    // Use this for initialization
    void Start()
    {

        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        for (int i = 0; i < (slotsX * slotsY); i++) {

            inventory.Add(new Item());
        }

        

        

    }
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            showInventory = !showInventory;
        }
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (GUI.Button(new Rect(40, 400, 100, 40), "Save"))
            SaveInventory();
        if (GUI.Button(new Rect(40, 450, 1000, 40), "Load"))
            LoadInventory();

        GUI.skin = skin;
        if (showInventory)
        {
            DrawInventory();
            if (showTooltip)
            {
                GUI.Box(new Rect(Event.current.mousePosition.x + 15, Event.current.mousePosition.y + 10, 200, 200), tooltip, skin.GetStyle("Tooltip"));

            }
            if (draggingItem)
            {
                GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon); }

        }


    }
    void DrawInventory()
    {
        Event e = Event.current;
        int i = 0;
        for (int y = 0; y < slotsY; y++)
        {
            for (int x = 0; x < slotsX; x++)
            {
                Rect slotRect = new Rect(x * 60, y * 60, 50, 50);
                GUI.Box(slotRect, "", skin.GetStyle("Slot"));
                Item item = inventory[i];
                if (item.itemName != null)
                {
                    if (item.itemIcon != null) GUI.DrawTexture(slotRect, inventory[i].itemIcon);
                    if (slotRect.Contains(e.mousePosition))
                    {
                        tooltip = CreatTooltip(inventory[i]);
                        showTooltip = true;
                        if (e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
                        {
                            draggingItem = true;
                            prevIndex = i;
                            draggedItem = inventory[i];
                            inventory[i] = new Item();
                        }
                        if (e.type == EventType.mouseUp && draggingItem)
                        {
                            inventory[prevIndex] = inventory[i];
                            inventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;

                        }
                        if (e.isMouse && e.type == EventType.mouseDown && e.button == 1)
                        {
                            if (item.itemType == Item.ItemType.Consumable)
                                UseConsumable(item, i, true);
                        }
                    }
                }
                else
                {
                    if (slotRect.Contains(e.mousePosition))
                    {
                        if (e.type == EventType.mouseUp && draggingItem)
                        {
                            inventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;

                        }
                    }
                }
                if (tooltip == "")
                {
                    showTooltip = false;
                }

                i++;
            }
        }
    }
    string CreatTooltip(Item item)
    {
        tooltip = "<color=#002952><b>" + item.itemName + "</b></color>\n>" + "color=#41A383>" + item.itemDesc + "</color>";
        return tooltip;
    }

    void RemoveItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemID == id)
            {
                inventory[i] = new Item();
                break;
            }
        }
    }

    void AddItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == null)
            {
                if(id < 0)
                {
                    print("Yeah");
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

    public bool InventoryContains(int id)
    {
        foreach (Item item in inventory)
            if (item.itemID == id) return true;
        return false;

    }
    private void UseConsumable(Item item, int slot, bool delete)
    {
        switch (item.itemID)
        {
            case 2:
                {
                    print("Used Consumable: " + item.itemName);
                    break;
                }
        }
    }

    void SaveInventory()
    {
        for (int i = 0; i < inventory.Count; i++)
            PlayerPrefs.SetInt("Inventory " + i, inventory[i].itemID);
    }
    void LoadInventory()
    {
        for (int i = 0; i < inventory.Count; i++)
            inventory[i] = PlayerPrefs.GetInt("Inventory " + inventory, -1) >= 0 ? database.items[PlayerPrefs.GetInt("Inventory " + i)] : new Item();
    }
}