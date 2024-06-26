using System;
using UnityEngine;

namespace FiniteGameStudio
{
    public class GameInstance : MonoBehaviour
    {
        #region Set Singleton

        private static GameInstance _instance;
    
        public static GameInstance Instance
        {
            get
            {
                // If the instance doesn't exist, find it or create it
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameInstance>();

                    // If there are multiple instances, log an error
                    if (FindObjectsOfType<GameInstance>().Length > 1)
                    {
                        Debug.LogError("More than one GameInstance instance found in the scene.");
                        return _instance;
                    }

                    // If instance is still null, create a new GameObject and add the GameInstance script to it
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject("GameInstance");
                        _instance = singletonObject.AddComponent<GameInstance>();
                    }
                }

                return _instance;
            }
        }

        #endregion
        
        //TODO: Need to change it once accounting system is done.
        public UserDataSO _userData; // private static UserDataSO _userData;
    
        private void Awake()
        {
            // Make sure the instance persists between scenes
            Initialize();
        }

        private void Start()
        {
            //TODO: Test Purpose
            _userData.GetBattlePassData().SetPoints(150);
        }

        public void Initialize()
        {
            #region Check Singleton

            // Ensure that only one instance of the Singleton exists
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                // Make sure the instance persists between scenes
                DontDestroyOnLoad(gameObject);
            }
        
            #endregion

        }

        public UserDataSO GetUserData()
        {
            if(_userData == null)
                Debug.LogError("User Data isn't set yet - GameInstance.cs");
            
            return _userData;
        }

        public void SetUserData(UserDataSO userdata) { _userData = userdata; }
    }
}
