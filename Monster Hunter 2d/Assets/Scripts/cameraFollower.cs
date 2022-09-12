using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollower : MonoBehaviour
{

    private Transform player;
    private Vector3 pos;

    private float minX = -8 ;
    private float maxX = 8;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
            return;

        pos = transform.position;
        pos.x = player.position.x;

        if (pos.x < minX)
        {
            pos.x = minX;
        }

        if (pos.x > maxX)
        {
            pos.x = maxX;
        }
        
        transform.position = pos;
    }
}
