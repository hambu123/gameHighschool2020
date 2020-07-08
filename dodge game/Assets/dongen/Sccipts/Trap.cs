using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("트리거 안에 어떤 collider나 Tirgger가 들어갔다 ");
        if (other.attachedRigidbody != null)
        {
            var player = other.attachedRigidbody
                .GetComponent<PlayerControllrrDongen>();
            if (player != null)
                player.Die();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("트리거 안에 어떤 collider나 Tirgger가 나갓다 ");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("트리거 안에 어떤 collider나 Tirgger가 들어가있는중 ");
    }
}
