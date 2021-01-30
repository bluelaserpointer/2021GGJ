using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightBreath : MonoBehaviour
{
    // Start is called before the first frame update
    private Light pointLight;
    public float lightRangeMax = 50;
    public float lightRangeMin = 5;
    public float lightBreathOffset = 5;
    public float lightBreathSpeed = 1.5f;
    public float lightRotateSpeed = 0.25f;
    private bool fadeIn = true;
    void Start()
    {        
        pointLight = GetComponent<Light>();
        pointLight.range = lightRangeMin;
    }

    private void FixedUpdate() {
        if(fadeIn)
        {
            pointLight.range = Mathf.Lerp(pointLight.range, lightRangeMax, lightBreathSpeed * Time.deltaTime);
            if(pointLight.range > lightRangeMax - lightBreathOffset)
                fadeIn = false;
        }else{
            pointLight.range = Mathf.Lerp(pointLight.range, lightRangeMin, lightBreathSpeed * Time.deltaTime);
            if(pointLight.range < lightRangeMin + lightBreathOffset)
                fadeIn = true;
        }

        transform.Rotate(Vector3.up, lightRotateSpeed);
    }

}
