using UnityEngine;

namespace FiniteGameStudio
{
    [CreateAssetMenu(fileName = "ItemDataSO", menuName = "Scriptable Objects/ItemDataSO")]
    public class ItemDataSO : ScriptableObject
    {
        public int ID;
        public string name;
        public ItemType type;
        public ItemTier tier;
        public int amount;
        public int price;

        public Sprite icon;
        public Sprite defaultIcon;
    }
}
