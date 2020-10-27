using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            LevelGenerator.sharedInstance.AddNewBlock();

            LevelGenerator.sharedInstance.RemoveOldBlock();
        }
    }
}
