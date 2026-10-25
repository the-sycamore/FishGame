using Unity.VisualScripting;
using UnityEngine;

public interface InterItemData
{
    string itemName { get; }
    Sprite sprite { get; }
    void ItemActivation();
}
