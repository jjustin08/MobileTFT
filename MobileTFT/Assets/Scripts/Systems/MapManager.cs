using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // change to have a map with each player
    [SerializeField] private List<GameObject> maps;
    [SerializeField] private GameObject currentMap;


    public void ChangeMap(int index)
    {
        currentMap.SetActive(false);
        maps[index].SetActive(true);
        currentMap = maps[index];
    }
}
