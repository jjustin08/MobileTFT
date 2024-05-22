using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int connectionId;
    private bool isLoaded;
    private PlayerStats stats = new PlayerStats();
    public Player(int connectionId)
    {
        this.connectionId = connectionId;
    }

    public int getId()
    {
        return connectionId;
    }

    public void SetIsLoaded(bool toggle)
    {
        isLoaded = toggle;
    }

    public bool IsLoaded() { return  isLoaded; }

}
