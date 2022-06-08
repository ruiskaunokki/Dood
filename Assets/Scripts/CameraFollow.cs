using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    float right;
    float up;
    float left;
    float down;
    float x;
    float y;

    void Start () 
    {        
        offset = transform.position - player.transform.position;
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0)); // bottom-left corner
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1)); // top-right corner 

        if (transform.position.x * max.x < 0) right = 50f - (max.x + transform.position.x);
        else if (transform.position.x * max.x > 0) right = 50f - (max.x - transform.position.x);
        else right = 50f - max.x;

        if (transform.position.y * max.y < 0) up = 50f - (max.y + transform.position.y);
        else if (transform.position.y * max.y > 0) up = 50f - (max.y - transform.position.y);
        else up = 50f - max.y;

        left = -right;
        down = -up;
    }

    void LateUpdate () 
    {
        x = player.transform.position.x;
        y = player.transform.position.y;
        if (x > right) x = right;
        if (x < left) x = left;
        if (y > up) y = up;
        if (y < down) y = down;
        transform.position = new Vector3(x, y, 0) + offset;
    }
}
