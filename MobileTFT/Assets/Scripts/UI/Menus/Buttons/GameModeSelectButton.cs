using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FiniteGameStudio
{
    public class GameModeSelectButton : MonoBehaviour
    {
        public TMP_Dropdown dropdown;
        public StartButton startBtn;
        void Start()
        {
            dropdown = GetComponent<TMP_Dropdown>();
            dropdown.onValueChanged.AddListener(delegate {
                DropdownValueChanged(dropdown);
            });
        }

        void DropdownValueChanged(TMP_Dropdown change)
        {
            // Get the index of the selected option
            int index = change.value;
            // Get the text of the selected option
            string selectedOption = change.options[index].text;
            //Debug.Log("Selected option: " + selectedOption);
            startBtn.ChangeSelectedSceneName(selectedOption);
        }
    }
}
