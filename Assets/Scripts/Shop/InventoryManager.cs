using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    private List<InterItemData> ownedItems = new();

    public static InventoryManager Instance { get; private set; }

    void Awake() // singleton 
    {
        if (InventoryManager.Instance == null) InventoryManager.Instance = this;
        else Destroy(this);
    }

    public void AddItem(InterItemData item)
    {
        if (item == null) return;

        ownedItems.Add(item);

        // print for testing
        if (ownedItems.Count == 5)
        {
            print("Inventory: ");
            for (int i = 0; i < ownedItems.Count; i++)
            {
                print(ownedItems[i].itemName);
            }
        }
        
    }

    public bool RemoveItem(InterItemData item) => ownedItems.Remove(item);
    public IReadOnlyList<InterItemData> GetItems() => ownedItems;
   
}