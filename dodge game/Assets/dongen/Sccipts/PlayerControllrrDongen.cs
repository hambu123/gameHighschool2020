using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllrrDongen : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    public float m_Speed = 15f;
    // Update is called once per frame
    private void Start()
    {

    }
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(xAxis, 0, zAxis).normalized * m_Speed;
        //리지드 바디를 이용한 이동 처리
        velocity.y = m_Rigidbody.velocity.y;
        m_Rigidbody.velocity = velocity;

    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
