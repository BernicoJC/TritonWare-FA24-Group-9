using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveItem : MonoBehaviour
{
    public ProgressManager progressManager;
    private bool Examined = false;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "Player" && !Examined)
        {
            Examined = true;
            progressManager.itemCount += 1;

            Destroy(gameObject);
        }
    }
}