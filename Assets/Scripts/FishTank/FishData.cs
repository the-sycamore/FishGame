using UnityEngine;


// scriptable object 
[CreateAssetMenu(fileName = "FishData", menuName = "Scriptable Objects/FishData")]
public class FishData : ScriptableObject, InterItemData
{
    public float speed = 1;
    public float rarity = 0.50f;
    [field: SerializeField]
    public Sprite sprite { get; private set; }
    public string itemName => name;
    public string personality;
    public void ItemActivation()
    {
        
    }

}
