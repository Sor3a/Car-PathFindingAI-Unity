using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position - player.position; 
    }

    
    void Update()
    {
        transform.position = player.position + startPos;
    }
}
