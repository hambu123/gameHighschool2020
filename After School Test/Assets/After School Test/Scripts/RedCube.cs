using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    public float m_Speed = 5;
    private void Start()
    {

    }

    void Update()
    {
        var movement = Vector3.down * m_Speed * Time.deltaTime;
        transform.position += movement;
    }

    public void onPointDownEvent()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plane")
        {
            Destroy(gameObject);
        }
    }
}
