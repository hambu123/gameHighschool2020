using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgound : MonoBehaviour
{
    private float width;

    private void Awake()
    {
        var collider = GetComponent<BoxCollider2D>();
        width = collider.size.x;
    }
    // Update is called once per frame
    void Update()
    {          
        if(transform.position.x < -width)
        {
            transform.position += Vector3.right * 2* width;
        }
    }
}
