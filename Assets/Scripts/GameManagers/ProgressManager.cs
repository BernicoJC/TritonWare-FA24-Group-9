using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public int itemCount;
    public ExitDoorProperties exitDoor;
    public TMPro.TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = "Items Found: " + (itemCount.ToString());

        if (itemCount == 4)
        {
            exitDoor.open = true;
        }
    }
}
