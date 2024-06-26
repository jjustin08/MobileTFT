using UnityEngine;

namespace FiniteGameStudio
{
    [CreateAssetMenu(fileName = "UserDataSO", menuName = "Scriptable Objects/UserDataSO")]
    public class UserDataSO : ScriptableObject
    {
        [SerializeField] private string _ID;
        [SerializeField] private string _nickName;
        // Rank, Wons, Losts
        
        [SerializeField] private InventoryDataSO _inventoryData;
        [SerializeField] private BattlePassDataSO _battlePassData;
        
        public string GetID() { return _ID; }
        public string GetNickName() { return _nickName; }
        public InventoryDataSO GetInventoryData() { return _inventoryData; }
        public BattlePassDataSO GetBattlePassData() { return _battlePassData; }
    }
}
