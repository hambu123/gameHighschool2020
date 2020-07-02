using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_Speed = 15f;
    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = /*gameObject.*/GetComponent<Rigidbody>();

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        
        rigidbody.AddForce(new Vector3(xAxis, 0, yAxis) * m_Speed);    

        //Geaxis fire   사망처리 해보자.`
       // float fireAxis = Input.GetAxis("Firel");
       //
       // if (fireAxis > 0.95f)
        //    Die();

    }


    public void Die()
    {
        Debug.Log("사망");
        gameObject.SetActive(false);
    }
}
