using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public int lightCount;
    public TMPro.TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = "Candles: "+(lightCount.ToString());
    }
}
