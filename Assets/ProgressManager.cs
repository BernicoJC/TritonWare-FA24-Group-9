using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public int itemCount;
    public GameObject exitDoor;
    public TMPro.TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = "Items Found: " + (itemCount.ToString());

        if (itemCount == 3)
        {
            exitDoor.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
