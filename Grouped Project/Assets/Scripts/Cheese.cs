using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    public AudioClip collectedClip;
    void OnTriggerEnter(Collider other)
    {
        PlayerMovement controller = other.GetComponent<PlayerMovement>();
        if (controller != null)
        {
            controller.cheeseCheck = true;
            Destroy(gameObject);

            controller.PlaySound(this.collectedClip);
            
        }
    }
}
