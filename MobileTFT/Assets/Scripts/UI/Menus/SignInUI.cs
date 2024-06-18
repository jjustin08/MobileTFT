using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignInUI : MonoBehaviour
{
    [SerializeField] private InputField ID_IF;
    [SerializeField] private InputField password_IF;
    
    [SerializeField] private Button signUpBtn;
    [SerializeField] private Button signInBtn;
    [SerializeField] private Button deleteBtn;

    void Start()
    {
        //Open();
        
        signUpBtn.onClick.AddListener(() =>
        {
            //ccountManager.Instance.signUp_UI.Open();
            //Close();
        });
        
        signInBtn.onClick.AddListener(() =>
        {
           
        });
        
        deleteBtn.onClick.AddListener(() =>
        {
            
        });
    }
    
    // public void Open()
    // {
    //     UIObject.SetActive(true);
    // }
    //
    // public void Close()
    // {
    //     UIObject.SetActive(false);
    // }
    
}
