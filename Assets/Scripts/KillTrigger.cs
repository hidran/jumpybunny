using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D element)
    {
        if(element.tag == "Player")
        {
            print("Bunny has been eliminated");
            PlayerController.GetInstance().KillPlayer();
        }
    }
}
