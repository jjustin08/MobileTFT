using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public PlayerInput PlayerInput => playerInput;

    [SerializeField] private PlayerInput playerInput;


    private void Awake()
    {
        Instance = this;
    }
}
