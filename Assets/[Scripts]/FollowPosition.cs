using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public GameObject followTarget;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(followTarget.transform.position.x, transform.position.y, transform.position.z);
    }
}
