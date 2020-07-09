using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trap2 : MonoBehaviour
{
    public UnityEvent m_onExit;
  
    public void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision이 어떤 Collision과 충돌이 일어나고있음  ");
        
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision이 어떤 Collision과 충돌이 끝남 ");
        if (collision.rigidbody != null)
        {
            var player = collision.rigidbody
                .GetComponent<PlayerControllrrDongen>();
            if (player != null)
                m_onExit.Invoke();

        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        //if (collision.GetComponent<Rigidbody>() != null)
        //{
        //    var player = collision.GetComponent<Rigidbody>()
        //        .GetComponent<PlayerControllrrDongen>();
        //    if (player != null)
        //        player.Die();
        //}
    }
}
