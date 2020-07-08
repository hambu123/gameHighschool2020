using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
{
  
    private void OnTriggerStay(Collider collision)
    {
        Debug.Log("Collision이 어떤 Collision과 충돌이 일어나고있음  ");
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("Collision이 어떤 Collision과 충돌이 끝남 ");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Rigidbody>() != null)
        {
            var player = collision.GetComponent<Rigidbody>()
                .GetComponent<PlayerControllrrDongen>();
            if (player != null)
                player.Die();
        }
    }
}
