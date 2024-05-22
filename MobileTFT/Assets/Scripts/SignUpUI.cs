using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SignUpUI : MonoBehaviour
{
    [SerializeField] private InputField ID_IF;
    [SerializeField] private InputField password_IF;
    
    [SerializeField] private Button signUpBtn;
    [SerializeField] private Button exitBtn;
    //[SerializeField] private GameObject UIObject;

    void Start()
    {
        //Close();
        
        signUpBtn.onClick.AddListener(() =>
        {
            FirebaseAuthManager.Instance.Create(ID_IF.text, password_IF.text);
        });
        
        exitBtn.onClick.AddListener(() =>
        {
            //UIObject.Open();
            //Close();
        });
    }
    
    
//     public void Open()
//     {
//         UIObject.SetActive(true);
//     }
//
//     public void Close()
//     {
//         UIObject.SetActive(false);
//     }
}
