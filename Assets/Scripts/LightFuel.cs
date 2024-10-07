using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFuel : MonoBehaviour
{


    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player has collided with the pickup

        if (collision.CompareTag("Player"))
        {
            // Get the PlayerLight script from the player
            PlayerLight playerLight = collision.GetComponent<PlayerLight>();

            // Check if the PlayerLight script is available
            if (playerLight != null)
            {
                playerLight.restore = true;
                Destroy(gameObject); // Destroy the pickup after use
            }
        }
    }
}
