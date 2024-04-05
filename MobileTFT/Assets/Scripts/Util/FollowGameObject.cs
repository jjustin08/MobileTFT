using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    private bool isFollowing = true;
    [SerializeField] private GameObject target;

    [SerializeField] private Vector3 offset;
    
    public void ToggleFollow(bool toggle)
    {
        isFollowing = toggle;
    }


    private void Update()
    {
        FollowUpdate();
    }

    private void FollowUpdate()
    {
        if (!isFollowing)
            return;
        
        transform.position = target.transform.position;
        transform.position += offset;
    }
}
