using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    public Light2D playerLight;
    public float init_intensity = 1.0f;
    public float init_radius = 5.0f;
    public float light_duration = 30.0f;
    private float light_timer = 0f;
    public bool needRestore = false;
    public float restore_speed = 0.2f;

    public LightManager lightManager;

    // Start is called before the first frame update
    void Start()
    {
        if (playerLight == null)
        {
            Debug.LogError("No Light2D component assigned to playerLight");
        }
        else
        {
            ResetLight();
        }
    }


    void ResetLight()
    {
        playerLight.intensity = init_intensity;
        playerLight.pointLightOuterRadius = init_radius;
        light_timer = 0f;
        needRestore = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (needRestore)
        {
            // Gradually increase light until initial values
            float intensity_step = restore_speed * init_intensity;
            float radius_step = restore_speed * init_radius;

            playerLight.intensity = Mathf.Clamp(playerLight.intensity + intensity_step, 0, init_intensity);
            playerLight.pointLightOuterRadius = Mathf.Clamp(playerLight.pointLightOuterRadius + radius_step, 0, init_radius);

            // If it's reached the initial values, make it go down again
            if (playerLight.intensity >= init_intensity || playerLight.pointLightOuterRadius >= init_radius)
            {
                ResetLight();
            }
        }
        else
        {
            light_timer += Time.deltaTime;
            float scalar = Mathf.Clamp01(1.0f - (light_timer / light_duration));
            playerLight.intensity = init_intensity * scalar;
            playerLight.pointLightOuterRadius = init_radius * scalar;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(lightManager.lightCount > 0)
            {
                // Add timer
                // Add animation trigger
                needRestore = true;
                lightManager.lightCount--;
            }
        }
    }
}
