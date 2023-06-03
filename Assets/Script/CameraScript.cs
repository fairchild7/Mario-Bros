using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform Player;
    private float minX = 0, maxX = 204;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        if(Player != null)
        {
            Vector3 viTri = transform.position;
            viTri.x = Player.position.x;
            if (viTri.x < minX) viTri.x = minX;
            if (viTri.x > maxX) viTri.x = maxX;
            transform.position = viTri;
        }
    }
}
