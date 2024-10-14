using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorProperties : MonoBehaviour
{
    public bool open = false;

    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (open && other.collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
