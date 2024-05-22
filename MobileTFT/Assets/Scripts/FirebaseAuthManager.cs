using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;

public class FirebaseAuthManager
{
    #region Singleton

    private static FirebaseAuthManager instance = null;
    
    public static FirebaseAuthManager Instance
    {
        get
        {
            if (instance == null)
                instance = new FirebaseAuthManager();
            
            return instance;
        }
    }

    #endregion
    
    private FirebaseAuth auth;
    private FirebaseUser user;
    
    // Action
    public Action<bool> LoginState;
    public void Init()
    {
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += OnStateChanged;
    }

    private void OnStateChanged(object sender, EventArgs e)
    {
        if (auth.CurrentUser != user)
        {
            bool isSigned = (auth.CurrentUser != user && auth.CurrentUser != null);
            if (!isSigned && user != null)
            {
                Debug.Log("LogOut !");
                LoginState?.Invoke(false);
            }

            user = auth.CurrentUser;
            if (isSigned)
            {
                Debug.Log("LogIn !");
                LoginState?.Invoke(true);
            }
        }
    }

    public void Create(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("Canceled SignUp");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.Log("Failed SignUp");
                return;
            }
            if (task.IsCompleted)
            {
                FirebaseUser newUser = task.Result.User;
                Debug.Log("Created ID successfully");
            }
        });
    }

    public void LogIn(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("Canceled LogIn");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.Log("Failed LogIn");
                return;
            }
            if (task.IsCompleted)
            {
                FirebaseUser newUser = task.Result.User;
                Debug.Log("LogIn with ID and password successfully");
            }
        });
    }
    
    public void LogOut()
    {
        auth.SignOut();
        Debug.Log("LogOut !");
    }
    
}
