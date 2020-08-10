using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuleCube : MonoBehaviour
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
        GameManager.Instance.DamgeLife();
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plane")
        {
            Destroy(gameObject);
            GameManager.Instance.AddScore();
        }
    }

}
