using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FiniteGameStudio
{
    public class StartButton : MonoBehaviour
    {
        private string _selectedSceneName;

        void Start() {
            _selectedSceneName = "Single";
        }

        public void ChangeScene() {
            SceneManager.LoadScene(_selectedSceneName);
        }

        public string GetSelectedSceneName() {
            return _selectedSceneName;}

        public void ChangeSelectedSceneName(string name) {
            _selectedSceneName = name;
        }
    }
}
